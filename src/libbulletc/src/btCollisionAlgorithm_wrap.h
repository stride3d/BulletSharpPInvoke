#include "main.h"

extern "C"
{
	EXPORT btCollisionAlgorithmConstructionInfo* btCollisionAlgorithmConstructionInfo_new();
	EXPORT btCollisionAlgorithmConstructionInfo* btCollisionAlgorithmConstructionInfo_new2(btDispatcher* dispatcher, int temp);
	EXPORT btDispatcher* btCollisionAlgorithmConstructionInfo_getDispatcher1(btCollisionAlgorithmConstructionInfo* obj);
	EXPORT btPersistentManifold* btCollisionAlgorithmConstructionInfo_getManifold(btCollisionAlgorithmConstructionInfo* obj);
	EXPORT void btCollisionAlgorithmConstructionInfo_setDispatcher1(btCollisionAlgorithmConstructionInfo* obj, btDispatcher* value);
	EXPORT void btCollisionAlgorithmConstructionInfo_setManifold(btCollisionAlgorithmConstructionInfo* obj, btPersistentManifold* value);
	EXPORT void btCollisionAlgorithmConstructionInfo_delete(btCollisionAlgorithmConstructionInfo* obj);

	EXPORT btScalar btCollisionAlgorithm_calculateTimeOfImpact(btCollisionAlgorithm* obj, btCollisionObject* body0, btCollisionObject* body1, btDispatcherInfo* dispatchInfo, btManifoldResult* resultOut);
	EXPORT void btCollisionAlgorithm_getAllContactManifolds(btCollisionAlgorithm* obj, btManifoldArray* manifoldArray);
	EXPORT void btCollisionAlgorithm_processCollision(btCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btDispatcherInfo* dispatchInfo, btManifoldResult* resultOut);
	EXPORT void btCollisionAlgorithm_delete(btCollisionAlgorithm* obj);
}
