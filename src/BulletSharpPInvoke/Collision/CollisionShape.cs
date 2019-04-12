using Xenko.Core.Mathematics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class CollisionShape
	{
		internal IntPtr _native;

        internal static CollisionShape GetManaged(IntPtr obj)
        {
            if (obj == IntPtr.Zero)
            {
                return null;
            }

            var userPtr = btCollisionShape_getUserPointer(obj);
            if (userPtr != IntPtr.Zero)
            {
                return GCHandle.FromIntPtr(userPtr).Target as CollisionShape;
            }

            switch (btCollisionShape_getShapeType(obj))
            {
                case BroadphaseNativeType.BoxShape:
                    return new BoxShape(obj);
                case BroadphaseNativeType.CompoundShape:
                    return new CompoundShape(obj);
                case BroadphaseNativeType.ConvexHullShape:
                    return new ConvexHullShape(obj);
                case BroadphaseNativeType.StaticPlane:
                    return new StaticPlaneShape(obj);
            }
            throw new NotImplementedException();
        }

        GCHandle nativeHandle;

        internal CollisionShape(IntPtr obj)
        {
            _native = obj;

            if (btCollisionShape_getUserPointer(_native) != IntPtr.Zero) return;

            nativeHandle = GCHandle.Alloc(this);
            btCollisionShape_setUserPointer(_native, GCHandle.ToIntPtr(nativeHandle));
        }

        public Vector3 CalculateLocalInertia(float mass)
        {
            Vector3 inertia;
            btCollisionShape_calculateLocalInertia(_native, mass, out inertia);
            return inertia;
        }

        public void CalculateLocalInertia(float mass, out Vector3 inertia)
        {
            btCollisionShape_calculateLocalInertia(_native, mass, out inertia);
        }

		public int CalculateSerializeBufferSize()
		{
			return btCollisionShape_calculateSerializeBufferSize(_native);
		}
        /*
		public void CalculateTemporalAabb(Transform curTrans, Vector3 linvel, Vector3 angvel, float timeStep, Vector3 temporalAabbMin, Vector3 temporalAabbMax)
		{
			btCollisionShape_calculateTemporalAabb(_native, curTrans._native, linvel._native, angvel._native, timeStep, temporalAabbMin._native, temporalAabbMax._native);
		}

		public void GetAabb(Transform t, Vector3 aabbMin, Vector3 aabbMax)
		{
			btCollisionShape_getAabb(_native, t._native, aabbMin._native, aabbMax._native);
		}
        */
		public void GetBoundingSphere(out Vector3 center, out float radius)
		{
			btCollisionShape_getBoundingSphere(_native, out center, out radius);
		}

		public float GetContactBreakingThreshold(float defaultContactThresholdFactor)
		{
			return btCollisionShape_getContactBreakingThreshold(_native, defaultContactThresholdFactor);
		}
        /*
		public char Serialize(IntPtr dataBuffer, Serializer serializer)
		{
			return btCollisionShape_serialize(_native, dataBuffer, serializer._native);
		}
        */
		public void SerializeSingleShape(Serializer serializer)
		{
			btCollisionShape_serializeSingleShape(_native, serializer._native);
		}

		public float AngularMotionDisc
		{
			get { return btCollisionShape_getAngularMotionDisc(_native); }
		}
        
		public Vector3 AnisotropicRollingFrictionDirection
		{
            get
            {
                Vector3 value;
                btCollisionShape_getAnisotropicRollingFrictionDirection(_native, out value);
                return value;
            }
		}
        
		public bool IsCompound
		{
			get { return btCollisionShape_isCompound(_native); }
		}

		public bool IsConcave
		{
			get { return btCollisionShape_isConcave(_native); }
		}

		public bool IsConvex
		{
			get { return btCollisionShape_isConvex(_native); }
		}

		public bool IsConvex2d
		{
			get { return btCollisionShape_isConvex2d(_native); }
		}

		public bool IsInfinite
		{
			get { return btCollisionShape_isInfinite(_native); }
		}

		public bool IsNonMoving
		{
			get { return btCollisionShape_isNonMoving(_native); }
		}

		public bool IsPolyhedral
		{
			get { return btCollisionShape_isPolyhedral(_native); }
		}

		public bool IsSoftBody
		{
			get { return btCollisionShape_isSoftBody(_native); }
		}

        public Vector3 LocalScaling
        {
            get
            {
                Vector3 scaling;
                btCollisionShape_getLocalScaling(_native, out scaling);
                return scaling;
            }
            set { btCollisionShape_setLocalScaling(_native, ref value); }
        }

		public float Margin
		{
			get { return btCollisionShape_getMargin(_native); }
			set { btCollisionShape_setMargin(_native, value); }
		}
        
		public string Name
		{
			get { return btCollisionShape_getName(_native); }
		}
        
        public BroadphaseNativeType ShapeType
		{
			get { return btCollisionShape_getShapeType(_native); }
		}

        public object UserObject { get; set; }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
            if (nativeHandle.IsAllocated)
            {
                nativeHandle.Free();
            }

		    if (_native == IntPtr.Zero) return;

		    btCollisionShape_delete(_native);
		    _native = IntPtr.Zero;
		}

		~CollisionShape()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btCollisionShape_calculateLocalInertia(IntPtr obj, float mass, [Out] out Vector3 inertia);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btCollisionShape_calculateSerializeBufferSize(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionShape_getAngularMotionDisc(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_getAnisotropicRollingFrictionDirection(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_getBoundingSphere(IntPtr obj, [Out] out Vector3 center, [Out] out float radius);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionShape_getContactBreakingThreshold(IntPtr obj, float defaultContactThresholdFactor);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btCollisionShape_getLocalScaling(IntPtr obj, [Out] out Vector3 scaling);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionShape_getMargin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.LPStr)]
		static extern string btCollisionShape_getName(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern BroadphaseNativeType btCollisionShape_getShapeType(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionShape_getUserPointer(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isCompound(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isConcave(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isConvex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isConvex2d(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isInfinite(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isNonMoving(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isPolyhedral(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionShape_isSoftBody(IntPtr obj);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern IntPtr btCollisionShape_serialize(IntPtr obj, IntPtr dataBuffer, IntPtr serializer);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_serializeSingleShape(IntPtr obj, IntPtr serializer);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_setLocalScaling(IntPtr obj, [In] ref Vector3 scaling);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_setMargin(IntPtr obj, float margin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_setUserPointer(IntPtr obj, IntPtr userPtr);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionShape_delete(IntPtr obj);
	}
}
