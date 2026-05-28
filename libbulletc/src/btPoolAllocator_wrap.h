#include "main.h"

class btPoolAllocator;

#ifdef __cplusplus
extern "C" {
#endif
	EXPORT btPoolAllocator* btPoolAllocator_new(int elemSize, int maxElements);
	EXPORT void* btPoolAllocator_allocate(btPoolAllocator* obj, int size);
	EXPORT void btPoolAllocator_freeMemory(btPoolAllocator* obj, void* ptr);
	EXPORT int btPoolAllocator_getElementSize(btPoolAllocator* obj);
	EXPORT int btPoolAllocator_getFreeCount(btPoolAllocator* obj);
	EXPORT int btPoolAllocator_getMaxCount(btPoolAllocator* obj);
	EXPORT void* btPoolAllocator_getPoolAddress(btPoolAllocator* obj);
	EXPORT int btPoolAllocator_getUsedCount(btPoolAllocator* obj);
	EXPORT bool btPoolAllocator_validPtr(btPoolAllocator* obj, void* ptr);
	EXPORT void btPoolAllocator_delete(btPoolAllocator* obj);
#ifdef __cplusplus
}
#endif
