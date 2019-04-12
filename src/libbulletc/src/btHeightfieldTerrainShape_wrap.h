#include "main.h"

extern "C"
{
	EXPORT btHeightfieldTerrainShape* btHeightfieldTerrainShape_new(int heightStickWidth, int heightStickLength, const void *heightfieldData, btScalar heightScale, btScalar minHeight, btScalar maxHeight, int upAxis, PHY_ScalarType heightDataType, bool flipQuadEdges);
	EXPORT void btHeightfieldTerrainShape_setUseDiamondSubdivision(btHeightfieldTerrainShape* h, bool use);
	EXPORT void btHeightfieldTerrainShape_setUseZigzagSubdivision(btHeightfieldTerrainShape* h, bool use);
}
