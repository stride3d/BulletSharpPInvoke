using Xenko.Core.Mathematics;
﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics;

namespace BulletSharp
{
    public class AlignedCollisionObjectArrayDebugView
    {
        private AlignedCollisionObjectArray _array;

        public AlignedCollisionObjectArrayDebugView(AlignedCollisionObjectArray array)
        {
            _array = array;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public CollisionObject[] Items
        {
            get
            {
                CollisionObject[] array = new CollisionObject[_array.Count];
                for (int i = 0; i < _array.Count; i++)
                {
                    array[i] = _array[i];
                }
                return array;
            }
        }
    }

    public class AlignedCollisionObjectArrayEnumerator : IEnumerator<CollisionObject>
    {
        int _i;
        int _count;
        AlignedCollisionObjectArray _array;

        public AlignedCollisionObjectArrayEnumerator(AlignedCollisionObjectArray array)
        {
            _array = array;
            _count = array.Count;
            _i = -1;
        }

        public CollisionObject Current
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

    [DebuggerTypeProxy(typeof(AlignedCollisionObjectArrayDebugView)), DebuggerDisplay("Count = {Count}")]
    public class AlignedCollisionObjectArray : AlignedObjectArray, IList<CollisionObject>, IDisposable
    {
        bool _preventDelete;

        internal AlignedCollisionObjectArray(IntPtr native, bool preventDelete = false)
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
                    btAlignedCollisionObjectArray_delete(_native);
                }
                _native = IntPtr.Zero;
            }
        }

        ~AlignedCollisionObjectArray()
        {
            Dispose(false);
        }

        public int IndexOf(CollisionObject item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, CollisionObject item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public CollisionObject this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)

                    throw new ArgumentOutOfRangeException("index");

                return CollisionObject.GetManaged(btAlignedCollisionObjectArray_at(_native, index));
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(CollisionObject item)
        {
            btAlignedCollisionObjectArray_push_back(_native, item._native);
        }

        public void Clear()
        {
            btAlignedCollisionObjectArray_resizeNoInitialize(_native, 0);
        }

        public bool Contains(CollisionObject item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(CollisionObject[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return btAlignedCollisionObjectArray_size(_native); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(CollisionObject item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<CollisionObject> GetEnumerator()
        {
            return new AlignedCollisionObjectArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new AlignedCollisionObjectArrayEnumerator(this);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btAlignedCollisionObjectArray_at(IntPtr obj, int n);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btAlignedCollisionObjectArray_push_back(IntPtr obj, IntPtr val);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btAlignedCollisionObjectArray_resizeNoInitialize(IntPtr obj, int newSize);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern int btAlignedCollisionObjectArray_size(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btAlignedCollisionObjectArray_delete(IntPtr obj);
    }
}
