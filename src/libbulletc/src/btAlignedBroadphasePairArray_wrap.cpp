#include "conversion.h"
#include "btAlignedBroadphasePairArray_wrap.h"

btBroadphasePair* btAlignedBroadphasePairArray_at(btAlignedBroadphasePairArray* obj, int n)
{
	return &obj->at(n);
}

void btAlignedBroadphasePairArray_push_back(btAlignedBroadphasePairArray* obj, btBroadphasePair* val)
{
	obj->push_back(*val);
}

void btAlignedBroadphasePairArray_resizeNoInitialize(btAlignedBroadphasePairArray* obj, int newSize)
{
	return obj->resizeNoInitialize(newSize);
}

int btAlignedBroadphasePairArray_size(btAlignedBroadphasePairArray* obj)
{
	return obj->size();
}

void btAlignedBroadphasePairArray_delete(btAlignedBroadphasePairArray* obj)
{
	delete obj;
}
