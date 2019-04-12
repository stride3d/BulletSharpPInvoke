#include "conversion.h"
#include "btConvexShape_wrap.h"
/*
void btConvexShape_batchedUnitVectorGetSupportingVertexWithoutMargin(btConvexShape* obj, btVector3* vectors, btVector3* supportVerticesOut, int numVectors)
{
	VECTOR3_CONV(vectors);
	VECTOR3_CONV(supportVerticesOut);
	obj->batchedUnitVectorGetSupportingVertexWithoutMargin(VECTOR3_USE(vectors), VECTOR3_USE(supportVerticesOut), numVectors);
}
*/
void btConvexShape_getAabbNonVirtual(btConvexShape* obj, btScalar* t, btScalar* aabbMin, btScalar* aabbMax)
{
	TRANSFORM_CONV(t);
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->getAabbNonVirtual(TRANSFORM_USE(t), VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}

void btConvexShape_getAabbSlow(btConvexShape* obj, btScalar* t, btScalar* aabbMin, btScalar* aabbMax)
{
	TRANSFORM_CONV(t);
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->getAabbSlow(TRANSFORM_USE(t), VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}

btScalar btConvexShape_getMarginNonVirtual(btConvexShape* obj)
{
	return obj->getMarginNonVirtual();
}

int btConvexShape_getNumPreferredPenetrationDirections(btConvexShape* obj)
{
	return obj->getNumPreferredPenetrationDirections();
}

void btConvexShape_getPreferredPenetrationDirection(btConvexShape* obj, int index, btScalar* penetrationVector)
{
	VECTOR3_DEF(penetrationVector);
	obj->getPreferredPenetrationDirection(index, VECTOR3_USE(penetrationVector));
	VECTOR3_DEF_OUT(penetrationVector);
}

void btConvexShape_localGetSupportingVertex(btConvexShape* obj, btScalar* vec)
{
	VECTOR3_DEF(vec);
	obj->localGetSupportingVertex(VECTOR3_USE(vec));
	VECTOR3_DEF_OUT(vec);
}

void btConvexShape_localGetSupportingVertexWithoutMargin(btConvexShape* obj, btScalar* vec)
{
	VECTOR3_DEF(vec);
	obj->localGetSupportingVertexWithoutMargin(VECTOR3_USE(vec));
	VECTOR3_DEF_OUT(vec);
}

void btConvexShape_localGetSupportVertexNonVirtual(btConvexShape* obj, btScalar* vec)
{
	VECTOR3_DEF(vec);
	obj->localGetSupportVertexNonVirtual(VECTOR3_USE(vec));
	VECTOR3_DEF_OUT(vec);
}

void btConvexShape_localGetSupportVertexWithoutMarginNonVirtual(btConvexShape* obj, btScalar* vec)
{
	VECTOR3_DEF(vec);
	obj->localGetSupportVertexWithoutMarginNonVirtual(VECTOR3_USE(vec));
	VECTOR3_DEF_OUT(vec);
}
/*
void btConvexShape_project(btConvexShape* obj, btScalar* trans, btScalar* dir, btScalar* min, btScalar* max)
{
	TRANSFORM_CONV(trans);
	VECTOR3_CONV(dir);
	obj->project(TRANSFORM_USE(trans), VECTOR3_USE(dir), *min, *max);
}
*/