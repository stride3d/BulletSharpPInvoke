#include "main.h"

extern "C"
{
	EXPORT btBroadphasePair* btAlignedBroadphasePairArray_at(btAlignedBroadphasePairArray* obj, int n);
	EXPORT void btAlignedBroadphasePairArray_push_back(btAlignedBroadphasePairArray* obj, btBroadphasePair* val);
	EXPORT void btAlignedBroadphasePairArray_resizeNoInitialize(btAlignedBroadphasePairArray* obj, int newSize);
	EXPORT int btAlignedBroadphasePairArray_size(btAlignedBroadphasePairArray* obj);
	EXPORT void btAlignedBroadphasePairArray_delete(btAlignedBroadphasePairArray* obj);
}
