#include "main.h"

extern "C"
{
	EXPORT btAlignedCollisionShapeArray* btAlignedCollisionShapeArray_new();
	EXPORT btCollisionShape* btAlignedCollisionShapeArray_at(btAlignedCollisionShapeArray* obj, int n);
	EXPORT void btAlignedCollisionShapeArray_push_back(btAlignedCollisionShapeArray* obj, btCollisionShape* val);
	EXPORT void btAlignedCollisionShapeArray_resizeNoInitialize(btAlignedCollisionShapeArray* obj, int newSize);
	EXPORT int btAlignedCollisionShapeArray_size(btAlignedCollisionShapeArray* obj);
	EXPORT void btAlignedCollisionShapeArray_delete(btAlignedCollisionShapeArray* obj);
}
