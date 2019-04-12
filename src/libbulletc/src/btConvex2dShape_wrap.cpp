#include <BulletCollision/CollisionShapes/btConvex2dShape.h>
#include <BulletCollision/CollisionShapes/btBox2dShape.h>

#include "conversion.h"
#include "btConvex2dShape_wrap.h"


btConvex2dShape* btConvex2dShape_new(btConvexShape* convexChildShape)
{
	return new btConvex2dShape(convexChildShape);
}

btConvexShape* btConvex2dShape_getChildShape(btConvex2dShape* obj)
{
	return obj->getChildShape();
}

btBox2dShape* btBox2dShape_new(float halfExtentX, float halfExtentY)
{
	btVector3 s(halfExtentX, halfExtentY, 0);
	return new btBox2dShape(s);
}
