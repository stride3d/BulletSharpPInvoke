#include <BulletCollision/CollisionDispatch/btGhostObject.h>

#include "conversion.h"
#include "btGhostObject_wrap.h"

btGhostObject* btGhostObject_new()
{
	return new btGhostObject();
}

void btGhostObject_addOverlappingObjectInternal(btGhostObject* obj, btBroadphaseProxy* otherProxy, btBroadphaseProxy* thisProxy)
{
	obj->addOverlappingObjectInternal(otherProxy, thisProxy);
}

void btGhostObject_addOverlappingObjectInternal2(btGhostObject* obj, btBroadphaseProxy* otherProxy)
{
	obj->addOverlappingObjectInternal(otherProxy);
}

void btGhostObject_convexSweepTest(btGhostObject* obj, btConvexShape* castShape, btScalar* convexFromWorld, btScalar* convexToWorld, btCollisionWorld_ConvexResultCallback* resultCallback, btScalar allowedCcdPenetration)
{
	TRANSFORM_CONV(convexFromWorld);
	TRANSFORM_CONV(convexToWorld);
	obj->convexSweepTest(castShape, TRANSFORM_USE(convexFromWorld), TRANSFORM_USE(convexToWorld), *resultCallback, allowedCcdPenetration);
}

void btGhostObject_convexSweepTest2(btGhostObject* obj, btConvexShape* castShape, btScalar* convexFromWorld, btScalar* convexToWorld, btCollisionWorld_ConvexResultCallback* resultCallback)
{
	TRANSFORM_CONV(convexFromWorld);
	TRANSFORM_CONV(convexToWorld);
	obj->convexSweepTest(castShape, TRANSFORM_USE(convexFromWorld), TRANSFORM_USE(convexToWorld), *resultCallback);
}

int btGhostObject_getNumOverlappingObjects(btGhostObject* obj)
{
	return obj->getNumOverlappingObjects();
}

btCollisionObject* btGhostObject_getOverlappingObject(btGhostObject* obj, int index)
{
	return obj->getOverlappingObject(index);
}

btAlignedCollisionObjectArray* btGhostObject_getOverlappingPairs(btGhostObject* obj)
{
	return &obj->getOverlappingPairs();
}

void btGhostObject_getOverlappingPairs2(btGhostObject* obj)
{
	obj->getOverlappingPairs();
}

void btGhostObject_rayTest(btGhostObject* obj, btScalar* rayFromWorld, btScalar* rayToWorld, btCollisionWorld_RayResultCallback* resultCallback)
{
	VECTOR3_CONV(rayFromWorld);
	VECTOR3_CONV(rayToWorld);
	obj->rayTest(VECTOR3_USE(rayFromWorld), VECTOR3_USE(rayToWorld), *resultCallback);
}

void btGhostObject_removeOverlappingObjectInternal(btGhostObject* obj, btBroadphaseProxy* otherProxy, btDispatcher* dispatcher, btBroadphaseProxy* thisProxy)
{
	obj->removeOverlappingObjectInternal(otherProxy, dispatcher, thisProxy);
}

void btGhostObject_removeOverlappingObjectInternal2(btGhostObject* obj, btBroadphaseProxy* otherProxy, btDispatcher* dispatcher)
{
	obj->removeOverlappingObjectInternal(otherProxy, dispatcher);
}

btGhostObject* btGhostObject_upcast(btCollisionObject* colObj)
{
	return btGhostObject::upcast(colObj);
}

btPairCachingGhostObject* btPairCachingGhostObject_new()
{
	return new btPairCachingGhostObject();
}

btHashedOverlappingPairCache* btPairCachingGhostObject_getOverlappingPairCache(btPairCachingGhostObject* obj)
{
	return obj->getOverlappingPairCache();
}

btGhostPairCallback* btGhostPairCallback_new()
{
	return new btGhostPairCallback();
}
