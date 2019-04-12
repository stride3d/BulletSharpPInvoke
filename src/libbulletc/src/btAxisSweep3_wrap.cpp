#include "conversion.h"
#include "btAxisSweep3_wrap.h"

btAxisSweep3* btAxisSweep3_new(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned short maxHandles, btOverlappingPairCache* pairCache, bool disableRaycastAccelerator)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new btAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax), maxHandles, pairCache, disableRaycastAccelerator);
}

btAxisSweep3* btAxisSweep3_new2(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned short maxHandles, btOverlappingPairCache* pairCache)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new btAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax), maxHandles, pairCache);
}

btAxisSweep3* btAxisSweep3_new3(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned short maxHandles)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new btAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax), maxHandles);
}

btAxisSweep3* btAxisSweep3_new4(btScalar* worldAabbMin, btScalar* worldAabbMax)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new btAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax));
}

bt32BitAxisSweep3* bt32BitAxisSweep3_new(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned int maxHandles, btOverlappingPairCache* pairCache, bool disableRaycastAccelerator)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new bt32BitAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax), maxHandles, pairCache, disableRaycastAccelerator);
}

bt32BitAxisSweep3* bt32BitAxisSweep3_new2(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned int maxHandles, btOverlappingPairCache* pairCache)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new bt32BitAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax), maxHandles, pairCache);
}

bt32BitAxisSweep3* bt32BitAxisSweep3_new3(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned int maxHandles)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new bt32BitAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax), maxHandles);
}

bt32BitAxisSweep3* bt32BitAxisSweep3_new4(btScalar* worldAabbMin, btScalar* worldAabbMax)
{
	VECTOR3_CONV(worldAabbMin);
	VECTOR3_CONV(worldAabbMax);
	return new bt32BitAxisSweep3(VECTOR3_USE(worldAabbMin), VECTOR3_USE(worldAabbMax));
}
