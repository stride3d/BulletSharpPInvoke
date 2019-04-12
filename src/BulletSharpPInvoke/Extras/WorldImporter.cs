using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class WorldImporter
	{
		internal IntPtr _native;

		internal WorldImporter(IntPtr native)
		{
			_native = native;
		}

		public WorldImporter(DynamicsWorld world)
		{
			_native = btWorldImporter_new(world._native);
		}

		public CollisionShape CreateBoxShape(Vector3 halfExtents)
		{
			return new BoxShape(btWorldImporter_createBoxShape(_native, ref halfExtents));
		}
        /*
		public BvhTriangleMeshShape CreateBvhTriangleMeshShape(StridingMeshInterface trimesh, OptimizedBvh bvh)
		{
			return btWorldImporter_createBvhTriangleMeshShape(_native, trimesh._native, bvh._native);
		}
        */
		public CollisionShape CreateCapsuleShapeZ(float radius, float height)
		{
            return new CapsuleShapeZ(btWorldImporter_createCapsuleShapeZ(_native, radius, height));
		}

		public CollisionShape CreateCapsuleShapeX(float radius, float height)
		{
            return new CapsuleShapeX(btWorldImporter_createCapsuleShapeX(_native, radius, height));
		}

		public CollisionShape CreateCapsuleShapeY(float radius, float height)
		{
            return new CapsuleShape(btWorldImporter_createCapsuleShapeY(_native, radius, height));
		}

		public CollisionObject CreateCollisionObject(Matrix startTransform, CollisionShape shape, string bodyName)
		{
			return CollisionObject.GetManaged(btWorldImporter_createCollisionObject(_native, ref startTransform, shape._native, bodyName));
		}

		public CompoundShape CreateCompoundShape()
		{
            return new CompoundShape(btWorldImporter_createCompoundShape(_native));
		}

		public CollisionShape CreateConeShapeZ(float radius, float height)
		{
			return new ConeShapeZ(radius, height);
		}

		public CollisionShape CreateConeShapeX(float radius, float height)
		{
			return new ConeShapeX(radius, height);
		}

		public CollisionShape CreateConeShapeY(float radius, float height)
		{
			return new ConeShape(radius, height);
		}

		public ConeTwistConstraint CreateConeTwistConstraint(RigidBody rbA, Matrix rbAFrame)
		{
            return new ConeTwistConstraint(btWorldImporter_createConeTwistConstraint(_native, rbA._native, ref rbAFrame));
		}

		public ConeTwistConstraint CreateConeTwistConstraint(RigidBody rbA, RigidBody rbB, Matrix rbAFrame, Matrix rbBFrame)
		{
            return new ConeTwistConstraint(btWorldImporter_createConeTwistConstraint2(_native, rbA._native, rbB._native, ref rbAFrame, ref rbBFrame));
		}

		public ConvexHullShape CreateConvexHullShape()
		{
            return new ConvexHullShape(btWorldImporter_createConvexHullShape(_native));
		}
        /*
		public CollisionShape CreateConvexTriangleMeshShape(StridingMeshInterface trimesh)
		{
			return btWorldImporter_createConvexTriangleMeshShape(_native, trimesh._native);
		}
        */
		public CollisionShape CreateCylinderShapeZ(float radius, float height)
		{
            return new CylinderShapeZ(btWorldImporter_createCylinderShapeZ(_native, radius, height));
		}

		public CollisionShape CreateCylinderShapeX(float radius, float height)
		{
            return new CylinderShapeX(btWorldImporter_createCylinderShapeX(_native, radius, height));
		}

		public CollisionShape CreateCylinderShapeY(float radius, float height)
		{
            return new CylinderShape(btWorldImporter_createCylinderShapeY(_native, radius, height));
		}

		public GearConstraint CreateGearConstraint(RigidBody rbA, RigidBody rbB, Vector3 axisInA, Vector3 axisInB, float ratio)
		{
			return new GearConstraint(rbA, rbB, ref axisInA, ref axisInB, ratio);
		}

		public Generic6DofConstraint CreateGeneric6DofConstraint(RigidBody rbB, Matrix frameInB, bool useLinearReferenceFrameB)
		{
			return new Generic6DofConstraint(rbB, frameInB, useLinearReferenceFrameB);
		}

		public Generic6DofConstraint CreateGeneric6DofConstraint(RigidBody rbA, RigidBody rbB, Matrix frameInA, Matrix frameInB, bool useLinearReferenceFrameA)
		{
			return new Generic6DofConstraint(rbA, rbB, frameInA, frameInB, useLinearReferenceFrameA);
		}

		public Generic6DofSpringConstraint CreateGeneric6DofSpringConstraint(RigidBody rbA, RigidBody rbB, Matrix frameInA, Matrix frameInB, bool useLinearReferenceFrameA)
		{
			return new Generic6DofSpringConstraint(rbA, rbB, frameInA, frameInB, useLinearReferenceFrameA);
		}

		public GImpactMeshShape CreateGimpactShape(StridingMeshInterface trimesh)
		{
            return new GImpactMeshShape(trimesh._native);
		}

		public HingeConstraint CreateHingeConstraint(RigidBody rbA, RigidBody rbB, Matrix rbAFrame, Matrix rbBFrame, bool useReferenceFrameA)
		{
            return new HingeConstraint(btWorldImporter_createHingeConstraint(_native, rbA._native, rbB._native, ref rbAFrame, ref rbBFrame, useReferenceFrameA));
		}

        public HingeConstraint CreateHingeConstraint(RigidBody rbA, RigidBody rbB, Matrix rbAFrame, Matrix rbBFrame)
		{
			return new HingeConstraint(btWorldImporter_createHingeConstraint2(_native, rbA._native, rbB._native, ref rbAFrame, ref rbBFrame));
		}

        public HingeConstraint CreateHingeConstraint(RigidBody rbA, Matrix rbAFrame, bool useReferenceFrameA)
		{
			return new HingeConstraint(btWorldImporter_createHingeConstraint3(_native, rbA._native, ref rbAFrame, useReferenceFrameA));
		}

        public HingeConstraint CreateHingeConstraint(RigidBody rbA, Matrix rbAFrame)
		{
			return new HingeConstraint(btWorldImporter_createHingeConstraint4(_native, rbA._native, ref rbAFrame));
		}
        /*
		public TriangleIndexVertexArray CreateMeshInterface(StridingMeshInterfaceData meshData)
		{
			return btWorldImporter_createMeshInterface(_native, meshData._native);
		}

		public MultiSphereShape CreateMultiSphereShape(Vector3 positions, float radi, int numSpheres)
		{
			return new MultiSphereShape(_native, ref positions, radi._native, numSpheres);
		}

		public OptimizedBvh CreateOptimizedBvh()
		{
			return new OptimizedBvh(_native);
		}
        */
		public CollisionShape CreatePlaneShape(Vector3 planeNormal, float planeConstant)
		{
            return new StaticPlaneShape(btWorldImporter_createPlaneShape(_native, ref planeNormal, planeConstant));
		}

		public Point2PointConstraint CreatePoint2PointConstraint(RigidBody rbA, RigidBody rbB, Vector3 pivotInA, Vector3 pivotInB)
		{
            return new Point2PointConstraint(btWorldImporter_createPoint2PointConstraint(_native, rbA._native, rbB._native, ref pivotInA, ref pivotInB));
		}

		public Point2PointConstraint CreatePoint2PointConstraint(RigidBody rbA, Vector3 pivotInA)
		{
			return new Point2PointConstraint(btWorldImporter_createPoint2PointConstraint2(_native, rbA._native, ref pivotInA));
		}

		public RigidBody CreateRigidBody(bool isDynamic, float mass, Matrix startTransform, CollisionShape shape, string bodyName)
		{
            return new RigidBody(btWorldImporter_createRigidBody(_native, isDynamic, mass, ref startTransform, shape._native, bodyName));
		}

		public ScaledBvhTriangleMeshShape CreateScaledTrangleMeshShape(BvhTriangleMeshShape meshShape, Vector3 localScalingbtBvhTriangleMeshShape)
		{
			return new ScaledBvhTriangleMeshShape(meshShape, localScalingbtBvhTriangleMeshShape);
		}

		public SliderConstraint CreateSliderConstraint(RigidBody rbB, Matrix frameInB, bool useLinearReferenceFrameA)
		{
			return new SliderConstraint(rbB, frameInB, useLinearReferenceFrameA);
		}

		public SliderConstraint CreateSliderConstraint(RigidBody rbA, RigidBody rbB, Matrix frameInA, Matrix frameInB, bool useLinearReferenceFrameA)
		{
			return new SliderConstraint(rbA, rbB, frameInA, frameInB, useLinearReferenceFrameA);
		}

		public CollisionShape CreateSphereShape(float radius)
		{
			return new SphereShape(radius);
		}
        /*
		public StridingMeshInterfaceData CreateStridingMeshInterfaceData(StridingMeshInterfaceData interfaceData)
		{
			return btWorldImporter_createStridingMeshInterfaceData(_native, interfaceData._native);
		}

		public TriangleInfoMap CreateTriangleInfoMap()
		{
			return btWorldImporter_createTriangleInfoMap(_native);
		}
        */
		public TriangleIndexVertexArray CreateTriangleMeshContainer()
		{
            return new TriangleIndexVertexArray(btWorldImporter_createTriangleMeshContainer(_native));
		}

		public void DeleteAllData()
		{
			btWorldImporter_deleteAllData(_native);
		}
        /*
		public OptimizedBvh GetBvhByIndex(int index)
		{
			return btWorldImporter_getBvhByIndex(_native, index);
		}
        */
		public CollisionShape GetCollisionShapeByIndex(int index)
		{
            return CollisionShape.GetManaged(btWorldImporter_getCollisionShapeByIndex(_native, index));
		}

		public CollisionShape GetCollisionShapeByName(string name)
		{
            return CollisionShape.GetManaged(btWorldImporter_getCollisionShapeByName(_native, name));
		}

		public TypedConstraint GetConstraintByIndex(int index)
		{
            return TypedConstraint.GetManaged(btWorldImporter_getConstraintByIndex(_native, index));
		}

		public TypedConstraint GetConstraintByName(string name)
		{
            return TypedConstraint.GetManaged(btWorldImporter_getConstraintByName(_native, name));
		}

		public string GetNameForPointer(IntPtr ptr)
		{
			return btWorldImporter_getNameForPointer(_native, ptr);
		}

		public CollisionObject GetRigidBodyByIndex(int index)
		{
            return CollisionObject.GetManaged(btWorldImporter_getRigidBodyByIndex(_native, index));
		}

		public RigidBody GetRigidBodyByName(string name)
		{
            return CollisionObject.GetManaged(btWorldImporter_getRigidBodyByName(_native, name)) as RigidBody;
		}
        /*
		public TriangleInfoMap GetTriangleInfoMapByIndex(int index)
		{
			return btWorldImporter_getTriangleInfoMapByIndex(_native, index);
		}
        */
		public void SetDynamicsWorldInfo(Vector3 gravity, ContactSolverInfo solverInfo)
		{
			btWorldImporter_setDynamicsWorldInfo(_native, ref gravity, solverInfo._native);
		}

		public int NumBvhs
		{
			get { return btWorldImporter_getNumBvhs(_native); }
		}

		public int NumCollisionShapes
		{
			get { return btWorldImporter_getNumCollisionShapes(_native); }
		}

		public int NumConstraints
		{
			get { return btWorldImporter_getNumConstraints(_native); }
		}

		public int NumRigidBodies
		{
			get { return btWorldImporter_getNumRigidBodies(_native); }
		}

		public int NumTriangleInfoMaps
		{
			get { return btWorldImporter_getNumTriangleInfoMaps(_native); }
		}

		public int VerboseMode
		{
			get { return btWorldImporter_getVerboseMode(_native); }
			set { btWorldImporter_setVerboseMode(_native, value); }
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
				btWorldImporter_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~WorldImporter()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_new(IntPtr world);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createBoxShape(IntPtr obj, [In] ref Vector3 halfExtents);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createBvhTriangleMeshShape(IntPtr obj, IntPtr trimesh, IntPtr bvh);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCapsuleShapeZ(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCapsuleShapeX(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCapsuleShapeY(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCollisionObject(IntPtr obj, [In] ref Matrix startTransform, IntPtr shape, string bodyName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCompoundShape(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConeShapeZ(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConeShapeX(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConeShapeY(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConeTwistConstraint(IntPtr obj, IntPtr rbA, [In] ref Matrix rbAFrame);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConeTwistConstraint2(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Matrix rbAFrame, [In] ref Matrix rbBFrame);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConvexHullShape(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createConvexTriangleMeshShape(IntPtr obj, IntPtr trimesh);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCylinderShapeZ(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCylinderShapeX(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createCylinderShapeY(IntPtr obj, float radius, float height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createGearConstraint(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Vector3 axisInA, [In] ref Vector3 axisInB, float ratio);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createGeneric6DofConstraint(IntPtr obj, IntPtr rbB, [In] ref Matrix frameInB, bool useLinearReferenceFrameB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createGeneric6DofConstraint2(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Matrix frameInA, [In] ref Matrix frameInB, bool useLinearReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createGeneric6DofSpringConstraint(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Matrix frameInA, [In] ref Matrix frameInB, bool useLinearReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createGimpactShape(IntPtr obj, IntPtr trimesh);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createHingeConstraint(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Matrix rbAFrame, [In] ref Matrix rbBFrame, bool useReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createHingeConstraint2(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Matrix rbAFrame, [In] ref Matrix rbBFrame);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createHingeConstraint3(IntPtr obj, IntPtr rbA, [In] ref Matrix rbAFrame, bool useReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createHingeConstraint4(IntPtr obj, IntPtr rbA, [In] ref Matrix rbAFrame);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createMeshInterface(IntPtr obj, IntPtr meshData);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createMultiSphereShape(IntPtr obj, IntPtr positions, IntPtr radi, int numSpheres);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createOptimizedBvh(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createPlaneShape(IntPtr obj, [In] ref Vector3 planeNormal, float planeConstant);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createPoint2PointConstraint(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Vector3 pivotInA, [In] ref Vector3 pivotInB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createPoint2PointConstraint2(IntPtr obj, IntPtr rbA, [In] ref Vector3 pivotInA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createRigidBody(IntPtr obj, bool isDynamic, float mass, [In] ref Matrix startTransform, IntPtr shape, string bodyName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createScaledTrangleMeshShape(IntPtr obj, IntPtr meshShape, IntPtr localScalingbtBvhTriangleMeshShape);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createSliderConstraint(IntPtr obj, IntPtr rbB, IntPtr frameInB, bool useLinearReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_createSliderConstraint2(IntPtr obj, IntPtr rbA, IntPtr rbB, [In] ref Matrix frameInA, [In] ref Matrix frameInB, bool useLinearReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createSphereShape(IntPtr obj, float radius);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createStridingMeshInterfaceData(IntPtr obj, IntPtr interfaceData);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createTriangleInfoMap(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_createTriangleMeshContainer(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWorldImporter_deleteAllData(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_getBvhByIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_getCollisionShapeByIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_getCollisionShapeByName(IntPtr obj, string name);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_getConstraintByIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_getConstraintByName(IntPtr obj, string name);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern string btWorldImporter_getNameForPointer(IntPtr obj, IntPtr ptr);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btWorldImporter_getNumBvhs(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btWorldImporter_getNumCollisionShapes(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btWorldImporter_getNumConstraints(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btWorldImporter_getNumRigidBodies(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btWorldImporter_getNumTriangleInfoMaps(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_getRigidBodyByIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWorldImporter_getRigidBodyByName(IntPtr obj, string name);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWorldImporter_getTriangleInfoMapByIndex(IntPtr obj, int index);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btWorldImporter_getVerboseMode(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWorldImporter_setDynamicsWorldInfo(IntPtr obj, [In] ref Vector3 gravity, IntPtr solverInfo);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWorldImporter_setVerboseMode(IntPtr obj, int verboseMode);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWorldImporter_delete(IntPtr obj);
	}
}
