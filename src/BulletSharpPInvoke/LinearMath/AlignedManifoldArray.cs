using Xenko.Core.Mathematics;
﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics;

namespace BulletSharp
{
    public class AlignedManifoldArrayDebugView
    {
        private AlignedManifoldArray _array;

        public AlignedManifoldArrayDebugView(AlignedManifoldArray array)
        {
            _array = array;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public PersistentManifold[] Items
        {
            get
            {
                PersistentManifold[] array = new PersistentManifold[_array.Count];
                for (int i = 0; i < _array.Count; i++)
                {
                    array[i] = _array[i];
                }
                return array;
            }
        }
    }

    public class AlignedManifoldArrayEnumerator : IEnumerator<PersistentManifold>
    {
        int _i;
        int _count;
        AlignedManifoldArray _array;

        public AlignedManifoldArrayEnumerator(AlignedManifoldArray array)
        {
            _array = array;
            _count = array.Count;
            _i = -1;
        }

        public PersistentManifold Current
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

    [DebuggerTypeProxy(typeof(AlignedManifoldArrayDebugView)), DebuggerDisplay("Count = {Count}")]
    public class AlignedManifoldArray : AlignedObjectArray, IList<PersistentManifold>, IDisposable
    {
        bool _preventDelete;

        internal AlignedManifoldArray(IntPtr native, bool preventDelete)
            : base(native)
        {
            _preventDelete = preventDelete;
        }

        public AlignedManifoldArray()
            : base(btManifoldArray_new())
        {
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
                    btManifoldArray_delete(_native);
                }
                _native = IntPtr.Zero;
            }
        }

        ~AlignedManifoldArray()
        {
            Dispose(false);
        }

        public int IndexOf(PersistentManifold item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, PersistentManifold item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public PersistentManifold this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)

                    throw new ArgumentOutOfRangeException("index");

                return new PersistentManifold(btManifoldArray_at(_native, index));
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(PersistentManifold item)
        {
            btManifoldArray_push_back(_native, item._native);
        }

        public void Clear()
        {
            btManifoldArray_resizeNoInitialize(_native, 0);
        }

        public bool Contains(PersistentManifold item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(PersistentManifold[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return btManifoldArray_size(_native); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(PersistentManifold item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<PersistentManifold> GetEnumerator()
        {
            return new AlignedManifoldArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new AlignedManifoldArrayEnumerator(this);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btManifoldArray_new();
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern int btManifoldArray_size(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btManifoldArray_at(IntPtr obj, int n);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btManifoldArray_push_back(IntPtr obj, IntPtr val);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btManifoldArray_resizeNoInitialize(IntPtr obj, int newSize);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btManifoldArray_delete(IntPtr obj);
    }
}
