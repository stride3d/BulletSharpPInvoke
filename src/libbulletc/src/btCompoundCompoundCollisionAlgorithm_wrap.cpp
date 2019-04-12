#include <BulletCollision/CollisionDispatch/btCollisionObjectWrapper.h>
#include <BulletCollision/CollisionDispatch/btCompoundCompoundCollisionAlgorithm.h>
#include <BulletCollision/NarrowPhaseCollision/btPersistentManifold.h>

#include "btCompoundCompoundCollisionAlgorithm_wrap.h"

btCompoundCompoundCollisionAlgorithm::CreateFunc* btCompoundCompoundCollisionAlgorithm_CreateFunc_new()
{
	return new btCompoundCompoundCollisionAlgorithm::CreateFunc();
}

btCompoundCompoundCollisionAlgorithm::SwappedCreateFunc* btCompoundCompoundCollisionAlgorithm_SwappedCreateFunc_new()
{
	return new btCompoundCompoundCollisionAlgorithm::SwappedCreateFunc();
}

btCompoundCompoundCollisionAlgorithm* btCompoundCompoundCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, bool isSwapped)
{
	return new btCompoundCompoundCollisionAlgorithm(*ci, body0Wrap, body1Wrap, isSwapped);
}
