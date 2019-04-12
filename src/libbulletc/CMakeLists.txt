CMAKE_MINIMUM_REQUIRED (VERSION 2.6)
PROJECT (libbulletc)

IF (APPLE OR MSVC)
	OPTION(BUILD_MULTITHREADING "Use BulletMultiThreading" ON)
ELSE()
	OPTION(BUILD_MULTITHREADING "Use BulletMultiThreading" OFF)
ENDIF()

IF (NOT CMAKE_BUILD_TYPE)
# SET(CMAKE_BUILD_TYPE "Debug")
 SET(CMAKE_BUILD_TYPE "MinSizeRel")
ENDIF (NOT CMAKE_BUILD_TYPE) 

FIND_PATH(BULLET_INCLUDE_DIR NAMES btBulletCollisionCommon.h
  PATHS
  ${PROJECT_SOURCE_DIR}/../../bullet/src/
  ${PROJECT_SOURCE_DIR}/../bullet/src/
  ${PROJECT_SOURCE_DIR}/../../bullet-2.82-r2704/src/
  ${PROJECT_SOURCE_DIR}/../bullet-2.82-r2704/src/
  ENV CPATH
  /usr/include
  /usr/local/include
  /opt/local/include
  NO_DEFAULT_PATH
)
INCLUDE_DIRECTORIES(${BULLET_INCLUDE_DIR})
INCLUDE_DIRECTORIES(${BULLET_INCLUDE_DIR}/../Extras/Serialize/BulletWorldImporter/)

FIND_PATH(BULLET_LIBS_DIR NAMES BulletCollision_Debug.lib
  PATHS
  ${PROJECT_SOURCE_DIR}/../../bullet/lib/
  ${PROJECT_SOURCE_DIR}/../bullet/lib/
  NO_DEFAULT_PATH
)

IF(${CMAKE_GENERATOR} MATCHES "Unix Makefiles")
	SET(BULLET_LIB_DIR ${BULLET_INCLUDE_DIR}/..)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/src/BulletCollision)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/src/BulletDynamics)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/src/BulletMultiThreaded)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/src/BulletSoftBody)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/src/LinearMath)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/Extras/Serialize/BulletFileLoader)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/Extras/Serialize/BulletWorldImporter)
	LINK_DIRECTORIES(${BULLET_LIB_DIR}/build/Extras/Serialize/BulletXmlWorldImporter)
	SET(BULLETC_LIB bulletc)
ELSE()
	LINK_DIRECTORIES(${BULLET_LIBS_DIR}/${CMAKE_CFG_INTDIR})
	SET(BULLETC_LIB libbulletc)
	SET(LIB_SUFFIX .lib)
ENDIF()

IF(BUILD_MULTITHREADING)
SET(MULTITHREADED_SOURCE
    src/btParallelConstraintSolver_wrap.cpp
    src/btParallelConstraintSolver_wrap.h
    src/btThreadSupportInterface_wrap.cpp
    src/btThreadSupportInterface_wrap.h
    src/SpuCollisionTaskProcess_wrap.cpp
    src/SpuCollisionTaskProcess_wrap.h
    src/SpuGatheringCollisionDispatcher_wrap.cpp
    src/SpuGatheringCollisionDispatcher_wrap.h
    src/SpuGatheringCollisionTask_wrap.cpp
    src/SpuGatheringCollisionTask_wrap.h
    src/Win32ThreadSupport_wrap.cpp
    src/Win32ThreadSupport_wrap.h
)
ENDIF(BUILD_MULTITHREADING)

ADD_LIBRARY(${BULLETC_LIB} SHARED
    dllmain.cpp
    src/conversion.h
    src/main.h
    src/collections.cpp
    src/collections.h
    src/btActionInterface_wrap.cpp
    src/btActionInterface_wrap.h
    src/btAlignedBroadphasePairArray_wrap.cpp
    src/btAlignedBroadphasePairArray_wrap.h
    src/btAlignedCollisionObjectArray_wrap.cpp
    src/btAlignedCollisionObjectArray_wrap.h
    src/btAlignedCollisionShapeArray_wrap.cpp
    src/btAlignedCollisionShapeArray_wrap.h
    src/btAlignedManifoldArray_wrap.cpp
    src/btAlignedManifoldArray_wrap.h
    src/btAxisSweep3_wrap.cpp
    src/btAxisSweep3_wrap.h
    src/btBox2dBox2dCollisionAlgorithm_wrap.cpp
    src/btBox2dBox2dCollisionAlgorithm_wrap.h
    src/btBoxBoxCollisionAlgorithm_wrap.cpp
    src/btBoxBoxCollisionAlgorithm_wrap.h
    src/btBoxCollision_wrap.cpp
    src/btBoxCollision_wrap.h
    src/btBoxShape_wrap.cpp
    src/btBoxShape_wrap.h
    src/btBroadphaseInterface_wrap.cpp
    src/btBroadphaseInterface_wrap.h
    src/btBroadphaseProxy_wrap.cpp
    src/btBroadphaseProxy_wrap.h
    src/btBulletFile_wrap.cpp
    src/btBulletFile_wrap.h
    src/btBulletWorldImporter_wrap.cpp
    src/btBulletWorldImporter_wrap.h
    src/btBulletXmlWorldImporter_wrap.cpp
    src/btBulletXmlWorldImporter_wrap.h
    src/btBvhTriangleMeshShape_wrap.cpp
    src/btBvhTriangleMeshShape_wrap.h
    src/btCapsuleShape_wrap.cpp
    src/btCapsuleShape_wrap.h
    src/btCharacterControllerInterface_wrap.cpp
    src/btCharacterControllerInterface_wrap.h
    src/btCollisionAlgorithm_wrap.cpp
    src/btCollisionAlgorithm_wrap.h
    src/btCollisionConfiguration_wrap.cpp
    src/btCollisionConfiguration_wrap.h
    src/btCollisionCreateFunc_wrap.cpp
    src/btCollisionCreateFunc_wrap.h
    src/btCollisionDispatcher_wrap.cpp
    src/btCollisionDispatcher_wrap.h
    src/btCollisionObject_wrap.cpp
    src/btCollisionObject_wrap.h
    src/btCollisionObjectWrapper_wrap.cpp
    src/btCollisionObjectWrapper_wrap.h
    src/btCollisionShape_wrap.cpp
    src/btCollisionShape_wrap.h
    src/btCollisionWorld_wrap.cpp
    src/btCollisionWorld_wrap.h
    src/btCompoundCollisionAlgorithm_wrap.cpp
    src/btCompoundCollisionAlgorithm_wrap.h
    src/btCompoundCompoundCollisionAlgorithm_wrap.cpp
    src/btCompoundCompoundCollisionAlgorithm_wrap.h
    src/btCompoundShape_wrap.cpp
    src/btCompoundShape_wrap.h
    src/btConeShape_wrap.cpp
    src/btConeShape_wrap.h
    src/btConeTwistConstraint_wrap.cpp
    src/btConeTwistConstraint_wrap.h
    src/btConstraintSolver_wrap.cpp
    src/btConstraintSolver_wrap.h
    src/btContactSolverInfo_wrap.cpp
    src/btContactSolverInfo_wrap.h
    src/btConvex2dConvex2dAlgorithm_wrap.cpp
    src/btConvex2dConvex2dAlgorithm_wrap.h
    src/btConvex2dShape_wrap.cpp
    src/btConvex2dShape_wrap.h
    src/btConvexConcaveCollisionAlgorithm_wrap.cpp
    src/btConvexConcaveCollisionAlgorithm_wrap.h
    src/btConvexConvexAlgorithm_wrap.cpp
    src/btConvexConvexAlgorithm_wrap.h
    src/btConvexHullShape_wrap.cpp
    src/btConvexHullShape_wrap.h
    src/btConvexInternalShape_wrap.cpp
    src/btConvexInternalShape_wrap.h
    src/btConvexPenetrationDepthSolver_wrap.cpp
    src/btConvexPenetrationDepthSolver_wrap.h
    src/btConvexPlaneCollisionAlgorithm_wrap.cpp
    src/btConvexPlaneCollisionAlgorithm_wrap.h
    src/btConvexPolyhedron_wrap.cpp
    src/btConvexPolyhedron_wrap.h
    src/btConvexShape_wrap.cpp
    src/btConvexShape_wrap.h
    src/btConvexTriangleMeshShape_wrap.cpp
    src/btConvexTriangleMeshShape_wrap.h
    src/btCylinderShape_wrap.cpp
    src/btCylinderShape_wrap.h
    src/btDbvtBroadphase_wrap.cpp
    src/btDbvtBroadphase_wrap.h
    src/btDefaultCollisionConfiguration_wrap.cpp
    src/btDefaultCollisionConfiguration_wrap.h
    src/btDefaultMotionState_wrap.cpp
    src/btDefaultMotionState_wrap.h
    src/btDiscreteCollisionDetectorInterface_wrap.cpp
    src/btDiscreteCollisionDetectorInterface_wrap.h
    src/btDiscreteDynamicsWorld_wrap.cpp
    src/btDiscreteDynamicsWorld_wrap.h
    src/btDispatcher_wrap.cpp
    src/btDispatcher_wrap.h
    src/btEmptyCollisionAlgorithm_wrap.cpp
    src/btEmptyCollisionAlgorithm_wrap.h
    src/btDynamicsWorld_wrap.cpp
    src/btDynamicsWorld_wrap.h
    src/btFixedConstraint_wrap.cpp
    src/btFixedConstraint_wrap.h
    src/btGearConstraint_wrap.cpp
    src/btGearConstraint_wrap.h
    src/btGeneric6DofConstraint_wrap.cpp
    src/btGeneric6DofConstraint_wrap.h
    src/btGeneric6DofSpringConstraint_wrap.cpp
    src/btGeneric6DofSpringConstraint_wrap.h
    src/btGeometryUtil_wrap.cpp
    src/btGeometryUtil_wrap.h
    src/btGhostObject_wrap.cpp
    src/btGhostObject_wrap.h
    src/btGImpactCollisionAlgorithm_wrap.cpp
    src/btGImpactCollisionAlgorithm_wrap.h
    src/btGImpactShape_wrap.cpp
    src/btGImpactShape_wrap.h
    src/btGjkPairDetector_wrap.cpp
    src/btGjkPairDetector_wrap.h
    src/btHinge2Constraint_wrap.cpp
    src/btHinge2Constraint_wrap.h
    src/btHingeConstraint_wrap.cpp
    src/btHingeConstraint_wrap.h
    src/btIDebugDraw_wrap.cpp
    src/btIDebugDraw_wrap.h
    src/btKinematicCharacterController_wrap.cpp
    src/btKinematicCharacterController_wrap.h
    src/btManifoldPoint_wrap.cpp
    src/btManifoldPoint_wrap.h
    src/btMinkowskiPenetrationDepthSolver_wrap.cpp
    src/btMinkowskiPenetrationDepthSolver_wrap.h
    src/btMultiSphereShape_wrap.cpp
    src/btMultiSphereShape_wrap.h
    src/btOverlappingPairCache_wrap.cpp
    src/btOverlappingPairCache_wrap.h
    src/btOverlappingPairCallback_wrap.cpp
    src/btOverlappingPairCallback_wrap.h
    src/btPersistentManifold_wrap.cpp
    src/btPersistentManifold_wrap.h
    src/btPoint2PointConstraint_wrap.cpp
    src/btPoint2PointConstraint_wrap.h
    src/btPointCollector_wrap.cpp
    src/btPointCollector_wrap.h
    src/btPolarDecomposition_wrap.cpp
    src/btPolarDecomposition_wrap.h
    src/btPolyhedralConvexShape_wrap.cpp
    src/btPolyhedralConvexShape_wrap.h
    src/btRaycastVehicle_wrap.cpp
    src/btRaycastVehicle_wrap.h
    src/btRigidBody_wrap.cpp
    src/btRigidBody_wrap.h
    src/btScaledBvhTriangleMeshShape_wrap.cpp
    src/btScaledBvhTriangleMeshShape_wrap.h
    src/btSequentialImpulseConstraintSolver_wrap.cpp
    src/btSequentialImpulseConstraintSolver_wrap.h
    src/btSerializer_wrap.cpp
    src/btSerializer_wrap.h
    src/btShapeHull_wrap.cpp
    src/btShapeHull_wrap.h
    src/btSimulationIslandManager_wrap.cpp
    src/btSimulationIslandManager_wrap.h
    src/btSliderConstraint_wrap.cpp
    src/btSliderConstraint_wrap.h
    src/btSoftBodyConcaveCollisionAlgorithm_wrap.cpp
    src/btSoftBodyConcaveCollisionAlgorithm_wrap.h
    src/btSoftBody_wrap.cpp
    src/btSoftBody_wrap.h
    src/btSoftBodyHelpers_wrap.cpp
    src/btSoftBodyHelpers_wrap.h
    src/btSoftBodyRigidBodyCollisionConfiguration_wrap.cpp
    src/btSoftBodyRigidBodyCollisionConfiguration_wrap.h
    src/btSoftRigidCollisionAlgorithm_wrap.cpp
    src/btSoftRigidCollisionAlgorithm_wrap.h
    src/btSoftRigidDynamicsWorld_wrap.cpp
    src/btSoftRigidDynamicsWorld_wrap.h
    src/btSoftSoftCollisionAlgorithm_wrap.cpp
    src/btSoftSoftCollisionAlgorithm_wrap.h
    src/btSphereBoxCollisionAlgorithm_wrap.cpp
    src/btSphereBoxCollisionAlgorithm_wrap.h
    src/btSphereShape_wrap.cpp
    src/btSphereShape_wrap.h
    src/btSphereSphereCollisionAlgorithm_wrap.cpp
    src/btSphereSphereCollisionAlgorithm_wrap.h
    src/btSphereTriangleCollisionAlgorithm_wrap.cpp
    src/btSphereTriangleCollisionAlgorithm_wrap.h
    src/btStaticPlaneShape_wrap.cpp
    src/btStaticPlaneShape_wrap.h
    src/btStridingMeshInterface_wrap.cpp
    src/btStridingMeshInterface_wrap.h
    src/btTransformUtil_wrap.cpp
    src/btTransformUtil_wrap.h
    src/btTriangleIndexVertexArray_wrap.cpp
    src/btTriangleIndexVertexArray_wrap.h
    src/btTriangleMesh_wrap.cpp
    src/btTriangleMesh_wrap.h
    src/btTriangleMeshShape_wrap.cpp
    src/btTriangleMeshShape_wrap.h
    src/btTypedConstraint_wrap.cpp
    src/btTypedConstraint_wrap.h
    src/btUniformScalingShape_wrap.cpp
    src/btUniformScalingShape_wrap.h
    src/btUniversalConstraint_wrap.cpp
    src/btUniversalConstraint_wrap.h
    src/btVehicleRaycaster_wrap.cpp
    src/btVehicleRaycaster_wrap.h
    src/btVoronoiSimplexSolver_wrap.cpp
    src/btVoronoiSimplexSolver_wrap.h
    src/btWheelInfo_wrap.cpp
    src/btWheelInfo_wrap.h
    src/btWorldImporter_wrap.cpp
    src/btWorldImporter_wrap.h
    src/SharpMotionState.h
    src/SharpMotionState.cpp
	src/btHeightfieldTerrainShape_wrap.h
	src/btHeightfieldTerrainShape_wrap.cpp
    ${MULTITHREADED_SOURCE}
)

TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletCollision${LIB_SUFFIX})
TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletDynamics${LIB_SUFFIX})
TARGET_LINK_LIBRARIES(${BULLETC_LIB} LinearMath${LIB_SUFFIX})
TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletFileLoader${LIB_SUFFIX})
TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletSoftBody${LIB_SUFFIX})
TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletWorldImporter${LIB_SUFFIX})
TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletXmlWorldImporter${LIB_SUFFIX})
IF(BUILD_MULTITHREADING)
    TARGET_LINK_LIBRARIES(${BULLETC_LIB} BulletMultiThreaded${LIB_SUFFIX})
ENDIF(BUILD_MULTITHREADING)
