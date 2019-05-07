using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class AllHitsRayResultCallback : RayResultCallback
	{
		public AllHitsRayResultCallback(Vector3 rayFromWorld, Vector3 rayToWorld)
		{
			RayFromWorld = rayFromWorld;
			RayToWorld = rayToWorld;

			CollisionObjects = new List<CollisionObject>();
			HitFractions = new List<float>();
			HitNormalWorld = new List<Vector3>();
			HitPointWorld = new List<Vector3>();
		}

		public override float AddSingleResult(ref LocalRayResult rayResult, bool normalInWorldSpace)
		{
			CollisionObject = rayResult.CollisionObject;
			CollisionObjects.Add(rayResult.CollisionObject);
			if (normalInWorldSpace)
			{
				HitNormalWorld.Add(rayResult.m_hitNormalLocal);
			}
			else
			{
				// need to transform normal into worldspace
				HitNormalWorld.Add(Vector3.TransformCoordinate(rayResult.m_hitNormalLocal, CollisionObject.WorldTransform.Basis));
			}
			HitPointWorld.Add(Vector3.Lerp(RayFromWorld, RayToWorld, rayResult.m_hitFraction));
			HitFractions.Add(rayResult.m_hitFraction);
			return ClosestHitFraction;
		}

		public List<CollisionObject> CollisionObjects { get; set; }
		public List<float> HitFractions { get; set; }
		public List<Vector3> HitNormalWorld { get; set; }
		public List<Vector3> HitPointWorld { get; set; }
		public Vector3 RayFromWorld { get; set; }
		public Vector3 RayToWorld { get; set; }
	}

	public class ClosestConvexResultCallback : ConvexResultCallback
	{
		public ClosestConvexResultCallback()
		{
		}

		public ClosestConvexResultCallback(ref Vector3 convexFromWorld, ref Vector3 convexToWorld)
		{
			ConvexFromWorld = convexFromWorld;
			ConvexToWorld = convexToWorld;
		}

		public override float AddSingleResult(ref LocalConvexResult convexResult, bool normalInWorldSpace)
		{
			//caller already does the filter on the m_closestHitFraction
			Debug.Assert(convexResult.m_hitFraction <= ClosestHitFraction);

			ClosestHitFraction = convexResult.m_hitFraction;
			HitCollisionObject = convexResult.HitCollisionObject;
			if (normalInWorldSpace)
			{
				HitNormalWorld = convexResult.m_hitNormalLocal;
			}
			else
			{
				// need to transform normal into worldspace
				HitNormalWorld = Vector3.TransformCoordinate(convexResult.m_hitNormalLocal, HitCollisionObject.WorldTransform.Basis);
			}
			HitPointWorld = convexResult.m_hitPointLocal;
			return convexResult.m_hitFraction;
		}

		public Vector3 ConvexFromWorld { get; set; }
		public Vector3 ConvexToWorld { get; set; }
		public CollisionObject HitCollisionObject { get; set; }
		public Vector3 HitNormalWorld { get; set; }
		public Vector3 HitPointWorld { get; set; }
	}

	public class ClosestRayResultCallback : RayResultCallback
	{
		public ClosestRayResultCallback(ref Vector3 rayFromWorld, ref Vector3 rayToWorld)
		{
			RayFromWorld = rayFromWorld;
			RayToWorld = rayToWorld;
		}

		public override float AddSingleResult(ref LocalRayResult rayResult, bool normalInWorldSpace)
		{
			//caller already does the filter on the m_closestHitFraction
			Debug.Assert(rayResult.m_hitFraction <= ClosestHitFraction);

			ClosestHitFraction = rayResult.m_hitFraction;
			CollisionObject = rayResult.CollisionObject;
			if (normalInWorldSpace)
			{
				HitNormalWorld = rayResult.m_hitNormalLocal;
			}
			else
			{
				// need to transform normal into worldspace
				HitNormalWorld = Vector3.TransformCoordinate(rayResult.m_hitNormalLocal, CollisionObject.WorldTransform.Basis);
			}
			HitPointWorld = Vector3.Lerp(RayFromWorld, RayToWorld, rayResult.m_hitFraction);
			return rayResult.m_hitFraction;
		}

		public Vector3 RayFromWorld { get; set; } //used to calculate hitPointWorld from hitFraction
		public Vector3 RayToWorld { get; set; }

		public Vector3 HitNormalWorld { get; set; }
		public Vector3 HitPointWorld { get; set; }
	}

	public abstract class ContactResultCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float AddSingleResultUnmanagedDelegate(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		private readonly AddSingleResultUnmanagedDelegate _addSingleResult;
		private readonly NeedsCollisionUnmanagedDelegate _needsCollision;

		public ContactResultCallback()
		{
			_addSingleResult = AddSingleResultUnmanaged;
			_needsCollision = NeedsCollisionUnmanaged;
			IntPtr native = btCollisionWorld_ContactResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
			InitializeUserOwned(native);
		}

		private float AddSingleResultUnmanaged(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1)
		{
			return AddSingleResult(ManifoldPoint.FromPtr(cp),
				new CollisionObjectWrapper(colObj0Wrap), partId0, index0,
				new CollisionObjectWrapper(colObj1Wrap), partId1, index1);
		}

		public abstract float AddSingleResult(ManifoldPoint cp, CollisionObjectWrapper colObj0Wrap, int partId0, int index0, CollisionObjectWrapper colObj1Wrap, int partId1, int index1);

		private bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_ContactResultCallbackWrapper_needsCollision(Native, proxy0.Native);
		}

		public float ClosestDistanceThreshold
		{
			get => btCollisionWorld_ContactResultCallback_getClosestDistanceThreshold(Native);
			set => btCollisionWorld_ContactResultCallback_setClosestDistanceThreshold(Native, value);
		}

		public int CollisionFilterGroup
		{
			get => btCollisionWorld_ContactResultCallback_getCollisionFilterGroup(Native);
			set => btCollisionWorld_ContactResultCallback_setCollisionFilterGroup(Native, value);
		}

		public int CollisionFilterMask
		{
			get => btCollisionWorld_ContactResultCallback_getCollisionFilterMask(Native);
			set => btCollisionWorld_ContactResultCallback_setCollisionFilterMask(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btCollisionWorld_ContactResultCallback_delete(Native);
		}
	}

	public abstract class ConvexResultCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float AddSingleResultUnmanagedDelegate(IntPtr convexResult, bool normalInWorldSpace);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		private readonly AddSingleResultUnmanagedDelegate _addSingleResult;
		private readonly NeedsCollisionUnmanagedDelegate _needsCollision;

		protected ConvexResultCallback()
		{
			_addSingleResult = AddSingleResultUnmanaged;
			_needsCollision = NeedsCollisionUnmanaged;
			IntPtr native = btCollisionWorld_ConvexResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
			InitializeUserOwned(native);
		}

		private float AddSingleResultUnmanaged(IntPtr convexResult, bool normalInWorldSpace)
		{
			var convexResultManaged = LocalConvexResult.FromPtr(convexResult);
			return AddSingleResult(ref convexResultManaged, normalInWorldSpace);
		}

		public abstract float AddSingleResult(ref LocalConvexResult convexResult, bool normalInWorldSpace);

		private bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_ConvexResultCallbackWrapper_needsCollision(Native,
				proxy0.Native);
		}

		public float ClosestHitFraction
		{
			get => btCollisionWorld_ConvexResultCallback_getClosestHitFraction(Native);
			set => btCollisionWorld_ConvexResultCallback_setClosestHitFraction(Native, value);
		}

		public int CollisionFilterGroup
		{
			get => btCollisionWorld_ConvexResultCallback_getCollisionFilterGroup(Native);
			set => btCollisionWorld_ConvexResultCallback_setCollisionFilterGroup(Native, value);
		}

		public int CollisionFilterMask
		{
			get => btCollisionWorld_ConvexResultCallback_getCollisionFilterMask(Native);
			set => btCollisionWorld_ConvexResultCallback_setCollisionFilterMask(Native, value);
		}

		public bool HasHit => btCollisionWorld_ConvexResultCallback_hasHit(Native);

		protected override void Dispose(bool disposing)
		{
			btCollisionWorld_ConvexResultCallback_delete(Native);
		}
	}

	public readonly struct LocalConvexResult
	{
		readonly IntPtr m_hitCollisionObject;
		readonly IntPtr m_localShapeInfo;
		public readonly Vector3_Interop m_hitNormalLocal;
		public readonly Vector3_Interop m_hitPointLocal;
		public readonly float m_hitFraction;

		public CollisionObject HitCollisionObject
		{
			get
			{
				if( m_hitCollisionObject == IntPtr.Zero )
					return null;
				return CollisionObject.GetManaged(m_hitCollisionObject);
			}
		}

		public LocalShapeInfo? LocalShapeInfo => m_localShapeInfo == IntPtr.Zero ? (LocalShapeInfo?)null : new LocalShapeInfo(m_localShapeInfo);

		public static LocalConvexResult FromPtr(IntPtr ptr) => Marshal.PtrToStructure<LocalConvexResult>(ptr);
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct LocalRayResult
	{
		readonly IntPtr m_collisionObject;
		readonly IntPtr m_localShapeInfo;
		public readonly Vector3_Interop m_hitNormalLocal;
		public readonly float m_hitFraction;

		public CollisionObject CollisionObject
		{
			get
			{
				if( m_collisionObject == IntPtr.Zero )
					return null;
				return CollisionObject.GetManaged(m_collisionObject);
			}
		}

		public LocalShapeInfo? LocalShapeInfo => m_localShapeInfo == IntPtr.Zero ? (LocalShapeInfo?)null : new LocalShapeInfo(m_localShapeInfo);

		public static LocalRayResult FromPtr(IntPtr ptr) => Marshal.PtrToStructure<LocalRayResult>(ptr);
	}

	public readonly struct LocalShapeInfo
	{
		public readonly int ShapePart;
		public readonly int TriangleIndex;

		internal LocalShapeInfo(IntPtr native)
		{
			ShapePart = btCollisionWorld_LocalShapeInfo_getShapePart(native);
			TriangleIndex = btCollisionWorld_LocalShapeInfo_getTriangleIndex(native);
		}
	}

	public abstract class RayResultCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float AddSingleResultUnmanagedDelegate(IntPtr rayResult, bool normalInWorldSpace);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		private readonly AddSingleResultUnmanagedDelegate _addSingleResult;
		private readonly NeedsCollisionUnmanagedDelegate _needsCollision;

		protected RayResultCallback()
		{
			_addSingleResult = AddSingleResultUnmanaged;
			_needsCollision = NeedsCollisionUnmanaged;

			IntPtr native = btCollisionWorld_RayResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
			InitializeUserOwned(native);
		}

		private float AddSingleResultUnmanaged(IntPtr rayResult, bool normalInWorldSpace)
		{
			var localRayResult = LocalRayResult.FromPtr(rayResult);
			return AddSingleResult(ref localRayResult, normalInWorldSpace);
		}

		public abstract float AddSingleResult(ref LocalRayResult rayResult, bool normalInWorldSpace);

		private bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_RayResultCallbackWrapper_needsCollision(Native, proxy0.Native);
		}

		public float ClosestHitFraction
		{
			get => btCollisionWorld_RayResultCallback_getClosestHitFraction(Native);
			set => btCollisionWorld_RayResultCallback_setClosestHitFraction(Native, value);
		}

		public int CollisionFilterGroup
		{
			get => btCollisionWorld_RayResultCallback_getCollisionFilterGroup(Native);
			set => btCollisionWorld_RayResultCallback_setCollisionFilterGroup(Native, value);
		}

		public int CollisionFilterMask
		{
			get => btCollisionWorld_RayResultCallback_getCollisionFilterMask(Native);
			set => btCollisionWorld_RayResultCallback_setCollisionFilterMask(Native, value);
		}

		public CollisionObject CollisionObject
		{
			get => CollisionObject.GetManaged(btCollisionWorld_RayResultCallback_getCollisionObject(Native));
			set => btCollisionWorld_RayResultCallback_setCollisionObject(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		public uint Flags
		{
			get => btCollisionWorld_RayResultCallback_getFlags(Native);
			set => btCollisionWorld_RayResultCallback_setFlags(Native, value);
		}

		public bool HasHit => btCollisionWorld_RayResultCallback_hasHit(Native);

		protected override void Dispose(bool disposing)
		{
			btCollisionWorld_RayResultCallback_delete(Native);
		}
	}

	public class CollisionWorld : BulletDisposableObject
	{
		private DebugDraw _debugDrawer;
		private BroadphaseInterface _broadphase;
		private DispatcherInfo _dispatchInfo;

		protected internal CollisionWorld()
		{
		}

		public CollisionWorld(Dispatcher dispatcher, BroadphaseInterface broadphasePairCache,
			CollisionConfiguration collisionConfiguration)
		{
			IntPtr native = btCollisionWorld_new(dispatcher.Native, broadphasePairCache.Native,
				collisionConfiguration.Native);
			InitializeUserOwned(native);
			InitializeMembers(dispatcher, broadphasePairCache);
		}

		protected internal void InitializeMembers(Dispatcher dispatcher, BroadphaseInterface broadphasePairCache)
		{
			Dispatcher = dispatcher;
			Broadphase = broadphasePairCache;
			CollisionObjectArray = new AlignedCollisionObjectArray(btCollisionWorld_getCollisionObjectArray(Native), this);
		}

		public void AddCollisionObject(CollisionObject collisionObject)
		{
			CollisionObjectArray.Add(collisionObject);
		}

		public void AddCollisionObject(CollisionObject collisionObject, CollisionFilterGroups collisionFilterGroup,
			CollisionFilterGroups collisionFilterMask)
		{
			CollisionObjectArray.Add(collisionObject, (int)collisionFilterGroup, (int)collisionFilterMask);
		}

		public void AddCollisionObject(CollisionObject collisionObject, int collisionFilterGroup,
			int collisionFilterMask)
		{
			CollisionObjectArray.Add(collisionObject, collisionFilterGroup, collisionFilterMask);
		}

		public void ComputeOverlappingPairs()
		{
			btCollisionWorld_computeOverlappingPairs(Native);
		}

		public void ContactPairTest(CollisionObject colObjA, CollisionObject colObjB,
			ContactResultCallback resultCallback)
		{
			btCollisionWorld_contactPairTest(Native, colObjA.Native, colObjB.Native,
				resultCallback.Native);
		}

		public void ContactTest(CollisionObject colObj, ContactResultCallback resultCallback)
		{
			btCollisionWorld_contactTest(Native, colObj.Native, resultCallback.Native);
		}

		public void ConvexSweepTestRef(ConvexShape castShape, ref Matrix from, ref Matrix to,
			ConvexResultCallback resultCallback, float allowedCcdPenetration = 0)
		{
			btCollisionWorld_convexSweepTest(Native, castShape.Native, ref from, ref to, resultCallback.Native, allowedCcdPenetration);
		}

		public void ConvexSweepTest(ConvexShape castShape, Matrix from, Matrix to,
			ConvexResultCallback resultCallback, float allowedCcdPenetration = 0)
		{
			btCollisionWorld_convexSweepTest(Native, castShape.Native, ref from,
				ref to, resultCallback.Native, allowedCcdPenetration);
		}

		public void DebugDrawObjectRef(ref Matrix worldTransform, CollisionShape shape, ref Vector3 color)
		{
			btCollisionWorld_debugDrawObject(Native, ref worldTransform, shape.Native, ref color);
		}

		public void DebugDrawObject(Matrix worldTransform, CollisionShape shape,
			Vector3 color)
		{
			btCollisionWorld_debugDrawObject(Native, ref worldTransform, shape.Native,
				ref color);
		}

		public void DebugDrawWorld()
		{
			btCollisionWorld_debugDrawWorld(Native);
		}

		public static void ObjectQuerySingleRef(ConvexShape castShape, ref Matrix rayFromTrans,
			ref Matrix rayToTrans, CollisionObject collisionObject, CollisionShape collisionShape,
			ref Matrix colObjWorldTransform, ConvexResultCallback resultCallback, float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingle(castShape.Native, ref rayFromTrans,
				ref rayToTrans, collisionObject.Native, collisionShape.Native, ref colObjWorldTransform,
				resultCallback.Native, allowedPenetration);
		}

		public static void ObjectQuerySingle(ConvexShape castShape, Matrix rayFromTrans,
			Matrix rayToTrans, CollisionObject collisionObject, CollisionShape collisionShape,
			Matrix colObjWorldTransform, ConvexResultCallback resultCallback, float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingle(castShape.Native, ref rayFromTrans,
				ref rayToTrans, collisionObject.Native, collisionShape.Native, ref colObjWorldTransform,
				resultCallback.Native, allowedPenetration);
		}

		public static void ObjectQuerySingleInternalRef(ConvexShape castShape, ref Matrix convexFromTrans,
			ref Matrix convexToTrans, CollisionObjectWrapper colObjWrap, ConvexResultCallback resultCallback,
			float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingleInternal(castShape.Native, ref convexFromTrans,
				ref convexToTrans, colObjWrap.Native, resultCallback.Native, allowedPenetration);
		}

		public static void ObjectQuerySingleInternal(ConvexShape castShape, Matrix convexFromTrans,
			Matrix convexToTrans, CollisionObjectWrapper colObjWrap, ConvexResultCallback resultCallback,
			float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingleInternal(castShape.Native, ref convexFromTrans,
				ref convexToTrans, colObjWrap.Native, resultCallback.Native, allowedPenetration);
		}

		public void PerformDiscreteCollisionDetection()
		{
			btCollisionWorld_performDiscreteCollisionDetection(Native);
		}

		public void RayTestRef(ref Vector3 rayFromWorld, ref Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTest(Native, ref rayFromWorld, ref rayToWorld, resultCallback.Native);
		}

		public void RayTest(Vector3 rayFromWorld, Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTest(Native, ref rayFromWorld, ref rayToWorld, resultCallback.Native);
		}

		public static void RayTestSingleRef(ref Matrix rayFromTrans, ref Matrix rayToTrans,
			CollisionObject collisionObject, CollisionShape collisionShape, ref Matrix colObjWorldTransform,
			RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingle(ref rayFromTrans, ref rayToTrans, collisionObject.Native, collisionShape.Native, ref colObjWorldTransform, resultCallback.Native);
		}

		public static void RayTestSingle(Matrix rayFromTrans, Matrix rayToTrans,
			CollisionObject collisionObject, CollisionShape collisionShape, Matrix colObjWorldTransform,
			RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingle(ref rayFromTrans, ref rayToTrans, collisionObject.Native,
				collisionShape.Native, ref colObjWorldTransform, resultCallback.Native);
		}

		public static void RayTestSingleInternalRef(ref Matrix rayFromTrans, ref Matrix rayToTrans,
			CollisionObjectWrapper collisionObjectWrap, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingleInternal(ref rayFromTrans, ref rayToTrans,
				collisionObjectWrap.Native, resultCallback.Native);
		}

		public static void RayTestSingleInternal(Matrix rayFromTrans, Matrix rayToTrans,
			CollisionObjectWrapper collisionObjectWrap, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingleInternal(ref rayFromTrans, ref rayToTrans,
				collisionObjectWrap.Native, resultCallback.Native);
		}

		public void RemoveCollisionObject(CollisionObject collisionObject)
		{
			CollisionObjectArray.Remove(collisionObject);
		}

		protected void SerializeCollisionObjects(Serializer serializer)
		{
			// keep track of shapes already serialized
			var serializedShapes = new Dictionary<CollisionShape, int>();

			foreach (var colObj in CollisionObjectArray)
			{
				var shape = colObj.CollisionShape;
				if (!serializedShapes.ContainsKey(shape))
				{
					serializedShapes.Add(shape, 0);
					shape.SerializeSingleShape(serializer);
				}
			}

			// serialize all collision objects
			foreach (var colObj in CollisionObjectArray)
			{
				if (colObj.InternalType == CollisionObjectTypes.CollisionObject)
				{
					colObj.SerializeSingleObject(serializer);
				}
			}
		}

		public virtual void Serialize(Serializer serializer)
		{
			serializer.StartSerialization();
			SerializeCollisionObjects(serializer);
			serializer.FinishSerialization();
		}

		public void UpdateAabbs()
		{
			btCollisionWorld_updateAabbs(Native);
		}

		public void UpdateSingleAabb(CollisionObject colObj)
		{
			btCollisionWorld_updateSingleAabb(Native, colObj.Native);
		}

		public BroadphaseInterface Broadphase
		{
			get => _broadphase;
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(nameof(value));
				}

				btCollisionWorld_setBroadphase(Native, value.Native);
				_broadphase = value;
			}
		}

		public AlignedCollisionObjectArray CollisionObjectArray { get; protected set; }

		public DebugDraw DebugDrawer
		{
			get => _debugDrawer;
			set
			{
				if (_debugDrawer != value)
				{
					_debugDrawer = value;
					btCollisionWorld_setDebugDrawer(Native, value != null ? value.Native : IntPtr.Zero);
				}
			}
		}

		public Dispatcher Dispatcher { get; private set; }

		public DispatcherInfo DispatchInfo
		{
			get
			{
				if (_dispatchInfo == null)
				{
					_dispatchInfo = new DispatcherInfo(btCollisionWorld_getDispatchInfo(Native));
				}
				return _dispatchInfo;
			}
		}

		public bool ForceUpdateAllAabbs
		{
			get => btCollisionWorld_getForceUpdateAllAabbs(Native);
			set => btCollisionWorld_setForceUpdateAllAabbs(Native, value);
		}

		public int NumCollisionObjects => btCollisionWorld_getNumCollisionObjects(Native);

		public OverlappingPairCache PairCache => Broadphase.OverlappingPairCache;

		protected override void Dispose(bool disposing)
		{
			// The btCollisionWorld will try to clean up remaining objects from the
			// broadphase and the dispatcher. If either of them have been deleted and
			// there are objects in the world, then deleting the btCollisionWorld or 
			// removing the objects from the world will cause an AccessViolationException.
			if (CollisionObjectArray.Count != 0 && (_broadphase.IsDisposed || Dispatcher.IsDisposed))
			{
				if (disposing)
				{
					throw new Exception(
						"To ensure proper resource cleanup, " +
						"remove all objects from the world before disposing the world.");
				}
				else
				{
					// Do not throw an exception in the GC finalizer thread
				}
			}
			else
			{
				btCollisionWorld_delete(Native);
			}
		}
	}
}
