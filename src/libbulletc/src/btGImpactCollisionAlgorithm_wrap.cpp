#include <BulletCollision/CollisionDispatch/btCollisionObjectWrapper.h>
#include <BulletCollision/Gimpact/btGImpactCollisionAlgorithm.h>

#include "btGImpactCollisionAlgorithm_wrap.h"

btGImpactCollisionAlgorithm::CreateFunc* btGImpactCollisionAlgorithm_CreateFunc_new()
{
	return new btGImpactCollisionAlgorithm::CreateFunc();
}

btGImpactCollisionAlgorithm* btGImpactCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap)
{
	return new btGImpactCollisionAlgorithm(*ci, body0Wrap, body1Wrap);
}

int btGImpactCollisionAlgorithm_getFace0(btGImpactCollisionAlgorithm* obj)
{
	return obj->getFace0();
}

int btGImpactCollisionAlgorithm_getFace1(btGImpactCollisionAlgorithm* obj)
{
	return obj->getFace1();
}

int btGImpactCollisionAlgorithm_getPart0(btGImpactCollisionAlgorithm* obj)
{
	return obj->getPart0();
}

int btGImpactCollisionAlgorithm_getPart1(btGImpactCollisionAlgorithm* obj)
{
	return obj->getPart1();
}

void btGImpactCollisionAlgorithm_gimpact_vs_compoundshape(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btCompoundShape* shape1, bool swapped)
{
	obj->gimpact_vs_compoundshape(body0Wrap, body1Wrap, shape0, shape1, swapped);
}

void btGImpactCollisionAlgorithm_gimpact_vs_concave(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btConcaveShape* shape1, bool swapped)
{
	obj->gimpact_vs_concave(body0Wrap, body1Wrap, shape0, shape1, swapped);
}

void btGImpactCollisionAlgorithm_gimpact_vs_gimpact(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btGImpactShapeInterface* shape1)
{
	obj->gimpact_vs_gimpact(body0Wrap, body1Wrap, shape0, shape1);
}

void btGImpactCollisionAlgorithm_gimpact_vs_shape(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btCollisionShape* shape1, bool swapped)
{
	obj->gimpact_vs_shape(body0Wrap, body1Wrap, shape0, shape1, swapped);
}

btManifoldResult* btGImpactCollisionAlgorithm_internalGetResultOut(btGImpactCollisionAlgorithm* obj)
{
	return obj->internalGetResultOut();
}

void btGImpactCollisionAlgorithm_registerAlgorithm(btCollisionDispatcher* dispatcher)
{
	btGImpactCollisionAlgorithm::registerAlgorithm(dispatcher);
}

void btGImpactCollisionAlgorithm_setFace0(btGImpactCollisionAlgorithm* obj, int value)
{
	obj->setFace0(value);
}

void btGImpactCollisionAlgorithm_setFace1(btGImpactCollisionAlgorithm* obj, int value)
{
	obj->setFace1(value);
}

void btGImpactCollisionAlgorithm_setPart0(btGImpactCollisionAlgorithm* obj, int value)
{
	obj->setPart0(value);
}

void btGImpactCollisionAlgorithm_setPart1(btGImpactCollisionAlgorithm* obj, int value)
{
	obj->setPart1(value);
}
