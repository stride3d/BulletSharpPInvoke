#include "conversion.h"
#include "btConvexHullShape_wrap.h"

btConvexHullShape* btConvexHullShape_new(btScalar* points, int numPoints, int stride)
{
	return new btConvexHullShape(points, numPoints, stride);
}

btConvexHullShape* btConvexHullShape_new2(btScalar* points, int numPoints)
{
	return new btConvexHullShape(points, numPoints);
}

btConvexHullShape* btConvexHullShape_new3(btScalar* points)
{
	return new btConvexHullShape(points);
}

btConvexHullShape* btConvexHullShape_new4()
{
	return new btConvexHullShape();
}

void btConvexHullShape_addPoint(btConvexHullShape* obj, btScalar* point, bool recalculateLocalAabb)
{
	VECTOR3_CONV(point);
	obj->addPoint(VECTOR3_USE(point), recalculateLocalAabb);
}

void btConvexHullShape_addPoint2(btConvexHullShape* obj, btScalar* point)
{
	VECTOR3_CONV(point);
	obj->addPoint(VECTOR3_USE(point));
}

int btConvexHullShape_getNumPoints(btConvexHullShape* obj)
{
	return obj->getNumPoints();
}
/*
btVector3* btConvexHullShape_getPoints(btConvexHullShape* obj)
{
	return obj->getPoints();
}
*/
void btConvexHullShape_getScaledPoint(btConvexHullShape* obj, int i)
{
	obj->getScaledPoint(i);
}

btVector3* btConvexHullShape_getUnscaledPoints(btConvexHullShape* obj)
{
	return obj->getUnscaledPoints();
}

void btConvexHullShape_project(btConvexHullShape* obj, btScalar* trans, btScalar* dir, btScalar* minProj, btScalar* maxProj, btScalar* witnesPtMin, btScalar* witnesPtMax)
{
	TRANSFORM_CONV(trans);
	VECTOR3_CONV(dir);
	VECTOR3_CONV(witnesPtMin);
	VECTOR3_CONV(witnesPtMax);
	obj->project(TRANSFORM_USE(trans), VECTOR3_USE(dir), *minProj, *maxProj, VECTOR3_USE(witnesPtMin), VECTOR3_USE(witnesPtMax));
}
