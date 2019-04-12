#include <BulletMultiThreaded/SpuGatheringCollisionDispatcher.h>
#include <BulletMultiThreaded/btThreadSupportInterface.h>

#include "conversion.h"
#include "SpuGatheringCollisionDispatcher_wrap.h"

SpuGatheringCollisionDispatcher* SpuGatheringCollisionDispatcher_new(btThreadSupportInterface* threadInterface, unsigned int maxNumOutstandingTasks, btCollisionConfiguration* collisionConfiguration)
{
	return new SpuGatheringCollisionDispatcher(threadInterface, maxNumOutstandingTasks, collisionConfiguration);
}

SpuCollisionTaskProcess* SpuGatheringCollisionDispatcher_getSpuCollisionTaskProcess(SpuGatheringCollisionDispatcher* obj)
{
	return obj->getSpuCollisionTaskProcess();
}

bool SpuGatheringCollisionDispatcher_supportsDispatchPairOnSpu(SpuGatheringCollisionDispatcher* obj, int proxyType0, int proxyType1)
{
	return obj->supportsDispatchPairOnSpu(proxyType0, proxyType1);
}
