#include "conversion.h"
#include "btCompoundShape_wrap.h"

btCompoundShapeChild* btCompoundShapeChild_new()
{
	return new btCompoundShapeChild();
}

btScalar btCompoundShapeChild_getChildMargin(btCompoundShapeChild* obj)
{
	return obj->m_childMargin;
}

btCollisionShape* btCompoundShapeChild_getChildShape(btCompoundShapeChild* obj)
{
	return obj->m_childShape;
}

int btCompoundShapeChild_getChildShapeType(btCompoundShapeChild* obj)
{
	return obj->m_childShapeType;
}

btDbvtNode* btCompoundShapeChild_getNode(btCompoundShapeChild* obj)
{
	return obj->m_node;
}

void btCompoundShapeChild_getTransform(btCompoundShapeChild* obj, btScalar* value)
{
	btTransformToMatrix(&obj->m_transform, value);
}

void btCompoundShapeChild_setChildMargin(btCompoundShapeChild* obj, btScalar value)
{
	obj->m_childMargin = value;
}

void btCompoundShapeChild_setChildShape(btCompoundShapeChild* obj, btCollisionShape* value)
{
	obj->m_childShape = value;
}

void btCompoundShapeChild_setChildShapeType(btCompoundShapeChild* obj, int value)
{
	obj->m_childShapeType = value;
}

void btCompoundShapeChild_setNode(btCompoundShapeChild* obj, btDbvtNode* value)
{
	obj->m_node = value;
}

void btCompoundShapeChild_setTransform(btCompoundShapeChild* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_transform);
}

void btCompoundShapeChild_delete(btCompoundShapeChild* obj)
{
	delete obj;
}

btCompoundShape* btCompoundShape_new(bool enableDynamicAabbTree)
{
	return new btCompoundShape(enableDynamicAabbTree);
}

btCompoundShape* btCompoundShape_new2()
{
	return new btCompoundShape();
}

void btCompoundShape_addChildShape(btCompoundShape* obj, btScalar* localTransform, btCollisionShape* shape)
{
	TRANSFORM_CONV(localTransform);
	obj->addChildShape(TRANSFORM_USE(localTransform), shape);
}
/*
void btCompoundShape_calculatePrincipalAxisTransform(btCompoundShape* obj, btScalar* masses, btTransform* principal, btVector3* inertia)
{
	TRANSFORM_CONV(principal);
	VECTOR3_CONV(inertia);
	obj->calculatePrincipalAxisTransform(masses, TRANSFORM_USE(principal), VECTOR3_USE(inertia));
}
*/
void btCompoundShape_createAabbTreeFromChildren(btCompoundShape* obj)
{
	obj->createAabbTreeFromChildren();
}

btCompoundShapeChild* btCompoundShape_getChildList(btCompoundShape* obj)
{
	return obj->getChildList();
}

btCollisionShape* btCompoundShape_getChildShape(btCompoundShape* obj, int index)
{
	return obj->getChildShape(index);
}

btTransform* btCompoundShape_getChildTransform(btCompoundShape* obj, int index)
{
	return &obj->getChildTransform(index);
}

btDbvt* btCompoundShape_getDynamicAabbTree(btCompoundShape* obj)
{
	return obj->getDynamicAabbTree();
}

int btCompoundShape_getNumChildShapes(btCompoundShape* obj)
{
	return obj->getNumChildShapes();
}

int btCompoundShape_getUpdateRevision(btCompoundShape* obj)
{
	return obj->getUpdateRevision();
}

void btCompoundShape_recalculateLocalAabb(btCompoundShape* obj)
{
	obj->recalculateLocalAabb();
}

void btCompoundShape_removeChildShape(btCompoundShape* obj, btCollisionShape* shape)
{
	obj->removeChildShape(shape);
}

void btCompoundShape_removeChildShapeByIndex(btCompoundShape* obj, int childShapeindex)
{
	obj->removeChildShapeByIndex(childShapeindex);
}

void btCompoundShape_updateChildTransform(btCompoundShape* obj, int childIndex, btScalar* newChildTransform, bool shouldRecalculateLocalAabb)
{
	TRANSFORM_CONV(newChildTransform);
	obj->updateChildTransform(childIndex, TRANSFORM_USE(newChildTransform), shouldRecalculateLocalAabb);
}

void btCompoundShape_updateChildTransform2(btCompoundShape* obj, int childIndex, btScalar* newChildTransform)
{
	TRANSFORM_CONV(newChildTransform);
	obj->updateChildTransform(childIndex, TRANSFORM_USE(newChildTransform));
}
