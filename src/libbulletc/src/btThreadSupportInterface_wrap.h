#include "main.h"

extern "C"
{
	EXPORT int btBarrier_getMaxCount(btBarrier* obj);
	EXPORT void btBarrier_setMaxCount(btBarrier* obj, int n);
	EXPORT void btBarrier_sync(btBarrier* obj);
	EXPORT void btBarrier_delete(btBarrier* obj);

	EXPORT unsigned int* btCriticalSection_getMCommonBuff(btCriticalSection* obj);
	EXPORT unsigned int btCriticalSection_getSharedParam(btCriticalSection* obj, int i);
	EXPORT void btCriticalSection_lock(btCriticalSection* obj);
	//EXPORT void btCriticalSection_setMCommonBuff(btCriticalSection* obj, unsigned int* value);
	EXPORT void btCriticalSection_setSharedParam(btCriticalSection* obj, int i, unsigned int p);
	EXPORT void btCriticalSection_unlock(btCriticalSection* obj);
	EXPORT void btCriticalSection_delete(btCriticalSection* obj);

	EXPORT btBarrier* btThreadSupportInterface_createBarrier(btThreadSupportInterface* obj);
	EXPORT btCriticalSection* btThreadSupportInterface_createCriticalSection(btThreadSupportInterface* obj);
	EXPORT void btThreadSupportInterface_deleteBarrier(btThreadSupportInterface* obj, btBarrier* barrier);
	EXPORT void btThreadSupportInterface_deleteCriticalSection(btThreadSupportInterface* obj, btCriticalSection* criticalSection);
	EXPORT int btThreadSupportInterface_getNumTasks(btThreadSupportInterface* obj);
	EXPORT void* btThreadSupportInterface_getThreadLocalMemory(btThreadSupportInterface* obj, int taskId);
	EXPORT void btThreadSupportInterface_sendRequest(btThreadSupportInterface* obj, unsigned int uiCommand, ppu_address_t uiArgument0, unsigned int uiArgument1);
	EXPORT void btThreadSupportInterface_setNumTasks(btThreadSupportInterface* obj, int numTasks);
	EXPORT void btThreadSupportInterface_startSPU(btThreadSupportInterface* obj);
	EXPORT void btThreadSupportInterface_stopSPU(btThreadSupportInterface* obj);
	EXPORT void btThreadSupportInterface_waitForResponse(btThreadSupportInterface* obj, unsigned int* puiArgument0, unsigned int* puiArgument1);
	EXPORT void btThreadSupportInterface_delete(btThreadSupportInterface* obj);
}
