#include "conversion.h"
#include "BulletCollision/CollisionShapes/btHeightfieldTerrainShape.h"
#include "btHeightfieldTerrainShape_wrap.h"

btHeightfieldTerrainShape* btHeightfieldTerrainShape_new(int heightStickWidth, int heightStickLength, const void *heightfieldData, btScalar heightScale, btScalar minHeight, btScalar maxHeight, int upAxis, PHY_ScalarType heightDataType, bool flipQuadEdges)
{
	return new btHeightfieldTerrainShape(heightStickWidth, heightStickLength, heightfieldData, heightScale, minHeight, maxHeight, upAxis, heightDataType, flipQuadEdges);
}

void btHeightfieldTerrainShape_setUseDiamondSubdivision(btHeightfieldTerrainShape* h, bool use)
{
	h->setUseDiamondSubdivision(use);
}

void btHeightfieldTerrainShape_setUseZigzagSubdivision(btHeightfieldTerrainShape* h, bool use)
{
	h->setUseZigzagSubdivision(use);
}
