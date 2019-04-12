#include "main.h"

extern "C"
{
	EXPORT btSphereSphereCollisionAlgorithm_CreateFunc* btSphereSphereCollisionAlgorithm_CreateFunc_new();
	EXPORT btSphereSphereCollisionAlgorithm* btSphereSphereCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* col0Wrap, btCollisionObjectWrapper* col1Wrap);
	EXPORT btSphereSphereCollisionAlgorithm* btSphereSphereCollisionAlgorithm_new2(btCollisionAlgorithmConstructionInfo* ci);
}
