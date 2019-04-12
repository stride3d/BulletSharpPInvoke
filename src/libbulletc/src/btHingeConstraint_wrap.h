#include "main.h"

extern "C"
{
	EXPORT btHingeConstraint* btHingeConstraint_new(btRigidBody* rbA, btRigidBody* rbB, btScalar* pivotInA, btScalar* pivotInB, btScalar* axisInA, btScalar* axisInB, bool useReferenceFrameA);
	EXPORT btHingeConstraint* btHingeConstraint_new2(btRigidBody* rbA, btRigidBody* rbB, btScalar* pivotInA, btScalar* pivotInB, btScalar* axisInA, btScalar* axisInB);
	EXPORT btHingeConstraint* btHingeConstraint_new3(btRigidBody* rbA, btScalar* pivotInA, btScalar* axisInA, bool useReferenceFrameA);
	EXPORT btHingeConstraint* btHingeConstraint_new4(btRigidBody* rbA, btScalar* pivotInA, btScalar* axisInA);
	EXPORT btHingeConstraint* btHingeConstraint_new5(btRigidBody* rbA, btRigidBody* rbB, btScalar* rbAFrame, btScalar* rbBFrame, bool useReferenceFrameA);
	EXPORT btHingeConstraint* btHingeConstraint_new6(btRigidBody* rbA, btRigidBody* rbB, btScalar* rbAFrame, btScalar* rbBFrame);
	EXPORT btHingeConstraint* btHingeConstraint_new7(btRigidBody* rbA, btScalar* rbAFrame, bool useReferenceFrameA);
	EXPORT btHingeConstraint* btHingeConstraint_new8(btRigidBody* rbA, btScalar* rbAFrame);
	EXPORT void btHingeConstraint_enableAngularMotor(btHingeConstraint* obj, bool enableMotor, btScalar targetVelocity, btScalar maxMotorImpulse);
	EXPORT void btHingeConstraint_enableMotor(btHingeConstraint* obj, bool enableMotor);
	EXPORT void btHingeConstraint_getAFrame(btHingeConstraint* obj, btScalar* value);
	EXPORT bool btHingeConstraint_getAngularOnly(btHingeConstraint* obj);
	EXPORT void btHingeConstraint_getBFrame(btHingeConstraint* obj, btScalar* value);
	EXPORT bool btHingeConstraint_getEnableAngularMotor(btHingeConstraint* obj);
	EXPORT void btHingeConstraint_getFrameOffsetA(btHingeConstraint* obj, btScalar* value);
	EXPORT void btHingeConstraint_getFrameOffsetB(btHingeConstraint* obj, btScalar* value);
	EXPORT btScalar btHingeConstraint_getHingeAngle(btHingeConstraint* obj, btScalar* transA, btScalar* transB);
	EXPORT btScalar btHingeConstraint_getHingeAngle2(btHingeConstraint* obj);
	EXPORT void btHingeConstraint_getInfo1NonVirtual(btHingeConstraint* obj, btTypedConstraint_btConstraintInfo1* info);
	EXPORT void btHingeConstraint_getInfo2Internal(btHingeConstraint* obj, btTypedConstraint_btConstraintInfo2* info, btScalar* transA, btScalar* transB, btScalar* angVelA, btScalar* angVelB);
	EXPORT void btHingeConstraint_getInfo2InternalUsingFrameOffset(btHingeConstraint* obj, btTypedConstraint_btConstraintInfo2* info, btScalar* transA, btScalar* transB, btScalar* angVelA, btScalar* angVelB);
	EXPORT void btHingeConstraint_getInfo2NonVirtual(btHingeConstraint* obj, btTypedConstraint_btConstraintInfo2* info, btScalar* transA, btScalar* transB, btScalar* angVelA, btScalar* angVelB);
	EXPORT btScalar btHingeConstraint_getLimitSign(btHingeConstraint* obj);
	EXPORT btScalar btHingeConstraint_getLowerLimit(btHingeConstraint* obj);
	EXPORT btScalar btHingeConstraint_getMaxMotorImpulse(btHingeConstraint* obj);
	EXPORT btScalar btHingeConstraint_getMotorTargetVelosity(btHingeConstraint* obj);
	EXPORT int btHingeConstraint_getSolveLimit(btHingeConstraint* obj);
	EXPORT btScalar btHingeConstraint_getUpperLimit(btHingeConstraint* obj);
	EXPORT bool btHingeConstraint_getUseFrameOffset(btHingeConstraint* obj);
	EXPORT void btHingeConstraint_setAngularOnly(btHingeConstraint* obj, bool angularOnly);
	EXPORT void btHingeConstraint_setAxis(btHingeConstraint* obj, btScalar* axisInA);
	EXPORT void btHingeConstraint_setFrames(btHingeConstraint* obj, btScalar* frameA, btScalar* frameB);
	EXPORT void btHingeConstraint_setLimit(btHingeConstraint* obj, btScalar low, btScalar high, btScalar _softness, btScalar _biasFactor, btScalar _relaxationFactor);
	EXPORT void btHingeConstraint_setLimit2(btHingeConstraint* obj, btScalar low, btScalar high, btScalar _softness, btScalar _biasFactor);
	EXPORT void btHingeConstraint_setLimit3(btHingeConstraint* obj, btScalar low, btScalar high, btScalar _softness);
	EXPORT void btHingeConstraint_setLimit4(btHingeConstraint* obj, btScalar low, btScalar high);
	EXPORT void btHingeConstraint_setMaxMotorImpulse(btHingeConstraint* obj, btScalar maxMotorImpulse);
	EXPORT void btHingeConstraint_setMotorTarget(btHingeConstraint* obj, btScalar targetAngle, btScalar dt);
	EXPORT void btHingeConstraint_setMotorTarget2(btHingeConstraint* obj, btQuaternion* qAinB, btScalar dt);
	EXPORT void btHingeConstraint_setUseFrameOffset(btHingeConstraint* obj, bool frameOffsetOnOff);
	EXPORT void btHingeConstraint_testLimit(btHingeConstraint* obj, btScalar* transA, btScalar* transB);
	EXPORT void btHingeConstraint_updateRHS(btHingeConstraint* obj, btScalar timeStep);
}
