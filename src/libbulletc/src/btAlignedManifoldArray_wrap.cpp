#include "conversion.h"
#include "btAlignedManifoldArray_wrap.h"

EXPORT btManifoldArray* btManifoldArray_new()
{
	return new btManifoldArray();
}

btPersistentManifold* btManifoldArray_at(btManifoldArray* obj, int n)
{
	return obj->at(n);
}

void btManifoldArray_push_back(btManifoldArray* obj, btPersistentManifold* val)
{
	obj->push_back(val);
}

void btManifoldArray_resizeNoInitialize(btManifoldArray* obj, int newSize)
{
	return obj->resizeNoInitialize(newSize);
}

int btManifoldArray_size(btManifoldArray* obj)
{
	return obj->size();
}

void btManifoldArray_delete(btManifoldArray* obj)
{
	delete obj;
}
