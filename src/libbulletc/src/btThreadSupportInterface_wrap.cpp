#include <BulletMultiThreaded/btThreadSupportInterface.h>

#include "conversion.h"
#include "btThreadSupportInterface_wrap.h"

int btBarrier_getMaxCount(btBarrier* obj)
{
	return obj->getMaxCount();
}

void btBarrier_setMaxCount(btBarrier* obj, int n)
{
	obj->setMaxCount(n);
}

void btBarrier_sync(btBarrier* obj)
{
	obj->sync();
}

void btBarrier_delete(btBarrier* obj)
{
	delete obj;
}

unsigned int* btCriticalSection_getMCommonBuff(btCriticalSection* obj)
{
	return obj->mCommonBuff;
}

unsigned int btCriticalSection_getSharedParam(btCriticalSection* obj, int i)
{
	return obj->getSharedParam(i);
}

void btCriticalSection_lock(btCriticalSection* obj)
{
	obj->lock();
}
/*
void btCriticalSection_setMCommonBuff(btCriticalSection* obj, unsigned int* value)
{
	obj->mCommonBuff = value;
}
*/
void btCriticalSection_setSharedParam(btCriticalSection* obj, int i, unsigned int p)
{
	obj->setSharedParam(i, p);
}

void btCriticalSection_unlock(btCriticalSection* obj)
{
	obj->unlock();
}

void btCriticalSection_delete(btCriticalSection* obj)
{
	delete obj;
}

btBarrier* btThreadSupportInterface_createBarrier(btThreadSupportInterface* obj)
{
	return obj->createBarrier();
}

btCriticalSection* btThreadSupportInterface_createCriticalSection(btThreadSupportInterface* obj)
{
	return obj->createCriticalSection();
}

void btThreadSupportInterface_deleteBarrier(btThreadSupportInterface* obj, btBarrier* barrier)
{
	obj->deleteBarrier(barrier);
}

void btThreadSupportInterface_deleteCriticalSection(btThreadSupportInterface* obj, btCriticalSection* criticalSection)
{
	obj->deleteCriticalSection(criticalSection);
}

int btThreadSupportInterface_getNumTasks(btThreadSupportInterface* obj)
{
	return obj->getNumTasks();
}

void* btThreadSupportInterface_getThreadLocalMemory(btThreadSupportInterface* obj, int taskId)
{
	return obj->getThreadLocalMemory(taskId);
}

void btThreadSupportInterface_sendRequest(btThreadSupportInterface* obj, unsigned int uiCommand, ppu_address_t uiArgument0, unsigned int uiArgument1)
{
	obj->sendRequest(uiCommand, uiArgument0, uiArgument1);
}

void btThreadSupportInterface_setNumTasks(btThreadSupportInterface* obj, int numTasks)
{
	obj->setNumTasks(numTasks);
}

void btThreadSupportInterface_startSPU(btThreadSupportInterface* obj)
{
	obj->startSPU();
}

void btThreadSupportInterface_stopSPU(btThreadSupportInterface* obj)
{
	obj->stopSPU();
}

void btThreadSupportInterface_waitForResponse(btThreadSupportInterface* obj, unsigned int* puiArgument0, unsigned int* puiArgument1)
{
	obj->waitForResponse(puiArgument0, puiArgument1);
}

void btThreadSupportInterface_delete(btThreadSupportInterface* obj)
{
	delete obj;
}
