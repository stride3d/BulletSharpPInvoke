#include <BulletMultiThreaded/SpuCollisionTaskProcess.h>

#include "conversion.h"
#include "SpuCollisionTaskProcess_wrap.h"

SpuGatherAndProcessWorkUnitInput* SpuGatherAndProcessWorkUnitInput_new()
{
	return new SpuGatherAndProcessWorkUnitInput();
}

int SpuGatherAndProcessWorkUnitInput_getEndIndex(SpuGatherAndProcessWorkUnitInput* obj)
{
	return obj->m_endIndex;
}

unsigned long SpuGatherAndProcessWorkUnitInput_getPairArrayPtr(SpuGatherAndProcessWorkUnitInput* obj)
{
	return obj->m_pairArrayPtr;
}

int SpuGatherAndProcessWorkUnitInput_getStartIndex(SpuGatherAndProcessWorkUnitInput* obj)
{
	return obj->m_startIndex;
}

void SpuGatherAndProcessWorkUnitInput_setEndIndex(SpuGatherAndProcessWorkUnitInput* obj, int value)
{
	obj->m_endIndex = value;
}

void SpuGatherAndProcessWorkUnitInput_setPairArrayPtr(SpuGatherAndProcessWorkUnitInput* obj, unsigned long value)
{
	obj->m_pairArrayPtr = value;
}

void SpuGatherAndProcessWorkUnitInput_setStartIndex(SpuGatherAndProcessWorkUnitInput* obj, int value)
{
	obj->m_startIndex = value;
}

void SpuGatherAndProcessWorkUnitInput_delete(SpuGatherAndProcessWorkUnitInput* obj)
{
	delete obj;
}

SpuCollisionTaskProcess* SpuCollisionTaskProcess_new(btThreadSupportInterface* threadInterface, unsigned int maxNumOutstandingTasks)
{
	return new SpuCollisionTaskProcess(threadInterface, maxNumOutstandingTasks);
}

void SpuCollisionTaskProcess_addWorkToTask(SpuCollisionTaskProcess* obj, void* pairArrayPtr, int startIndex, int endIndex)
{
	obj->addWorkToTask(pairArrayPtr, startIndex, endIndex);
}

void SpuCollisionTaskProcess_flush2(SpuCollisionTaskProcess* obj)
{
	obj->flush2();
}

int SpuCollisionTaskProcess_getNumTasks(SpuCollisionTaskProcess* obj)
{
	return obj->getNumTasks();
}

void SpuCollisionTaskProcess_initialize2(SpuCollisionTaskProcess* obj, bool useEpa)
{
	obj->initialize2(useEpa);
}

void SpuCollisionTaskProcess_initialize22(SpuCollisionTaskProcess* obj)
{
	obj->initialize2();
}

void SpuCollisionTaskProcess_setNumTasks(SpuCollisionTaskProcess* obj, int maxNumTasks)
{
	obj->setNumTasks(maxNumTasks);
}

void SpuCollisionTaskProcess_delete(SpuCollisionTaskProcess* obj)
{
	delete obj;
}
