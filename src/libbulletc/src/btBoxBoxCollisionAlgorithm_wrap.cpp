#include <BulletCollision/CollisionDispatch/btBoxBoxCollisionAlgorithm.h>
#include <BulletCollision/CollisionDispatch/btCollisionObjectWrapper.h>
#include <BulletCollision/NarrowPhaseCollision/btPersistentManifold.h>

#include "btBoxBoxCollisionAlgorithm_wrap.h"

btBoxBoxCollisionAlgorithm::CreateFunc* btBoxBoxCollisionAlgorithm_CreateFunc_new()
{
	return new btBoxBoxCollisionAlgorithm::CreateFunc();
}

btBoxBoxCollisionAlgorithm* btBoxBoxCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci)
{
	return new btBoxBoxCollisionAlgorithm(*ci);
}

btBoxBoxCollisionAlgorithm* btBoxBoxCollisionAlgorithm_new2(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap)
{
	return new btBoxBoxCollisionAlgorithm(mf, *ci, body0Wrap, body1Wrap);
}
