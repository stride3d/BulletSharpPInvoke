#include "main.h"

extern "C"
{
	EXPORT btManifoldArray* btManifoldArray_new();
	EXPORT btPersistentManifold* btManifoldArray_at(btManifoldArray* obj, int n);
	EXPORT void btManifoldArray_push_back(btManifoldArray* obj, btPersistentManifold* val);
	EXPORT void btManifoldArray_resizeNoInitialize(btManifoldArray* obj, int newSize);
	EXPORT int btManifoldArray_size(btManifoldArray* obj);
	EXPORT void btManifoldArray_delete(btManifoldArray* obj);
}
