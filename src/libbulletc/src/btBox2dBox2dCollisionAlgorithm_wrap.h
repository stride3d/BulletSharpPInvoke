#include "main.h"

extern "C"
{
	EXPORT btBox2dBox2dCollisionAlgorithm_CreateFunc* btBox2dBox2dCollisionAlgorithm_CreateFunc_new();
	EXPORT btBox2dBox2dCollisionAlgorithm* btBox2dBox2dCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci);
	EXPORT btBox2dBox2dCollisionAlgorithm* btBox2dBox2dCollisionAlgorithm_new2(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap);
}
