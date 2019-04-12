using Xenko.Core.Mathematics;
﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics;

namespace BulletSharp
{
    public class AlignedBroadphasePairArrayDebugView
    {
        private AlignedBroadphasePairArray _array;

        public AlignedBroadphasePairArrayDebugView(AlignedBroadphasePairArray array)
        {
            _array = array;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public BroadphasePair[] Items
        {
            get
            {
                BroadphasePair[] array = new BroadphasePair[_array.Count];
                for (int i = 0; i < _array.Count; i++)
                {
                    array[i] = _array[i];
                }
                return array;
            }
        }
    }

    public class AlignedBroadphasePairArrayEnumerator : IEnumerator<BroadphasePair>
    {
        int _i;
        int _count;
        AlignedBroadphasePairArray _array;

        public AlignedBroadphasePairArrayEnumerator(AlignedBroadphasePairArray array)
        {
            _array = array;
            _count = array.Count;
            _i = -1;
        }

        public BroadphasePair Current
        {
            get { return _array[_i]; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _array[_i]; }
        }

        public bool MoveNext()
        {
            _i++;
            return _i != _count;
        }

        public void Reset()
        {
            _i = 0;
        }
    }

    [DebuggerTypeProxy(typeof(AlignedBroadphasePairArrayDebugView)), DebuggerDisplay("Count = {Count}")]
    public class AlignedBroadphasePairArray : AlignedObjectArray, IList<BroadphasePair>, IDisposable
    {
        bool _preventDelete;

        internal AlignedBroadphasePairArray(IntPtr native, bool preventDelete)
            : base(native)
        {
            _preventDelete = preventDelete;
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
                if (!_preventDelete)
                {
                    btAlignedBroadphasePairArray_delete(_native);
                }
                _native = IntPtr.Zero;
            }
        }

        ~AlignedBroadphasePairArray()
        {
            Dispose(false);
        }

        public int IndexOf(BroadphasePair item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, BroadphasePair item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public BroadphasePair this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)

                    throw new ArgumentOutOfRangeException("index");

                return new BroadphasePair(btAlignedBroadphasePairArray_at(_native, index), true);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(BroadphasePair item)
        {
            btAlignedBroadphasePairArray_push_back(_native, item._native);
        }

        public void Clear()
        {
            btAlignedBroadphasePairArray_resizeNoInitialize(_native, 0);
        }

        public bool Contains(BroadphasePair item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(BroadphasePair[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return btAlignedBroadphasePairArray_size(_native); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(BroadphasePair item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<BroadphasePair> GetEnumerator()
        {
            return new AlignedBroadphasePairArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new AlignedBroadphasePairArrayEnumerator(this);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btAlignedBroadphasePairArray_at(IntPtr obj, int n);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btAlignedBroadphasePairArray_push_back(IntPtr obj, IntPtr val);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btAlignedBroadphasePairArray_resizeNoInitialize(IntPtr obj, int newSize);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern int btAlignedBroadphasePairArray_size(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btAlignedBroadphasePairArray_delete(IntPtr obj);
    }
}
