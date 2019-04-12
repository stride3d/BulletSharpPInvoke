#include "conversion.h"
#include "btStridingMeshInterface_wrap.h"

void btStridingMeshInterface_calculateAabbBruteForce(btStridingMeshInterface* obj, btScalar* aabbMin, btScalar* aabbMax)
{
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->calculateAabbBruteForce(VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}

int btStridingMeshInterface_calculateSerializeBufferSize(btStridingMeshInterface* obj)
{
	return obj->calculateSerializeBufferSize();
}

void btStridingMeshInterface_getLockedReadOnlyVertexIndexBase(btStridingMeshInterface* obj, const unsigned char ** vertexbase, int* numverts, PHY_ScalarType* type, int* stride, const unsigned char** indexbase, int* indexstride, int* numfaces, PHY_ScalarType* indicestype, int subpart)
{
	obj->getLockedReadOnlyVertexIndexBase(vertexbase, *numverts, *type, *stride, indexbase, *indexstride, *numfaces, *indicestype, subpart);
}

/*
void btStridingMeshInterface_getLockedVertexIndexBase(btStridingMeshInterface* obj, * vertexbase, int* numverts, PHY_ScalarType* type, int* stride, * indexbase, int* indexstride, int* numfaces, PHY_ScalarType* indicestype, int subpart)
{
	obj->getLockedVertexIndexBase(vertexbase, *numverts, *type, *stride, indexbase, *indexstride, *numfaces, *indicestype, subpart);
}

void btStridingMeshInterface_getLockedVertexIndexBase2(btStridingMeshInterface* obj, * vertexbase, int* numverts, PHY_ScalarType* type, int* stride, * indexbase, int* indexstride, int* numfaces, PHY_ScalarType* indicestype)
{
	obj->getLockedVertexIndexBase(vertexbase, *numverts, *type, *stride, indexbase, *indexstride, *numfaces, *indicestype);
}
*/
int btStridingMeshInterface_getNumSubParts(btStridingMeshInterface* obj)
{
	return obj->getNumSubParts();
}

void btStridingMeshInterface_getPremadeAabb(btStridingMeshInterface* obj, btScalar* aabbMin, btScalar* aabbMax)
{
	VECTOR3_DEF(aabbMin);
	VECTOR3_DEF(aabbMax);
	obj->getPremadeAabb(&VECTOR3_USE(aabbMin), &VECTOR3_USE(aabbMax));
	VECTOR3_DEF_OUT(aabbMin);
	VECTOR3_DEF_OUT(aabbMax);
}

void btStridingMeshInterface_getScaling(btStridingMeshInterface* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getScaling(), value);
}

bool btStridingMeshInterface_hasPremadeAabb(btStridingMeshInterface* obj)
{
	return obj->hasPremadeAabb();
}

void btStridingMeshInterface_InternalProcessAllTriangles(btStridingMeshInterface* obj, btInternalTriangleIndexCallback* callback, btScalar* aabbMin, btScalar* aabbMax)
{
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->InternalProcessAllTriangles(callback, VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}

void btStridingMeshInterface_preallocateIndices(btStridingMeshInterface* obj, int numindices)
{
	obj->preallocateIndices(numindices);
}

void btStridingMeshInterface_preallocateVertices(btStridingMeshInterface* obj, int numverts)
{
	obj->preallocateVertices(numverts);
}

const char* btStridingMeshInterface_serialize(btStridingMeshInterface* obj, void* dataBuffer, btSerializer* serializer)
{
	return obj->serialize(dataBuffer, serializer);
}

void btStridingMeshInterface_setPremadeAabb(btStridingMeshInterface* obj, btScalar* aabbMin, btScalar* aabbMax)
{
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->setPremadeAabb(VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}

void btStridingMeshInterface_setScaling(btStridingMeshInterface* obj, btScalar* scaling)
{
	VECTOR3_CONV(scaling);
	obj->setScaling(VECTOR3_USE(scaling));
}

void btStridingMeshInterface_unLockReadOnlyVertexBase(btStridingMeshInterface* obj, int subpart)
{
	obj->unLockReadOnlyVertexBase(subpart);
}

void btStridingMeshInterface_unLockVertexBase(btStridingMeshInterface* obj, int subpart)
{
	obj->unLockVertexBase(subpart);
}

void btStridingMeshInterface_delete(btStridingMeshInterface* obj)
{
	delete obj;
}
