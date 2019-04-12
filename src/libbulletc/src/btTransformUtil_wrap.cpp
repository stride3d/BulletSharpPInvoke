#include "conversion.h"
#include "btTransformUtil_wrap.h"

void btTransformUtil_calculateDiffAxisAngle(btScalar* transform0, btScalar* transform1, btScalar* axis, btScalar* angle)
{
	TRANSFORM_CONV(transform0);
	TRANSFORM_CONV(transform1);
	VECTOR3_DEF(axis);
	btTransformUtil::calculateDiffAxisAngle(TRANSFORM_USE(transform0), TRANSFORM_USE(transform1), VECTOR3_USE(axis), *angle);
	VECTOR3_DEF_OUT(axis);
}

void btTransformUtil_calculateDiffAxisAngleQuaternion(btScalar* orn0, btScalar* orn1a, btScalar* axis, btScalar* angle)
{
	QUATERNION_CONV(orn0);
	QUATERNION_CONV(orn1a);
	VECTOR3_DEF(axis);
	btTransformUtil::calculateDiffAxisAngleQuaternion(QUATERNION_USE(orn0), QUATERNION_USE(orn1a), VECTOR3_USE(axis), *angle);
	VECTOR3_DEF_OUT(axis);
}

void btTransformUtil_calculateVelocity(btScalar* transform0, btScalar* transform1, btScalar timeStep, btScalar* linVel, btScalar* angVel)
{
	TRANSFORM_CONV(transform0);
	TRANSFORM_CONV(transform1);
	VECTOR3_DEF(linVel);
	VECTOR3_DEF(angVel);
	btTransformUtil::calculateVelocity(TRANSFORM_USE(transform0), TRANSFORM_USE(transform1), timeStep, VECTOR3_USE(linVel), VECTOR3_USE(angVel));
	VECTOR3_DEF_OUT(linVel);
	VECTOR3_DEF_OUT(angVel);
}

void btTransformUtil_calculateVelocityQuaternion(btScalar* pos0, btScalar* pos1, btScalar* orn0, btScalar* orn1, btScalar timeStep, btScalar* linVel, btScalar* angVel)
{
	VECTOR3_CONV(pos0);
	VECTOR3_CONV(pos1);
	QUATERNION_CONV(orn0);
	QUATERNION_CONV(orn1);
	VECTOR3_DEF(linVel);
	VECTOR3_DEF(angVel);
	btTransformUtil::calculateVelocityQuaternion(VECTOR3_USE(pos0), VECTOR3_USE(pos1), QUATERNION_USE(orn0), QUATERNION_USE(orn1), timeStep, VECTOR3_USE(linVel), VECTOR3_USE(angVel));
	VECTOR3_DEF_OUT(linVel);
	VECTOR3_DEF_OUT(angVel);
}

void btTransformUtil_integrateTransform(btScalar* curTrans, btScalar* linvel, btScalar* angvel, btScalar timeStep, btScalar* predictedTransform)
{
	TRANSFORM_CONV(curTrans);
	VECTOR3_DEF(linvel);
	VECTOR3_DEF(angvel);
	TRANSFORM_DEF(predictedTransform);
	btTransformUtil::integrateTransform(TRANSFORM_USE(curTrans), VECTOR3_USE(linvel), VECTOR3_USE(angvel), timeStep, TRANSFORM_USE(predictedTransform));
	TRANSFORM_DEF_OUT(predictedTransform);
}

btConvexSeparatingDistanceUtil* btConvexSeparatingDistanceUtil_new(btScalar boundingRadiusA, btScalar boundingRadiusB)
{
	return new btConvexSeparatingDistanceUtil(boundingRadiusA, boundingRadiusB);
}

btScalar btConvexSeparatingDistanceUtil_getConservativeSeparatingDistance(btConvexSeparatingDistanceUtil* obj)
{
	return obj->getConservativeSeparatingDistance();
}

void btConvexSeparatingDistanceUtil_initSeparatingDistance(btConvexSeparatingDistanceUtil* obj, btScalar* separatingVector, btScalar separatingDistance, btScalar* transA, btScalar* transB)
{
	VECTOR3_CONV(separatingVector);
	TRANSFORM_CONV(transA);
	TRANSFORM_CONV(transB);
	obj->initSeparatingDistance(VECTOR3_USE(separatingVector), separatingDistance, TRANSFORM_USE(transA), TRANSFORM_USE(transB));
}

void btConvexSeparatingDistanceUtil_updateSeparatingDistance(btConvexSeparatingDistanceUtil* obj, btScalar* transA, btScalar* transB)
{
	TRANSFORM_CONV(transA);
	TRANSFORM_CONV(transB);
	obj->updateSeparatingDistance(TRANSFORM_USE(transA), TRANSFORM_USE(transB));
}

void btConvexSeparatingDistanceUtil_delete(btConvexSeparatingDistanceUtil* obj)
{
	delete obj;
}
