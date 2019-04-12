#include "main.h"

extern "C"
{
	EXPORT btSphereTriangleCollisionAlgorithm_CreateFunc* btSphereTriangleCollisionAlgorithm_CreateFunc_new();
	EXPORT btSphereTriangleCollisionAlgorithm* btSphereTriangleCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, bool swapped);
	EXPORT btSphereTriangleCollisionAlgorithm* btSphereTriangleCollisionAlgorithm_new2(btCollisionAlgorithmConstructionInfo* ci);
}
