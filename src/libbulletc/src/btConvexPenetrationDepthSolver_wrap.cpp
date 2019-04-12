#include <BulletCollision/NarrowPhaseCollision/btConvexPenetrationDepthSolver.h>

#include "conversion.h"
#include "btConvexPenetrationDepthSolver_wrap.h"

bool btConvexPenetrationDepthSolver_calcPenDepth(btConvexPenetrationDepthSolver* obj, btVoronoiSimplexSolver* simplexSolver, btConvexShape* convexA, btConvexShape* convexB, btScalar* transA, btScalar* transB, btScalar* v, btScalar* pa, btScalar* pb, btIDebugDraw* debugDraw)
{
	TRANSFORM_CONV(transA);
	TRANSFORM_CONV(transB);
	VECTOR3_CONV(v);
	VECTOR3_CONV(pa);
	VECTOR3_CONV(pb);
	return obj->calcPenDepth(*simplexSolver, convexA, convexB, TRANSFORM_USE(transA), TRANSFORM_USE(transB), VECTOR3_USE(v), VECTOR3_USE(pa), VECTOR3_USE(pb), debugDraw);
}

void btConvexPenetrationDepthSolver_delete(btConvexPenetrationDepthSolver* obj)
{
	delete obj;
}
