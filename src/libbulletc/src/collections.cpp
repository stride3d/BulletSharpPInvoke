#include "conversion.h"
#include "collections.h"

btCompoundShapeChild* btCompoundShapeChild_array_at(btCompoundShapeChild* a, int n)
{
	return &a[n];
}

unsigned int uint_array_at(const unsigned int* a, int n)
{
	return a[n];
}

void btVector3_array_at(const btVector3* a, int n, btScalar* value)
{
	VECTOR3_OUT(&a[n], value);
}

btAlignedVector3Array* btAlignedVector3Array_new()
{
	return new btAlignedVector3Array();
}

void btAlignedVector3Array_at(btAlignedVector3Array* obj, int n, btScalar* value)
{
	VECTOR3_OUT(&obj->at(n), value);
}

void btAlignedVector3Array_push_back(btAlignedVector3Array* obj, btScalar* value)
{
	VECTOR3_DEF(value);
	obj->push_back(VECTOR3_USE(value));
}

void btAlignedVector3Array_push_back2(btAlignedVector3Array* obj, btScalar* value) // btVector4
{
	//VECTOR4_DEF(value);
	//obj->push_back(VECTOR4_USE(value));
	ATTRIBUTE_ALIGNED16(btVector4) valueTemp = btVector4(value[0], value[1], value[2], value[3]);
	obj->push_back(valueTemp);
}

void btAlignedVector3Array_set(btAlignedVector3Array* obj, int n, btScalar* value)
{
	VECTOR3_IN(value, &obj->at(n));
}

int btAlignedVector3Array_size(btAlignedVector3Array* obj)
{
	return obj->size();
}

void btAlignedVector3Array_delete(btAlignedVector3Array* obj)
{
	delete obj;
}
