#include "main.h"

extern "C"
{
	EXPORT btConvexTriangleMeshShape* btConvexTriangleMeshShape_new(btStridingMeshInterface* meshInterface, bool calcAabb);
	EXPORT btConvexTriangleMeshShape* btConvexTriangleMeshShape_new2(btStridingMeshInterface* meshInterface);
	EXPORT void btConvexTriangleMeshShape_calculatePrincipalAxisTransform(btConvexTriangleMeshShape* obj, btScalar* principal, btScalar* inertia, btScalar* volume);
	EXPORT btStridingMeshInterface* btConvexTriangleMeshShape_getMeshInterface(btConvexTriangleMeshShape* obj);
}
