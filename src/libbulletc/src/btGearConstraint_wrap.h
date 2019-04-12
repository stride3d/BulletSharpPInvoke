#include "main.h"

extern "C"
{
	EXPORT btGearConstraint* btGearConstraint_new(btRigidBody* rbA, btRigidBody* rbB, btScalar* axisInA, btScalar* axisInB, btScalar ratio);
	EXPORT btGearConstraint* btGearConstraint_new2(btRigidBody* rbA, btRigidBody* rbB, btScalar* axisInA, btScalar* axisInB);
	EXPORT void btGearConstraint_getAxisA(btGearConstraint* obj, btScalar* axisA);
	EXPORT void btGearConstraint_getAxisB(btGearConstraint* obj, btScalar* axisB);
	EXPORT btScalar btGearConstraint_getRatio(btGearConstraint* obj);
	EXPORT void btGearConstraint_setAxisA(btGearConstraint* obj, btScalar* axisA);
	EXPORT void btGearConstraint_setAxisB(btGearConstraint* obj, btScalar* axisB);
	EXPORT void btGearConstraint_setRatio(btGearConstraint* obj, btScalar ratio);
}
