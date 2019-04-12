#include "main.h"

extern "C"
{
	EXPORT btCylinderShape* btCylinderShape_new(btScalar* halfExtents);
	EXPORT btCylinderShape* btCylinderShape_new2(btScalar halfExtentX, btScalar halfExtentY, btScalar halfExtentZ);
	EXPORT void btCylinderShape_getHalfExtentsWithMargin(btCylinderShape* obj, btScalar* value);
	EXPORT void btCylinderShape_getHalfExtentsWithoutMargin(btCylinderShape* obj, btScalar* value);
	EXPORT btScalar btCylinderShape_getRadius(btCylinderShape* obj);
	EXPORT int btCylinderShape_getUpAxis(btCylinderShape* obj);

	EXPORT btCylinderShapeX* btCylinderShapeX_new(btScalar* halfExtents);
	EXPORT btCylinderShapeX* btCylinderShapeX_new2(btScalar halfExtentX, btScalar halfExtentY, btScalar halfExtentZ);

	EXPORT btCylinderShapeZ* btCylinderShapeZ_new(btScalar* halfExtents);
	EXPORT btCylinderShapeZ* btCylinderShapeZ_new2(btScalar halfExtentX, btScalar halfExtentY, btScalar halfExtentZ);
}
