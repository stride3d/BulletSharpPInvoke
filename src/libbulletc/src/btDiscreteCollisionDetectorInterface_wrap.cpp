#include "conversion.h"
#include "btDiscreteCollisionDetectorInterface_wrap.h"

void btDiscreteCollisionDetectorInterface_Result_addContactPoint(btDiscreteCollisionDetectorInterface_Result* obj, btScalar* normalOnBInWorld, btScalar* pointInWorld, btScalar depth)
{
	VECTOR3_CONV(normalOnBInWorld);
	VECTOR3_CONV(pointInWorld);
	obj->addContactPoint(VECTOR3_USE(normalOnBInWorld), VECTOR3_USE(pointInWorld), depth);
}

void btDiscreteCollisionDetectorInterface_Result_setShapeIdentifiersA(btDiscreteCollisionDetectorInterface_Result* obj, int partId0, int index0)
{
	obj->setShapeIdentifiersA(partId0, index0);
}

void btDiscreteCollisionDetectorInterface_Result_setShapeIdentifiersB(btDiscreteCollisionDetectorInterface_Result* obj, int partId1, int index1)
{
	obj->setShapeIdentifiersB(partId1, index1);
}

void btDiscreteCollisionDetectorInterface_Result_delete(btDiscreteCollisionDetectorInterface_Result* obj)
{
	delete obj;
}

btDiscreteCollisionDetectorInterface_ClosestPointInput* btDiscreteCollisionDetectorInterface_ClosestPointInput_new()
{
	return new btDiscreteCollisionDetectorInterface_ClosestPointInput();
}

btScalar btDiscreteCollisionDetectorInterface_ClosestPointInput_getMaximumDistanceSquared(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj)
{
	return obj->m_maximumDistanceSquared;
}

void btDiscreteCollisionDetectorInterface_ClosestPointInput_getTransformA(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj, btScalar* value)
{
	TRANSFORM_OUT(&obj->m_transformA, value);
}

void btDiscreteCollisionDetectorInterface_ClosestPointInput_getTransformB(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj, btScalar* value)
{
	TRANSFORM_OUT(&obj->m_transformB, value);
}

void btDiscreteCollisionDetectorInterface_ClosestPointInput_setMaximumDistanceSquared(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj, btScalar value)
{
	obj->m_maximumDistanceSquared = value;
}

void btDiscreteCollisionDetectorInterface_ClosestPointInput_setTransformA(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_transformA);
}

void btDiscreteCollisionDetectorInterface_ClosestPointInput_setTransformB(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_transformB);
}

void btDiscreteCollisionDetectorInterface_ClosestPointInput_delete(btDiscreteCollisionDetectorInterface_ClosestPointInput* obj)
{
	delete obj;
}

void btDiscreteCollisionDetectorInterface_getClosestPoints(btDiscreteCollisionDetectorInterface* obj, btDiscreteCollisionDetectorInterface_ClosestPointInput* input, btDiscreteCollisionDetectorInterface_Result* output, btIDebugDraw* debugDraw, bool swapResults)
{
	obj->getClosestPoints(*input, *output, debugDraw, swapResults);
}

void btDiscreteCollisionDetectorInterface_getClosestPoints2(btDiscreteCollisionDetectorInterface* obj, btDiscreteCollisionDetectorInterface_ClosestPointInput* input, btDiscreteCollisionDetectorInterface_Result* output, btIDebugDraw* debugDraw)
{
	obj->getClosestPoints(*input, *output, debugDraw);
}

void btDiscreteCollisionDetectorInterface_delete(btDiscreteCollisionDetectorInterface* obj)
{
	delete obj;
}

void btStorageResult_getClosestPointInB(btStorageResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_closestPointInB, value);
}

btScalar btStorageResult_getDistance(btStorageResult* obj)
{
	return obj->m_distance;
}

void btStorageResult_getNormalOnSurfaceB(btStorageResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_normalOnSurfaceB, value);
}

void btStorageResult_setClosestPointInB(btStorageResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_closestPointInB);
}

void btStorageResult_setDistance(btStorageResult* obj, btScalar value)
{
	obj->m_distance = value;
}

void btStorageResult_setNormalOnSurfaceB(btStorageResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_normalOnSurfaceB);
}
