#include "main.h"

extern "C"
{
	EXPORT void btConstraintSolver_delete(btConstraintSolver* obj);
	EXPORT void btConstraintSolver_allSolved(btConstraintSolver* obj, btContactSolverInfo* __unnamed0, btIDebugDraw* __unnamed1);
	EXPORT void btConstraintSolver_prepareSolve(btConstraintSolver* obj, int __unnamed0, int __unnamed1);
	EXPORT void btConstraintSolver_reset(btConstraintSolver* obj);
	//EXPORT btScalar btConstraintSolver_solveGroup(btConstraintSolver* obj, * bodies, int numBodies, * manifold, int numManifolds, * constraints, int numConstraints, btContactSolverInfo* info, btIDebugDraw* debugDrawer, btDispatcher* dispatcher);
}
