#include "conversion.h"
#include "btTriangleMesh_wrap.h"

btTriangleMesh* btTriangleMesh_new(bool use32bitIndices, bool use4componentVertices)
{
	return new btTriangleMesh(use32bitIndices, use4componentVertices);
}

btTriangleMesh* btTriangleMesh_new2(bool use32bitIndices)
{
	return new btTriangleMesh(use32bitIndices);
}

btTriangleMesh* btTriangleMesh_new3()
{
	return new btTriangleMesh();
}

void btTriangleMesh_addIndex(btTriangleMesh* obj, int index)
{
	obj->addIndex(index);
}

void btTriangleMesh_addTriangle(btTriangleMesh* obj, btScalar* vertex0, btScalar* vertex1, btScalar* vertex2, bool removeDuplicateVertices)
{
	VECTOR3_CONV(vertex0);
	VECTOR3_CONV(vertex1);
	VECTOR3_CONV(vertex2);
	obj->addTriangle(VECTOR3_USE(vertex0), VECTOR3_USE(vertex1), VECTOR3_USE(vertex2), removeDuplicateVertices);
}

void btTriangleMesh_addTriangle2(btTriangleMesh* obj, btScalar* vertex0, btScalar* vertex1, btScalar* vertex2)
{
	VECTOR3_CONV(vertex0);
	VECTOR3_CONV(vertex1);
	VECTOR3_CONV(vertex2);
	obj->addTriangle(VECTOR3_USE(vertex0), VECTOR3_USE(vertex1), VECTOR3_USE(vertex2));
}

int btTriangleMesh_findOrAddVertex(btTriangleMesh* obj, btScalar* vertex, bool removeDuplicateVertices)
{
	VECTOR3_CONV(vertex);
	return obj->findOrAddVertex(VECTOR3_USE(vertex), removeDuplicateVertices);
}

int btTriangleMesh_getNumTriangles(btTriangleMesh* obj)
{
	return obj->getNumTriangles();
}

bool btTriangleMesh_getUse32bitIndices(btTriangleMesh* obj)
{
	return obj->getUse32bitIndices();
}

bool btTriangleMesh_getUse4componentVertices(btTriangleMesh* obj)
{
	return obj->getUse4componentVertices();
}

btScalar btTriangleMesh_getWeldingThreshold(btTriangleMesh* obj)
{
	return obj->m_weldingThreshold;
}

void btTriangleMesh_setWeldingThreshold(btTriangleMesh* obj, btScalar value)
{
	obj->m_weldingThreshold = value;
}
