#include "conversion.h"
#include "btConstraintSolver_wrap.h"

void btConstraintSolver_delete(btConstraintSolver* obj)
{
	ALIGNED_FREE(obj);
}

void btConstraintSolver_allSolved(btConstraintSolver* obj, btContactSolverInfo* __unnamed0, btIDebugDraw* __unnamed1)
{
	obj->allSolved(*__unnamed0, __unnamed1);
}

void btConstraintSolver_prepareSolve(btConstraintSolver* obj, int __unnamed0, int __unnamed1)
{
	obj->prepareSolve(__unnamed0, __unnamed1);
}

void btConstraintSolver_reset(btConstraintSolver* obj)
{
	obj->reset();
}
/*
btScalar btConstraintSolver_solveGroup(btConstraintSolver* obj, * bodies, int numBodies, * manifold, int numManifolds, * constraints, int numConstraints, btContactSolverInfo* info, btIDebugDraw* debugDrawer, btDispatcher* dispatcher)
{
	return obj->solveGroup(bodies, numBodies, manifold, numManifolds, constraints, numConstraints, *info, debugDrawer, dispatcher);
}
*/