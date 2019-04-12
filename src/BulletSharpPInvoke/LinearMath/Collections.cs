using Xenko.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public class ArrayEnumerator
    {
        protected int _i;
        protected int _count;

        public ArrayEnumerator()
        {
            _i = -1;
        }

        public void Dispose()
        {
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

    public class CompoundShapeChildArrayEnumerator : ArrayEnumerator, IEnumerator<CompoundShapeChild>
    {
        IList<CompoundShapeChild> _array;

        public CompoundShapeChildArrayEnumerator(IList<CompoundShapeChild> array)
        {
            _array = array;
            _count = array.Count;
        }

        public CompoundShapeChild Current
        {
            get { return _array[_i]; }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _array[_i]; }
        }
    }

    public class UIntArrayEnumerator : ArrayEnumerator, IEnumerator<uint>
    {
        IList<uint> _array;

        public UIntArrayEnumerator(IList<uint> array)
        {
            _array = array;
            _count = array.Count;
        }

        public uint Current
        {
            get { return _array[_i]; }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _array[_i]; }
        }
    }

    public class Vector3ArrayEnumerator : ArrayEnumerator, IEnumerator<Vector3>
    {
        IList<Vector3> _array;

        public Vector3ArrayEnumerator(IList<Vector3> array)
        {
            _array = array;
            _count = array.Count;
        }

        public Vector3 Current
        {
            get { return _array[_i]; }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _array[_i]; }
        }
    }

    public class FixedSizeArray
    {
        internal IntPtr _native;

        protected int _count;

        public FixedSizeArray(IntPtr native, int count)
        {
            _native = native;
            _count = count;
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public void RemoveAt(int index)
        {
            throw new InvalidOperationException();
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
    }

    public class CompoundShapeChildArray : FixedSizeArray, IList<CompoundShapeChild>
    {
        internal CompoundShapeChildArray(IntPtr native, int count)
            : base(native, count)
        {
        }

        public void Add(CompoundShapeChild item)
        {
            throw new InvalidOperationException();
        }

        public int IndexOf(CompoundShapeChild item)
        {
            throw new NotImplementedException();
        }

        public CompoundShapeChild this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return new CompoundShapeChild(btCompoundShapeChild_array_at(_native, index), true);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Contains(CompoundShapeChild item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(CompoundShapeChild[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<CompoundShapeChild> GetEnumerator()
        {
            return new CompoundShapeChildArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new CompoundShapeChildArrayEnumerator(this);
        }

        public void Insert(int index, CompoundShapeChild item)
        {
            throw new InvalidOperationException();
        }

        public bool Remove(CompoundShapeChild item)
        {
            throw new NotImplementedException();
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btCompoundShapeChild_array_at(IntPtr obj, int n);
    }

    public class UIntArray : FixedSizeArray, IList<uint>
    {
        internal UIntArray(IntPtr native, int count)
            : base(native, count)
        {
        }

        public void Add(uint item)
        {
            throw new InvalidOperationException();
        }

        public int IndexOf(uint item)
        {
            throw new NotImplementedException();
        }

        public uint this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return uint_array_at(_native, index);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Contains(uint item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(uint[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<uint> GetEnumerator()
        {
            return new UIntArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new UIntArrayEnumerator(this);
        }

        public void Insert(int index, uint item)
        {
            throw new InvalidOperationException();
        }

        public bool Remove(uint item)
        {
            throw new NotImplementedException();
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern uint uint_array_at(IntPtr obj, int n);
    }

    public class Vector3Array : FixedSizeArray, IList<Vector3>
    {
        internal Vector3Array(IntPtr native, int count)
            : base(native, count)
        {
        }

        public int IndexOf(Vector3 item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Vector3 item)
        {
            throw new NotImplementedException();
        }

        public Vector3 this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                Vector3 value;
                btVector3_array_at(_native, index, out value);
                return value;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Vector3 item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector3 item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Vector3[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Vector3 item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Vector3> GetEnumerator()
        {
            return new Vector3ArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Vector3ArrayEnumerator(this);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btVector3_array_at(IntPtr obj, int n, [Out] out Vector3 value);
    }
}
