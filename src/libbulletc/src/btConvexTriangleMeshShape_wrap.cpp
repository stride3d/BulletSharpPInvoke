#include "conversion.h"
#include "btConvexTriangleMeshShape_wrap.h"

btConvexTriangleMeshShape* btConvexTriangleMeshShape_new(btStridingMeshInterface* meshInterface, bool calcAabb)
{
	return new btConvexTriangleMeshShape(meshInterface, calcAabb);
}

btConvexTriangleMeshShape* btConvexTriangleMeshShape_new2(btStridingMeshInterface* meshInterface)
{
	return new btConvexTriangleMeshShape(meshInterface);
}

void btConvexTriangleMeshShape_calculatePrincipalAxisTransform(btConvexTriangleMeshShape* obj, btScalar* principal, btScalar* inertia, btScalar* volume)
{
	TRANSFORM_CONV(principal);
	VECTOR3_CONV(inertia);
	obj->calculatePrincipalAxisTransform(TRANSFORM_USE(principal), VECTOR3_USE(inertia), *volume);
}

btStridingMeshInterface* btConvexTriangleMeshShape_getMeshInterface(btConvexTriangleMeshShape* obj)
{
	return obj->getMeshInterface();
}
