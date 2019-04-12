#include "main.h"

extern "C"
{
	EXPORT btBoxShape* btBoxShape_new(btScalar* boxHalfExtents);
	EXPORT btBoxShape* btBoxShape_new2(btScalar boxHalfExtent);
	EXPORT btBoxShape* btBoxShape_new3(btScalar boxHalfExtentX, btScalar boxHalfExtentY, btScalar boxHalfExtentZ);
	EXPORT void btBoxShape_getHalfExtentsWithMargin(btBoxShape* obj, btScalar* extents);
	EXPORT void btBoxShape_getHalfExtentsWithoutMargin(btBoxShape* obj, btScalar* extents);
	EXPORT void btBoxShape_getPlaneEquation(btBoxShape* obj, btScalar* plane, int i);
}
