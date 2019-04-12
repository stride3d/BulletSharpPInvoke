#include "conversion.h"
#include "btCollisionObject_wrap.h"

btCollisionObject* btCollisionObject_new()
{
	return new btCollisionObject();
}

void btCollisionObject_activate(btCollisionObject* obj, bool forceActivation)
{
	obj->activate(forceActivation);
}

void btCollisionObject_activate2(btCollisionObject* obj)
{
	obj->activate();
}

int btCollisionObject_calculateSerializeBufferSize(btCollisionObject* obj)
{
	return obj->calculateSerializeBufferSize();
}

bool btCollisionObject_checkCollideWith(btCollisionObject* obj, btCollisionObject* co)
{
	return obj->checkCollideWith(co);
}

void btCollisionObject_forceActivationState(btCollisionObject* obj, int newState)
{
	obj->forceActivationState(newState);
}

int btCollisionObject_getActivationState(btCollisionObject* obj)
{
	return obj->getActivationState();
}

void btCollisionObject_getAnisotropicFriction(btCollisionObject* obj, btScalar* friction)
{
	VECTOR3_DEF(friction);
	VECTOR3_USE(friction) = obj->getAnisotropicFriction();
	VECTOR3_DEF_OUT(friction);
}

btBroadphaseProxy* btCollisionObject_getBroadphaseHandle(btCollisionObject* obj)
{
	return obj->getBroadphaseHandle();
}

btScalar btCollisionObject_getCcdMotionThreshold(btCollisionObject* obj)
{
	return obj->getCcdMotionThreshold();
}

btScalar btCollisionObject_getCcdSquareMotionThreshold(btCollisionObject* obj)
{
	return obj->getCcdSquareMotionThreshold();
}

btScalar btCollisionObject_getCcdSweptSphereRadius(btCollisionObject* obj)
{
	return obj->getCcdSweptSphereRadius();
}

int btCollisionObject_getCollisionFlags(btCollisionObject* obj)
{
	return obj->getCollisionFlags();
}

btCollisionShape* btCollisionObject_getCollisionShape(btCollisionObject* obj)
{
	return obj->getCollisionShape();
}

int btCollisionObject_getCompanionId(btCollisionObject* obj)
{
	return obj->getCompanionId();
}

btScalar btCollisionObject_getContactProcessingThreshold(btCollisionObject* obj)
{
	return obj->getContactProcessingThreshold();
}

btScalar btCollisionObject_getDeactivationTime(btCollisionObject* obj)
{
	return obj->getDeactivationTime();
}

btScalar btCollisionObject_getFriction(btCollisionObject* obj)
{
	return obj->getFriction();
}

btScalar btCollisionObject_getHitFraction(btCollisionObject* obj)
{
	return obj->getHitFraction();
}

int btCollisionObject_getInternalType(btCollisionObject* obj)
{
	return obj->getInternalType();
}

void btCollisionObject_getInterpolationAngularVelocity(btCollisionObject* obj, btScalar* velocity)
{
	VECTOR3_DEF(velocity);
	VECTOR3_USE(velocity) = obj->getInterpolationAngularVelocity();
	VECTOR3_DEF_OUT(velocity);
}

void btCollisionObject_getInterpolationLinearVelocity(btCollisionObject* obj, btScalar* velocity)
{
	VECTOR3_DEF(velocity);
	VECTOR3_USE(velocity) = obj->getInterpolationLinearVelocity();
	VECTOR3_DEF_OUT(velocity);
}

void btCollisionObject_getInterpolationWorldTransform(btCollisionObject* obj, btScalar* transform)
{
	btTransformToMatrix(&obj->getInterpolationWorldTransform(), transform);
}

int btCollisionObject_getIslandTag(btCollisionObject* obj)
{
	return obj->getIslandTag();
}

btScalar btCollisionObject_getRestitution(btCollisionObject* obj)
{
	return obj->getRestitution();
}

btScalar btCollisionObject_getRollingFriction(btCollisionObject* obj)
{
	return obj->getRollingFriction();
}

void* btCollisionObject_getUserPointer(btCollisionObject* obj)
{
	return obj->getUserPointer();
}

void btCollisionObject_getWorldTransform(btCollisionObject* obj, btScalar* transform)
{
	btTransformToMatrix(&obj->getWorldTransform(), transform);
}

bool btCollisionObject_hasAnisotropicFriction(btCollisionObject* obj, int frictionMode)
{
	return obj->hasAnisotropicFriction(frictionMode);
}

bool btCollisionObject_hasAnisotropicFriction2(btCollisionObject* obj)
{
	return obj->hasAnisotropicFriction();
}

bool btCollisionObject_hasContactResponse(btCollisionObject* obj)
{
	return obj->hasContactResponse();
}

void* btCollisionObject_internalGetExtensionPointer(btCollisionObject* obj)
{
	return obj->internalGetExtensionPointer();
}

void btCollisionObject_internalSetExtensionPointer(btCollisionObject* obj, void* pointer)
{
	obj->internalSetExtensionPointer(pointer);
}

bool btCollisionObject_isActive(btCollisionObject* obj)
{
	return obj->isActive();
}

bool btCollisionObject_isKinematicObject(btCollisionObject* obj)
{
	return obj->isKinematicObject();
}

bool btCollisionObject_isStaticObject(btCollisionObject* obj)
{
	return obj->isStaticObject();
}

bool btCollisionObject_isStaticOrKinematicObject(btCollisionObject* obj)
{
	return obj->isStaticOrKinematicObject();
}

bool btCollisionObject_mergesSimulationIslands(btCollisionObject* obj)
{
	return obj->mergesSimulationIslands();
}
/*
char* btCollisionObject_serialize(btCollisionObject* obj, void* dataBuffer, btSerializer* serializer)
{
	return obj->serialize(dataBuffer, serializer);
}
*/
void btCollisionObject_serializeSingleObject(btCollisionObject* obj, btSerializer* serializer)
{
	obj->serializeSingleObject(serializer);
}

void btCollisionObject_setActivationState(btCollisionObject* obj, int newState)
{
	obj->setActivationState(newState);
}

void btCollisionObject_setAnisotropicFriction(btCollisionObject* obj, btScalar* anisotropicFriction, int frictionMode)
{
	VECTOR3_CONV(anisotropicFriction);
	obj->setAnisotropicFriction(VECTOR3_USE(anisotropicFriction), frictionMode);
}

void btCollisionObject_setAnisotropicFriction2(btCollisionObject* obj, btScalar* anisotropicFriction)
{
	VECTOR3_CONV(anisotropicFriction);
	obj->setAnisotropicFriction(VECTOR3_USE(anisotropicFriction));
}

void btCollisionObject_setBroadphaseHandle(btCollisionObject* obj, btBroadphaseProxy* handle)
{
	obj->setBroadphaseHandle(handle);
}

void btCollisionObject_setCcdMotionThreshold(btCollisionObject* obj, btScalar ccdMotionThreshold)
{
	obj->setCcdMotionThreshold(ccdMotionThreshold);
}

void btCollisionObject_setCcdSweptSphereRadius(btCollisionObject* obj, btScalar radius)
{
	obj->setCcdSweptSphereRadius(radius);
}

void btCollisionObject_setCollisionFlags(btCollisionObject* obj, int flags)
{
	obj->setCollisionFlags(flags);
}

void btCollisionObject_setCollisionShape(btCollisionObject* obj, btCollisionShape* collisionShape)
{
	obj->setCollisionShape(collisionShape);
}

void btCollisionObject_setCompanionId(btCollisionObject* obj, int id)
{
	obj->setCompanionId(id);
}

void btCollisionObject_setContactProcessingThreshold(btCollisionObject* obj, btScalar contactProcessingThreshold)
{
	obj->setContactProcessingThreshold(contactProcessingThreshold);
}

void btCollisionObject_setDeactivationTime(btCollisionObject* obj, btScalar time)
{
	obj->setDeactivationTime(time);
}

void btCollisionObject_setFriction(btCollisionObject* obj, btScalar frict)
{
	obj->setFriction(frict);
}

void btCollisionObject_setHitFraction(btCollisionObject* obj, btScalar hitFraction)
{
	obj->setHitFraction(hitFraction);
}

void btCollisionObject_setInterpolationAngularVelocity(btCollisionObject* obj, btScalar* angvel)
{
	VECTOR3_CONV(angvel);
	obj->setInterpolationAngularVelocity(VECTOR3_USE(angvel));
}

void btCollisionObject_setInterpolationLinearVelocity(btCollisionObject* obj, btScalar* linvel)
{
	VECTOR3_CONV(linvel);
	obj->setInterpolationLinearVelocity(VECTOR3_USE(linvel));
}

void btCollisionObject_setInterpolationWorldTransform(btCollisionObject* obj, btScalar* trans)
{
	TRANSFORM_CONV(trans);
	obj->setInterpolationWorldTransform(TRANSFORM_USE(trans));
}

void btCollisionObject_setIslandTag(btCollisionObject* obj, int tag)
{
	obj->setIslandTag(tag);
}

void btCollisionObject_setRestitution(btCollisionObject* obj, btScalar rest)
{
	obj->setRestitution(rest);
}

void btCollisionObject_setRollingFriction(btCollisionObject* obj, btScalar frict)
{
	obj->setRollingFriction(frict);
}

void btCollisionObject_setUserIndex(btCollisionObject* obj, int index)
{
	obj->setUserIndex(index);
}

void btCollisionObject_setUserPointer(btCollisionObject* obj, void* userPointer)
{
	obj->setUserPointer(userPointer);
}

void btCollisionObject_setWorldTransform(btCollisionObject* obj, btScalar* worldTrans)
{
	TRANSFORM_CONV(worldTrans);
	obj->setWorldTransform(TRANSFORM_USE(worldTrans));
}

void btCollisionObject_delete(btCollisionObject* obj)
{
	delete obj;
}
