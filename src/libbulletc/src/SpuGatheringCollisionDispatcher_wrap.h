#include "main.h"

extern "C"
{
	EXPORT SpuGatheringCollisionDispatcher* SpuGatheringCollisionDispatcher_new(btThreadSupportInterface* threadInterface, unsigned int maxNumOutstandingTasks, btCollisionConfiguration* collisionConfiguration);
	EXPORT SpuCollisionTaskProcess* SpuGatheringCollisionDispatcher_getSpuCollisionTaskProcess(SpuGatheringCollisionDispatcher* obj);
	EXPORT bool SpuGatheringCollisionDispatcher_supportsDispatchPairOnSpu(SpuGatheringCollisionDispatcher* obj, int proxyType0, int proxyType1);
}
