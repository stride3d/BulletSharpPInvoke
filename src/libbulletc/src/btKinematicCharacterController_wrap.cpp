#include <BulletDynamics/Character/btKinematicCharacterController.h>
#include <BulletCollision/CollisionDispatch/btGhostObject.h>

#include "conversion.h"
#include "btKinematicCharacterController_wrap.h"

btKinematicCharacterController* btKinematicCharacterController_new(btPairCachingGhostObject* ghostObject, btConvexShape* convexShape, btScalar stepHeight, btScalar* up)
{
	VECTOR3_CONV(up);
	return new btKinematicCharacterController(ghostObject, convexShape, stepHeight, VECTOR3_USE(up));
}

btKinematicCharacterController* btKinematicCharacterController_new2(btPairCachingGhostObject* ghostObject, btConvexShape* convexShape, btScalar stepHeight)
{
	return new btKinematicCharacterController(ghostObject, convexShape, stepHeight);
}

btPairCachingGhostObject* btKinematicCharacterController_getGhostObject(btKinematicCharacterController* obj)
{
	return obj->getGhostObject();
}

//btVector3 btKinematicCharacterController_getGravity(btKinematicCharacterController* obj)
//{
//	return obj->getGravity();
//}

btScalar btKinematicCharacterController_getMaxSlope(btKinematicCharacterController* obj)
{
	return obj->getMaxSlope();
}

void btKinematicCharacterController_setFallSpeed(btKinematicCharacterController* obj, btScalar fallSpeed)
{
	obj->setFallSpeed(fallSpeed);
}

void btKinematicCharacterController_setGravity(btKinematicCharacterController* obj, btScalar* gravity)
{
	VECTOR3_CONV(gravity);
	obj->setGravity(VECTOR3_USE(gravity));
}

void btKinematicCharacterController_setJumpSpeed(btKinematicCharacterController* obj, btScalar jumpSpeed)
{
	obj->setJumpSpeed(jumpSpeed);
}

void btKinematicCharacterController_setMaxJumpHeight(btKinematicCharacterController* obj, btScalar maxJumpHeight)
{
	obj->setMaxJumpHeight(maxJumpHeight);
}

void btKinematicCharacterController_setMaxSlope(btKinematicCharacterController* obj, btScalar slopeRadians)
{
	obj->setMaxSlope(slopeRadians);
}

void btKinematicCharacterController_setUpAxis(btKinematicCharacterController* obj, btScalar* up)
{
	VECTOR3_CONV(up);
	obj->setUp(VECTOR3_USE(up));
}

void btKinematicCharacterController_setUseGhostSweepTest(btKinematicCharacterController* obj, bool useGhostObjectSweepTest)
{
	obj->setUseGhostSweepTest(useGhostObjectSweepTest);
}
