// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
#if !__iOS__
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using BulletSharp;
using SR = BulletSharp.Resources.Strings;
using Utilities = Xenko.Core.Utilities;

namespace System.IO
{
    /*
     * This class is used to access a contiguous block of memory, likely outside 
     * the GC heap (or pinned in place in the GC heap, but a MemoryStream may 
     * make more sense in those cases).  It's great if you have a pointer and
     * a length for a section of memory mapped in by someone else and you don't
     * want to copy this into the GC heap.  UnmanagedMemoryStream assumes these 
     * two things:
     *
     * 1) All the memory in the specified block is readable or writable,
     *    depending on the values you pass to the constructor.
     * 2) The lifetime of the block of memory is at least as long as the lifetime
     *    of the UnmanagedMemoryStream.
     * 3) You clean up the memory when appropriate.  The UnmanagedMemoryStream 
     *    currently will do NOTHING to free this memory.
     * 4) All calls to Write and WriteByte may not be threadsafe currently.
     *
     * It may become necessary to add in some sort of 
     * DeallocationMode enum, specifying whether we unmap a section of memory, 
     * call free, run a user-provided delegate to free the memory, etc etc.  
     * We'll suggest user write a subclass of UnmanagedMemoryStream that uses
     * a SafeHandle subclass to hold onto the memory.
     * Check for problems when using this in the negative parts of a 
     * process's address space.  We may need to use unsigned longs internally
     * and change the overflow detection logic.
     * 
     * -----SECURITY MODEL AND SILVERLIGHT-----
     * A few key notes about exposing UMS in silverlight:
     * 1. No ctors are exposed to transparent code. This version of UMS only
     * supports byte* (not SafeBuffer). Therefore, framework code can create
     * a UMS and hand it to transparent code. Transparent code can use most
     * operations on a UMS, but not operations that directly expose a 
     * pointer.
     * 
     * 2. Scope of "unsafe" and non-CLS compliant operations reduced: The
     * Whidbey version of this class has CLSCompliant(false) at the class 
     * level and unsafe modifiers at the method level. These were reduced to 
     * only where the unsafe operation is performed -- i.e. immediately 
     * around the pointer manipulation. Note that this brings UMS in line 
     * with recent changes in pu/clr to support SafeBuffer.
     * 
     * 3. Currently, the only caller that creates a UMS is ResourceManager, 
     * which creates read-only UMSs, and therefore operations that can 
     * change the length will throw because write isn't supported. A 
     * conservative option would be to formalize the concept that _only_
     * read-only UMSs can be creates, and enforce this by making WriteX and
     * SetLength SecurityCritical. However, this is a violation of 
     * security inheritance rules, so we must keep these safe. The 
     * following notes make this acceptable for future use.
     *    a. a race condition in WriteX that could have allowed a thread to 
     *    read from unzeroed memory was fixed
     *    b. memory region cannot be expanded beyond _capacity; in other 
     *    words, a UMS creator is saying a writeable UMS is safe to 
     *    write to anywhere in the memory range up to _capacity, specified
     *    in the ctor. Even if the caller doesn't specify a capacity, then
     *    length is used as the capacity.
     */

    /// <summary>
    /// Stream over a memory pointer or over a SafeBuffer
    /// </summary>
    public class UnmanagedMemoryStream : Stream
    {
        [System.Security.SecurityCritical] // auto-generated
        private SafeBuffer _buffer;
        [SecurityCritical]
        private unsafe byte* _mem;
        private long _length;
        private long _capacity;
        private long _position;
        private long _offset;
        private bool _isOpen;

        private Task<Int32> _lastReadTask; // The last successful task returned from ReadAsync 

        /// <summary>
        /// This code is copied from system\buffer.cs in mscorlib
        /// </summary>
        /// <param name="src"></param>
        /// <param name="len"></param>
        [System.Security.SecurityCritical]  // auto-generated
        private unsafe static void ZeroMemory(byte* src, long len)
        {
            while (len-- > 0)
                *(src + len) = 0;
        }

        /// <summary>
        /// Creates a closed stream.
        /// </summary>
        // Needed for subclasses that need to map a file, etc.
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected UnmanagedMemoryStream()
        {
            unsafe
            {
                _mem = null;
            }
            _isOpen = false;
        }

        /// <summary>
        /// Creates a stream over a SafeBuffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        [System.Security.SecuritySafeCritical]  // auto-generated
        public UnmanagedMemoryStream(SafeBuffer buffer, long offset, long length)
        {
            Initialize(buffer, offset, length, false);
        }

        [System.Security.SecurityCritical]  // auto-generated
        private void Initialize(SafeBuffer buffer, long offset, long length, bool skipSecurityCheck)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "ArgumentOutOfRange_NeedNonNegNum");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", SR.ArgumentOutOfRange_NeedNonNegNum);
            }
            if (buffer.ByteLength < (ulong)(offset + length))
            {
                throw new ArgumentException(SR.Argument_InvalidSafeBufferOffLen);
            }
            Contract.EndContractBlock();

            if (_isOpen)
            {
                throw new InvalidOperationException(SR.InvalidOperation_CalledTwice);
            }

            // check for wraparound
            unsafe
            {
                byte* pointer = null;

                try
                {
                    buffer.AcquirePointer(ref pointer);
                    if ((pointer + offset + length) < pointer)
                    {
                        throw new ArgumentException(SR.ArgumentOutOfRange_UnmanagedMemStreamWrapAround);
                    }
                }
                finally
                {
                    if (pointer != null)
                    {
                        buffer.ReleasePointer();
                    }
                }
            }

            _offset = offset;
            _buffer = buffer;
            _length = length;
            _capacity = length;
            _isOpen = true;
        }

        /// <summary>
        /// Creates a stream over a byte*.
        /// </summary>
        [System.Security.SecurityCritical]  // auto-generated
        [CLSCompliant(false)]
        public unsafe UnmanagedMemoryStream(byte* pointer, long length)
        {
            Initialize(pointer, length, length, false);
        }

        /// <summary>
        /// Creates a stream over a byte*.
        /// </summary>
        [System.Security.SecurityCritical]  // auto-generated
        [CLSCompliant(false)]
        public unsafe UnmanagedMemoryStream(byte* pointer, long length, long capacity)
        {
            Initialize(pointer, length, capacity, false);
        }

        /// <summary>
        /// Subclasses must call this method (or the other overload) to properly initialize all instance fields.
        /// </summary>
        [System.Security.SecurityCritical]  // auto-generated
        [CLSCompliant(false)]
        protected unsafe void Initialize(byte* pointer, long length, long capacity)
        {
            Initialize(pointer, length, capacity, false);
        }

        /// <summary>
        /// Subclasses must call this method (or the other overload) to properly initialize all instance fields.
        /// </summary>
        [System.Security.SecurityCritical]  // auto-generated
        private unsafe void Initialize(byte* pointer, long length, long capacity, bool skipSecurityCheck)
        {
            if (pointer == null)
                throw new ArgumentNullException("pointer");
            if (length < 0 || capacity < 0)
                throw new ArgumentOutOfRangeException((length < 0) ? "length" : "capacity", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (length > capacity)
                throw new ArgumentOutOfRangeException("length", SR.ArgumentOutOfRange_LengthGreaterThanCapacity);
            Contract.EndContractBlock();
            // Check for wraparound.
            if (((byte*)((long)pointer + capacity)) < pointer)
                throw new ArgumentOutOfRangeException("capacity", SR.ArgumentOutOfRange_UnmanagedMemStreamWrapAround);
            if (_isOpen)
                throw new InvalidOperationException(SR.InvalidOperation_CalledTwice);

            _mem = pointer;
            _offset = 0;
            _length = length;
            _capacity = capacity;
            _isOpen = true;
        }

        /// <summary>
        /// Returns true if the stream can be read; otherwise returns false.
        /// </summary>
        public override bool CanRead
        {
            [Pure]
            get { return _isOpen; }
        }

        /// <summary>
        /// Returns true if the stream can seek; otherwise returns false.
        /// </summary>
        public override bool CanSeek
        {
            [Pure]
            get { return _isOpen; }
        }

        /// <summary>
        /// Returns true if the stream can be written to; otherwise returns false.
        /// </summary>
        public override bool CanWrite
        {
            [Pure]
            get { return _isOpen; }
        }

        /// <summary>
        /// Closes the stream. The stream's memory needs to be dealt with separately.
        /// </summary>
        /// <param name="disposing"></param>
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected override void Dispose(bool disposing)
        {
            _isOpen = false;
            unsafe { _mem = null; }

            // Stream allocates WaitHandles for async calls. So for correctness 
            // call base.Dispose(disposing) for better perf, avoiding waiting
            // for the finalizers to run on those types.
            base.Dispose(disposing);
        }

        /// <summary>
        /// Since it's a memory stream, this method does nothing.
        /// </summary>
        public override void Flush()
        {
            if (!_isOpen) throw __Error.GetStreamIsClosed();
        }

        /// <summary>
        /// Since it's a memory stream, this method does nothing specific.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return TaskHelper.FromCanceled(cancellationToken);

            try
            {
                Flush();
                return TaskHelper.CompletedTask;
            }
            catch (Exception ex)
            {
                return TaskHelper.FromException(ex);
            }
        }

        /// <summary>
        /// Number of bytes in the stream.
        /// </summary>
        public override long Length
        {
            get
            {
                if (!_isOpen) throw __Error.GetStreamIsClosed();
                return Interlocked.Read(ref _length);
            }
        }

        /// <summary>
        /// Number of bytes that can be written to the stream.
        /// </summary>
        public long Capacity
        {
            get
            {
                if (!_isOpen) throw __Error.GetStreamIsClosed();
                return _capacity;
            }
        }

        /// <summary>
        /// ReadByte will read byte at the Position in the stream
        /// </summary>
        public override long Position
        {
            get
            {
                if (!CanSeek) throw __Error.GetStreamIsClosed();
                Contract.EndContractBlock();
                return Interlocked.Read(ref _position);
            }
            [System.Security.SecuritySafeCritical]  // auto-generated
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("value", SR.ArgumentOutOfRange_NeedNonNegNum);
                if (!CanSeek) throw __Error.GetStreamIsClosed();
                Contract.EndContractBlock();

                if (IntPtr.Size == 4)
                {
                    unsafe
                    {
                        // On 32 bit process, ensure we don't wrap around.
                        if (value > (long)Int32.MaxValue || _mem + value < _mem)
                            throw new ArgumentOutOfRangeException("value", SR.ArgumentOutOfRange_StreamLength);
                    }
                }
                Interlocked.Exchange(ref _position, value);
            }
        }

        /// <summary>
        /// Pointer to memory at the current Position in the stream. 
        /// </summary>
        [CLSCompliant(false)]
        public unsafe byte* PositionPointer
        {
            [System.Security.SecurityCritical]  // auto-generated_required
            get
            {
                if (_buffer != null) throw new NotSupportedException(SR.NotSupported_UmsSafeBuffer);
                if (!_isOpen) throw __Error.GetStreamIsClosed();

                // Use a temp to avoid a race
                long pos = Interlocked.Read(ref _position);
                if (pos > _capacity) throw new IndexOutOfRangeException(SR.IndexOutOfRange_UMSPosition);
                byte* ptr = _mem + pos;

                return ptr;
            }
            [System.Security.SecurityCritical]  // auto-generated_required
            set
            {
                if (_buffer != null) throw new NotSupportedException(SR.NotSupported_UmsSafeBuffer);
                if (!_isOpen) throw __Error.GetStreamIsClosed();
                if (value < _mem) throw new IOException(SR.IO_SeekBeforeBegin);

                Interlocked.Exchange(ref _position, value - _mem);
            }
        }

        /// <summary>
        /// Reads bytes from stream and puts them into the buffer
        /// </summary>
        /// <param name="buffer">Buffer to read the bytes to.</param>
        /// <param name="offset">Starting index in the buffer.</param>
        /// <param name="count">Maximum number of bytes to read.</param>
        /// <returns>Number of bytes actually read.</returns>
        [System.Security.SecuritySafeCritical]  // auto-generated
        public override int Read([In, Out] byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer", SR.ArgumentNull_Buffer);
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (buffer.Length - offset < count)
                throw new ArgumentException(SR.Argument_InvalidOffLen);
            Contract.EndContractBlock();  // Keep this in sync with contract validation in ReadAsync

            if (!_isOpen) throw __Error.GetStreamIsClosed();
            if (!CanRead) throw __Error.GetReadNotSupported();

            // Use a local variable to avoid a race where another thread 
            // changes our position after we decide we can read some bytes.
            long pos = Interlocked.Read(ref _position);
            long len = Interlocked.Read(ref _length);
            long n = len - pos;
            if (n > count)
                n = count;
            if (n <= 0)
                return 0;

            int nInt = (int)n; // Safe because n <= count, which is an Int32
            if (nInt < 0)
                return 0;  // _position could be beyond EOF
            Debug.Assert(pos + nInt >= 0, "_position + n >= 0");  // len is less than 2^63 -1.

            unsafe
            {
                fixed (byte* pBuffer = buffer)
                {
                    if (_buffer != null)
                    {
                        byte* pointer = null;

                        try
                        {
                            _buffer.AcquirePointer(ref pointer);
                            Utilities.CopyMemory((IntPtr)(pBuffer + offset), (IntPtr)(pointer + pos + _offset), nInt);
                        }
                        finally
                        {
                            if (pointer != null)
                            {
                                _buffer.ReleasePointer();
                            }
                        }
                    }
                    else
                    {
                        Utilities.CopyMemory((IntPtr)(pBuffer + offset), (IntPtr)(_mem + pos), nInt);
                    }
                }
            }
            Interlocked.Exchange(ref _position, pos + n);
            return nInt;
        }

        /// <summary>
        /// Reads bytes from stream and puts them into the buffer
        /// </summary>
        /// <param name="buffer">Buffer to read the bytes to.</param>
        /// <param name="offset">Starting index in the buffer.</param>
        /// <param name="count">Maximum number of bytes to read.</param>       
        /// <param name="cancellationToken">Token that can be used to cancell this operation.</param>
        /// <returns>Task that can be used to access the number of bytes actually read.</returns>
        public override Task<Int32> ReadAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer", SR.ArgumentNull_Buffer);
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (buffer.Length - offset < count)
                throw new ArgumentException(SR.Argument_InvalidOffLen);
            Contract.EndContractBlock();  // contract validation copied from Read(...) 

            if (cancellationToken.IsCancellationRequested)
                return TaskHelper.FromCanceled<Int32>(cancellationToken);

            try
            {
                Int32 n = Read(buffer, offset, count);
                Task<Int32> t = _lastReadTask;
                return (t != null && t.Result == n) ? t : (_lastReadTask = Task.FromResult<Int32>(n));
            }
            catch (Exception ex)
            {
                Debug.Assert(!(ex is OperationCanceledException));
                return TaskHelper.FromException<Int32>(ex);
            }
        }

        /// <summary>
        /// Returns the byte at the stream current Position and advances the Position.
        /// </summary>
        /// <returns></returns>
        [System.Security.SecuritySafeCritical]  // auto-generated
        public override int ReadByte()
        {
            if (!_isOpen) throw __Error.GetStreamIsClosed();
            if (!CanRead) throw __Error.GetReadNotSupported();

            long pos = Interlocked.Read(ref _position);  // Use a local to avoid a race condition
            long len = Interlocked.Read(ref _length);
            if (pos >= len)
                return -1;
            Interlocked.Exchange(ref _position, pos + 1);
            int result;
            if (_buffer != null)
            {
                unsafe
                {
                    byte* pointer = null;

                    try
                    {
                        _buffer.AcquirePointer(ref pointer);
                        result = *(pointer + pos + _offset);
                    }
                    finally
                    {
                        if (pointer != null)
                        {
                            _buffer.ReleasePointer();
                        }
                    }
                }
            }
            else
            {
                unsafe
                {
                    result = _mem[pos];
                }
            }
            return result;
        }

        /// <summary>
        /// Advanced the Position to specifice location in the stream.
        /// </summary>
        /// <param name="offset">Offset from the loc parameter.</param>
        /// <param name="loc">Origin for the offset parameter.</param>
        /// <returns></returns>
        public override long Seek(long offset, SeekOrigin loc)
        {
            if (!_isOpen) throw __Error.GetStreamIsClosed();
            switch (loc)
            {
                case SeekOrigin.Begin:
                    if (offset < 0)
                        throw new IOException(SR.IO_SeekBeforeBegin);
                    Interlocked.Exchange(ref _position, offset);
                    break;

                case SeekOrigin.Current:
                    long pos = Interlocked.Read(ref _position);
                    if (offset + pos < 0)
                        throw new IOException(SR.IO_SeekBeforeBegin);
                    Interlocked.Exchange(ref _position, offset + pos);
                    break;

                case SeekOrigin.End:
                    long len = Interlocked.Read(ref _length);
                    if (len + offset < 0)
                        throw new IOException(SR.IO_SeekBeforeBegin);
                    Interlocked.Exchange(ref _position, len + offset);
                    break;

                default:
                    throw new ArgumentException(SR.Argument_InvalidSeekOrigin);
            }

            long finalPos = Interlocked.Read(ref _position);
            Debug.Assert(finalPos >= 0, "_position >= 0");
            return finalPos;
        }

        /// <summary>
        /// Sets the Length of the stream.
        /// </summary>
        /// <param name="value"></param>
        [System.Security.SecuritySafeCritical]  // auto-generated
        public override void SetLength(long value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("length", SR.ArgumentOutOfRange_NeedNonNegNum);
            Contract.EndContractBlock();
            if (_buffer != null)
                throw new NotSupportedException(SR.NotSupported_UmsSafeBuffer);
            if (!_isOpen) throw __Error.GetStreamIsClosed();
            if (!CanWrite) throw __Error.GetWriteNotSupported();

            if (value > _capacity)
                throw new IOException(SR.IO_FixedCapacity);

            long pos = Interlocked.Read(ref _position);
            long len = Interlocked.Read(ref _length);
            if (value > len)
            {
                unsafe
                {
                    ZeroMemory(_mem + len, value - len);
                }
            }
            Interlocked.Exchange(ref _length, value);
            if (pos > value)
            {
                Interlocked.Exchange(ref _position, value);
            }
        }

        /// <summary>
        /// Writes buffer into the stream
        /// </summary>
        /// <param name="buffer">Buffer that will be written.</param>
        /// <param name="offset">Starting index in the buffer.</param>
        /// <param name="count">Number of bytes to write.</param>
        [System.Security.SecuritySafeCritical]  // auto-generated
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer", SR.ArgumentNull_Buffer);
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (buffer.Length - offset < count)
                throw new ArgumentException(SR.Argument_InvalidOffLen);
            Contract.EndContractBlock();  // Keep contract validation in sync with WriteAsync(..)

            if (!_isOpen) throw __Error.GetStreamIsClosed();
            if (!CanWrite) throw __Error.GetWriteNotSupported();

            long pos = Interlocked.Read(ref _position);  // Use a local to avoid a race condition
            long len = Interlocked.Read(ref _length);
            long n = pos + count;
            // Check for overflow
            if (n < 0)
                throw new IOException(SR.IO_StreamTooLong);

            if (n > _capacity)
            {
                throw new NotSupportedException(SR.IO_FixedCapacity);
            }

            if (_buffer == null)
            {
                // Check to see whether we are now expanding the stream and must 
                // zero any memory in the middle.
                if (pos > len)
                {
                    unsafe
                    {
                        ZeroMemory(_mem + len, pos - len);
                    }
                }

                // set length after zeroing memory to avoid race condition of accessing unzeroed memory
                if (n > len)
                {
                    Interlocked.Exchange(ref _length, n);
                }
            }

            unsafe
            {
                fixed (byte* pBuffer = buffer)
                {
                    if (_buffer != null)
                    {
                        long bytesLeft = _capacity - pos;
                        if (bytesLeft < count)
                        {
                            throw new ArgumentException(SR.Arg_BufferTooSmall);
                        }

                        byte* pointer = null;
                        try
                        {
                            _buffer.AcquirePointer(ref pointer);
                            Utilities.CopyMemory((IntPtr)(pointer + pos + _offset), (IntPtr)(pBuffer + offset), count);
                        }
                        finally
                        {
                            if (pointer != null)
                            {
                                _buffer.ReleasePointer();
                            }
                        }
                    }
                    else
                    {
                        Utilities.CopyMemory((IntPtr)(_mem + pos), (IntPtr)(pBuffer + offset), count);
                    }
                }
            }
            Interlocked.Exchange(ref _position, n);
            return;
        }

        /// <summary>
        /// Writes buffer into the stream. The operation completes synchronously.
        /// </summary>
        /// <param name="buffer">Buffer that will be written.</param>
        /// <param name="offset">Starting index in the buffer.</param>
        /// <param name="count">Number of bytes to write.</param>
        /// <param name="cancellationToken">Token that can be used to cancell the operation.</param>
        /// <returns>Task that can be awaited </returns>
        public override Task WriteAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer", SR.ArgumentNull_Buffer);
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", SR.ArgumentOutOfRange_NeedNonNegNum);
            if (buffer.Length - offset < count)
                throw new ArgumentException(SR.Argument_InvalidOffLen);
            Contract.EndContractBlock();  // contract validation copied from Write(..) 

            if (cancellationToken.IsCancellationRequested)
                return TaskHelper.FromCanceled(cancellationToken);

            try
            {
                Write(buffer, offset, count);
                return TaskHelper.CompletedTask;
            }
            catch (Exception ex)
            {
                Debug.Assert(!(ex is OperationCanceledException));
                return TaskHelper.FromException(ex);
            }
        }

        /// <summary>
        /// Writes a byte to the stream and advances the current Position.
        /// </summary>
        /// <param name="value"></param>
        [System.Security.SecuritySafeCritical]  // auto-generated
        public override void WriteByte(byte value)
        {
            if (!_isOpen) throw __Error.GetStreamIsClosed();
            if (!CanWrite) throw __Error.GetWriteNotSupported();

            long pos = Interlocked.Read(ref _position);  // Use a local to avoid a race condition
            long len = Interlocked.Read(ref _length);
            long n = pos + 1;
            if (pos >= len)
            {
                // Check for overflow
                if (n < 0)
                    throw new IOException(SR.IO_StreamTooLong);

                if (n > _capacity)
                    throw new NotSupportedException(SR.IO_FixedCapacity);

                // Check to see whether we are now expanding the stream and must 
                // zero any memory in the middle.
                // don't do if created from SafeBuffer
                if (_buffer == null)
                {
                    if (pos > len)
                    {
                        unsafe
                        {
                            ZeroMemory(_mem + len, pos - len);
                        }
                    }

                    // set length after zeroing memory to avoid race condition of accessing unzeroed memory
                    Interlocked.Exchange(ref _length, n);
                }
            }

            if (_buffer != null)
            {
                unsafe
                {
                    byte* pointer = null;

                    try
                    {
                        _buffer.AcquirePointer(ref pointer);
                        *(pointer + pos + _offset) = value;
                    }
                    finally
                    {
                        if (pointer != null)
                        {
                            _buffer.ReleasePointer();
                        }
                    }
                }
            }
            else
            {
                unsafe
                {
                    _mem[pos] = value;
                }
            }
            Interlocked.Exchange(ref _position, n);
        }

        // Only static data; no need to serialize
        internal static class __Error
        {
            internal static Exception GetStreamIsClosed()
            {
                return new ObjectDisposedException(null, SR.ObjectDisposed_StreamIsClosed);
            }

            internal static Exception GetReadNotSupported()
            {
                return new NotSupportedException(SR.NotSupported_UnreadableStream);
            }

            internal static Exception GetWriteNotSupported()
            {
                return new NotSupportedException(SR.NotSupported_UnwritableStream);
            }
        }
    }
}
#endif