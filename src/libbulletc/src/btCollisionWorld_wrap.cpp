#include "conversion.h"
#include "btCollisionWorld_wrap.h"

btCollisionWorld_ContactResultCallbackWrapper::btCollisionWorld_ContactResultCallbackWrapper(pAddSingleResult addSingleResultCallback, pNeedsCollision needsCollisionCallback)
{
	_addSingleResultCallback = addSingleResultCallback;
	_needsCollisionCallback = needsCollisionCallback;
}

bool btCollisionWorld_ContactResultCallbackWrapper::needsCollision(btBroadphaseProxy* proxy0) const
{
	return _needsCollisionCallback(proxy0);
}

btScalar btCollisionWorld_ContactResultCallbackWrapper::addSingleResult(btManifoldPoint& cp,
	const btCollisionObjectWrapper* colObj0Wrap, int partId0, int index0,
	const btCollisionObjectWrapper* colObj1Wrap, int partId1, int index1)
{
	return _addSingleResultCallback(cp, colObj0Wrap, partId0, index0, colObj1Wrap, partId1, index1);
}

bool btCollisionWorld_ContactResultCallbackWrapper::baseNeedsCollision(btBroadphaseProxy* proxy0) const
{
	return btCollisionWorld_ContactResultCallback::needsCollision(proxy0);
}


btCollisionWorld::LocalShapeInfo* btCollisionWorld_LocalShapeInfo_new()
{
	return new btCollisionWorld::LocalShapeInfo();
}

int btCollisionWorld_LocalShapeInfo_getShapePart(btCollisionWorld::LocalShapeInfo* obj)
{
	return obj->m_shapePart;
}

int btCollisionWorld_LocalShapeInfo_getTriangleIndex(btCollisionWorld::LocalShapeInfo* obj)
{
	return obj->m_triangleIndex;
}

void btCollisionWorld_LocalShapeInfo_setShapePart(btCollisionWorld::LocalShapeInfo* obj, int value)
{
	obj->m_shapePart = value;
}

void btCollisionWorld_LocalShapeInfo_setTriangleIndex(btCollisionWorld::LocalShapeInfo* obj, int value)
{
	obj->m_triangleIndex = value;
}

void btCollisionWorld_LocalShapeInfo_delete(btCollisionWorld::LocalShapeInfo* obj)
{
	delete obj;
}

btCollisionWorld::LocalRayResult* btCollisionWorld_LocalRayResult_new(btCollisionObject* collisionObject, btCollisionWorld::LocalShapeInfo* localShapeInfo, btScalar* hitNormalLocal, btScalar hitFraction)
{
	VECTOR3_CONV(hitNormalLocal);
	return new btCollisionWorld::LocalRayResult(collisionObject, localShapeInfo, VECTOR3_USE(hitNormalLocal), hitFraction);
}

const btCollisionObject* btCollisionWorld_LocalRayResult_getCollisionObject(btCollisionWorld::LocalRayResult* obj)
{
	return obj->m_collisionObject;
}

btScalar btCollisionWorld_LocalRayResult_getHitFraction(btCollisionWorld::LocalRayResult* obj)
{
	return obj->m_hitFraction;
}

void btCollisionWorld_LocalRayResult_getHitNormalLocal(btCollisionWorld::LocalRayResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitNormalLocal, value);
}

btCollisionWorld::LocalShapeInfo* btCollisionWorld_LocalRayResult_getLocalShapeInfo(btCollisionWorld::LocalRayResult* obj)
{
	return obj->m_localShapeInfo;
}

void btCollisionWorld_LocalRayResult_setCollisionObject(btCollisionWorld::LocalRayResult* obj, btCollisionObject* value)
{
	obj->m_collisionObject = value;
}

void btCollisionWorld_LocalRayResult_setHitFraction(btCollisionWorld::LocalRayResult* obj, btScalar value)
{
	obj->m_hitFraction = value;
}

void btCollisionWorld_LocalRayResult_setHitNormalLocal(btCollisionWorld::LocalRayResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitNormalLocal);
}

void btCollisionWorld_LocalRayResult_setLocalShapeInfo(btCollisionWorld::LocalRayResult* obj, btCollisionWorld::LocalShapeInfo* value)
{
	obj->m_localShapeInfo = value;
}

void btCollisionWorld_LocalRayResult_delete(btCollisionWorld::LocalRayResult* obj)
{
	delete obj;
}

btScalar btCollisionWorld_RayResultCallback_addSingleResult(btCollisionWorld_RayResultCallback* obj, btCollisionWorld::LocalRayResult* rayResult, bool normalInWorldSpace)
{
	return obj->addSingleResult(*rayResult, normalInWorldSpace);
}

btScalar btCollisionWorld_RayResultCallback_getClosestHitFraction(btCollisionWorld_RayResultCallback* obj)
{
	return obj->m_closestHitFraction;
}

short btCollisionWorld_RayResultCallback_getCollisionFilterGroup(btCollisionWorld_RayResultCallback* obj)
{
	return obj->m_collisionFilterGroup;
}

short btCollisionWorld_RayResultCallback_getCollisionFilterMask(btCollisionWorld_RayResultCallback* obj)
{
	return obj->m_collisionFilterMask;
}

const btCollisionObject* btCollisionWorld_RayResultCallback_getCollisionObject(btCollisionWorld_RayResultCallback* obj)
{
	return obj->m_collisionObject;
}

unsigned int btCollisionWorld_RayResultCallback_getFlags(btCollisionWorld_RayResultCallback* obj)
{
	return obj->m_flags;
}

bool btCollisionWorld_RayResultCallback_hasHit(btCollisionWorld_RayResultCallback* obj)
{
	return obj->hasHit();
}

bool btCollisionWorld_RayResultCallback_needsCollision(btCollisionWorld_RayResultCallback* obj, btBroadphaseProxy* proxy0)
{
	return obj->needsCollision(proxy0);
}

void btCollisionWorld_RayResultCallback_setClosestHitFraction(btCollisionWorld_RayResultCallback* obj, btScalar value)
{
	obj->m_closestHitFraction = value;
}

void btCollisionWorld_RayResultCallback_setCollisionFilterGroup(btCollisionWorld_RayResultCallback* obj, short value)
{
	obj->m_collisionFilterGroup = value;
}

void btCollisionWorld_RayResultCallback_setCollisionFilterMask(btCollisionWorld_RayResultCallback* obj, short value)
{
	obj->m_collisionFilterMask = value;
}

void btCollisionWorld_RayResultCallback_setCollisionObject(btCollisionWorld_RayResultCallback* obj, btCollisionObject* value)
{
	obj->m_collisionObject = value;
}

void btCollisionWorld_RayResultCallback_setFlags(btCollisionWorld_RayResultCallback* obj, unsigned int value)
{
	obj->m_flags = value;
}

void btCollisionWorld_RayResultCallback_delete(btCollisionWorld_RayResultCallback* obj)
{
	ALIGNED_FREE(obj);
}

btCollisionWorld::ClosestRayResultCallback* btCollisionWorld_ClosestRayResultCallback_new(btScalar* rayFromWorld, btScalar* rayToWorld)
{
	VECTOR3_CONV(rayFromWorld);
	VECTOR3_CONV(rayToWorld);
	return ALIGNED_NEW(btCollisionWorld::ClosestRayResultCallback) (VECTOR3_USE(rayFromWorld), VECTOR3_USE(rayToWorld));
}

void btCollisionWorld_ClosestRayResultCallback_getHitNormalWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitNormalWorld, value);
}

void btCollisionWorld_ClosestRayResultCallback_getHitPointWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitPointWorld, value);
}

void btCollisionWorld_ClosestRayResultCallback_getRayFromWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_rayFromWorld, value);
}

void btCollisionWorld_ClosestRayResultCallback_getRayToWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_rayToWorld, value);
}

void btCollisionWorld_ClosestRayResultCallback_setHitNormalWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitNormalWorld);
}

void btCollisionWorld_ClosestRayResultCallback_setHitPointWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitPointWorld);
}

void btCollisionWorld_ClosestRayResultCallback_setRayFromWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_rayFromWorld);
}

void btCollisionWorld_ClosestRayResultCallback_setRayToWorld(btCollisionWorld::ClosestRayResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_rayToWorld);
}

btCollisionWorld::AllHitsRayResultCallback* btCollisionWorld_AllHitsRayResultCallback_new(btScalar* rayFromWorld, btScalar* rayToWorld)
{
	VECTOR3_CONV(rayFromWorld);
	VECTOR3_CONV(rayToWorld);
	return new btCollisionWorld::AllHitsRayResultCallback(VECTOR3_USE(rayFromWorld), VECTOR3_USE(rayToWorld));
}

btAlignedCollisionObjectArray* btCollisionWorld_AllHitsRayResultCallback_getCollisionObjects(btCollisionWorld::AllHitsRayResultCallback* obj)
{
	return (btAlignedCollisionObjectArray*)&obj->m_collisionObjects;
}

btAlignedScalarArray* btCollisionWorld_AllHitsRayResultCallback_getHitFractions(btCollisionWorld::AllHitsRayResultCallback* obj)
{
	return &obj->m_hitFractions;
}

btAlignedVector3Array* btCollisionWorld_AllHitsRayResultCallback_getHitNormalWorld(btCollisionWorld::AllHitsRayResultCallback* obj)
{
	return &obj->m_hitNormalWorld;
}

btAlignedVector3Array* btCollisionWorld_AllHitsRayResultCallback_getHitPointWorld(btCollisionWorld::AllHitsRayResultCallback* obj)
{
	return &obj->m_hitPointWorld;
}

void btCollisionWorld_AllHitsRayResultCallback_getRayFromWorld(btCollisionWorld::AllHitsRayResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_rayFromWorld, value);
}

void btCollisionWorld_AllHitsRayResultCallback_getRayToWorld(btCollisionWorld::AllHitsRayResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_rayToWorld, value);
}

btAlignedVector3Array* btCollisionWorld_AllHitsRayResultCallback_setHitNormalWorld(btCollisionWorld::AllHitsRayResultCallback* obj)
{
	return &obj->m_hitNormalWorld;
}

btAlignedVector3Array* btCollisionWorld_AllHitsRayResultCallback_setHitPointWorld(btCollisionWorld::AllHitsRayResultCallback* obj)
{
	return &obj->m_hitPointWorld;
}

void btCollisionWorld_AllHitsRayResultCallback_setRayFromWorld(btCollisionWorld::AllHitsRayResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_rayFromWorld);
}

void btCollisionWorld_AllHitsRayResultCallback_setRayToWorld(btCollisionWorld::AllHitsRayResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_rayToWorld);
}

btCollisionWorld_LocalConvexResult* btCollisionWorld_LocalConvexResult_new(btCollisionObject* hitCollisionObject, btCollisionWorld::LocalShapeInfo* localShapeInfo, btScalar* hitNormalLocal, btScalar* hitPointLocal, btScalar hitFraction)
{
	VECTOR3_CONV(hitNormalLocal);
	VECTOR3_CONV(hitPointLocal);
	return new btCollisionWorld_LocalConvexResult(hitCollisionObject, localShapeInfo, VECTOR3_USE(hitNormalLocal), VECTOR3_USE(hitPointLocal), hitFraction);
}

const btCollisionObject* btCollisionWorld_LocalConvexResult_getHitCollisionObject(btCollisionWorld_LocalConvexResult* obj)
{
	return obj->m_hitCollisionObject;
}

btScalar btCollisionWorld_LocalConvexResult_getHitFraction(btCollisionWorld_LocalConvexResult* obj)
{
	return obj->m_hitFraction;
}

void btCollisionWorld_LocalConvexResult_getHitNormalLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitNormalLocal, value);
}

void btCollisionWorld_LocalConvexResult_getHitPointLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitPointLocal, value);
}

btCollisionWorld::LocalShapeInfo* btCollisionWorld_LocalConvexResult_getLocalShapeInfo(btCollisionWorld_LocalConvexResult* obj)
{
	return obj->m_localShapeInfo;
}

void btCollisionWorld_LocalConvexResult_setHitCollisionObject(btCollisionWorld_LocalConvexResult* obj, btCollisionObject* value)
{
	obj->m_hitCollisionObject = value;
}

void btCollisionWorld_LocalConvexResult_setHitFraction(btCollisionWorld_LocalConvexResult* obj, btScalar value)
{
	obj->m_hitFraction = value;
}

void btCollisionWorld_LocalConvexResult_setHitNormalLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitNormalLocal);
}

void btCollisionWorld_LocalConvexResult_setHitPointLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitPointLocal);
}

void btCollisionWorld_LocalConvexResult_setLocalShapeInfo(btCollisionWorld_LocalConvexResult* obj, btCollisionWorld::LocalShapeInfo* value)
{
	obj->m_localShapeInfo = value;
}

void btCollisionWorld_LocalConvexResult_delete(btCollisionWorld_LocalConvexResult* obj)
{
	delete obj;
}

btScalar btCollisionWorld_ConvexResultCallback_addSingleResult(btCollisionWorld_ConvexResultCallback* obj, btCollisionWorld_LocalConvexResult* convexResult, bool normalInWorldSpace)
{
	return obj->addSingleResult(*convexResult, normalInWorldSpace);
}

btScalar btCollisionWorld_ConvexResultCallback_getClosestHitFraction(btCollisionWorld_ConvexResultCallback* obj)
{
	return obj->m_closestHitFraction;
}

short btCollisionWorld_ConvexResultCallback_getCollisionFilterGroup(btCollisionWorld_ConvexResultCallback* obj)
{
	return obj->m_collisionFilterGroup;
}

short btCollisionWorld_ConvexResultCallback_getCollisionFilterMask(btCollisionWorld_ConvexResultCallback* obj)
{
	return obj->m_collisionFilterMask;
}

bool btCollisionWorld_ConvexResultCallback_hasHit(btCollisionWorld_ConvexResultCallback* obj)
{
	return obj->hasHit();
}

bool btCollisionWorld_ConvexResultCallback_needsCollision(btCollisionWorld_ConvexResultCallback* obj, btBroadphaseProxy* proxy0)
{
	return obj->needsCollision(proxy0);
}

void btCollisionWorld_ConvexResultCallback_setClosestHitFraction(btCollisionWorld_ConvexResultCallback* obj, btScalar value)
{
	obj->m_closestHitFraction = value;
}

void btCollisionWorld_ConvexResultCallback_setCollisionFilterGroup(btCollisionWorld_ConvexResultCallback* obj, short value)
{
	obj->m_collisionFilterGroup = value;
}

void btCollisionWorld_ConvexResultCallback_setCollisionFilterMask(btCollisionWorld_ConvexResultCallback* obj, short value)
{
	obj->m_collisionFilterMask = value;
}

void btCollisionWorld_ConvexResultCallback_delete(btCollisionWorld_ConvexResultCallback* obj)
{
	delete obj;
}

btCollisionWorld_ClosestConvexResultCallback* btCollisionWorld_ClosestConvexResultCallback_new(btScalar* convexFromWorld, btScalar* convexToWorld)
{
	VECTOR3_CONV(convexFromWorld);
	VECTOR3_CONV(convexToWorld);
	return ALIGNED_NEW(btCollisionWorld_ClosestConvexResultCallback) (VECTOR3_USE(convexFromWorld), VECTOR3_USE(convexToWorld));
}

void btCollisionWorld_ClosestConvexResultCallback_getConvexFromWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_convexFromWorld, value);
}

void btCollisionWorld_ClosestConvexResultCallback_getConvexToWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_convexToWorld, value);
}

const btCollisionObject* btCollisionWorld_ClosestConvexResultCallback_getHitCollisionObject(btCollisionWorld_ClosestConvexResultCallback* obj)
{
	return obj->m_hitCollisionObject;
}

void btCollisionWorld_ClosestConvexResultCallback_getHitNormalWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitNormalWorld, value);
}

void btCollisionWorld_ClosestConvexResultCallback_getHitPointWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitPointWorld, value);
}

void btCollisionWorld_ClosestConvexResultCallback_setConvexFromWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_convexFromWorld);
}

void btCollisionWorld_ClosestConvexResultCallback_setConvexToWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_convexToWorld);
}

void btCollisionWorld_ClosestConvexResultCallback_setHitCollisionObject(btCollisionWorld_ClosestConvexResultCallback* obj, btCollisionObject* value)
{
	obj->m_hitCollisionObject = value;
}

void btCollisionWorld_ClosestConvexResultCallback_setHitNormalWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitNormalWorld);
}

void btCollisionWorld_ClosestConvexResultCallback_setHitPointWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitPointWorld);
}

btScalar btCollisionWorld_ContactResultCallback_addSingleResult(btCollisionWorld_ContactResultCallback* obj, btManifoldPoint* cp, btCollisionObjectWrapper* colObj0Wrap, int partId0, int index0, btCollisionObjectWrapper* colObj1Wrap, int partId1, int index1)
{
	return obj->addSingleResult(*cp, colObj0Wrap, partId0, index0, colObj1Wrap, partId1, index1);
}

short btCollisionWorld_ContactResultCallback_getCollisionFilterGroup(btCollisionWorld_ContactResultCallback* obj)
{
	return obj->m_collisionFilterGroup;
}

short btCollisionWorld_ContactResultCallback_getCollisionFilterMask(btCollisionWorld_ContactResultCallback* obj)
{
	return obj->m_collisionFilterMask;
}

bool btCollisionWorld_ContactResultCallback_needsCollision(btCollisionWorld_ContactResultCallback* obj, btBroadphaseProxy* proxy0)
{
	return obj->needsCollision(proxy0);
}

void btCollisionWorld_ContactResultCallback_setCollisionFilterGroup(btCollisionWorld_ContactResultCallback* obj, short value)
{
	obj->m_collisionFilterGroup = value;
}

void btCollisionWorld_ContactResultCallback_setCollisionFilterMask(btCollisionWorld_ContactResultCallback* obj, short value)
{
	obj->m_collisionFilterMask = value;
}

void btCollisionWorld_ContactResultCallback_delete(btCollisionWorld_ContactResultCallback* obj)
{
	delete obj;
}

btCollisionWorld_ContactResultCallbackWrapper* btCollisionWorld_ContactResultCallbackWrapper_new(pAddSingleResult addSingleResultCallback, pNeedsCollision needsCollisionCallback)
{
	return new btCollisionWorld_ContactResultCallbackWrapper(addSingleResultCallback, needsCollisionCallback);
}

bool btCollisionWorld_ContactResultCallbackWrapper_needsCollision(btCollisionWorld_ContactResultCallbackWrapper* obj, btBroadphaseProxy* proxy0)
{
	return obj->baseNeedsCollision(proxy0);
}

btCollisionWorld* btCollisionWorld_new(btDispatcher* dispatcher, btBroadphaseInterface* broadphasePairCache, btCollisionConfiguration* collisionConfiguration)
{
	return new btCollisionWorld(dispatcher, broadphasePairCache, collisionConfiguration);
}

void btCollisionWorld_addCollisionObject(btCollisionWorld* obj, btCollisionObject* collisionObject, short collisionFilterGroup, short collisionFilterMask)
{
	obj->addCollisionObject(collisionObject, collisionFilterGroup, collisionFilterMask);
}

void btCollisionWorld_addCollisionObject2(btCollisionWorld* obj, btCollisionObject* collisionObject, short collisionFilterGroup)
{
	obj->addCollisionObject(collisionObject, collisionFilterGroup);
}

void btCollisionWorld_addCollisionObject3(btCollisionWorld* obj, btCollisionObject* collisionObject)
{
	obj->addCollisionObject(collisionObject);
}

void btCollisionWorld_computeOverlappingPairs(btCollisionWorld* obj)
{
	obj->computeOverlappingPairs();
}

void btCollisionWorld_contactPairTest(btCollisionWorld* obj, btCollisionObject* colObjA, btCollisionObject* colObjB, btCollisionWorld_ContactResultCallback* resultCallback)
{
	obj->contactPairTest(colObjA, colObjB, *resultCallback);
}

void btCollisionWorld_contactTest(btCollisionWorld* obj, btCollisionObject* colObj, btCollisionWorld_ContactResultCallback* resultCallback)
{
	obj->contactTest(colObj, *resultCallback);
}

void btCollisionWorld_convexSweepTest(btCollisionWorld* obj, btConvexShape* castShape, btScalar* from, btScalar* to, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedCcdPenetration)
{
	TRANSFORM_CONV(from);
	TRANSFORM_CONV(to);
	obj->convexSweepTest(castShape, TRANSFORM_USE(from), TRANSFORM_USE(to), *resultCallback, allowedCcdPenetration);
}

void btCollisionWorld_convexSweepTest2(btCollisionWorld* obj, btConvexShape* castShape, btScalar* from, btScalar* to, btCollisionWorld_ConvexResultCallback* resultCallback)
{
	TRANSFORM_CONV(from);
	TRANSFORM_CONV(to);
	obj->convexSweepTest(castShape, TRANSFORM_USE(from), TRANSFORM_USE(to), *resultCallback);
}

void btCollisionWorld_debugDrawObject(btCollisionWorld* obj, btScalar* worldTransform, btCollisionShape* shape, btScalar* color)
{
	TRANSFORM_CONV(worldTransform);
	VECTOR3_CONV(color);
	obj->debugDrawObject(TRANSFORM_USE(worldTransform), shape, VECTOR3_USE(color));
}

void btCollisionWorld_debugDrawWorld(btCollisionWorld* obj)
{
	obj->debugDrawWorld();
}

btBroadphaseInterface* btCollisionWorld_getBroadphase(btCollisionWorld* obj)
{
	return obj->getBroadphase();
}

btCollisionObjectArray* btCollisionWorld_getCollisionObjectArray(btCollisionWorld* obj)
{
	return &obj->getCollisionObjectArray();
}

btIDebugDraw* btCollisionWorld_getDebugDrawer(btCollisionWorld* obj)
{
	return obj->getDebugDrawer();
}

btDispatcher* btCollisionWorld_getDispatcher(btCollisionWorld* obj)
{
	return obj->getDispatcher();
}

btDispatcherInfo* btCollisionWorld_getDispatchInfo(btCollisionWorld* obj)
{
	return &obj->getDispatchInfo();
}

bool btCollisionWorld_getForceUpdateAllAabbs(btCollisionWorld* obj)
{
	return obj->getForceUpdateAllAabbs();
}

int btCollisionWorld_getNumCollisionObjects(btCollisionWorld* obj)
{
	return obj->getNumCollisionObjects();
}

btOverlappingPairCache* btCollisionWorld_getPairCache(btCollisionWorld* obj)
{
	return obj->getPairCache();
}

void btCollisionWorld_objectQuerySingle(btConvexShape* castShape, btScalar* rayFromTrans, btScalar* rayToTrans, btCollisionObject* collisionObject, btCollisionShape* collisionShape, btScalar* colObjWorldTransform, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedPenetration)
{
	TRANSFORM_CONV(rayFromTrans);
	TRANSFORM_CONV(rayToTrans);
	TRANSFORM_CONV(colObjWorldTransform);
	btCollisionWorld::objectQuerySingle(castShape, TRANSFORM_USE(rayFromTrans), TRANSFORM_USE(rayToTrans), collisionObject, collisionShape, TRANSFORM_USE(colObjWorldTransform), *resultCallback, allowedPenetration);
}

void btCollisionWorld_objectQuerySingleInternal(btConvexShape* castShape, btScalar* convexFromTrans, btScalar* convexToTrans, btCollisionObjectWrapper* colObjWrap, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedPenetration)
{
	TRANSFORM_CONV(convexFromTrans);
	TRANSFORM_CONV(convexToTrans);
	btCollisionWorld::objectQuerySingleInternal(castShape, TRANSFORM_USE(convexFromTrans), TRANSFORM_USE(convexToTrans), colObjWrap, *resultCallback, allowedPenetration);
}

void btCollisionWorld_performDiscreteCollisionDetection(btCollisionWorld* obj)
{
	obj->performDiscreteCollisionDetection();
}

void btCollisionWorld_rayTest(btCollisionWorld* obj, btScalar* rayFromWorld, btScalar* rayToWorld, btCollisionWorld_RayResultCallback* resultCallback)
{
	VECTOR3_CONV(rayFromWorld);
	VECTOR3_CONV(rayToWorld);
	obj->rayTest(VECTOR3_USE(rayFromWorld), VECTOR3_USE(rayToWorld), *resultCallback);
}

void btCollisionWorld_rayTestSingle(btScalar* rayFromTrans, btScalar* rayToTrans, btCollisionObject* collisionObject, btCollisionShape* collisionShape, btScalar* colObjWorldTransform, btCollisionWorld_RayResultCallback* resultCallback)
{
	TRANSFORM_CONV(rayFromTrans);
	TRANSFORM_CONV(rayToTrans);
	TRANSFORM_CONV(colObjWorldTransform);
	btCollisionWorld::rayTestSingle(TRANSFORM_USE(rayFromTrans), TRANSFORM_USE(rayToTrans), collisionObject, collisionShape, TRANSFORM_USE(colObjWorldTransform), *resultCallback);
}

void btCollisionWorld_rayTestSingleInternal(btScalar* rayFromTrans, btScalar* rayToTrans, btCollisionObjectWrapper* collisionObjectWrap, btCollisionWorld_RayResultCallback* resultCallback)
{
	TRANSFORM_CONV(rayFromTrans);
	TRANSFORM_CONV(rayToTrans);
	btCollisionWorld::rayTestSingleInternal(TRANSFORM_USE(rayFromTrans), TRANSFORM_USE(rayToTrans), collisionObjectWrap, *resultCallback);
}

void btCollisionWorld_removeCollisionObject(btCollisionWorld* obj, btCollisionObject* collisionObject)
{
	obj->removeCollisionObject(collisionObject);
}

void btCollisionWorld_serialize(btCollisionWorld* obj, btSerializer* serializer)
{
	obj->serialize(serializer);
}

void btCollisionWorld_setBroadphase(btCollisionWorld* obj, btBroadphaseInterface* pairCache)
{
	obj->setBroadphase(pairCache);
}

void btCollisionWorld_setDebugDrawer(btCollisionWorld* obj, btIDebugDraw* debugDrawer)
{
	obj->setDebugDrawer(debugDrawer);
}

void btCollisionWorld_setForceUpdateAllAabbs(btCollisionWorld* obj, bool forceUpdateAllAabbs)
{
	obj->setForceUpdateAllAabbs(forceUpdateAllAabbs);
}

void btCollisionWorld_updateAabbs(btCollisionWorld* obj)
{
	obj->updateAabbs();
}

void btCollisionWorld_updateSingleAabb(btCollisionWorld* obj, btCollisionObject* colObj)
{
	obj->updateSingleAabb(colObj);
}

void btCollisionWorld_delete(btCollisionWorld* obj)
{
	delete obj;
}

AllHitsConvexResultCallback* btCollisionWorld_AllHitsConvexResultCallback_new(pAddSingleResult2 callback, void* sharpReference)
{
	return new AllHitsConvexResultCallback(callback, sharpReference);
}

void btCollisionWorld_AllHitsConvexResultCallback_delete(AllHitsConvexResultCallback* obj)
{
	delete obj;
}

AllHitsRayResultCallback* btCollisionWorld_AllHitsRayResultCallback_new2(pAddSingleResult2 callback, void* sharpReference, btScalar* rayFrom, btScalar* rayTo)
{
	return new AllHitsRayResultCallback(callback, sharpReference, rayFrom, rayTo);
}

void btCollisionWorld_AllHitsRayResultCallback_delete2(AllHitsRayResultCallback* obj)
{
	delete obj;
}

#include <vector>

#define MAX_CONTACTS_PER_OBJECT 1024

#pragma pack(push, 4)
struct ContactData
{
	const void* ColliderA;
	const void* ColliderB;

	float Distance;

	float NormalX;
	float NormalY;
	float NormalZ;

	float PositionOnAx;
	float PositionOnAy;
	float PositionOnAz;

	float PositionOnBx;
	float PositionOnBy;
	float PositionOnBz;
};
#pragma pack(pop)

class ContactCallback : public btCollisionWorld::ContactResultCallback
{
public:
	ContactCallback(std::vector<ContactData>* buffer) : data(buffer)
	{
	}

	virtual	btScalar addSingleResult(btManifoldPoint& cp, const btCollisionObjectWrapper* colObj0Wrap, int partId0, int index0, const btCollisionObjectWrapper* colObj1Wrap, int partId1, int index1)
	{
		if (data->size() == MAX_CONTACTS_PER_OBJECT) return 0;

		ContactData result;

		result.ColliderA = colObj0Wrap->getCollisionObject();
		result.ColliderB = colObj1Wrap->getCollisionObject();
		result.Distance = cp.getDistance();
		result.NormalX = cp.m_normalWorldOnB.getX();
		result.NormalY = cp.m_normalWorldOnB.getY();
		result.NormalZ = cp.m_normalWorldOnB.getZ();
		result.PositionOnAx = cp.m_positionWorldOnA.getX();
		result.PositionOnAy = cp.m_positionWorldOnA.getY();
		result.PositionOnAz = cp.m_positionWorldOnA.getZ();
		result.PositionOnBx = cp.m_positionWorldOnB.getX();
		result.PositionOnBy = cp.m_positionWorldOnB.getY();
		result.PositionOnBz = cp.m_positionWorldOnB.getZ();

		data->push_back(result);
		
		return 0;
	}

private:
	std::vector<ContactData>* data;
};

int Xenko_GetCollisions(btCollisionWorld* world, btCollisionObject* shape, void* dataBuffer, short int flags, short int group)
{
	std::vector<ContactData>* data = (std::vector<ContactData>*)dataBuffer;

	data->clear();

	ContactCallback cb(data);
	cb.m_collisionFilterGroup = group;
	cb.m_collisionFilterMask = flags;
	world->contactTest(shape, cb);

	return data->size();
}

void* Xenko_CreateBuffer()
{
	std::vector<ContactData>* buffer = new std::vector<ContactData>(MAX_CONTACTS_PER_OBJECT);
	return buffer;
}

void Xenko_DeleteBuffer(void* buffer)
{
	std::vector<ContactData>* data = (std::vector<ContactData>*)buffer;
	delete data;
}

void* Xenko_GetBufferData(void* buffer)
{
	std::vector<ContactData>* data = (std::vector<ContactData>*)buffer;
	return &(*data)[0];
}

