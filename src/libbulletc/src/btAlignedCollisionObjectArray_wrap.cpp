#include "conversion.h"
#include "btAlignedCollisionObjectArray_wrap.h"

btCollisionObject* btAlignedCollisionObjectArray_at(btAlignedCollisionObjectArray* obj, int n)
{
	return obj->at(n);
}

void btAlignedCollisionObjectArray_push_back(btAlignedCollisionObjectArray* obj, btCollisionObject* val)
{
	obj->push_back(val);
}

void btAlignedCollisionObjectArray_resizeNoInitialize(btAlignedCollisionObjectArray* obj, int newSize)
{
	return obj->resizeNoInitialize(newSize);
}

int btAlignedCollisionObjectArray_size(btAlignedCollisionObjectArray* obj)
{
	return obj->size();
}

void btAlignedCollisionObjectArray_delete(btAlignedCollisionObjectArray* obj)
{
	delete obj;
}
