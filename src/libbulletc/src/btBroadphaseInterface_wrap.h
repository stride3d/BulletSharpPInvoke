#include "main.h"

extern "C"
{
	EXPORT bool btBroadphaseAabbCallback_process(btBroadphaseAabbCallback* obj, btBroadphaseProxy* proxy);
	EXPORT void btBroadphaseAabbCallback_delete(btBroadphaseAabbCallback* obj);

	EXPORT btScalar btBroadphaseRayCallback_getLambda_max(btBroadphaseRayCallback* obj);
	EXPORT void btBroadphaseRayCallback_getRayDirectionInverse(btBroadphaseRayCallback* obj, btScalar* value);
	EXPORT unsigned int* btBroadphaseRayCallback_getSigns(btBroadphaseRayCallback* obj);
	EXPORT void btBroadphaseRayCallback_setLambda_max(btBroadphaseRayCallback* obj, btScalar value);
	EXPORT void btBroadphaseRayCallback_setRayDirectionInverse(btBroadphaseRayCallback* obj, btScalar* value);
	EXPORT void btBroadphaseRayCallback_setSigns(btBroadphaseRayCallback* obj, unsigned int* value);

	EXPORT void btBroadphaseInterface_aabbTest(btBroadphaseInterface* obj, btScalar* aabbMin, btScalar* aabbMax, btBroadphaseAabbCallback* callback);
	EXPORT void btBroadphaseInterface_calculateOverlappingPairs(btBroadphaseInterface* obj, btDispatcher* dispatcher);
	EXPORT btBroadphaseProxy* btBroadphaseInterface_createProxy(btBroadphaseInterface* obj, btScalar* aabbMin, btScalar* aabbMax, int shapeType, void* userPtr, short collisionFilterGroup, short collisionFilterMask, btDispatcher* dispatcher, void* multiSapProxy);
	EXPORT void btBroadphaseInterface_destroyProxy(btBroadphaseInterface* obj, btBroadphaseProxy* proxy, btDispatcher* dispatcher);
	EXPORT void btBroadphaseInterface_getAabb(btBroadphaseInterface* obj, btBroadphaseProxy* proxy, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btBroadphaseInterface_getBroadphaseAabb(btBroadphaseInterface* obj, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT btOverlappingPairCache* btBroadphaseInterface_getOverlappingPairCache(btBroadphaseInterface* obj);
	EXPORT void btBroadphaseInterface_printStats(btBroadphaseInterface* obj);
	EXPORT void btBroadphaseInterface_rayTest(btBroadphaseInterface* obj, btScalar* rayFrom, btScalar* rayTo, btBroadphaseRayCallback* rayCallback, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btBroadphaseInterface_rayTest2(btBroadphaseInterface* obj, btScalar* rayFrom, btScalar* rayTo, btBroadphaseRayCallback* rayCallback, btScalar* aabbMin);
	EXPORT void btBroadphaseInterface_rayTest3(btBroadphaseInterface* obj, btScalar* rayFrom, btScalar* rayTo, btBroadphaseRayCallback* rayCallback);
	EXPORT void btBroadphaseInterface_resetPool(btBroadphaseInterface* obj, btDispatcher* dispatcher);
	EXPORT void btBroadphaseInterface_setAabb(btBroadphaseInterface* obj, btBroadphaseProxy* proxy, btScalar* aabbMin, btScalar* aabbMax, btDispatcher* dispatcher);
	EXPORT void btBroadphaseInterface_delete(btBroadphaseInterface* obj);
}
