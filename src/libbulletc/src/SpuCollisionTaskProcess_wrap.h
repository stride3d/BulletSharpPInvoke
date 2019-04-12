#include "main.h"

extern "C"
{
	EXPORT SpuGatherAndProcessWorkUnitInput* SpuGatherAndProcessWorkUnitInput_new();
	EXPORT int SpuGatherAndProcessWorkUnitInput_getEndIndex(SpuGatherAndProcessWorkUnitInput* obj);
	EXPORT unsigned long SpuGatherAndProcessWorkUnitInput_getPairArrayPtr(SpuGatherAndProcessWorkUnitInput* obj);
	EXPORT int SpuGatherAndProcessWorkUnitInput_getStartIndex(SpuGatherAndProcessWorkUnitInput* obj);
	EXPORT void SpuGatherAndProcessWorkUnitInput_setEndIndex(SpuGatherAndProcessWorkUnitInput* obj, int value);
	EXPORT void SpuGatherAndProcessWorkUnitInput_setPairArrayPtr(SpuGatherAndProcessWorkUnitInput* obj, unsigned long value);
	EXPORT void SpuGatherAndProcessWorkUnitInput_setStartIndex(SpuGatherAndProcessWorkUnitInput* obj, int value);
	EXPORT void SpuGatherAndProcessWorkUnitInput_delete(SpuGatherAndProcessWorkUnitInput* obj);

	EXPORT SpuCollisionTaskProcess* SpuCollisionTaskProcess_new(btThreadSupportInterface* threadInterface, unsigned int maxNumOutstandingTasks);
	EXPORT void SpuCollisionTaskProcess_addWorkToTask(SpuCollisionTaskProcess* obj, void* pairArrayPtr, int startIndex, int endIndex);
	EXPORT void SpuCollisionTaskProcess_flush2(SpuCollisionTaskProcess* obj);
	EXPORT int SpuCollisionTaskProcess_getNumTasks(SpuCollisionTaskProcess* obj);
	EXPORT void SpuCollisionTaskProcess_initialize2(SpuCollisionTaskProcess* obj, bool useEpa);
	EXPORT void SpuCollisionTaskProcess_initialize22(SpuCollisionTaskProcess* obj);
	EXPORT void SpuCollisionTaskProcess_setNumTasks(SpuCollisionTaskProcess* obj, int maxNumTasks);
	EXPORT void SpuCollisionTaskProcess_delete(SpuCollisionTaskProcess* obj);
}
