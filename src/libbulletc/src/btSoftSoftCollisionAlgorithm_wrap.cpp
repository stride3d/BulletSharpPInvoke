#include <BulletCollision/CollisionDispatch/btCollisionObjectWrapper.h>
#include <BulletCollision/NarrowPhaseCollision/btPersistentManifold.h>
#include <BulletSoftBody/btSoftSoftCollisionAlgorithm.h>

#include "btSoftSoftCollisionAlgorithm_wrap.h"

btSoftSoftCollisionAlgorithm::CreateFunc* btSoftSoftCollisionAlgorithm_CreateFunc_new()
{
	return new btSoftSoftCollisionAlgorithm::CreateFunc();
}

btSoftSoftCollisionAlgorithm* btSoftSoftCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci)
{
	return new btSoftSoftCollisionAlgorithm(*ci);
}

btSoftSoftCollisionAlgorithm* btSoftSoftCollisionAlgorithm_new2(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap)
{
	return new btSoftSoftCollisionAlgorithm(mf, *ci, body0Wrap, body1Wrap);
}
