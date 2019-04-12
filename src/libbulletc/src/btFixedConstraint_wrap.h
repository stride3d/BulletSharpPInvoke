#include "main.h"

extern "C"
{
	EXPORT btFixedConstraint* btFixedConstraint_new(btRigidBody* rbA, btRigidBody* rbB, btScalar* frameInA, btScalar* frameInB);
}
