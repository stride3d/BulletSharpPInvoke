#include "main.h"

extern "C"
{
	EXPORT btCompoundShapeChild* btCompoundShapeChild_array_at(btCompoundShapeChild* a, int n);
	EXPORT unsigned int uint_array_at(const unsigned int* a, int n);
	EXPORT void btVector3_array_at(const btVector3* a, int n, btScalar* value);
	EXPORT btAlignedVector3Array* btAlignedVector3Array_new();
	EXPORT void btAlignedVector3Array_at(btAlignedVector3Array* obj, int n, btScalar* value);
	EXPORT void btAlignedVector3Array_push_back(btAlignedVector3Array* obj, btScalar* value);
	EXPORT void btAlignedVector3Array_push_back2(btAlignedVector3Array* obj, btScalar* value); // btVector4
	EXPORT void btAlignedVector3Array_set(btAlignedVector3Array* obj, int n, btScalar* value);
	EXPORT int btAlignedVector3Array_size(btAlignedVector3Array* obj);
	EXPORT void btAlignedVector3Array_delete(btAlignedVector3Array* obj);
}
