using System;
using System.Runtime.InteropServices;
using System.Security;
using Xenko.Core.Mathematics;

namespace BulletSharp
{
    public class CompoundShapeChild
    {
        private readonly bool _preventDelete;
        internal IntPtr _native;

        internal CompoundShapeChild(IntPtr native, bool preventDelete = false)
        {
            _native = native;
            _preventDelete = preventDelete;
        }

        public CompoundShapeChild()
        {
            _native = btCompoundShapeChild_new();
        }

        public float ChildMargin
        {
            get { return btCompoundShapeChild_getChildMargin(_native); }
            set { btCompoundShapeChild_setChildMargin(_native, value); }
        }

        public CollisionShape ChildShape
        {
            get { return CollisionShape.GetManaged(btCompoundShapeChild_getChildShape(_native)); }
            set { btCompoundShapeChild_setChildShape(_native, value._native); }
        }

        public int ChildShapeType
        {
            get { return btCompoundShapeChild_getChildShapeType(_native); }
            set { btCompoundShapeChild_setChildShapeType(_native, value); }
        }

        /*
		public DbvtNode Node
		{
			get { return btCompoundShapeChild_getNode(_native); }
			set { btCompoundShapeChild_setNode(_native, value._native); }
		}
        */

        public Matrix Transform
        {
            get
            {
                Matrix value;
                btCompoundShapeChild_getTransform(_native, out value);
                return value;
            }
            set { btCompoundShapeChild_setTransform(_native, ref value); }
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
                    btCompoundShapeChild_delete(_native);
                }
                _native = IntPtr.Zero;
            }
        }

        ~CompoundShapeChild()
        {
            Dispose(false);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr btCompoundShapeChild_new();

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern float btCompoundShapeChild_getChildMargin(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr btCompoundShapeChild_getChildShape(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern int btCompoundShapeChild_getChildShapeType(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShapeChild_getTransform(IntPtr obj, [Out] out Matrix value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShapeChild_setChildMargin(IntPtr obj, float value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShapeChild_setChildShape(IntPtr obj, IntPtr value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShapeChild_setChildShapeType(IntPtr obj, int value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShapeChild_setTransform(IntPtr obj, [In] ref Matrix value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShapeChild_delete(IntPtr obj);
    }

    public class CompoundShape : CollisionShape
    {
        private CompoundShapeChildArray _childList;

        internal CompoundShape(IntPtr native)
            : base(native)
        {
        }

        public CompoundShape(bool enableDynamicAabbTree)
            : base(btCompoundShape_new(enableDynamicAabbTree))
        {
        }

        public CompoundShape()
            : base(btCompoundShape_new2())
        {
        }

        public CompoundShapeChildArray ChildList
        {
            get
            {
                if (_childList == null)
                {
                    _childList = new CompoundShapeChildArray(btCompoundShape_getChildList(_native), NumChildShapes);
                }
                return _childList;
            }
        }

        /*
		public Dbvt DynamicAabbTree
		{
			get { return btCompoundShape_getDynamicAabbTree(_native); }
		}
        */

        public int NumChildShapes
        {
            get { return btCompoundShape_getNumChildShapes(_native); }
        }

        public int UpdateRevision
        {
            get { return btCompoundShape_getUpdateRevision(_native); }
        }

        public void AddChildShape(Matrix localTransform, CollisionShape shape)
        {
            btCompoundShape_addChildShape(_native, ref localTransform, shape._native);
        }

        /*
		public void CalculatePrincipalAxisTransform(float masses, Matrix principal, Vector3 inertia)
		{
			btCompoundShape_calculatePrincipalAxisTransform(_native, masses._native, ref principal, ref inertia);
		}
        */

        public void CreateAabbTreeFromChildren()
        {
            btCompoundShape_createAabbTreeFromChildren(_native);
        }

        public CollisionShape GetChildShape(int index)
        {
            return GetManaged(btCompoundShape_getChildShape(_native, index));
        }

        public Matrix GetChildTransform(int index)
        {
            Matrix value;
            btCompoundShape_getChildTransform(_native, index, out value);
            return value;
        }

        public void RecalculateLocalAabb()
        {
            btCompoundShape_recalculateLocalAabb(_native);
        }

        public void RemoveChildShape(CollisionShape shape)
        {
            btCompoundShape_removeChildShape(_native, shape._native);
        }

        public void RemoveChildShapeByIndex(int childShapeindex)
        {
            btCompoundShape_removeChildShapeByIndex(_native, childShapeindex);
        }

        public void UpdateChildTransform(int childIndex, Matrix newChildTransform, bool shouldRecalculateLocalAabb)
        {
            btCompoundShape_updateChildTransform(_native, childIndex, ref newChildTransform, shouldRecalculateLocalAabb);
        }

        public void UpdateChildTransform(int childIndex, Matrix newChildTransform)
        {
            btCompoundShape_updateChildTransform2(_native, childIndex, ref newChildTransform);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr btCompoundShape_new(bool enableDynamicAabbTree);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr btCompoundShape_new2();

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_addChildShape(IntPtr obj, [In] ref Matrix localTransform,
            IntPtr shape);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_createAabbTreeFromChildren(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr btCompoundShape_getChildList(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr btCompoundShape_getChildShape(IntPtr obj, int index);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_getChildTransform(IntPtr obj, int index, [Out] out Matrix value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern int btCompoundShape_getNumChildShapes(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern int btCompoundShape_getUpdateRevision(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_recalculateLocalAabb(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_removeChildShape(IntPtr obj, IntPtr shape);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_removeChildShapeByIndex(IntPtr obj, int childShapeindex);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_updateChildTransform(IntPtr obj, int childIndex,
            [In] ref Matrix newChildTransform, bool shouldRecalculateLocalAabb);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void btCompoundShape_updateChildTransform2(IntPtr obj, int childIndex,
            [In] ref Matrix newChildTransform);
    }
}