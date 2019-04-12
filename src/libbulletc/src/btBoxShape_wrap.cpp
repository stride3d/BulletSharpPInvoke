#include "conversion.h"
#include "btBoxShape_wrap.h"

btBoxShape* btBoxShape_new(btScalar* boxHalfExtents)
{
	VECTOR3_CONV(boxHalfExtents);
	return new btBoxShape(VECTOR3_USE(boxHalfExtents));
}

btBoxShape* btBoxShape_new2(btScalar boxHalfExtent)
{
	return new btBoxShape(btVector3(boxHalfExtent, boxHalfExtent, boxHalfExtent));
}

btBoxShape* btBoxShape_new3(btScalar boxHalfExtentX, btScalar boxHalfExtentY, btScalar boxHalfExtentZ)
{
	return new btBoxShape(btVector3(boxHalfExtentX, boxHalfExtentY, boxHalfExtentZ));
}

void btBoxShape_getHalfExtentsWithMargin(btBoxShape* obj, btScalar* extents)
{
	VECTOR3_OUT2(obj->getHalfExtentsWithMargin(), extents);
}

void btBoxShape_getHalfExtentsWithoutMargin(btBoxShape* obj, btScalar* extents)
{
	VECTOR3_OUT(&obj->getHalfExtentsWithoutMargin(), extents);
}

void btBoxShape_getPlaneEquation(btBoxShape* obj, btScalar* plane, int i)
{
	btVector4* planeTemp = ALIGNED_NEW(btVector4);
	obj->getPlaneEquation(*planeTemp, i);
	btVector4ToVector4(planeTemp, plane);
}
