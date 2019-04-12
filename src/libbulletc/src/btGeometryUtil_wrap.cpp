#include <LinearMath/btGeometryUtil.h>

#include "conversion.h"
#include "btGeometryUtil_wrap.h"

bool btGeometryUtil_areVerticesBehindPlane(btScalar* planeNormal, btAlignedVector3Array* vertices, btScalar margin)
{
	VECTOR3_CONV(planeNormal);
	return btGeometryUtil::areVerticesBehindPlane(VECTOR3_USE(planeNormal), *vertices, margin);
}

void btGeometryUtil_getPlaneEquationsFromVertices(btAlignedVector3Array* vertices, btAlignedVector3Array* planeEquationsOut)
{
	btGeometryUtil::getPlaneEquationsFromVertices(*vertices, *planeEquationsOut);
}

void btGeometryUtil_getVerticesFromPlaneEquations(btAlignedVector3Array* planeEquations, btAlignedVector3Array* verticesOut)
{
	btGeometryUtil::getVerticesFromPlaneEquations(*planeEquations, *verticesOut);
}
/*
bool btGeometryUtil_isInside(btAlignedVector3Array* vertices, btVector3* planeNormal, btScalar margin)
{
	VECTOR3_CONV(planeNormal);
	return btGeometryUtil::isInside(*vertices, VECTOR3_USE(planeNormal), margin);
}
*/
bool btGeometryUtil_isPointInsidePlanes(btAlignedVector3Array* planeEquations, btScalar* point, btScalar margin)
{
	VECTOR3_CONV(point);
	return btGeometryUtil::isPointInsidePlanes(*planeEquations, VECTOR3_USE(point), margin);
}
