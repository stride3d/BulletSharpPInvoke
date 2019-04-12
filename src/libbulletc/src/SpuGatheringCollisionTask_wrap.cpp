#include <BulletMultiThreaded/SpuNarrowPhaseCollisionTask/SpuGatheringCollisionTask.h>

#include "conversion.h"
#include "SpuGatheringCollisionTask_wrap.h"

SpuGatherAndProcessPairsTaskDesc* SpuGatherAndProcessPairsTaskDesc_new()
{
	return new SpuGatherAndProcessPairsTaskDesc();
}

ppu_address_t SpuGatherAndProcessPairsTaskDesc_getDispatcher(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->m_dispatcher;
}

ppu_address_t SpuGatherAndProcessPairsTaskDesc_getInPairPtr(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->m_inPairPtr;
}

CollisionTask_LocalStoreMemory* SpuGatherAndProcessPairsTaskDesc_getLsMemory(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->m_lsMemory;
}

unsigned int SpuGatherAndProcessPairsTaskDesc_getNumOnLastPage(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->numOnLastPage;
}

unsigned short SpuGatherAndProcessPairsTaskDesc_getNumPages(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->numPages;
}

unsigned int SpuGatherAndProcessPairsTaskDesc_getSomeMutexVariableInMainMemory(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->m_someMutexVariableInMainMemory;
}

unsigned short SpuGatherAndProcessPairsTaskDesc_getTaskId(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->taskId;
}

bool SpuGatherAndProcessPairsTaskDesc_getUseEpa(SpuGatherAndProcessPairsTaskDesc* obj)
{
	return obj->m_useEpa;
}

void SpuGatherAndProcessPairsTaskDesc_setDispatcher(SpuGatherAndProcessPairsTaskDesc* obj, ppu_address_t value)
{
	obj->m_dispatcher = value;
}

void SpuGatherAndProcessPairsTaskDesc_setInPairPtr(SpuGatherAndProcessPairsTaskDesc* obj, ppu_address_t value)
{
	obj->m_inPairPtr = value;
}

void SpuGatherAndProcessPairsTaskDesc_setLsMemory(SpuGatherAndProcessPairsTaskDesc* obj, CollisionTask_LocalStoreMemory* value)
{
	obj->m_lsMemory = value;
}

void SpuGatherAndProcessPairsTaskDesc_setNumOnLastPage(SpuGatherAndProcessPairsTaskDesc* obj, unsigned int value)
{
	obj->numOnLastPage = value;
}

void SpuGatherAndProcessPairsTaskDesc_setNumPages(SpuGatherAndProcessPairsTaskDesc* obj, unsigned short value)
{
	obj->numPages = value;
}

void SpuGatherAndProcessPairsTaskDesc_setSomeMutexVariableInMainMemory(SpuGatherAndProcessPairsTaskDesc* obj, unsigned int value)
{
	obj->m_someMutexVariableInMainMemory = value;
}

void SpuGatherAndProcessPairsTaskDesc_setTaskId(SpuGatherAndProcessPairsTaskDesc* obj, unsigned short value)
{
	obj->taskId = value;
}

void SpuGatherAndProcessPairsTaskDesc_setUseEpa(SpuGatherAndProcessPairsTaskDesc* obj, bool value)
{
	obj->m_useEpa = value;
}

void SpuGatherAndProcessPairsTaskDesc_delete(SpuGatherAndProcessPairsTaskDesc* obj)
{
	delete obj;
}
