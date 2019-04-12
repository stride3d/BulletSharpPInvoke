#include "main.h"

extern "C"
{
	EXPORT btSoftSoftCollisionAlgorithm::CreateFunc* btSoftSoftCollisionAlgorithm_CreateFunc_new();
	EXPORT btSoftSoftCollisionAlgorithm* btSoftSoftCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci);
	EXPORT btSoftSoftCollisionAlgorithm* btSoftSoftCollisionAlgorithm_new2(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap);
}
