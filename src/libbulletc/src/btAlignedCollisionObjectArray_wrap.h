#include "main.h"

extern "C"
{
	EXPORT btCollisionObject* btAlignedCollisionObjectArray_at(btAlignedCollisionObjectArray* obj, int n);
	EXPORT void btAlignedCollisionObjectArray_push_back(btAlignedCollisionObjectArray* obj, btCollisionObject* val);
	EXPORT void btAlignedCollisionObjectArray_resizeNoInitialize(btAlignedCollisionObjectArray* obj, int newSize);
	EXPORT int btAlignedCollisionObjectArray_size(btAlignedCollisionObjectArray* obj);
	EXPORT void btAlignedCollisionObjectArray_delete(btAlignedCollisionObjectArray* obj);
}
