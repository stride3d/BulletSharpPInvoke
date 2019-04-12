#include "conversion.h"
#include "btActionInterface_wrap.h"

void btActionInterface_debugDraw(btActionInterface* obj, btIDebugDraw* debugDrawer)
{
	obj->debugDraw(debugDrawer);
}

void btActionInterface_updateAction(btActionInterface* obj, btCollisionWorld* collisionWorld, btScalar deltaTimeStep)
{
	obj->updateAction(collisionWorld, deltaTimeStep);
}

void btActionInterface_delete(btActionInterface* obj)
{
	delete obj;
}
