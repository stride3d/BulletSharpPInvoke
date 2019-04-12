#include "main.h"

extern "C"
{
	EXPORT btSoftRigidCollisionAlgorithm_CreateFunc* btSoftRigidCollisionAlgorithm_CreateFunc_new();
	EXPORT btSoftRigidCollisionAlgorithm* btSoftRigidCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* col0, btCollisionObjectWrapper* col1Wrap, bool isSwapped);
}
