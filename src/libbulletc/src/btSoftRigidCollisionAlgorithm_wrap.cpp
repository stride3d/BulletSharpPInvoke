#include <BulletSoftBody/btSoftRigidCollisionAlgorithm.h>

#include "btSoftRigidCollisionAlgorithm_wrap.h"

btSoftRigidCollisionAlgorithm::CreateFunc* btSoftRigidCollisionAlgorithm_CreateFunc_new()
{
	return new btSoftRigidCollisionAlgorithm::CreateFunc();
}

btSoftRigidCollisionAlgorithm* btSoftRigidCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* col0, btCollisionObjectWrapper* col1Wrap, bool isSwapped)
{
	return new btSoftRigidCollisionAlgorithm(mf, *ci, col0, col1Wrap, isSwapped);
}
