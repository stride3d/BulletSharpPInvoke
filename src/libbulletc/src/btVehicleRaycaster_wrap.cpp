#include <BulletDynamics/Vehicle/btVehicleRaycaster.h>

#include "conversion.h"
#include "btVehicleRaycaster_wrap.h"

btVehicleRaycaster_btVehicleRaycasterResult* btVehicleRaycaster_btVehicleRaycasterResult_new()
{
	return new btVehicleRaycaster_btVehicleRaycasterResult();
}

btScalar btVehicleRaycaster_btVehicleRaycasterResult_getDistFraction(btVehicleRaycaster_btVehicleRaycasterResult* obj)
{
	return obj->m_distFraction;
}

void btVehicleRaycaster_btVehicleRaycasterResult_getHitNormalInWorld(btVehicleRaycaster_btVehicleRaycasterResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitNormalInWorld, value);
}

void btVehicleRaycaster_btVehicleRaycasterResult_getHitPointInWorld(btVehicleRaycaster_btVehicleRaycasterResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_hitPointInWorld, value);
}

void btVehicleRaycaster_btVehicleRaycasterResult_setDistFraction(btVehicleRaycaster_btVehicleRaycasterResult* obj, btScalar value)
{
	obj->m_distFraction = value;
}

void btVehicleRaycaster_btVehicleRaycasterResult_setHitNormalInWorld(btVehicleRaycaster_btVehicleRaycasterResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitNormalInWorld);
}

void btVehicleRaycaster_btVehicleRaycasterResult_setHitPointInWorld(btVehicleRaycaster_btVehicleRaycasterResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_hitPointInWorld);
}

void btVehicleRaycaster_btVehicleRaycasterResult_delete(btVehicleRaycaster_btVehicleRaycasterResult* obj)
{
	delete obj;
}

void* btVehicleRaycaster_castRay(btVehicleRaycaster* obj, btScalar* from, btScalar* to, btVehicleRaycaster_btVehicleRaycasterResult* result)
{
	VECTOR3_CONV(from);
	VECTOR3_CONV(to);
	return obj->castRay(VECTOR3_USE(from), VECTOR3_USE(to), *result);
}

void btVehicleRaycaster_delete(btVehicleRaycaster* obj)
{
	delete obj;
}
