
#if __iOS__
using ObjCRuntime;
#endif
using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.Generic;

namespace BulletSharp
{
	public class LocalShapeInfo : IDisposable
	{
		internal IntPtr _native;

		internal LocalShapeInfo(IntPtr native)
		{
			_native = native;
		}

		public LocalShapeInfo()
		{
			_native = btCollisionWorld_LocalShapeInfo_new();
		}

		public int ShapePart
		{
			get { return btCollisionWorld_LocalShapeInfo_getShapePart(_native); }
			set { btCollisionWorld_LocalShapeInfo_setShapePart(_native, value); }
		}

		public int TriangleIndex
		{
			get { return btCollisionWorld_LocalShapeInfo_getTriangleIndex(_native); }
			set { btCollisionWorld_LocalShapeInfo_setTriangleIndex(_native, value); }
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
				btCollisionWorld_LocalShapeInfo_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~LocalShapeInfo()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalShapeInfo_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btCollisionWorld_LocalShapeInfo_getShapePart(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btCollisionWorld_LocalShapeInfo_getTriangleIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalShapeInfo_setShapePart(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalShapeInfo_setTriangleIndex(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalShapeInfo_delete(IntPtr obj);
	}

	public class LocalRayResult
	{
		internal IntPtr _native;

		internal LocalRayResult(IntPtr native)
		{
			_native = native;
		}

		public LocalRayResult(CollisionObject collisionObject, LocalShapeInfo localShapeInfo, Vector3 hitNormalLocal, float hitFraction)
		{
			_native = btCollisionWorld_LocalRayResult_new(collisionObject._native, localShapeInfo._native, ref hitNormalLocal, hitFraction);
		}

		public CollisionObject CollisionObject
		{
			get { return CollisionObject.GetManaged(btCollisionWorld_LocalRayResult_getCollisionObject(_native)); }
			set { btCollisionWorld_LocalRayResult_setCollisionObject(_native, value._native); }
		}

		public float HitFraction
		{
			get { return btCollisionWorld_LocalRayResult_getHitFraction(_native); }
			set { btCollisionWorld_LocalRayResult_setHitFraction(_native, value); }
		}

		public Vector3 HitNormalLocal
		{
			get
			{
				Vector3 value;
				btCollisionWorld_LocalRayResult_getHitNormalLocal(_native, out value);
				return value;
			}
			set { btCollisionWorld_LocalRayResult_setHitNormalLocal(_native, ref value); }
		}

		public LocalShapeInfo LocalShapeInfo
		{
			get { return new LocalShapeInfo(btCollisionWorld_LocalRayResult_getLocalShapeInfo(_native)); }
			set { btCollisionWorld_LocalRayResult_setLocalShapeInfo(_native, value._native); }
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
				btCollisionWorld_LocalRayResult_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~LocalRayResult()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalRayResult_new(IntPtr collisionObject, IntPtr localShapeInfo, [In] ref Vector3 hitNormalLocal, float hitFraction);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalRayResult_getCollisionObject(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionWorld_LocalRayResult_getHitFraction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalRayResult_getHitNormalLocal(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalRayResult_getLocalShapeInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalRayResult_setCollisionObject(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalRayResult_setHitFraction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalRayResult_setHitNormalLocal(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalRayResult_setLocalShapeInfo(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalRayResult_delete(IntPtr obj);
	}

	public class RayResultCallback : IDisposable
	{
		internal IntPtr _native;

		internal RayResultCallback(IntPtr native)
		{
			_native = native;
		}

		public float AddSingleResult(LocalRayResult rayResult, bool normalInWorldSpace)
		{
			return btCollisionWorld_RayResultCallback_addSingleResult(_native, rayResult._native, normalInWorldSpace);
		}

		public bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_RayResultCallback_needsCollision(_native, proxy0._native);
		}

		public float ClosestHitFraction
		{
			get { return btCollisionWorld_RayResultCallback_getClosestHitFraction(_native); }
			set { btCollisionWorld_RayResultCallback_setClosestHitFraction(_native, value); }
		}

		public short CollisionFilterGroup
		{
			get { return btCollisionWorld_RayResultCallback_getCollisionFilterGroup(_native); }
			set { btCollisionWorld_RayResultCallback_setCollisionFilterGroup(_native, value); }
		}

		public short CollisionFilterMask
		{
			get { return btCollisionWorld_RayResultCallback_getCollisionFilterMask(_native); }
			set { btCollisionWorld_RayResultCallback_setCollisionFilterMask(_native, value); }
		}

		public CollisionObject CollisionObject
		{
			get { return CollisionObject.GetManaged(btCollisionWorld_RayResultCallback_getCollisionObject(_native)); }
			set { btCollisionWorld_RayResultCallback_setCollisionObject(_native, value._native); }
		}

		public uint Flags
		{
			get { return btCollisionWorld_RayResultCallback_getFlags(_native); }
			set { btCollisionWorld_RayResultCallback_setFlags(_native, value); }
		}

		public bool HasHit
		{
			get { return btCollisionWorld_RayResultCallback_hasHit(_native); }
		}

		public virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btCollisionWorld_RayResultCallback_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~RayResultCallback()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionWorld_RayResultCallback_addSingleResult(IntPtr obj, IntPtr rayResult, bool normalInWorldSpace);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionWorld_RayResultCallback_getClosestHitFraction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btCollisionWorld_RayResultCallback_getCollisionFilterGroup(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btCollisionWorld_RayResultCallback_getCollisionFilterMask(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_RayResultCallback_getCollisionObject(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btCollisionWorld_RayResultCallback_getFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionWorld_RayResultCallback_hasHit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionWorld_RayResultCallback_needsCollision(IntPtr obj, IntPtr proxy0);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_RayResultCallback_setClosestHitFraction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_RayResultCallback_setCollisionFilterGroup(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_RayResultCallback_setCollisionFilterMask(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_RayResultCallback_setCollisionObject(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_RayResultCallback_setFlags(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_RayResultCallback_delete(IntPtr obj);
	}

	public class ClosestRayResultCallback : RayResultCallback
	{
		internal ClosestRayResultCallback(IntPtr native)
			: base(native)
		{
		}

		public ClosestRayResultCallback(ref Vector3 rayFromWorld, ref Vector3 rayToWorld)
			: base(btCollisionWorld_ClosestRayResultCallback_new(ref rayFromWorld, ref rayToWorld))
		{
		}

		public ClosestRayResultCallback(Vector3 rayFromWorld, Vector3 rayToWorld)
			: base(btCollisionWorld_ClosestRayResultCallback_new(ref rayFromWorld, ref rayToWorld))
		{
		}

		public Vector3 HitNormalWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestRayResultCallback_getHitNormalWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestRayResultCallback_setHitNormalWorld(_native, ref value); }
		}

		public Vector3 HitPointWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestRayResultCallback_getHitPointWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestRayResultCallback_setHitPointWorld(_native, ref value); }
		}

		public Vector3 RayFromWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestRayResultCallback_getRayFromWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestRayResultCallback_setRayFromWorld(_native, ref value); }
		}

		public Vector3 RayToWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestRayResultCallback_getRayToWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestRayResultCallback_setRayToWorld(_native, ref value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_ClosestRayResultCallback_new([In] ref Vector3 rayFromWorld, [In] ref Vector3 rayToWorld);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_getHitNormalWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_getHitPointWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_getRayFromWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_getRayToWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_setHitNormalWorld(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_setHitPointWorld(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_setRayFromWorld(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestRayResultCallback_setRayToWorld(IntPtr obj, [In] ref Vector3 value);
	}

	public class LocalConvexResult : IDisposable
	{
		internal IntPtr _native;

		internal LocalConvexResult(IntPtr native)
		{
			_native = native;
		}

		public LocalConvexResult(CollisionObject hitCollisionObject, LocalShapeInfo localShapeInfo, Vector3 hitNormalLocal, Vector3 hitPointLocal, float hitFraction)
		{
			_native = btCollisionWorld_LocalConvexResult_new(hitCollisionObject._native, localShapeInfo._native, ref hitNormalLocal, ref hitPointLocal, hitFraction);
		}

		public CollisionObject HitCollisionObject
		{
			get { return CollisionObject.GetManaged(btCollisionWorld_LocalConvexResult_getHitCollisionObject(_native)); }
			set { btCollisionWorld_LocalConvexResult_setHitCollisionObject(_native, value._native); }
		}

		public float HitFraction
		{
			get { return btCollisionWorld_LocalConvexResult_getHitFraction(_native); }
			set { btCollisionWorld_LocalConvexResult_setHitFraction(_native, value); }
		}

		public Vector3 HitNormalLocal
		{
			get
			{
				Vector3 value;
				btCollisionWorld_LocalConvexResult_getHitNormalLocal(_native, out value);
				return value;
			}
			set { btCollisionWorld_LocalConvexResult_setHitNormalLocal(_native, ref value); }
		}

		public Vector3 HitPointLocal
		{
			get
			{
				Vector3 value;
				btCollisionWorld_LocalConvexResult_getHitPointLocal(_native, out value);
				return value;
			}
			set { btCollisionWorld_LocalConvexResult_setHitPointLocal(_native, ref value); }
		}

		public LocalShapeInfo LocalShapeInfo
		{
			get { return new LocalShapeInfo(btCollisionWorld_LocalConvexResult_getLocalShapeInfo(_native)); }
			set { btCollisionWorld_LocalConvexResult_setLocalShapeInfo(_native, value._native); }
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
				btCollisionWorld_LocalConvexResult_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~LocalConvexResult()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalConvexResult_new(IntPtr hitCollisionObject, IntPtr localShapeInfo, [In] ref Vector3 hitNormalLocal, [In] ref Vector3 hitPointLocal, float hitFraction);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalConvexResult_getHitCollisionObject(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionWorld_LocalConvexResult_getHitFraction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_getHitNormalLocal(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_getHitPointLocal(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_LocalConvexResult_getLocalShapeInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_setHitCollisionObject(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_setHitFraction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_setHitNormalLocal(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_setHitPointLocal(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_setLocalShapeInfo(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_LocalConvexResult_delete(IntPtr obj);
	}

	public class ConvexResultCallback : IDisposable
	{
		internal IntPtr _native;

		internal ConvexResultCallback(IntPtr native)
		{
			_native = native;
		}

		public float AddSingleResult(LocalConvexResult convexResult, bool normalInWorldSpace)
		{
			return btCollisionWorld_ConvexResultCallback_addSingleResult(_native, convexResult._native, normalInWorldSpace);
		}

		public bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_ConvexResultCallback_needsCollision(_native, proxy0._native);
		}

		public float ClosestHitFraction
		{
			get { return btCollisionWorld_ConvexResultCallback_getClosestHitFraction(_native); }
			set { btCollisionWorld_ConvexResultCallback_setClosestHitFraction(_native, value); }
		}

		public CollisionFilterGroups CollisionFilterGroup
		{
			get { return (CollisionFilterGroups)btCollisionWorld_ConvexResultCallback_getCollisionFilterGroup(_native); }
			set { btCollisionWorld_ConvexResultCallback_setCollisionFilterGroup(_native, (short)value); }
		}

		public CollisionFilterGroups CollisionFilterMask
		{
			get { return (CollisionFilterGroups)btCollisionWorld_ConvexResultCallback_getCollisionFilterMask(_native); }
			set { btCollisionWorld_ConvexResultCallback_setCollisionFilterMask(_native, (short)value); }
		}

		public bool HasHit
		{
			get { return btCollisionWorld_ConvexResultCallback_hasHit(_native); }
		}

		public virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btCollisionWorld_ConvexResultCallback_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ConvexResultCallback()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionWorld_ConvexResultCallback_addSingleResult(IntPtr obj, IntPtr convexResult, bool normalInWorldSpace);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btCollisionWorld_ConvexResultCallback_getClosestHitFraction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btCollisionWorld_ConvexResultCallback_getCollisionFilterGroup(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btCollisionWorld_ConvexResultCallback_getCollisionFilterMask(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionWorld_ConvexResultCallback_hasHit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionWorld_ConvexResultCallback_needsCollision(IntPtr obj, IntPtr proxy0);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ConvexResultCallback_setClosestHitFraction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ConvexResultCallback_setCollisionFilterGroup(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ConvexResultCallback_setCollisionFilterMask(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ConvexResultCallback_delete(IntPtr obj);
	}

	public class ClosestConvexResultCallback : ConvexResultCallback
	{
		internal ClosestConvexResultCallback(IntPtr native)
			: base(native)
		{
		}

		public ClosestConvexResultCallback(ref Vector3 convexFromWorld, ref Vector3 convexToWorld)
			: base(btCollisionWorld_ClosestConvexResultCallback_new(ref convexFromWorld, ref convexToWorld))
		{
		}

		public ClosestConvexResultCallback(Vector3 convexFromWorld, Vector3 convexToWorld)
			: base(btCollisionWorld_ClosestConvexResultCallback_new(ref convexFromWorld, ref convexToWorld))
		{
		}

		public Vector3 ConvexFromWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestConvexResultCallback_getConvexFromWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestConvexResultCallback_setConvexFromWorld(_native, ref value); }
		}

		public Vector3 ConvexToWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestConvexResultCallback_getConvexToWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestConvexResultCallback_setConvexToWorld(_native, ref value); }
		}

		public CollisionObject HitCollisionObject
		{
			get { return CollisionObject.GetManaged(btCollisionWorld_ClosestConvexResultCallback_getHitCollisionObject(_native)); }
			set { btCollisionWorld_ClosestConvexResultCallback_setHitCollisionObject(_native, value._native); }
		}

		public Vector3 HitNormalWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestConvexResultCallback_getHitNormalWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestConvexResultCallback_setHitNormalWorld(_native, ref value); }
		}

		public Vector3 HitPointWorld
		{
			get
			{
				Vector3 value;
				btCollisionWorld_ClosestConvexResultCallback_getHitPointWorld(_native, out value);
				return value;
			}
			set { btCollisionWorld_ClosestConvexResultCallback_setHitPointWorld(_native, ref value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_ClosestConvexResultCallback_new([In] ref Vector3 convexFromWorld, [In] ref Vector3 convexToWorld);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_getConvexFromWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_getConvexToWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_ClosestConvexResultCallback_getHitCollisionObject(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_getHitNormalWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_getHitPointWorld(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_setConvexFromWorld(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_setConvexToWorld(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_setHitCollisionObject(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_setHitNormalWorld(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ClosestConvexResultCallback_setHitPointWorld(IntPtr obj, [In] ref Vector3 value);
	}

    public class AllHitsConvexResultCallback : ConvexResultCallback
    {
        [UnmanagedFunctionPointer(Native.Conv)]
        protected delegate void AddSingleResultUnmanagedDelegate(IntPtr sharpReference, IntPtr collider, [In] ref Vector3 point, [In] ref Vector3 normal, float hitFraction);

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly AddSingleResultUnmanagedDelegate _addSingleResult;

#if __iOS__
        [MonoPInvokeCallback(typeof(AddSingleResultUnmanagedDelegate))]
#endif
        private static void AddSingleResultUnmanaged(IntPtr sharpReference, IntPtr collider, [In] ref Vector3 point, [In] ref Vector3 normal, float hitFraction)
        {
            var obj = (AllHitsConvexResultCallback)GCHandle.FromIntPtr(sharpReference).Target;
            obj.AddSingleResult(CollisionObject.GetManaged(collider), ref point, ref normal, hitFraction);
        }

        public virtual void AddSingleResult(CollisionObject collisionObject, ref Vector3 point, ref Vector3 normal, float hitFraction)
        {
            
        }

        internal AllHitsConvexResultCallback(IntPtr native)
			: base(native)
		{
		}

        private GCHandle _mHandle;

		public AllHitsConvexResultCallback()
            : base(IntPtr.Zero)
		{
		    _mHandle = GCHandle.Alloc(this);

            _addSingleResult = AddSingleResultUnmanaged;
#if !__iOS__
            _native = btCollisionWorld_AllHitsConvexResultCallback_new(Marshal.GetFunctionPointerForDelegate(_addSingleResult), GCHandle.ToIntPtr(_mHandle));
#else
            _native = btCollisionWorld_AllHitsConvexResultCallback_new(_addSingleResult, GCHandle.ToIntPtr(_mHandle));
#endif
		}

        public override void Dispose()
        {
            _mHandle.Free();
            btCollisionWorld_AllHitsConvexResultCallback_delete(_native);
            GC.SuppressFinalize(this);
        }

#if !__iOS__
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btCollisionWorld_AllHitsConvexResultCallback_new(IntPtr resultCallback, IntPtr sharpReference);
#else
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btCollisionWorld_AllHitsConvexResultCallback_new(AddSingleResultUnmanagedDelegate resultCallback, IntPtr sharpReference);
#endif

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btCollisionWorld_AllHitsConvexResultCallback_delete(IntPtr obj);
    }

    public class AllHitsRayResultCallback : RayResultCallback
    {
        [UnmanagedFunctionPointer(Native.Conv)]
        protected delegate void AddSingleResultUnmanagedDelegate(IntPtr sharpReference, IntPtr collider, [In] ref Vector3 point, [In] ref Vector3 normal, float hitFraction);

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly AddSingleResultUnmanagedDelegate _addSingleResult;

#if __iOS__
        [MonoPInvokeCallback(typeof(AddSingleResultUnmanagedDelegate))]
#endif
        private static void AddSingleResultUnmanaged(IntPtr sharpReference, IntPtr collider, [In] ref Vector3 point, [In] ref Vector3 normal, float hitFraction)
        {
            var obj = (AllHitsRayResultCallback)GCHandle.FromIntPtr(sharpReference).Target;
            obj.AddSingleResult(CollisionObject.GetManaged(collider), ref point, ref normal, hitFraction);
        }

        public virtual void AddSingleResult(CollisionObject collisionObject, ref Vector3 point, ref Vector3 normal, float hitFraction)
        {

        }

        internal AllHitsRayResultCallback(IntPtr native)
            : base(native)
        {
        }

        private GCHandle _mHandle;

        public AllHitsRayResultCallback(ref Vector3 from, ref Vector3 to)
            : base(IntPtr.Zero)
        {
            _mHandle = GCHandle.Alloc(this);

            _addSingleResult = AddSingleResultUnmanaged;
#if !__iOS__
            _native = btCollisionWorld_AllHitsRayResultCallback_new2(Marshal.GetFunctionPointerForDelegate(_addSingleResult), GCHandle.ToIntPtr(_mHandle), ref from, ref to);
#else
            _native = btCollisionWorld_AllHitsRayResultCallback_new2(_addSingleResult, GCHandle.ToIntPtr(_mHandle), ref from, ref to);
#endif
        }

        public override void Dispose()
        {
            _mHandle.Free();
            GC.SuppressFinalize(this);
        }

#if !__iOS__
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btCollisionWorld_AllHitsRayResultCallback_new2(IntPtr resultCallback, IntPtr sharpReference, [In] ref Vector3 rayFromWorld, [In] ref Vector3 rayToWorld);
#else
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern IntPtr btCollisionWorld_AllHitsRayResultCallback_new2(AddSingleResultUnmanagedDelegate resultCallback, IntPtr sharpReference, [In] ref Vector3 rayFromWorld, [In] ref Vector3 rayToWorld);
#endif

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        protected static extern void btCollisionWorld_AllHitsRayResultCallback_delete2(IntPtr obj);
    }

    public abstract class ContactResultCallback : IDisposable
	{
		internal IntPtr _native;

        [UnmanagedFunctionPointer(Native.Conv)]
		delegate float AddSingleResultUnmanagedDelegate(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1);
        [UnmanagedFunctionPointer(Native.Conv)]
		delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		AddSingleResultUnmanagedDelegate _addSingleResult;
		NeedsCollisionUnmanagedDelegate _needsCollision;

		public ContactResultCallback()
		{
			_addSingleResult = new AddSingleResultUnmanagedDelegate(AddSingleResultUnmanaged);
			_needsCollision = new NeedsCollisionUnmanagedDelegate(NeedsCollisionUnmanaged);
			_native = btCollisionWorld_ContactResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
		}

		float AddSingleResultUnmanaged(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1)
		{
			return AddSingleResult(new ManifoldPoint(cp, true),
				new CollisionObjectWrapper(colObj0Wrap), partId0, index0,
				new CollisionObjectWrapper(colObj1Wrap), partId1, index1);
		}

		public abstract float AddSingleResult(ManifoldPoint cp, CollisionObjectWrapper colObj0Wrap, int partId0, int index0, CollisionObjectWrapper colObj1Wrap, int partId1, int index1);

		bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_ContactResultCallbackWrapper_needsCollision(_native, proxy0._native);
		}

		public short CollisionFilterGroup
		{
			get { return btCollisionWorld_ContactResultCallback_getCollisionFilterGroup(_native); }
			set { btCollisionWorld_ContactResultCallback_setCollisionFilterGroup(_native, value); }
		}

		public short CollisionFilterMask
		{
			get { return btCollisionWorld_ContactResultCallback_getCollisionFilterMask(_native); }
			set { btCollisionWorld_ContactResultCallback_setCollisionFilterMask(_native, value); }
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
				btCollisionWorld_ContactResultCallback_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ContactResultCallback()
		{
			Dispose(false);
		}

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btCollisionWorld_ContactResultCallback_getCollisionFilterGroup(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern short btCollisionWorld_ContactResultCallback_getCollisionFilterMask(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ContactResultCallback_setCollisionFilterGroup(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ContactResultCallback_setCollisionFilterMask(IntPtr obj, short value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_ContactResultCallback_delete(IntPtr obj);

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_ContactResultCallbackWrapper_new(IntPtr addSingleResult, IntPtr needsCollision);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionWorld_ContactResultCallbackWrapper_needsCollision(IntPtr obj, IntPtr proxy0);
	}

	public class CollisionWorld : IDisposable
	{
		internal IntPtr _native;

		AlignedCollisionObjectArray _collisionObjectArray;
		protected CollisionConfiguration _collisionConfiguration;
		protected Dispatcher _dispatcher;
		protected BroadphaseInterface _broadphase;
		OverlappingPairCache _pairCache;

		internal CollisionWorld(IntPtr native)
		{
			_native = native;

		    bufferData = Xenko_GetBufferData(collisionsBuffer);
		}

		public CollisionWorld(Dispatcher dispatcher, BroadphaseInterface broadphasePairCache, CollisionConfiguration collisionConfiguration)
		{
			_native = btCollisionWorld_new(dispatcher._native, broadphasePairCache._native, collisionConfiguration._native);
			_dispatcher = dispatcher;
			_broadphase = broadphasePairCache;
			_collisionConfiguration = collisionConfiguration;

            bufferData = Xenko_GetBufferData(collisionsBuffer);
        }

		public void AddCollisionObject(CollisionObject collisionObject, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask)
		{
			btCollisionWorld_addCollisionObject(_native, collisionObject._native, (short)collisionFilterGroup, (short)collisionFilterMask);
		}

		public void AddCollisionObject(CollisionObject collisionObject, CollisionFilterGroups collisionFilterGroup)
		{
			btCollisionWorld_addCollisionObject2(_native, collisionObject._native, (short)collisionFilterGroup);
		}

		public void AddCollisionObject(CollisionObject collisionObject)
		{
			btCollisionWorld_addCollisionObject3(_native, collisionObject._native);
		}

		public void ComputeOverlappingPairs()
		{
			btCollisionWorld_computeOverlappingPairs(_native);
		}

		public void ContactPairTest(CollisionObject colObjA, CollisionObject colObjB, ContactResultCallback resultCallback)
		{
			btCollisionWorld_contactPairTest(_native, colObjA._native, colObjB._native, resultCallback._native);
		}

		public void ContactTest(CollisionObject colObj, ContactResultCallback resultCallback)
		{
			btCollisionWorld_contactTest(_native, colObj._native, resultCallback._native);
		}

		public void ConvexSweepTest(ConvexShape castShape, Matrix from, Matrix to, ConvexResultCallback resultCallback, float allowedCcdPenetration)
		{
			btCollisionWorld_convexSweepTest(_native, castShape._native, ref from, ref to, resultCallback._native, allowedCcdPenetration);
		}

		public void ConvexSweepTest(ConvexShape castShape, Matrix from, Matrix to, ConvexResultCallback resultCallback)
		{
			btCollisionWorld_convexSweepTest2(_native, castShape._native, ref from, ref to, resultCallback._native);
		}

		public void DebugDrawObject(Matrix worldTransform, CollisionShape shape, Vector3 color)
		{
			btCollisionWorld_debugDrawObject(_native, ref worldTransform, shape._native, ref color);
		}

		public void DebugDrawWorld()
		{
			btCollisionWorld_debugDrawWorld(_native);
		}

		public void ObjectQuerySingle(ConvexShape castShape, Matrix rayFromTrans, Matrix rayToTrans, CollisionObject collisionObject, CollisionShape collisionShape, Matrix colObjWorldTransform, ConvexResultCallback resultCallback, float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingle(castShape._native, ref rayFromTrans, ref rayToTrans, collisionObject._native, collisionShape._native, ref colObjWorldTransform, resultCallback._native, allowedPenetration);
		}

		public void ObjectQuerySingleInternal(ConvexShape castShape, Matrix convexFromTrans, Matrix convexToTrans, CollisionObjectWrapper colObjWrap, ConvexResultCallback resultCallback, float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingleInternal(castShape._native, ref convexFromTrans, ref convexToTrans, colObjWrap._native, resultCallback._native, allowedPenetration);
		}

		public void PerformDiscreteCollisionDetection()
		{
			btCollisionWorld_performDiscreteCollisionDetection(_native);
		}

		public void RayTest(ref Vector3 rayFromWorld, ref Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTest(_native, ref rayFromWorld, ref rayToWorld, resultCallback._native);
		}

		public void RayTestSingle(Matrix rayFromTrans, Matrix rayToTrans, CollisionObject collisionObject, CollisionShape collisionShape, Matrix colObjWorldTransform, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingle(ref rayFromTrans, ref rayToTrans, collisionObject._native, collisionShape._native, ref colObjWorldTransform, resultCallback._native);
		}

		public void RayTestSingleInternal(Matrix rayFromTrans, Matrix rayToTrans, CollisionObjectWrapper collisionObjectWrap, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingleInternal(ref rayFromTrans, ref rayToTrans, collisionObjectWrap._native, resultCallback._native);
		}

		public void RemoveCollisionObject(CollisionObject collisionObject)
		{
			btCollisionWorld_removeCollisionObject(_native, collisionObject._native);
		}

		public void Serialize(Serializer serializer)
		{
			btCollisionWorld_serialize(_native, serializer._native);
		}

		public void UpdateAabbs()
		{
			btCollisionWorld_updateAabbs(_native);
		}

		public void UpdateSingleAabb(CollisionObject colObj)
		{
			btCollisionWorld_updateSingleAabb(_native, colObj._native);
		}

		public BroadphaseInterface Broadphase
		{
			get { return _broadphase; }
			set
			{
				_broadphase = value;
				btCollisionWorld_setBroadphase(_native, value._native);
			}
		}

		public AlignedCollisionObjectArray CollisionObjectArray
		{
			get
			{
				if (_collisionObjectArray == null)
				{
					_collisionObjectArray = new AlignedCollisionObjectArray(btCollisionWorld_getCollisionObjectArray(_native), true);
				}
				return _collisionObjectArray;
			}
		}

		public IDebugDraw DebugDrawer
		{
			get
			{
				return DebugDraw.GetManaged(btCollisionWorld_getDebugDrawer(_native));
			}
			set
			{
				btCollisionWorld_setDebugDrawer(_native, DebugDraw.GetUnmanaged(value));
			}
		}

		public Dispatcher Dispatcher
		{
			get { return _dispatcher; }
		}

		public DispatcherInfo DispatchInfo
		{
			get { return new DispatcherInfo(btCollisionWorld_getDispatchInfo(_native)); }
		}

		public bool ForceUpdateAllAabbs
		{
			get { return btCollisionWorld_getForceUpdateAllAabbs(_native); }
			set { btCollisionWorld_setForceUpdateAllAabbs(_native, value); }
		}

		public int NumCollisionObjects
		{
			get { return btCollisionWorld_getNumCollisionObjects(_native); }
		}

		public OverlappingPairCache PairCache
		{
			get
			{
				if (_pairCache == null)
				{
					_pairCache = new OverlappingPairCache(btCollisionWorld_getPairCache(_native), true);
				}
				return _pairCache;
			}
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
				btCollisionWorld_delete(_native);
				_native = IntPtr.Zero;
			}

            Xenko_DeleteBuffer(collisionsBuffer);
        }

		~CollisionWorld()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_new(IntPtr dispatcher, IntPtr broadphasePairCache, IntPtr collisionConfiguration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_addCollisionObject(IntPtr obj, IntPtr collisionObject, short collisionFilterGroup, short collisionFilterMask);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_addCollisionObject2(IntPtr obj, IntPtr collisionObject, short collisionFilterGroup);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_addCollisionObject3(IntPtr obj, IntPtr collisionObject);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_computeOverlappingPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_contactPairTest(IntPtr obj, IntPtr colObjA, IntPtr colObjB, IntPtr resultCallback);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_contactTest(IntPtr obj, IntPtr colObj, IntPtr resultCallback);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_convexSweepTest(IntPtr obj, IntPtr castShape, [In] ref Matrix from, [In] ref Matrix to, IntPtr resultCallback, float allowedCcdPenetration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_convexSweepTest2(IntPtr obj, IntPtr castShape, [In] ref Matrix from, [In] ref Matrix to, IntPtr resultCallback);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_debugDrawObject(IntPtr obj, [In] ref Matrix worldTransform, IntPtr shape, [In] ref Vector3 color);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_debugDrawWorld(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_getCollisionObjectArray(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_getDebugDrawer(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_getDispatchInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btCollisionWorld_getForceUpdateAllAabbs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btCollisionWorld_getNumCollisionObjects(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionWorld_getPairCache(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_objectQuerySingle(IntPtr castShape, [In] ref Matrix rayFromTrans, [In] ref Matrix rayToTrans, IntPtr collisionObject, IntPtr collisionShape, [In] ref Matrix colObjWorldTransform, IntPtr resultCallback, float allowedPenetration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_objectQuerySingleInternal(IntPtr castShape, [In] ref Matrix convexFromTrans, [In] ref Matrix convexToTrans, IntPtr colObjWrap, IntPtr resultCallback, float allowedPenetration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_performDiscreteCollisionDetection(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_rayTest(IntPtr obj, [In] ref Vector3 rayFromWorld, [In] ref Vector3 rayToWorld, IntPtr resultCallback);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_rayTestSingle([In] ref Matrix rayFromTrans, [In] ref Matrix rayToTrans, IntPtr collisionObject, IntPtr collisionShape, [In] ref Matrix colObjWorldTransform, IntPtr resultCallback);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_rayTestSingleInternal([In] ref Matrix rayFromTrans, [In] ref Matrix rayToTrans, IntPtr collisionObjectWrap, IntPtr resultCallback);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_removeCollisionObject(IntPtr obj, IntPtr collisionObject);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_serialize(IntPtr obj, IntPtr serializer);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_setBroadphase(IntPtr obj, IntPtr pairCache);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_setDebugDrawer(IntPtr obj, IntPtr debugDrawer);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_setForceUpdateAllAabbs(IntPtr obj, bool forceUpdateAllAabbs);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_updateAabbs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_updateSingleAabb(IntPtr obj, IntPtr colObj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionWorld_delete(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Xenko_CreateBuffer();

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Xenko_DeleteBuffer(IntPtr buffer);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int Xenko_GetCollisions(IntPtr collisionWorld, IntPtr shape, IntPtr dataBuffer, short flags, short group);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Xenko_GetBufferData(IntPtr dataBuffer);

        private readonly IntPtr collisionsBuffer = Xenko_CreateBuffer();
        private readonly IntPtr bufferData;

	    public void GetCollisions(CollisionObject collisionObject, short masks, short group, out IntPtr buffer, out int size)
	    {
            size = Xenko_GetCollisions(_native, collisionObject._native, collisionsBuffer, masks, group);
	        buffer = bufferData;
	    }
    }
}
