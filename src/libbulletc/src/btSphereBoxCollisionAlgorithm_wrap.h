#include "main.h"

extern "C"
{
	EXPORT btSphereBoxCollisionAlgorithm::CreateFunc* btSphereBoxCollisionAlgorithm_CreateFunc_new();
	EXPORT btSphereBoxCollisionAlgorithm* btSphereBoxCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, bool isSwapped);
	EXPORT bool btSphereBoxCollisionAlgorithm_getSphereDistance(btSphereBoxCollisionAlgorithm* obj, btCollisionObjectWrapper* boxObjWrap, btScalar* v3PointOnBox, btScalar* normal, btScalar* penetrationDepth, btScalar* v3SphereCenter, btScalar fRadius, btScalar maxContactDistance);
	EXPORT btScalar btSphereBoxCollisionAlgorithm_getSpherePenetration(btSphereBoxCollisionAlgorithm* obj, btScalar* boxHalfExtent, btScalar* sphereRelPos, btScalar* closestPoint, btScalar* normal);
}
