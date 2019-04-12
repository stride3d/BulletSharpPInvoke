#include <BulletCollision/CollisionDispatch/btSphereTriangleCollisionAlgorithm.h>

#include "btSphereTriangleCollisionAlgorithm_wrap.h"

btSphereTriangleCollisionAlgorithm::CreateFunc* btSphereTriangleCollisionAlgorithm_CreateFunc_new()
{
	return new btSphereTriangleCollisionAlgorithm::CreateFunc();
}

btSphereTriangleCollisionAlgorithm* btSphereTriangleCollisionAlgorithm_new(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, bool swapped)
{
	return new btSphereTriangleCollisionAlgorithm(mf, *ci, body0Wrap, body1Wrap, swapped);
}

btSphereTriangleCollisionAlgorithm* btSphereTriangleCollisionAlgorithm_new2(btCollisionAlgorithmConstructionInfo* ci)
{
	return new btSphereTriangleCollisionAlgorithm(*ci);
}
