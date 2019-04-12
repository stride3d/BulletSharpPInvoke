#include "conversion.h"
#include "btRigidBody_wrap.h"

btRigidBody_btRigidBodyConstructionInfo* btRigidBody_btRigidBodyConstructionInfo_new(btScalar mass, btMotionState* motionState, btCollisionShape* collisionShape, btScalar* localInertia)
{
	VECTOR3_CONV(localInertia);
	return ALIGNED_NEW(btRigidBody_btRigidBodyConstructionInfo) (mass, motionState, collisionShape, VECTOR3_USE(localInertia));
}

btRigidBody_btRigidBodyConstructionInfo* btRigidBody_btRigidBodyConstructionInfo_new2(btScalar mass, btMotionState* motionState, btCollisionShape* collisionShape)
{
	return ALIGNED_NEW(btRigidBody_btRigidBodyConstructionInfo) (mass, motionState, collisionShape);
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getAdditionalAngularDampingFactor(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_additionalAngularDampingFactor;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getAdditionalAngularDampingThresholdSqr(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_additionalAngularDampingThresholdSqr;
}

bool btRigidBody_btRigidBodyConstructionInfo_getAdditionalDamping(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_additionalDamping;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getAdditionalDampingFactor(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_additionalDampingFactor;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getAdditionalLinearDampingThresholdSqr(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_additionalLinearDampingThresholdSqr;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getAngularDamping(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_angularDamping;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getAngularSleepingThreshold(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_angularSleepingThreshold;
}

btCollisionShape* btRigidBody_btRigidBodyConstructionInfo_getCollisionShape(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_collisionShape;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getFriction(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_friction;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getLinearDamping(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_linearDamping;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getLinearSleepingThreshold(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_linearSleepingThreshold;
}

void btRigidBody_btRigidBodyConstructionInfo_getLocalInertia(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_localInertia, value);
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getMass(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_mass;
}

btMotionState* btRigidBody_btRigidBodyConstructionInfo_getMotionState(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_motionState;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getRestitution(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_restitution;
}

btScalar btRigidBody_btRigidBodyConstructionInfo_getRollingFriction(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	return obj->m_rollingFriction;
}

void btRigidBody_btRigidBodyConstructionInfo_getStartWorldTransform(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar* value)
{
	TRANSFORM_OUT(&obj->m_startWorldTransform, value);
}

void btRigidBody_btRigidBodyConstructionInfo_setAdditionalAngularDampingFactor(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_additionalAngularDampingFactor = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setAdditionalAngularDampingThresholdSqr(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_additionalAngularDampingThresholdSqr = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setAdditionalDamping(btRigidBody_btRigidBodyConstructionInfo* obj, bool value)
{
	obj->m_additionalDamping = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setAdditionalDampingFactor(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_additionalDampingFactor = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setAdditionalLinearDampingThresholdSqr(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_additionalLinearDampingThresholdSqr = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setAngularDamping(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_angularDamping = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setAngularSleepingThreshold(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_angularSleepingThreshold = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setCollisionShape(btRigidBody_btRigidBodyConstructionInfo* obj, btCollisionShape* value)
{
	obj->m_collisionShape = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setFriction(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_friction = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setLinearDamping(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_linearDamping = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setLinearSleepingThreshold(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_linearSleepingThreshold = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setLocalInertia(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_localInertia);
}

void btRigidBody_btRigidBodyConstructionInfo_setMass(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_mass = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setMotionState(btRigidBody_btRigidBodyConstructionInfo* obj, btMotionState* value)
{
	obj->m_motionState = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setRestitution(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_restitution = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setRollingFriction(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar value)
{
	obj->m_rollingFriction = value;
}

void btRigidBody_btRigidBodyConstructionInfo_setStartWorldTransform(btRigidBody_btRigidBodyConstructionInfo* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_startWorldTransform);
}

void btRigidBody_btRigidBodyConstructionInfo_delete(btRigidBody_btRigidBodyConstructionInfo* obj)
{
	ALIGNED_FREE(obj);
}

btRigidBody* btRigidBody_new(btRigidBody_btRigidBodyConstructionInfo* constructionInfo)
{
	return new btRigidBody(*constructionInfo);
}

btRigidBody* btRigidBody_new2(btScalar mass, btMotionState* motionState, btCollisionShape* collisionShape, btScalar* localInertia)
{
	VECTOR3_CONV(localInertia);
	return new btRigidBody(mass, motionState, collisionShape, VECTOR3_USE(localInertia));
}

btRigidBody* btRigidBody_new3(btScalar mass, btMotionState* motionState, btCollisionShape* collisionShape)
{
	return new btRigidBody(mass, motionState, collisionShape);
}

void btRigidBody_addConstraintRef(btRigidBody* obj, btTypedConstraint* c)
{
	obj->addConstraintRef(c);
}

void btRigidBody_applyCentralForce(btRigidBody* obj, btScalar* force)
{
	VECTOR3_CONV(force);
	obj->applyCentralForce(VECTOR3_USE(force));
}

void btRigidBody_applyCentralImpulse(btRigidBody* obj, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	obj->applyCentralImpulse(VECTOR3_USE(impulse));
}

void btRigidBody_applyDamping(btRigidBody* obj, btScalar timeStep)
{
	obj->applyDamping(timeStep);
}

void btRigidBody_applyForce(btRigidBody* obj, btScalar* force, btScalar* rel_pos)
{
	VECTOR3_CONV(force);
	VECTOR3_CONV(rel_pos);
	obj->applyForce(VECTOR3_USE(force), VECTOR3_USE(rel_pos));
}

void btRigidBody_applyGravity(btRigidBody* obj)
{
	obj->applyGravity();
}

void btRigidBody_applyImpulse(btRigidBody* obj, btScalar* impulse, btScalar* rel_pos)
{
	VECTOR3_CONV(impulse);
	VECTOR3_CONV(rel_pos);
	obj->applyImpulse(VECTOR3_USE(impulse), VECTOR3_USE(rel_pos));
}

void btRigidBody_applyTorque(btRigidBody* obj, btScalar* torque)
{
	VECTOR3_CONV(torque);
	obj->applyTorque(VECTOR3_USE(torque));
}

void btRigidBody_applyTorqueImpulse(btRigidBody* obj, btScalar* torque)
{
	VECTOR3_CONV(torque);
	obj->applyTorqueImpulse(VECTOR3_USE(torque));
}

bool btRigidBody_checkCollideWithOverride(btRigidBody* obj, btCollisionObject* co)
{
	return obj->checkCollideWithOverride(co);
}

void btRigidBody_clearForces(btRigidBody* obj)
{
	obj->clearForces();
}

btScalar btRigidBody_computeAngularImpulseDenominator(btRigidBody* obj, btScalar* axis)
{
	VECTOR3_CONV(axis);
	return obj->computeAngularImpulseDenominator(VECTOR3_USE(axis));
}

//void btRigidBody_computeGyroscopicForce(btRigidBody* obj, btScalar maxGyroscopicForce)
//{
//	obj->computeGyroscopicForce(maxGyroscopicForce);
//}

btScalar btRigidBody_computeImpulseDenominator(btRigidBody* obj, btScalar* pos, btScalar* normal)
{
	VECTOR3_CONV(pos);
	VECTOR3_CONV(normal);
	return obj->computeImpulseDenominator(VECTOR3_USE(pos), VECTOR3_USE(normal));
}

void btRigidBody_getAabb(btRigidBody* obj, btScalar* aabbMin, btScalar* aabbMax)
{
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->getAabb(VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}

btScalar btRigidBody_getAngularDamping(btRigidBody* obj)
{
	return obj->getAngularDamping();
}

void btRigidBody_getAngularFactor(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getAngularFactor(), value);
}

btScalar btRigidBody_getAngularSleepingThreshold(btRigidBody* obj)
{
	return obj->getAngularSleepingThreshold();
}

void btRigidBody_getAngularVelocity(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getAngularVelocity(), value);
}

btBroadphaseProxy* btRigidBody_getBroadphaseProxy(btRigidBody* obj)
{
	return obj->getBroadphaseProxy();
}

void btRigidBody_getCenterOfMassPosition(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getCenterOfMassPosition(), value);
}

void btRigidBody_getCenterOfMassTransform(btRigidBody* obj, btScalar* value)
{
	btTransformToMatrix(&obj->getCenterOfMassTransform(), value);
}

btTypedConstraint* btRigidBody_getConstraintRef(btRigidBody* obj, int index)
{
	return obj->getConstraintRef(index);
}

int btRigidBody_getContactSolverType(btRigidBody* obj)
{
	return obj->m_contactSolverType;
}

int btRigidBody_getFlags(btRigidBody* obj)
{
	return obj->getFlags();
}

int btRigidBody_getFrictionSolverType(btRigidBody* obj)
{
	return obj->m_frictionSolverType;
}

void btRigidBody_getGravity(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getGravity(), value);
}

void btRigidBody_getInvInertiaDiagLocal(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getInvInertiaDiagLocal(), value);
}

void btRigidBody_getInvInertiaTensorWorld(btRigidBody* obj, btScalar* value)
{
	btMatrix3x3ToMatrix(&obj->getInvInertiaTensorWorld(), value);
}

btScalar btRigidBody_getInvMass(btRigidBody* obj)
{
	return obj->getInvMass();
}

btScalar btRigidBody_getLinearDamping(btRigidBody* obj)
{
	return obj->getLinearDamping();
}

void btRigidBody_getLinearFactor(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getLinearFactor(), value);
}

btScalar btRigidBody_getLinearSleepingThreshold(btRigidBody* obj)
{
	return obj->getLinearSleepingThreshold();
}

void btRigidBody_getLinearVelocity(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getLinearVelocity(), value);
}

btMotionState* btRigidBody_getMotionState(btRigidBody* obj)
{
	return obj->getMotionState();
}

int btRigidBody_getNumConstraintRefs(btRigidBody* obj)
{
	return obj->getNumConstraintRefs();
}

void btRigidBody_getOrientation(btRigidBody* obj, btScalar* value)
{
	QUATERNION_OUT2(obj->getOrientation(), value);
}

void btRigidBody_getTotalForce(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getTotalForce(), value);
}

void btRigidBody_getTotalTorque(btRigidBody* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->getTotalTorque(), value);
}

void btRigidBody_getVelocityInLocalPoint(btRigidBody* obj, btScalar* rel_pos, btScalar* value)
{
	VECTOR3_CONV(rel_pos);
	VECTOR3_OUT2(obj->getVelocityInLocalPoint(VECTOR3_USE(rel_pos)), value);
}

void btRigidBody_integrateVelocities(btRigidBody* obj, btScalar step)
{
	obj->integrateVelocities(step);
}

bool btRigidBody_isInWorld(btRigidBody* obj)
{
	return obj->isInWorld();
}

void btRigidBody_predictIntegratedTransform(btRigidBody* obj, btScalar step, btScalar* predictedTransform)
{
	TRANSFORM_CONV(predictedTransform);
	obj->predictIntegratedTransform(step, TRANSFORM_USE(predictedTransform));
}

void btRigidBody_proceedToTransform(btRigidBody* obj, btScalar* newTrans)
{
	TRANSFORM_CONV(newTrans);
	obj->proceedToTransform(TRANSFORM_USE(newTrans));
}

void btRigidBody_removeConstraintRef(btRigidBody* obj, btTypedConstraint* c)
{
	obj->removeConstraintRef(c);
}

void btRigidBody_saveKinematicState(btRigidBody* obj, btScalar step)
{
	obj->saveKinematicState(step);
}

void btRigidBody_setAngularFactor(btRigidBody* obj, btScalar* angFac)
{
	VECTOR3_CONV(angFac);
	obj->setAngularFactor(VECTOR3_USE(angFac));
}

void btRigidBody_setAngularFactor2(btRigidBody* obj, btScalar angFac)
{
	obj->setAngularFactor(angFac);
}

void btRigidBody_setAngularVelocity(btRigidBody* obj, btScalar* ang_vel)
{
	VECTOR3_CONV(ang_vel);
	obj->setAngularVelocity(VECTOR3_USE(ang_vel));
}

void btRigidBody_setCenterOfMassTransform(btRigidBody* obj, btScalar* xform)
{
	TRANSFORM_CONV(xform);
	obj->setCenterOfMassTransform(TRANSFORM_USE(xform));
}

void btRigidBody_setContactSolverType(btRigidBody* obj, int value)
{
	obj->m_contactSolverType = value;
}

void btRigidBody_setDamping(btRigidBody* obj, btScalar lin_damping, btScalar ang_damping)
{
	obj->setDamping(lin_damping, ang_damping);
}

void btRigidBody_setFlags(btRigidBody* obj, int flags)
{
	obj->setFlags(flags);
}

void btRigidBody_setFrictionSolverType(btRigidBody* obj, int value)
{
	obj->m_frictionSolverType = value;
}

void btRigidBody_setGravity(btRigidBody* obj, btScalar* acceleration)
{
	VECTOR3_CONV(acceleration);
	obj->setGravity(VECTOR3_USE(acceleration));
}

void btRigidBody_setInvInertiaDiagLocal(btRigidBody* obj, btScalar* diagInvInertia)
{
	VECTOR3_CONV(diagInvInertia);
	obj->setInvInertiaDiagLocal(VECTOR3_USE(diagInvInertia));
}

void btRigidBody_setLinearFactor(btRigidBody* obj, btScalar* linearFactor)
{
	VECTOR3_CONV(linearFactor);
	obj->setLinearFactor(VECTOR3_USE(linearFactor));
}

void btRigidBody_setLinearVelocity(btRigidBody* obj, btScalar* lin_vel)
{
	VECTOR3_CONV(lin_vel);
	obj->setLinearVelocity(VECTOR3_USE(lin_vel));
}

void btRigidBody_setMassProps(btRigidBody* obj, btScalar mass, btScalar* inertia)
{
	VECTOR3_CONV(inertia);
	obj->setMassProps(mass, VECTOR3_USE(inertia));
}

void btRigidBody_setMotionState(btRigidBody* obj, btMotionState* motionState)
{
	obj->setMotionState(motionState);
}

void btRigidBody_setNewBroadphaseProxy(btRigidBody* obj, btBroadphaseProxy* broadphaseProxy)
{
	obj->setNewBroadphaseProxy(broadphaseProxy);
}

void btRigidBody_setSleepingThresholds(btRigidBody* obj, btScalar linear, btScalar angular)
{
	obj->setSleepingThresholds(linear, angular);
}

void btRigidBody_translate(btRigidBody* obj, btScalar* v)
{
	VECTOR3_CONV(v);
	obj->translate(VECTOR3_USE(v));
}

btRigidBody* btRigidBody_upcast(btCollisionObject* colObj)
{
	return btRigidBody::upcast(colObj);
}

void btRigidBody_updateDeactivation(btRigidBody* obj, btScalar timeStep)
{
	obj->updateDeactivation(timeStep);
}

void btRigidBody_updateInertiaTensor(btRigidBody* obj)
{
	obj->updateInertiaTensor();
}

bool btRigidBody_wantsSleeping(btRigidBody* obj)
{
	return obj->wantsSleeping();
}
