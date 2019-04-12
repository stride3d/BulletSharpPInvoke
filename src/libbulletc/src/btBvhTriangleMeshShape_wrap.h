#include "main.h"

extern "C"
{
	EXPORT btBvhTriangleMeshShape* btBvhTriangleMeshShape_new(btStridingMeshInterface* meshInterface, bool useQuantizedAabbCompression, bool buildBvh);
	EXPORT btBvhTriangleMeshShape* btBvhTriangleMeshShape_new2(btStridingMeshInterface* meshInterface, bool useQuantizedAabbCompression);
	EXPORT btBvhTriangleMeshShape* btBvhTriangleMeshShape_new3(btStridingMeshInterface* meshInterface, bool useQuantizedAabbCompression, btScalar* bvhAabbMin, btScalar* bvhAabbMax, bool buildBvh);
	EXPORT btBvhTriangleMeshShape* btBvhTriangleMeshShape_new4(btStridingMeshInterface* meshInterface, bool useQuantizedAabbCompression, btScalar* bvhAabbMin, btScalar* bvhAabbMax);
	EXPORT void btBvhTriangleMeshShape_buildOptimizedBvh(btBvhTriangleMeshShape* obj);
	EXPORT btOptimizedBvh* btBvhTriangleMeshShape_getOptimizedBvh(btBvhTriangleMeshShape* obj);
	EXPORT bool btBvhTriangleMeshShape_getOwnsBvh(btBvhTriangleMeshShape* obj);
	EXPORT btTriangleInfoMap* btBvhTriangleMeshShape_getTriangleInfoMap(btBvhTriangleMeshShape* obj);
	EXPORT void btBvhTriangleMeshShape_partialRefitTree(btBvhTriangleMeshShape* obj, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btBvhTriangleMeshShape_performConvexcast(btBvhTriangleMeshShape* obj, btTriangleCallback* callback, btScalar* boxSource, btScalar* boxTarget, btScalar* boxMin, btScalar* boxMax);
	EXPORT void btBvhTriangleMeshShape_performRaycast(btBvhTriangleMeshShape* obj, btTriangleCallback* callback, btScalar* raySource, btScalar* rayTarget);
	EXPORT void btBvhTriangleMeshShape_refitTree(btBvhTriangleMeshShape* obj, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btBvhTriangleMeshShape_serializeSingleBvh(btBvhTriangleMeshShape* obj, btSerializer* serializer);
	EXPORT void btBvhTriangleMeshShape_serializeSingleTriangleInfoMap(btBvhTriangleMeshShape* obj, btSerializer* serializer);
	EXPORT void btBvhTriangleMeshShape_setOptimizedBvh(btBvhTriangleMeshShape* obj, btOptimizedBvh* bvh, btScalar* localScaling);
	EXPORT void btBvhTriangleMeshShape_setOptimizedBvh2(btBvhTriangleMeshShape* obj, btOptimizedBvh* bvh);
	EXPORT void btBvhTriangleMeshShape_setTriangleInfoMap(btBvhTriangleMeshShape* obj, btTriangleInfoMap* triangleInfoMap);
	EXPORT bool btBvhTriangleMeshShape_usesQuantizedAabbCompression(btBvhTriangleMeshShape* obj);
}
