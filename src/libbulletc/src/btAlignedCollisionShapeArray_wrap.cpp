#include "conversion.h"
#include "btAlignedCollisionShapeArray_wrap.h"

EXPORT btAlignedCollisionShapeArray* btAlignedCollisionShapeArray_new()
{
	return new btAlignedCollisionShapeArray();
}

void btAlignedCollisionShapeArray_push_back(btAlignedCollisionShapeArray* obj, btCollisionShape* val)
{
	obj->push_back(val);
}

btCollisionShape* btAlignedCollisionShapeArray_at(btAlignedCollisionShapeArray* obj, int n)
{
	return obj->at(n);
}

void btAlignedCollisionShapeArray_resizeNoInitialize(btAlignedCollisionShapeArray* obj, int newSize)
{
	return obj->resizeNoInitialize(newSize);
}

int btAlignedCollisionShapeArray_size(btAlignedCollisionShapeArray* obj)
{
	return obj->size();
}

void btAlignedCollisionShapeArray_delete(btAlignedCollisionShapeArray* obj)
{
	delete obj;
}
