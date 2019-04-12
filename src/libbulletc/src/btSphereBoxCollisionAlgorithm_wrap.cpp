#include <BulletCollision/CollisionDispatch/btSphereBoxCollisionAlgorithm.h>

#include "conversion.h"
#include "btSphereBoxCollisionAlgorithm_wrap.h"

btSphereBoxCollisionAlgorithm::CreateFunc* btSphereBoxCollisionAlgorithm_CreateFunc_new()
{
	return new btSphereBoxCollisionAlgorithm::CreateFunc();
}

btSphereBoxCollisionAlgorithm* btSphereBoxCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, bool isSwapped)
{
	return new btSphereBoxCollisionAlgorithm(mf, *ci, body0Wrap, body1Wrap, isSwapped);
}

bool btSphereBoxCollisionAlgorithm_getSphereDistance(btSphereBoxCollisionAlgorithm* obj, btCollisionObjectWrapper* boxObjWrap, btScalar* v3PointOnBox, btScalar* normal, btScalar* penetrationDepth, btScalar* v3SphereCenter, btScalar fRadius, btScalar maxContactDistance)
{
	VECTOR3_CONV(v3PointOnBox);
	VECTOR3_CONV(normal);
	VECTOR3_CONV(v3SphereCenter);
	return obj->getSphereDistance(boxObjWrap, VECTOR3_USE(v3PointOnBox), VECTOR3_USE(normal), *penetrationDepth, VECTOR3_USE(v3SphereCenter), fRadius, maxContactDistance);
}

btScalar btSphereBoxCollisionAlgorithm_getSpherePenetration(btSphereBoxCollisionAlgorithm* obj, btScalar* boxHalfExtent, btScalar* sphereRelPos, btScalar* closestPoint, btScalar* normal)
{
	VECTOR3_CONV(boxHalfExtent);
	VECTOR3_CONV(sphereRelPos);
	VECTOR3_CONV(closestPoint);
	VECTOR3_CONV(normal);
	return obj->getSpherePenetration(VECTOR3_USE(boxHalfExtent), VECTOR3_USE(sphereRelPos), VECTOR3_USE(closestPoint), VECTOR3_USE(normal));
}
