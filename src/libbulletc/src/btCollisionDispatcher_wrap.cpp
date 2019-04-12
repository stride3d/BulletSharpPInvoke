#include "conversion.h"
#include "btCollisionDispatcher_wrap.h"

btCollisionDispatcher* btCollisionDispatcher_new(btCollisionConfiguration* collisionConfiguration)
{
	return new btCollisionDispatcher(collisionConfiguration);
}

void btCollisionDispatcher_defaultNearCallback(btBroadphasePair* collisionPair, btCollisionDispatcher* dispatcher, btDispatcherInfo* dispatchInfo)
{
	btCollisionDispatcher::defaultNearCallback(*collisionPair, *dispatcher, *dispatchInfo);
}

btCollisionConfiguration* btCollisionDispatcher_getCollisionConfiguration(btCollisionDispatcher* obj)
{
	return obj->getCollisionConfiguration();
}

btCollisionConfiguration* btCollisionDispatcher_getCollisionConfiguration2(btCollisionDispatcher* obj)
{
	return obj->getCollisionConfiguration();
}

int btCollisionDispatcher_getDispatcherFlags(btCollisionDispatcher* obj)
{
	return obj->getDispatcherFlags();
}
/*
* btCollisionDispatcher_getNearCallback(btCollisionDispatcher* obj)
{
	return obj->getNearCallback();
}
*/
void btCollisionDispatcher_registerCollisionCreateFunc(btCollisionDispatcher* obj, int proxyType0, int proxyType1, btCollisionAlgorithmCreateFunc* createFunc)
{
	obj->registerCollisionCreateFunc(proxyType0, proxyType1, createFunc);
}

void btCollisionDispatcher_setCollisionConfiguration(btCollisionDispatcher* obj, btCollisionConfiguration* config)
{
	obj->setCollisionConfiguration(config);
}

void btCollisionDispatcher_setDispatcherFlags(btCollisionDispatcher* obj, int flags)
{
	obj->setDispatcherFlags(flags);
}
/*
void btCollisionDispatcher_setNearCallback(btCollisionDispatcher* obj, * nearCallback)
{
	obj->setNearCallback(nearCallback);
}
*/