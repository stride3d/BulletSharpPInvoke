#include "main.h"

extern "C"
{
	EXPORT void btTransformUtil_calculateDiffAxisAngle(btScalar* transform0, btScalar* transform1, btScalar* axis, btScalar* angle);
	EXPORT void btTransformUtil_calculateDiffAxisAngleQuaternion(btScalar* orn0, btScalar* orn1a, btScalar* axis, btScalar* angle);
	EXPORT void btTransformUtil_calculateVelocity(btScalar* transform0, btScalar* transform1, btScalar timeStep, btScalar* linVel, btScalar* angVel);
	EXPORT void btTransformUtil_calculateVelocityQuaternion(btScalar* pos0, btScalar* pos1, btScalar* orn0, btScalar* orn1, btScalar timeStep, btScalar* linVel, btScalar* angVel);
	EXPORT void btTransformUtil_integrateTransform(btScalar* curTrans, btScalar* linvel, btScalar* angvel, btScalar timeStep, btScalar* predictedTransform);

	EXPORT btConvexSeparatingDistanceUtil* btConvexSeparatingDistanceUtil_new(btScalar boundingRadiusA, btScalar boundingRadiusB);
	EXPORT btScalar btConvexSeparatingDistanceUtil_getConservativeSeparatingDistance(btConvexSeparatingDistanceUtil* obj);
	EXPORT void btConvexSeparatingDistanceUtil_initSeparatingDistance(btConvexSeparatingDistanceUtil* obj, btScalar* separatingVector, btScalar separatingDistance, btScalar* transA, btScalar* transB);
	EXPORT void btConvexSeparatingDistanceUtil_updateSeparatingDistance(btConvexSeparatingDistanceUtil* obj, btScalar* transA, btScalar* transB);
	EXPORT void btConvexSeparatingDistanceUtil_delete(btConvexSeparatingDistanceUtil* obj);
}
