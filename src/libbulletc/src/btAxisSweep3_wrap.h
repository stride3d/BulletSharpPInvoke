#include "main.h"

extern "C"
{
	EXPORT btAxisSweep3* btAxisSweep3_new(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned short maxHandles, btOverlappingPairCache* pairCache, bool disableRaycastAccelerator);
	EXPORT btAxisSweep3* btAxisSweep3_new2(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned short maxHandles, btOverlappingPairCache* pairCache);
	EXPORT btAxisSweep3* btAxisSweep3_new3(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned short maxHandles);
	EXPORT btAxisSweep3* btAxisSweep3_new4(btScalar* worldAabbMin, btScalar* worldAabbMax);

	EXPORT bt32BitAxisSweep3* bt32BitAxisSweep3_new(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned int maxHandles, btOverlappingPairCache* pairCache, bool disableRaycastAccelerator);
	EXPORT bt32BitAxisSweep3* bt32BitAxisSweep3_new2(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned int maxHandles, btOverlappingPairCache* pairCache);
	EXPORT bt32BitAxisSweep3* bt32BitAxisSweep3_new3(btScalar* worldAabbMin, btScalar* worldAabbMax, unsigned int maxHandles);
	EXPORT bt32BitAxisSweep3* bt32BitAxisSweep3_new4(btScalar* worldAabbMin, btScalar* worldAabbMax);
}
