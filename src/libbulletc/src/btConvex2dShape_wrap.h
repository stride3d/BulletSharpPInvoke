#include "main.h"

extern "C"
{
	EXPORT btConvex2dShape* btConvex2dShape_new(btConvexShape* convexChildShape);
	EXPORT btConvexShape* btConvex2dShape_getChildShape(btConvex2dShape* obj);
	EXPORT btBox2dShape* btBox2dShape_new(float halfExtentX, float halfExtentY);
}
