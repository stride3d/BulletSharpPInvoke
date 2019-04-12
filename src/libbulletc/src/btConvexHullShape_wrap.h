#include "main.h"

extern "C"
{
	EXPORT btConvexHullShape* btConvexHullShape_new(btScalar* points, int numPoints, int stride);
	EXPORT btConvexHullShape* btConvexHullShape_new2(btScalar* points, int numPoints);
	EXPORT btConvexHullShape* btConvexHullShape_new3(btScalar* points);
	EXPORT btConvexHullShape* btConvexHullShape_new4();
	EXPORT void btConvexHullShape_addPoint(btConvexHullShape* obj, btScalar* point, bool recalculateLocalAabb);
	EXPORT void btConvexHullShape_addPoint2(btConvexHullShape* obj, btScalar* point);
	EXPORT int btConvexHullShape_getNumPoints(btConvexHullShape* obj);
	EXPORT btVector3* btConvexHullShape_getPoints(btConvexHullShape* obj);
	EXPORT void btConvexHullShape_getScaledPoint(btConvexHullShape* obj, int i);
	EXPORT btVector3* btConvexHullShape_getUnscaledPoints(btConvexHullShape* obj);
	EXPORT void btConvexHullShape_project(btConvexHullShape* obj, btScalar* trans, btScalar* dir, btScalar* minProj, btScalar* maxProj, btScalar* witnesPtMin, btScalar* witnesPtMax);
}
