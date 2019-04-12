#include "main.h"

extern "C"
{
	EXPORT btCompoundShapeChild* btCompoundShapeChild_new();
	EXPORT btScalar btCompoundShapeChild_getChildMargin(btCompoundShapeChild* obj);
	EXPORT btCollisionShape* btCompoundShapeChild_getChildShape(btCompoundShapeChild* obj);
	EXPORT int btCompoundShapeChild_getChildShapeType(btCompoundShapeChild* obj);
	EXPORT btDbvtNode* btCompoundShapeChild_getNode(btCompoundShapeChild* obj);
	EXPORT void btCompoundShapeChild_getTransform(btCompoundShapeChild* obj, btScalar* value);
	EXPORT void btCompoundShapeChild_setChildMargin(btCompoundShapeChild* obj, btScalar value);
	EXPORT void btCompoundShapeChild_setChildShape(btCompoundShapeChild* obj, btCollisionShape* value);
	EXPORT void btCompoundShapeChild_setChildShapeType(btCompoundShapeChild* obj, int value);
	EXPORT void btCompoundShapeChild_setNode(btCompoundShapeChild* obj, btDbvtNode* value);
	EXPORT void btCompoundShapeChild_setTransform(btCompoundShapeChild* obj, btScalar* value);
	EXPORT void btCompoundShapeChild_delete(btCompoundShapeChild* obj);

	EXPORT btCompoundShape* btCompoundShape_new(bool enableDynamicAabbTree);
	EXPORT btCompoundShape* btCompoundShape_new2();
	EXPORT void btCompoundShape_addChildShape(btCompoundShape* obj, btScalar* localTransform, btCollisionShape* shape);
	//EXPORT void btCompoundShape_calculatePrincipalAxisTransform(btCompoundShape* obj, btScalar* masses, btTransform* principal, btVector3* inertia);
	EXPORT void btCompoundShape_createAabbTreeFromChildren(btCompoundShape* obj);
	EXPORT btCompoundShapeChild* btCompoundShape_getChildList(btCompoundShape* obj);
	EXPORT btCollisionShape* btCompoundShape_getChildShape(btCompoundShape* obj, int index);
	EXPORT btTransform* btCompoundShape_getChildTransform(btCompoundShape* obj, int index);
	EXPORT btDbvt* btCompoundShape_getDynamicAabbTree(btCompoundShape* obj);
	EXPORT int btCompoundShape_getNumChildShapes(btCompoundShape* obj);
	EXPORT int btCompoundShape_getUpdateRevision(btCompoundShape* obj);
	EXPORT void btCompoundShape_recalculateLocalAabb(btCompoundShape* obj);
	EXPORT void btCompoundShape_removeChildShape(btCompoundShape* obj, btCollisionShape* shape);
	EXPORT void btCompoundShape_removeChildShapeByIndex(btCompoundShape* obj, int childShapeindex);
	EXPORT void btCompoundShape_updateChildTransform(btCompoundShape* obj, int childIndex, btScalar* newChildTransform, bool shouldRecalculateLocalAabb);
	EXPORT void btCompoundShape_updateChildTransform2(btCompoundShape* obj, int childIndex, btScalar* newChildTransform);
}
