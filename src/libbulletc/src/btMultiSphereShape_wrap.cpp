#include "conversion.h"
#include "btMultiSphereShape_wrap.h"

btMultiSphereShape* btMultiSphereShape_new(btScalar* positions, btScalar* radi, int numSpheres)
{
	btVector3* positionsTemp = new btVector3[numSpheres];
	for (int i = 0; i < numSpheres; i++)
	{
		Vector3TobtVector3(&positions[i*3], &positionsTemp[i]);
	}
	btMultiSphereShape* shape = new btMultiSphereShape(positionsTemp, radi, numSpheres);
	delete[] positionsTemp;
	return shape;
}

btMultiSphereShape* btMultiSphereShape_new2(btVector3* positions, btScalar* radi, int numSpheres)
{
	return new btMultiSphereShape(positions, radi, numSpheres);
}

int btMultiSphereShape_getSphereCount(btMultiSphereShape* obj)
{
	return obj->getSphereCount();
}

void btMultiSphereShape_getSpherePosition(btMultiSphereShape* obj, int index, btScalar* value)
{
	VECTOR3_OUT(&obj->getSpherePosition(index), value);
}

btScalar btMultiSphereShape_getSphereRadius(btMultiSphereShape* obj, int index)
{
	return obj->getSphereRadius(index);
}

btPositionAndRadius* btPositionAndRadius_new()
{
	return new btPositionAndRadius();
}
/*
void btPositionAndRadius_getPos(btPositionAndRadius* obj, btScalar* value)
{
	obj->m_pos;
}
*/
float btPositionAndRadius_getRadius(btPositionAndRadius* obj)
{
	return obj->m_radius;
}
/*
void btPositionAndRadius_setPos(btPositionAndRadius* obj, btScalar* value)
{
	obj->m_pos = value;
}
*/
void btPositionAndRadius_setRadius(btPositionAndRadius* obj, float value)
{
	obj->m_radius = value;
}

void btPositionAndRadius_delete(btPositionAndRadius* obj)
{
	delete obj;
}
