#include "main.h"

#ifndef BT_COLLISION_WORLD_H
#define pNeedsCollision void*
#define pAddSingleResult void*

#define btCollisionWorld_ContactResultCallbackWrapper void

#define pAddSingleResult2 void*

#define AllHitsConvexResultCallback void
#define AllHitsRayResultCallback void
#else
typedef bool (*pNeedsCollision)(btBroadphaseProxy* proxy0);
typedef bool (*pAddSingleResult)(btManifoldPoint& cp,
		const btCollisionObjectWrapper* colObj0, int partId0, int index0,
		const btCollisionObjectWrapper* colObj1, int partId1, int index1);

class btCollisionWorld_ContactResultCallbackWrapper : public btCollisionWorld_ContactResultCallback
{
private:
	pNeedsCollision _needsCollisionCallback;
	pAddSingleResult _addSingleResultCallback;

public:
	btCollisionWorld_ContactResultCallbackWrapper(pAddSingleResult addSingleResultCallback, pNeedsCollision needsCollisionCallback);

	virtual bool needsCollision(btBroadphaseProxy* proxy0) const;
	virtual btScalar addSingleResult(btManifoldPoint& cp,
		const btCollisionObjectWrapper* colObj0, int partId0, int index0,
		const btCollisionObjectWrapper* colObj1, int partId1, int index1);

	virtual bool baseNeedsCollision(btBroadphaseProxy* proxy0) const;
};

typedef void (*pAddSingleResult2)(const void* sharpReference, const btCollisionObject* object, btVector3& point, btVector3& normal, float hitFraction);

class AllHitsConvexResultCallback : public btCollisionWorld::ConvexResultCallback
{
public:
	AllHitsConvexResultCallback(pAddSingleResult2 callback, void* sharpReference) : mCb(callback), mSharpReference(sharpReference)
	{}

	virtual	btScalar addSingleResult(btCollisionWorld::LocalConvexResult& convexResult, bool normalInWorldSpace)
	{				
		btVector3 normal = convexResult.m_hitNormalLocal;
		btVector3 point = convexResult.m_hitPointLocal;
		float hitFraction = convexResult.m_hitFraction;

		if (!normalInWorldSpace)
		{
			normal = convexResult.m_hitCollisionObject->getWorldTransform().getBasis()*convexResult.m_hitNormalLocal;
		} 

		if(mCb) mCb(mSharpReference, convexResult.m_hitCollisionObject, point, normal, hitFraction);

		return convexResult.m_hitFraction;
	}

private:
	pAddSingleResult2 mCb;
	void* mSharpReference;
};

class AllHitsRayResultCallback : public btCollisionWorld::RayResultCallback
{
public:
	AllHitsRayResultCallback(pAddSingleResult2 callback, void* sharpReference, btScalar* rayFromWorld, btScalar* rayToWorld) : mCb(callback), mSharpReference(sharpReference)
	{
		VECTOR3_CONV(rayFromWorld);
		m_rayFromWorld = VECTOR3_USE(rayFromWorld);
		VECTOR3_CONV(rayToWorld);
		m_rayToWorld = VECTOR3_USE(rayToWorld);
	}

	virtual	btScalar addSingleResult(btCollisionWorld::LocalRayResult& rayResult, bool normalInWorldSpace)
	{				
		btVector3 normal;
		btVector3 point;
		point.setInterpolate3(m_rayFromWorld, m_rayToWorld, rayResult.m_hitFraction);
		float hitFraction = rayResult.m_hitFraction;

		if (normalInWorldSpace)
		{
			normal = rayResult.m_hitNormalLocal;
		} else
		{
			///need to transform normal into worldspace
			normal = m_collisionObject->getWorldTransform().getBasis()*rayResult.m_hitNormalLocal;
		}

		if(mCb) mCb(mSharpReference, rayResult.m_collisionObject, point, normal, hitFraction);

		return rayResult.m_hitFraction;
	}

private:
	btVector3 m_rayFromWorld;//used to calculate hitPointWorld from hitFraction
	btVector3 m_rayToWorld;
	pAddSingleResult2 mCb;
	void* mSharpReference;
};
#endif

extern "C"
{
	EXPORT btCollisionWorld_LocalShapeInfo* btCollisionWorld_LocalShapeInfo_new();
	EXPORT int btCollisionWorld_LocalShapeInfo_getShapePart(btCollisionWorld_LocalShapeInfo* obj);
	EXPORT int btCollisionWorld_LocalShapeInfo_getTriangleIndex(btCollisionWorld_LocalShapeInfo* obj);
	EXPORT void btCollisionWorld_LocalShapeInfo_setShapePart(btCollisionWorld_LocalShapeInfo* obj, int value);
	EXPORT void btCollisionWorld_LocalShapeInfo_setTriangleIndex(btCollisionWorld_LocalShapeInfo* obj, int value);
	EXPORT void btCollisionWorld_LocalShapeInfo_delete(btCollisionWorld_LocalShapeInfo* obj);

	EXPORT btCollisionWorld_LocalRayResult* btCollisionWorld_LocalRayResult_new(btCollisionObject* collisionObject, btCollisionWorld_LocalShapeInfo* localShapeInfo, btScalar* hitNormalLocal, btScalar hitFraction);
	EXPORT const btCollisionObject* btCollisionWorld_LocalRayResult_getCollisionObject(btCollisionWorld_LocalRayResult* obj);
	EXPORT btScalar btCollisionWorld_LocalRayResult_getHitFraction(btCollisionWorld_LocalRayResult* obj);
	EXPORT void btCollisionWorld_LocalRayResult_getHitNormalLocal(btCollisionWorld_LocalRayResult* obj, btScalar* value);
	EXPORT btCollisionWorld_LocalShapeInfo* btCollisionWorld_LocalRayResult_getLocalShapeInfo(btCollisionWorld_LocalRayResult* obj);
	EXPORT void btCollisionWorld_LocalRayResult_setCollisionObject(btCollisionWorld_LocalRayResult* obj, btCollisionObject* value);
	EXPORT void btCollisionWorld_LocalRayResult_setHitFraction(btCollisionWorld_LocalRayResult* obj, btScalar value);
	EXPORT void btCollisionWorld_LocalRayResult_setHitNormalLocal(btCollisionWorld_LocalRayResult* obj, btScalar* value);
	EXPORT void btCollisionWorld_LocalRayResult_setLocalShapeInfo(btCollisionWorld_LocalRayResult* obj, btCollisionWorld_LocalShapeInfo* value);
	EXPORT void btCollisionWorld_LocalRayResult_delete(btCollisionWorld_LocalRayResult* obj);

	EXPORT btScalar btCollisionWorld_RayResultCallback_addSingleResult(btCollisionWorld_RayResultCallback* obj, btCollisionWorld_LocalRayResult* rayResult, bool normalInWorldSpace);
	EXPORT btScalar btCollisionWorld_RayResultCallback_getClosestHitFraction(btCollisionWorld_RayResultCallback* obj);
	EXPORT short btCollisionWorld_RayResultCallback_getCollisionFilterGroup(btCollisionWorld_RayResultCallback* obj);
	EXPORT short btCollisionWorld_RayResultCallback_getCollisionFilterMask(btCollisionWorld_RayResultCallback* obj);
	EXPORT const btCollisionObject* btCollisionWorld_RayResultCallback_getCollisionObject(btCollisionWorld_RayResultCallback* obj);
	EXPORT unsigned int btCollisionWorld_RayResultCallback_getFlags(btCollisionWorld_RayResultCallback* obj);
	EXPORT bool btCollisionWorld_RayResultCallback_hasHit(btCollisionWorld_RayResultCallback* obj);
	EXPORT bool btCollisionWorld_RayResultCallback_needsCollision(btCollisionWorld_RayResultCallback* obj, btBroadphaseProxy* proxy0);
	EXPORT void btCollisionWorld_RayResultCallback_setClosestHitFraction(btCollisionWorld_RayResultCallback* obj, btScalar value);
	EXPORT void btCollisionWorld_RayResultCallback_setCollisionFilterGroup(btCollisionWorld_RayResultCallback* obj, short value);
	EXPORT void btCollisionWorld_RayResultCallback_setCollisionFilterMask(btCollisionWorld_RayResultCallback* obj, short value);
	EXPORT void btCollisionWorld_RayResultCallback_setCollisionObject(btCollisionWorld_RayResultCallback* obj, btCollisionObject* value);
	EXPORT void btCollisionWorld_RayResultCallback_setFlags(btCollisionWorld_RayResultCallback* obj, unsigned int value);
	EXPORT void btCollisionWorld_RayResultCallback_delete(btCollisionWorld_RayResultCallback* obj);

	EXPORT btCollisionWorld_ClosestRayResultCallback* btCollisionWorld_ClosestRayResultCallback_new(btScalar* rayFromWorld, btScalar* rayToWorld);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_getHitNormalWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_getHitPointWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_getRayFromWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_getRayToWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_setHitNormalWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_setHitPointWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_setRayFromWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestRayResultCallback_setRayToWorld(btCollisionWorld_ClosestRayResultCallback* obj, btScalar* value);

	EXPORT btCollisionWorld_AllHitsRayResultCallback* btCollisionWorld_AllHitsRayResultCallback_new(btScalar* rayFromWorld, btScalar* rayToWorld);
	EXPORT btAlignedCollisionObjectArray* btCollisionWorld_AllHitsRayResultCallback_getCollisionObjects(btCollisionWorld_AllHitsRayResultCallback* obj);
	EXPORT btAlignedScalarArray* btCollisionWorld_AllHitsRayResultCallback_getHitFractions(btCollisionWorld_AllHitsRayResultCallback* obj);
	EXPORT btAlignedVector3Array* btCollisionWorld_AllHitsRayResultCallback_getHitNormalWorld(btCollisionWorld_AllHitsRayResultCallback* obj);
	EXPORT btAlignedVector3Array* btCollisionWorld_AllHitsRayResultCallback_getHitPointWorld(btCollisionWorld_AllHitsRayResultCallback* obj);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_getRayFromWorld(btCollisionWorld_AllHitsRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_getRayToWorld(btCollisionWorld_AllHitsRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_setHitNormalWorld(btCollisionWorld_AllHitsRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_setHitPointWorld(btCollisionWorld_AllHitsRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_setRayFromWorld(btCollisionWorld_AllHitsRayResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_setRayToWorld(btCollisionWorld_AllHitsRayResultCallback* obj, btScalar* value);

	EXPORT btCollisionWorld_LocalConvexResult* btCollisionWorld_LocalConvexResult_new(btCollisionObject* hitCollisionObject, btCollisionWorld_LocalShapeInfo* localShapeInfo, btScalar* hitNormalLocal, btScalar* hitPointLocal, btScalar hitFraction);
	EXPORT const btCollisionObject* btCollisionWorld_LocalConvexResult_getHitCollisionObject(btCollisionWorld_LocalConvexResult* obj);
	EXPORT btScalar btCollisionWorld_LocalConvexResult_getHitFraction(btCollisionWorld_LocalConvexResult* obj);
	EXPORT void btCollisionWorld_LocalConvexResult_getHitNormalLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value);
	EXPORT void btCollisionWorld_LocalConvexResult_getHitPointLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value);
	EXPORT btCollisionWorld_LocalShapeInfo* btCollisionWorld_LocalConvexResult_getLocalShapeInfo(btCollisionWorld_LocalConvexResult* obj);
	EXPORT void btCollisionWorld_LocalConvexResult_setHitCollisionObject(btCollisionWorld_LocalConvexResult* obj, btCollisionObject* value);
	EXPORT void btCollisionWorld_LocalConvexResult_setHitFraction(btCollisionWorld_LocalConvexResult* obj, btScalar value);
	EXPORT void btCollisionWorld_LocalConvexResult_setHitNormalLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value);
	EXPORT void btCollisionWorld_LocalConvexResult_setHitPointLocal(btCollisionWorld_LocalConvexResult* obj, btScalar* value);
	EXPORT void btCollisionWorld_LocalConvexResult_setLocalShapeInfo(btCollisionWorld_LocalConvexResult* obj, btCollisionWorld_LocalShapeInfo* value);
	EXPORT void btCollisionWorld_LocalConvexResult_delete(btCollisionWorld_LocalConvexResult* obj);

	EXPORT btScalar btCollisionWorld_ConvexResultCallback_addSingleResult(btCollisionWorld_ConvexResultCallback* obj, btCollisionWorld_LocalConvexResult* convexResult, bool normalInWorldSpace);
	EXPORT btScalar btCollisionWorld_ConvexResultCallback_getClosestHitFraction(btCollisionWorld_ConvexResultCallback* obj);
	EXPORT short btCollisionWorld_ConvexResultCallback_getCollisionFilterGroup(btCollisionWorld_ConvexResultCallback* obj);
	EXPORT short btCollisionWorld_ConvexResultCallback_getCollisionFilterMask(btCollisionWorld_ConvexResultCallback* obj);
	EXPORT bool btCollisionWorld_ConvexResultCallback_hasHit(btCollisionWorld_ConvexResultCallback* obj);
	EXPORT bool btCollisionWorld_ConvexResultCallback_needsCollision(btCollisionWorld_ConvexResultCallback* obj, btBroadphaseProxy* proxy0);
	EXPORT void btCollisionWorld_ConvexResultCallback_setClosestHitFraction(btCollisionWorld_ConvexResultCallback* obj, btScalar value);
	EXPORT void btCollisionWorld_ConvexResultCallback_setCollisionFilterGroup(btCollisionWorld_ConvexResultCallback* obj, short value);
	EXPORT void btCollisionWorld_ConvexResultCallback_setCollisionFilterMask(btCollisionWorld_ConvexResultCallback* obj, short value);
	EXPORT void btCollisionWorld_ConvexResultCallback_delete(btCollisionWorld_ConvexResultCallback* obj);

	EXPORT btCollisionWorld_ClosestConvexResultCallback* btCollisionWorld_ClosestConvexResultCallback_new(btScalar* convexFromWorld, btScalar* convexToWorld);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_getConvexFromWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_getConvexToWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT const btCollisionObject* btCollisionWorld_ClosestConvexResultCallback_getHitCollisionObject(btCollisionWorld_ClosestConvexResultCallback* obj);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_getHitNormalWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_getHitPointWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_setConvexFromWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_setConvexToWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_setHitCollisionObject(btCollisionWorld_ClosestConvexResultCallback* obj, btCollisionObject* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_setHitNormalWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);
	EXPORT void btCollisionWorld_ClosestConvexResultCallback_setHitPointWorld(btCollisionWorld_ClosestConvexResultCallback* obj, btScalar* value);

	EXPORT btScalar btCollisionWorld_ContactResultCallback_addSingleResult(btCollisionWorld_ContactResultCallback* obj, btManifoldPoint* cp, btCollisionObjectWrapper* colObj0Wrap, int partId0, int index0, btCollisionObjectWrapper* colObj1Wrap, int partId1, int index1);
	EXPORT short btCollisionWorld_ContactResultCallback_getCollisionFilterGroup(btCollisionWorld_ContactResultCallback* obj);
	EXPORT short btCollisionWorld_ContactResultCallback_getCollisionFilterMask(btCollisionWorld_ContactResultCallback* obj);
	EXPORT bool btCollisionWorld_ContactResultCallback_needsCollision(btCollisionWorld_ContactResultCallback* obj, btBroadphaseProxy* proxy0);
	EXPORT void btCollisionWorld_ContactResultCallback_setCollisionFilterGroup(btCollisionWorld_ContactResultCallback* obj, short value);
	EXPORT void btCollisionWorld_ContactResultCallback_setCollisionFilterMask(btCollisionWorld_ContactResultCallback* obj, short value);
	EXPORT void btCollisionWorld_ContactResultCallback_delete(btCollisionWorld_ContactResultCallback* obj);

	EXPORT btCollisionWorld_ContactResultCallbackWrapper* btCollisionWorld_ContactResultCallbackWrapper_new(pAddSingleResult addSingleResultCallback, pNeedsCollision needsCollisionCallback);
	EXPORT bool btCollisionWorld_ContactResultCallbackWrapper_needsCollision(btCollisionWorld_ContactResultCallbackWrapper* obj, btBroadphaseProxy* proxy0);

	EXPORT AllHitsConvexResultCallback* btCollisionWorld_AllHitsConvexResultCallback_new(pAddSingleResult2 callback, void* sharpReference);
	EXPORT void btCollisionWorld_AllHitsConvexResultCallback_delete(AllHitsConvexResultCallback* obj);
	EXPORT AllHitsRayResultCallback* btCollisionWorld_AllHitsRayResultCallback_new2(pAddSingleResult2 callback, void* sharpReference, btScalar* rayFrom, btScalar* rayTo);
	EXPORT void btCollisionWorld_AllHitsRayResultCallback_delete2(AllHitsRayResultCallback* obj);

	EXPORT btCollisionWorld* btCollisionWorld_new(btDispatcher* dispatcher, btBroadphaseInterface* broadphasePairCache, btCollisionConfiguration* collisionConfiguration);
	EXPORT void btCollisionWorld_addCollisionObject(btCollisionWorld* obj, btCollisionObject* collisionObject, short collisionFilterGroup, short collisionFilterMask);
	EXPORT void btCollisionWorld_addCollisionObject2(btCollisionWorld* obj, btCollisionObject* collisionObject, short collisionFilterGroup);
	EXPORT void btCollisionWorld_addCollisionObject3(btCollisionWorld* obj, btCollisionObject* collisionObject);
	EXPORT void btCollisionWorld_computeOverlappingPairs(btCollisionWorld* obj);
	EXPORT void btCollisionWorld_contactPairTest(btCollisionWorld* obj, btCollisionObject* colObjA, btCollisionObject* colObjB, btCollisionWorld_ContactResultCallback* resultCallback);
	EXPORT void btCollisionWorld_contactTest(btCollisionWorld* obj, btCollisionObject* colObj, btCollisionWorld_ContactResultCallback* resultCallback);
	EXPORT void btCollisionWorld_convexSweepTest(btCollisionWorld* obj, btConvexShape* castShape, btScalar* from, btScalar* to, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedCcdPenetration);
	EXPORT void btCollisionWorld_convexSweepTest2(btCollisionWorld* obj, btConvexShape* castShape, btScalar* from, btScalar* to, btCollisionWorld_ConvexResultCallback* resultCallback);
	EXPORT void btCollisionWorld_debugDrawObject(btCollisionWorld* obj, btScalar* worldTransform, btCollisionShape* shape, btScalar* color);
	EXPORT void btCollisionWorld_debugDrawWorld(btCollisionWorld* obj);
	EXPORT btBroadphaseInterface* btCollisionWorld_getBroadphase(btCollisionWorld* obj);
	EXPORT btCollisionObjectArray* btCollisionWorld_getCollisionObjectArray(btCollisionWorld* obj);
	EXPORT btIDebugDraw* btCollisionWorld_getDebugDrawer(btCollisionWorld* obj);
	EXPORT btDispatcher* btCollisionWorld_getDispatcher(btCollisionWorld* obj);
	EXPORT btDispatcherInfo* btCollisionWorld_getDispatchInfo(btCollisionWorld* obj);
	EXPORT bool btCollisionWorld_getForceUpdateAllAabbs(btCollisionWorld* obj);
	EXPORT int btCollisionWorld_getNumCollisionObjects(btCollisionWorld* obj);
	EXPORT btOverlappingPairCache* btCollisionWorld_getPairCache(btCollisionWorld* obj);
	EXPORT void btCollisionWorld_objectQuerySingle(btConvexShape* castShape, btScalar* rayFromTrans, btScalar* rayToTrans, btCollisionObject* collisionObject, btCollisionShape* collisionShape, btScalar* colObjWorldTransform, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedPenetration);
	EXPORT void btCollisionWorld_objectQuerySingleInternal(btConvexShape* castShape, btScalar* convexFromTrans, btScalar* convexToTrans, btCollisionObjectWrapper* colObjWrap, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedPenetration);
	EXPORT void btCollisionWorld_performDiscreteCollisionDetection(btCollisionWorld* obj);
	EXPORT void btCollisionWorld_rayTest(btCollisionWorld* obj, btScalar* rayFromWorld, btScalar* rayToWorld, btCollisionWorld_RayResultCallback* resultCallback);
	EXPORT void btCollisionWorld_rayTestSingle(btScalar* rayFromTrans, btScalar* rayToTrans, btCollisionObject* collisionObject, btCollisionShape* collisionShape, btScalar* colObjWorldTransform, btCollisionWorld_RayResultCallback* resultCallback);
	EXPORT void btCollisionWorld_rayTestSingleInternal(btScalar* rayFromTrans, btScalar* rayToTrans, btCollisionObjectWrapper* collisionObjectWrap, btCollisionWorld_RayResultCallback* resultCallback);
	EXPORT void btCollisionWorld_removeCollisionObject(btCollisionWorld* obj, btCollisionObject* collisionObject);
	EXPORT void btCollisionWorld_serialize(btCollisionWorld* obj, btSerializer* serializer);
	EXPORT void btCollisionWorld_setBroadphase(btCollisionWorld* obj, btBroadphaseInterface* pairCache);
	EXPORT void btCollisionWorld_setDebugDrawer(btCollisionWorld* obj, btIDebugDraw* debugDrawer);
	EXPORT void btCollisionWorld_setForceUpdateAllAabbs(btCollisionWorld* obj, bool forceUpdateAllAabbs);
	EXPORT void btCollisionWorld_updateAabbs(btCollisionWorld* obj);
	EXPORT void btCollisionWorld_updateSingleAabb(btCollisionWorld* obj, btCollisionObject* colObj);
	EXPORT void btCollisionWorld_delete(btCollisionWorld* obj);

	EXPORT void* Xenko_CreateBuffer();
	EXPORT void Xenko_DeleteBuffer(void* buffer);
	EXPORT int Xenko_GetCollisions(btCollisionWorld* world, btCollisionObject* shape, void* dataBuffer, short int flags, short int group);
	EXPORT void* Xenko_GetBufferData(void* buffer);
}
