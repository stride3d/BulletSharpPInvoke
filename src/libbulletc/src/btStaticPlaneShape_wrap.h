#include "main.h"

extern "C"
{
	EXPORT btStaticPlaneShape* btStaticPlaneShape_new(btScalar* planeNormal, btScalar planeConstant);
	EXPORT btScalar btStaticPlaneShape_getPlaneConstant(btStaticPlaneShape* obj);
	EXPORT void btStaticPlaneShape_getPlaneNormal(btStaticPlaneShape* obj, btScalar* value);
}
