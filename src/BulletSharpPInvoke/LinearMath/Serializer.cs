using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class Chunk
	{
		internal IntPtr _native;

		internal Chunk(IntPtr native)
		{
			_native = native;
		}

		public Chunk()
		{
			_native = btChunk_new();
		}

		public int ChunkCode
		{
			get { return btChunk_getChunkCode(_native); }
			set { btChunk_setChunkCode(_native, value); }
		}

		public int Dna_nr
		{
			get { return btChunk_getDna_nr(_native); }
			set { btChunk_setDna_nr(_native, value); }
		}

		public int Length
		{
			get { return btChunk_getLength(_native); }
			set { btChunk_setLength(_native, value); }
		}

		public int Number
		{
			get { return btChunk_getNumber(_native); }
			set { btChunk_setNumber(_native, value); }
		}

		public IntPtr OldPtr
		{
			get { return btChunk_getOldPtr(_native); }
			set { btChunk_setOldPtr(_native, value); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btChunk_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Chunk()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btChunk_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btChunk_getChunkCode(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btChunk_getDna_nr(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btChunk_getLength(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btChunk_getNumber(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btChunk_getOldPtr(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btChunk_setChunkCode(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btChunk_setDna_nr(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btChunk_setLength(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btChunk_setNumber(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btChunk_setOldPtr(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btChunk_delete(IntPtr obj);
	}

	public class Serializer
	{
		internal IntPtr _native;

		internal Serializer(IntPtr native)
		{
			_native = native;
		}

		public Chunk Allocate(uint size, int numElements)
		{
            return new Chunk(btSerializer_allocate(_native, size, numElements));
		}
        /*
		public void FinalizeChunk(Chunk chunk, char structType, int chunkCode, IntPtr oldPtr)
		{
			btSerializer_finalizeChunk(_native, chunk._native, structType, chunkCode, oldPtr);
		}
        */
		public string FindNameForPointer(IntPtr ptr)
		{
			return btSerializer_findNameForPointer(_native, ptr);
		}

		public IntPtr FindPointer(IntPtr oldPtr)
		{
			return btSerializer_findPointer(_native, oldPtr);
		}

		public void FinishSerialization()
		{
			btSerializer_finishSerialization(_native);
		}

		public IntPtr GetUniquePointer(IntPtr oldPtr)
		{
			return btSerializer_getUniquePointer(_native, oldPtr);
		}

		public void RegisterNameForObject(Object obj, string name)
		{
            if (obj is CollisionShape)
            {
                btSerializer_registerNameForPointer(_native, (obj as CollisionShape)._native, name);
            }
            else if (obj is CollisionObject)
            {
                btSerializer_registerNameForPointer(_native, (obj as CollisionObject)._native, name);
            }
            else
            {
                throw new NotImplementedException();
            }
		}
        /*
		public void SerializeName(char ptr)
		{
			btSerializer_serializeName(_native, ptr);
		}
        */
		public void StartSerialization()
		{
			btSerializer_startSerialization(_native);
		}
        /*
		public byte BufferPointer
		{
			get { return btSerializer_getBufferPointer(_native); }
		}
        */
		public int CurrentBufferSize
		{
			get { return btSerializer_getCurrentBufferSize(_native); }
		}

		public int SerializationFlags
		{
			get { return btSerializer_getSerializationFlags(_native); }
			set { btSerializer_setSerializationFlags(_native, value); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btSerializer_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Serializer()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSerializer_allocate(IntPtr obj, uint size, int numElements);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern string btSerializer_findNameForPointer(IntPtr obj, IntPtr ptr);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSerializer_findPointer(IntPtr obj, IntPtr oldPtr);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSerializer_finishSerialization(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSerializer_getCurrentBufferSize(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSerializer_getSerializationFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSerializer_getUniquePointer(IntPtr obj, IntPtr oldPtr);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSerializer_registerNameForPointer(IntPtr obj, IntPtr ptr, string name);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSerializer_setSerializationFlags(IntPtr obj, int flags);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSerializer_startSerialization(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSerializer_delete(IntPtr obj);
	}

	public class PointerUid
	{
		internal IntPtr _native;

		internal PointerUid(IntPtr native)
		{
			_native = native;
		}

		public PointerUid()
		{
			_native = btPointerUid_new();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btPointerUid_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PointerUid()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPointerUid_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPointerUid_delete(IntPtr obj);
	}

	public class DefaultSerializer : Serializer
	{
		internal DefaultSerializer(IntPtr native)
			: base(native)
		{
		}

		public DefaultSerializer(int totalSize)
			: base(btDefaultSerializer_new(totalSize))
		{
		}

		public DefaultSerializer()
			: base(btDefaultSerializer_new2())
		{
		}
        /*
		public byte InternalAlloc(uint size)
		{
			return btDefaultSerializer_internalAlloc(_native, size);
		}

		public void WriteHeader(byte buffer)
		{
			btDefaultSerializer_writeHeader(_native, buffer._native);
		}
        */
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultSerializer_new(int totalSize);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultSerializer_new2();
	}
}
