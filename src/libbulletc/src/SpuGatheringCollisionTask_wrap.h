#include "main.h"

extern "C"
{
	EXPORT SpuGatherAndProcessPairsTaskDesc* SpuGatherAndProcessPairsTaskDesc_new();
	EXPORT ppu_address_t SpuGatherAndProcessPairsTaskDesc_getDispatcher(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT ppu_address_t SpuGatherAndProcessPairsTaskDesc_getInPairPtr(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT CollisionTask_LocalStoreMemory* SpuGatherAndProcessPairsTaskDesc_getLsMemory(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT unsigned int SpuGatherAndProcessPairsTaskDesc_getNumOnLastPage(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT unsigned short SpuGatherAndProcessPairsTaskDesc_getNumPages(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT unsigned int SpuGatherAndProcessPairsTaskDesc_getSomeMutexVariableInMainMemory(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT unsigned short SpuGatherAndProcessPairsTaskDesc_getTaskId(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT bool SpuGatherAndProcessPairsTaskDesc_getUseEpa(SpuGatherAndProcessPairsTaskDesc* obj);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setDispatcher(SpuGatherAndProcessPairsTaskDesc* obj, ppu_address_t value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setInPairPtr(SpuGatherAndProcessPairsTaskDesc* obj, ppu_address_t value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setLsMemory(SpuGatherAndProcessPairsTaskDesc* obj, CollisionTask_LocalStoreMemory* value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setNumOnLastPage(SpuGatherAndProcessPairsTaskDesc* obj, unsigned int value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setNumPages(SpuGatherAndProcessPairsTaskDesc* obj, unsigned short value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setSomeMutexVariableInMainMemory(SpuGatherAndProcessPairsTaskDesc* obj, unsigned int value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setTaskId(SpuGatherAndProcessPairsTaskDesc* obj, unsigned short value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_setUseEpa(SpuGatherAndProcessPairsTaskDesc* obj, bool value);
	EXPORT void SpuGatherAndProcessPairsTaskDesc_delete(SpuGatherAndProcessPairsTaskDesc* obj);
}
