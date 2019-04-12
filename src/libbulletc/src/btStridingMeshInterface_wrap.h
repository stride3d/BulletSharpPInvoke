#include "main.h"

extern "C"
{
	EXPORT void btStridingMeshInterface_calculateAabbBruteForce(btStridingMeshInterface* obj, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT int btStridingMeshInterface_calculateSerializeBufferSize(btStridingMeshInterface* obj);
	EXPORT void btStridingMeshInterface_getLockedReadOnlyVertexIndexBase(btStridingMeshInterface* obj, const unsigned char** vertexbase, int* numverts, PHY_ScalarType* type, int* stride, const unsigned char** indexbase, int* indexstride, int* numfaces, PHY_ScalarType* indicestype, int subpart);
	//EXPORT void btStridingMeshInterface_getLockedVertexIndexBase(btStridingMeshInterface* obj, * vertexbase, int* numverts, PHY_ScalarType* type, int* stride, * indexbase, int* indexstride, int* numfaces, PHY_ScalarType* indicestype, int subpart);
	//EXPORT void btStridingMeshInterface_getLockedVertexIndexBase2(btStridingMeshInterface* obj, * vertexbase, int* numverts, PHY_ScalarType* type, int* stride, * indexbase, int* indexstride, int* numfaces, PHY_ScalarType* indicestype);
	EXPORT int btStridingMeshInterface_getNumSubParts(btStridingMeshInterface* obj);
	EXPORT void btStridingMeshInterface_getPremadeAabb(btStridingMeshInterface* obj, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btStridingMeshInterface_getScaling(btStridingMeshInterface* obj, btScalar* value);
	EXPORT bool btStridingMeshInterface_hasPremadeAabb(btStridingMeshInterface* obj);
	EXPORT void btStridingMeshInterface_InternalProcessAllTriangles(btStridingMeshInterface* obj, btInternalTriangleIndexCallback* callback, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btStridingMeshInterface_preallocateIndices(btStridingMeshInterface* obj, int numindices);
	EXPORT void btStridingMeshInterface_preallocateVertices(btStridingMeshInterface* obj, int numverts);
	EXPORT const char* btStridingMeshInterface_serialize(btStridingMeshInterface* obj, void* dataBuffer, btSerializer* serializer);
	EXPORT void btStridingMeshInterface_setPremadeAabb(btStridingMeshInterface* obj, btScalar* aabbMin, btScalar* aabbMax);
	EXPORT void btStridingMeshInterface_setScaling(btStridingMeshInterface* obj, btScalar* scaling);
	EXPORT void btStridingMeshInterface_unLockReadOnlyVertexBase(btStridingMeshInterface* obj, int subpart);
	EXPORT void btStridingMeshInterface_unLockVertexBase(btStridingMeshInterface* obj, int subpart);
	EXPORT void btStridingMeshInterface_delete(btStridingMeshInterface* obj);
}
