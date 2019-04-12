#include "main.h"

extern "C"
{
	EXPORT bool btConvexPenetrationDepthSolver_calcPenDepth(btConvexPenetrationDepthSolver* obj, btVoronoiSimplexSolver* simplexSolver, btConvexShape* convexA, btConvexShape* convexB, btScalar* transA, btScalar* transB, btScalar* v, btScalar* pa, btScalar* pb, btIDebugDraw* debugDraw);
	EXPORT void btConvexPenetrationDepthSolver_delete(btConvexPenetrationDepthSolver* obj);
}
