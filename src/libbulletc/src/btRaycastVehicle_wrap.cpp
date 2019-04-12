#include <BulletDynamics/Vehicle/btRaycastVehicle.h>

#include "conversion.h"
#include "btRaycastVehicle_wrap.h"

btRaycastVehicle_btVehicleTuning* btRaycastVehicle_btVehicleTuning_new()
{
	return new btRaycastVehicle_btVehicleTuning();
}

btScalar btRaycastVehicle_btVehicleTuning_getFrictionSlip(btRaycastVehicle_btVehicleTuning* obj)
{
	return obj->m_frictionSlip;
}

btScalar btRaycastVehicle_btVehicleTuning_getMaxSuspensionForce(btRaycastVehicle_btVehicleTuning* obj)
{
	return obj->m_maxSuspensionForce;
}

btScalar btRaycastVehicle_btVehicleTuning_getMaxSuspensionTravelCm(btRaycastVehicle_btVehicleTuning* obj)
{
	return obj->m_maxSuspensionTravelCm;
}

btScalar btRaycastVehicle_btVehicleTuning_getSuspensionCompression(btRaycastVehicle_btVehicleTuning* obj)
{
	return obj->m_suspensionCompression;
}

btScalar btRaycastVehicle_btVehicleTuning_getSuspensionDamping(btRaycastVehicle_btVehicleTuning* obj)
{
	return obj->m_suspensionDamping;
}

btScalar btRaycastVehicle_btVehicleTuning_getSuspensionStiffness(btRaycastVehicle_btVehicleTuning* obj)
{
	return obj->m_suspensionStiffness;
}

void btRaycastVehicle_btVehicleTuning_setFrictionSlip(btRaycastVehicle_btVehicleTuning* obj, btScalar value)
{
	obj->m_frictionSlip = value;
}

void btRaycastVehicle_btVehicleTuning_setMaxSuspensionForce(btRaycastVehicle_btVehicleTuning* obj, btScalar value)
{
	obj->m_maxSuspensionForce = value;
}

void btRaycastVehicle_btVehicleTuning_setMaxSuspensionTravelCm(btRaycastVehicle_btVehicleTuning* obj, btScalar value)
{
	obj->m_maxSuspensionTravelCm = value;
}

void btRaycastVehicle_btVehicleTuning_setSuspensionCompression(btRaycastVehicle_btVehicleTuning* obj, btScalar value)
{
	obj->m_suspensionCompression = value;
}

void btRaycastVehicle_btVehicleTuning_setSuspensionDamping(btRaycastVehicle_btVehicleTuning* obj, btScalar value)
{
	obj->m_suspensionDamping = value;
}

void btRaycastVehicle_btVehicleTuning_setSuspensionStiffness(btRaycastVehicle_btVehicleTuning* obj, btScalar value)
{
	obj->m_suspensionStiffness = value;
}

void btRaycastVehicle_btVehicleTuning_delete(btRaycastVehicle_btVehicleTuning* obj)
{
	delete obj;
}

btRaycastVehicle* btRaycastVehicle_new(btRaycastVehicle_btVehicleTuning* tuning, btRigidBody* chassis, btVehicleRaycaster* raycaster)
{
	return new btRaycastVehicle(*tuning, chassis, raycaster);
}

btWheelInfo* btRaycastVehicle_addWheel(btRaycastVehicle* obj, btScalar* connectionPointCS0, btScalar* wheelDirectionCS0, btScalar* wheelAxleCS, btScalar suspensionRestLength, btScalar wheelRadius, btRaycastVehicle_btVehicleTuning* tuning, bool isFrontWheel)
{
	VECTOR3_CONV(connectionPointCS0);
	VECTOR3_CONV(wheelDirectionCS0);
	VECTOR3_CONV(wheelAxleCS);
	return &obj->addWheel(VECTOR3_USE(connectionPointCS0), VECTOR3_USE(wheelDirectionCS0), VECTOR3_USE(wheelAxleCS), suspensionRestLength, wheelRadius, *tuning, isFrontWheel);
}

void btRaycastVehicle_applyEngineForce(btRaycastVehicle* obj, btScalar force, int wheel)
{
	obj->applyEngineForce(force, wheel);
}

void btRaycastVehicle_getChassisWorldTransform(btRaycastVehicle* obj, btScalar* value)
{
	TRANSFORM_DEF(value);
	TRANSFORM_USE(value) = obj->getChassisWorldTransform();
	TRANSFORM_DEF_OUT(value);
}

btScalar btRaycastVehicle_getCurrentSpeedKmHour(btRaycastVehicle* obj)
{
	return obj->getCurrentSpeedKmHour();
}

int btRaycastVehicle_getForwardAxis(btRaycastVehicle* obj)
{
	return obj->getForwardAxis();
}

void btRaycastVehicle_getForwardVector(btRaycastVehicle* obj, btScalar* value)
{
	obj->getForwardVector();
}

int btRaycastVehicle_getNumWheels(btRaycastVehicle* obj)
{
	return obj->getNumWheels();
}

int btRaycastVehicle_getRightAxis(btRaycastVehicle* obj)
{
	return obj->getRightAxis();
}

btRigidBody* btRaycastVehicle_getRigidBody(btRaycastVehicle* obj)
{
	return obj->getRigidBody();
}

btScalar btRaycastVehicle_getSteeringValue(btRaycastVehicle* obj, int wheel)
{
	return obj->getSteeringValue(wheel);
}

int btRaycastVehicle_getUpAxis(btRaycastVehicle* obj)
{
	return obj->getUpAxis();
}

int btRaycastVehicle_getUserConstraintId(btRaycastVehicle* obj)
{
	return obj->getUserConstraintId();
}

int btRaycastVehicle_getUserConstraintType(btRaycastVehicle* obj)
{
	return obj->getUserConstraintType();
}

btWheelInfo* btRaycastVehicle_getWheelInfo(btRaycastVehicle* obj, int index)
{
	return &obj->getWheelInfo(index);
}

btAlignedWheelInfoArray* btRaycastVehicle_getWheelInfo2(btRaycastVehicle* obj)
{
	return &obj->m_wheelInfo;
}

void btRaycastVehicle_getWheelTransformWS(btRaycastVehicle* obj, int wheelIndex, btScalar* value)
{
	btTransformToMatrix(&obj->getWheelTransformWS(wheelIndex), value);
}

btScalar btRaycastVehicle_rayCast(btRaycastVehicle* obj, btWheelInfo* wheel)
{
	return obj->rayCast(*wheel);
}

void btRaycastVehicle_resetSuspension(btRaycastVehicle* obj)
{
	obj->resetSuspension();
}

void btRaycastVehicle_setBrake(btRaycastVehicle* obj, btScalar brake, int wheelIndex)
{
	obj->setBrake(brake, wheelIndex);
}

void btRaycastVehicle_setCoordinateSystem(btRaycastVehicle* obj, int rightIndex, int upIndex, int forwardIndex)
{
	obj->setCoordinateSystem(rightIndex, upIndex, forwardIndex);
}

void btRaycastVehicle_setPitchControl(btRaycastVehicle* obj, btScalar pitch)
{
	obj->setPitchControl(pitch);
}

void btRaycastVehicle_setSteeringValue(btRaycastVehicle* obj, btScalar steering, int wheel)
{
	obj->setSteeringValue(steering, wheel);
}

void btRaycastVehicle_setUserConstraintId(btRaycastVehicle* obj, int uid)
{
	obj->setUserConstraintId(uid);
}

void btRaycastVehicle_setUserConstraintType(btRaycastVehicle* obj, int userConstraintType)
{
	obj->setUserConstraintType(userConstraintType);
}

void btRaycastVehicle_updateFriction(btRaycastVehicle* obj, btScalar timeStep)
{
	obj->updateFriction(timeStep);
}

void btRaycastVehicle_updateSuspension(btRaycastVehicle* obj, btScalar deltaTime)
{
	obj->updateSuspension(deltaTime);
}

void btRaycastVehicle_updateVehicle(btRaycastVehicle* obj, btScalar step)
{
	obj->updateVehicle(step);
}

void btRaycastVehicle_updateWheelTransform(btRaycastVehicle* obj, int wheelIndex, bool interpolatedTransform)
{
	obj->updateWheelTransform(wheelIndex, interpolatedTransform);
}

void btRaycastVehicle_updateWheelTransform2(btRaycastVehicle* obj, int wheelIndex)
{
	obj->updateWheelTransform(wheelIndex);
}

void btRaycastVehicle_updateWheelTransformsWS(btRaycastVehicle* obj, btWheelInfo* wheel, bool interpolatedTransform)
{
	obj->updateWheelTransformsWS(*wheel, interpolatedTransform);
}

void btRaycastVehicle_updateWheelTransformsWS2(btRaycastVehicle* obj, btWheelInfo* wheel)
{
	obj->updateWheelTransformsWS(*wheel);
}

btDefaultVehicleRaycaster* btDefaultVehicleRaycaster_new(btDynamicsWorld* world)
{
	return new btDefaultVehicleRaycaster(world);
}
