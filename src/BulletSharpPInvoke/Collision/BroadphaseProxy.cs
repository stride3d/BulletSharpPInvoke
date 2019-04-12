using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public enum BroadphaseNativeType
    {
        // polyhedral convex shapes
        BoxShape,
        TriangleShape,
        TetrahedralShape,
        ConvexTriangleMeshShape,
        ConvexHullShape,
        CONVEX_POINT_CLOUD_SHAPE_PROXYTYPE,
        CUSTOM_POLYHEDRAL_SHAPE_TYPE,
        //implicit convex shapes
        IMPLICIT_CONVEX_SHAPES_START_HERE,
        SphereShape,
        MultiSphereShape,
        CapsuleShape,
        ConeShape,
        ConvexShape,
        CylinderShape,
        UniformScalingShape,
        MINKOWSKI_SUM_SHAPE_PROXYTYPE,
        MinkowskiDifferenceShape,
        Box2DShape,
        Convex2DShape,
        CUSTOM_CONVEX_SHAPE_TYPE,
        //concave shapes
        CONCAVE_SHAPES_START_HERE,
        //keep all the convex shapetype below here, for the check IsConvexShape in broadphase proxy!
        TriangleMeshShape,
        SCALED_TRIANGLE_MESH_SHAPE_PROXYTYPE,
        ///used for demo integration FAST/Swift collision library and Bullet
        FAST_CONCAVE_MESH_PROXYTYPE,
        //terrain
        TERRAIN_SHAPE_PROXYTYPE,
        ///Used for GIMPACT Trimesh integration
        GImpactShape,
        ///Multimaterial mesh
        MULTIMATERIAL_TRIANGLE_MESH_PROXYTYPE,

        EmptyShape,
        StaticPlane,
        CUSTOM_CONCAVE_SHAPE_TYPE,
        CONCAVE_SHAPES_END_HERE,

        CompoundShape,

        SoftBodyShape,
        HFFLUID_SHAPE_PROXYTYPE,
        HFFLUID_BUOYANT_CONVEX_SHAPE_PROXYTYPE,
        INVALID_SHAPE_PROXYTYPE,

        MAX_BROADPHASE_COLLISION_TYPES
    }

    [Flags]
    public enum CollisionFilterGroups
    {
        DefaultFilter = 1,
        StaticFilter = 2,
        KinematicFilter = 4,
        DebrisFilter = 8,
        SensorTrigger = 16,
        CharacterFilter = 32,
        AllFilter = -1
    }

	public class BroadphaseProxy
	{
		internal IntPtr _native;
        bool _preventDelete;

		internal BroadphaseProxy(IntPtr native, bool preventDelete = false)
		{
			_native = native;
            _preventDelete = preventDelete;
		}

        internal static BroadphaseProxy GetManaged(IntPtr native)
        {
            if (native == IntPtr.Zero)
            {
                return null;
            }
            return new BroadphaseProxy(native, true);
        }

		public BroadphaseProxy()
		{
			_native = btBroadphaseProxy_new();
		}

		public BroadphaseProxy(Vector3 aabbMin, Vector3 aabbMax, IntPtr userPtr, short collisionFilterGroup, short collisionFilterMask, IntPtr multiSapParentProxy)
		{
			_native = btBroadphaseProxy_new2(ref aabbMin, ref aabbMax, userPtr, collisionFilterGroup, collisionFilterMask, multiSapParentProxy);
		}

		public BroadphaseProxy(Vector3 aabbMin, Vector3 aabbMax, IntPtr userPtr, short collisionFilterGroup, short collisionFilterMask)
		{
			_native = btBroadphaseProxy_new3(ref aabbMin, ref aabbMax, userPtr, collisionFilterGroup, collisionFilterMask);
		}

		public bool IsCompound(int proxyType)
		{
			return btBroadphaseProxy_isCompound(proxyType);
		}

		public bool IsConcave(int proxyType)
		{
			return btBroadphaseProxy_isConcave(proxyType);
		}

		public bool IsConvex(int proxyType)
		{
			return btBroadphaseProxy_isConvex(proxyType);
		}

		public bool IsConvex2d(int proxyType)
		{
			return btBroadphaseProxy_isConvex2d(proxyType);
		}

		public bool IsInfinite(int proxyType)
		{
			return btBroadphaseProxy_isInfinite(proxyType);
		}

		public bool IsNonMoving(int proxyType)
		{
			return btBroadphaseProxy_isNonMoving(proxyType);
		}

		public bool IsPolyhedral(int proxyType)
		{
			return btBroadphaseProxy_isPolyhedral(proxyType);
		}

		public bool IsSoftBody(int proxyType)
		{
			return btBroadphaseProxy_isSoftBody(proxyType);
		}

        public Vector3 AabbMax
		{
            get
            {
                Vector3 value;
                btBroadphaseProxy_getAabbMax(_native, out value);
                return value;
            }
			set { btBroadphaseProxy_setAabbMax(_native, ref value); }
		}

		public Vector3 AabbMin
		{
            get
            {
                Vector3 value;
                btBroadphaseProxy_getAabbMin(_native, out value);
                return value;
            }
			set { btBroadphaseProxy_setAabbMin(_native, ref value); }
		}

		public Object ClientObject
		{
			get { return CollisionObject.GetManaged(btBroadphaseProxy_getClientObject(_native)); }
			set { btBroadphaseProxy_setClientObject(_native, (value as CollisionObject)._native); }
		}

		public short CollisionFilterGroup
		{
			get { return btBroadphaseProxy_getCollisionFilterGroup(_native); }
			set { btBroadphaseProxy_setCollisionFilterGroup(_native, value); }
		}

		public short CollisionFilterMask
		{
			get { return btBroadphaseProxy_getCollisionFilterMask(_native); }
			set { btBroadphaseProxy_setCollisionFilterMask(_native, value); }
		}

		public IntPtr MultiSapParentProxy
		{
			get { return btBroadphaseProxy_getMultiSapParentProxy(_native); }
			set { btBroadphaseProxy_setMultiSapParentProxy(_native, value); }
		}

		public int Uid
		{
			get { return btBroadphaseProxy_getUid(_native); }
		}

		public int UniqueId
		{
			get { return btBroadphaseProxy_getUniqueId(_native); }
			set { btBroadphaseProxy_setUniqueId(_native, value); }
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
                    btBroadphaseProxy_delete(_native);
                }
				_native = IntPtr.Zero;
			}
		}

		~BroadphaseProxy()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphaseProxy_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphaseProxy_new2([In] ref Vector3 aabbMin, [In] ref Vector3 aabbMax, IntPtr userPtr, short collisionFilterGroup, short collisionFilterMask, IntPtr multiSapParentProxy);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphaseProxy_new3([In] ref Vector3 aabbMin, [In] ref Vector3 aabbMax, IntPtr userPtr, short collisionFilterGroup, short collisionFilterMask);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btBroadphaseProxy_getAabbMax(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_getAabbMin(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphaseProxy_getClientObject(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btBroadphaseProxy_getCollisionFilterGroup(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btBroadphaseProxy_getCollisionFilterMask(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphaseProxy_getMultiSapParentProxy(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBroadphaseProxy_getUid(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBroadphaseProxy_getUniqueId(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isCompound(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isConcave(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isConvex(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isConvex2d(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isInfinite(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isNonMoving(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isPolyhedral(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btBroadphaseProxy_isSoftBody(int proxyType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_setAabbMax(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btBroadphaseProxy_setAabbMin(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_setClientObject(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_setCollisionFilterGroup(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_setCollisionFilterMask(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_setMultiSapParentProxy(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_setUniqueId(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphaseProxy_delete(IntPtr obj);
	}

	public class BroadphasePair
	{
		internal IntPtr _native;
        bool _preventDelete;

		internal BroadphasePair(IntPtr native, bool preventDelete = false)
		{
			_native = native;
            _preventDelete = preventDelete;
		}

		public BroadphasePair()
		{
			_native = btBroadphasePair_new();
		}

		public BroadphasePair(BroadphasePair other)
		{
			_native = btBroadphasePair_new2(other._native);
		}

		public BroadphasePair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			_native = btBroadphasePair_new3(proxy0._native, proxy1._native);
		}
        
		public CollisionAlgorithm Algorithm
		{
            get
            {
                IntPtr valuePtr = btBroadphasePair_getAlgorithm(_native);
                return (valuePtr == IntPtr.Zero) ? null : new CollisionAlgorithm(valuePtr, true);
            }
			set { btBroadphasePair_setAlgorithm(_native, (value._native == IntPtr.Zero) ? IntPtr.Zero : value._native); }
		}
        
		public BroadphaseProxy Proxy0
		{
            get { return BroadphaseProxy.GetManaged(btBroadphasePair_getPProxy0(_native)); }
			set { btBroadphasePair_setPProxy0(_native, value._native); }
		}

		public BroadphaseProxy Proxy1
		{
            get { return BroadphaseProxy.GetManaged(btBroadphasePair_getPProxy1(_native)); }
			set { btBroadphasePair_setPProxy1(_native, value._native); }
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
                    btBroadphasePair_delete(_native);
                }
				_native = IntPtr.Zero;
			}
		}

		~BroadphasePair()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePair_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePair_new2(IntPtr other);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePair_new3(IntPtr proxy0, IntPtr proxy1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePair_getAlgorithm(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePair_getPProxy0(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePair_getPProxy1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphasePair_setAlgorithm(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphasePair_setPProxy0(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphasePair_setPProxy1(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphasePair_delete(IntPtr obj);
	}

	public class BroadphasePairSortPredicate
	{
		internal IntPtr _native;

		internal BroadphasePairSortPredicate(IntPtr native)
		{
			_native = native;
		}

		public BroadphasePairSortPredicate()
		{
			_native = btBroadphasePairSortPredicate_new();
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
				btBroadphasePairSortPredicate_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~BroadphasePairSortPredicate()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBroadphasePairSortPredicate_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBroadphasePairSortPredicate_delete(IntPtr obj);
	}
}
