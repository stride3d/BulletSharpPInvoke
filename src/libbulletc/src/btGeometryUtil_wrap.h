#include "main.h"

extern "C"
{
	EXPORT bool btGeometryUtil_areVerticesBehindPlane(btScalar* planeNormal, btAlignedVector3Array* vertices, btScalar margin);
	EXPORT void btGeometryUtil_getPlaneEquationsFromVertices(btAlignedVector3Array* vertices, btAlignedVector3Array* planeEquationsOut);
	EXPORT void btGeometryUtil_getVerticesFromPlaneEquations(btAlignedVector3Array* planeEquations, btAlignedVector3Array* verticesOut);
	//EXPORT bool btGeometryUtil_isInside(btAlignedVector3Array* vertices, btVector3* planeNormal, btScalar margin);
	EXPORT bool btGeometryUtil_isPointInsidePlanes(btAlignedVector3Array* planeEquations, btScalar* point, btScalar margin);
}
