#include "main.h"

extern "C"
{
	EXPORT float btSoftBodyHelpers_CalculateUV(int resx, int resy, int ix, int iy, int id);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateEllipsoid(btSoftBodyWorldInfo* worldInfo, btScalar* center, btScalar* radius, int res);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateFromConvexHull(btSoftBodyWorldInfo* worldInfo, btScalar* vertices, int nvertices, bool randomizeConstraints);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateFromConvexHull2(btSoftBodyWorldInfo* worldInfo, btScalar* vertices, int nvertices);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateFromTetGenData(btSoftBodyWorldInfo* worldInfo, char* ele, char* face, char* node, bool bfacelinks, bool btetralinks, bool bfacesfromtetras);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateFromTriMesh(btSoftBodyWorldInfo* worldInfo, btScalar* vertices, int* triangles, int ntriangles, bool randomizeConstraints);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateFromTriMesh2(btSoftBodyWorldInfo* worldInfo, btScalar* vertices, int* triangles, int ntriangles);
	EXPORT btSoftBody* btSoftBodyHelpers_CreatePatch(btSoftBodyWorldInfo* worldInfo, btScalar* corner00, btScalar* corner10, btScalar* corner01, btScalar* corner11, int resx, int resy, int fixeds, bool gendiags);
	EXPORT btSoftBody* btSoftBodyHelpers_CreatePatchUV(btSoftBodyWorldInfo* worldInfo, btScalar* corner00, btScalar* corner10, btScalar* corner01, btScalar* corner11, int resx, int resy, int fixeds, bool gendiags, float* tex_coords);
	EXPORT btSoftBody* btSoftBodyHelpers_CreatePatchUV2(btSoftBodyWorldInfo* worldInfo, btScalar* corner00, btScalar* corner10, btScalar* corner01, btScalar* corner11, int resx, int resy, int fixeds, bool gendiags);
	EXPORT btSoftBody* btSoftBodyHelpers_CreateRope(btSoftBodyWorldInfo* worldInfo, btScalar* from, btScalar* to, int res, int fixeds);
	EXPORT void btSoftBodyHelpers_Draw(btSoftBody* psb, btIDebugDraw* idraw, int drawflags);
	EXPORT void btSoftBodyHelpers_Draw2(btSoftBody* psb, btIDebugDraw* idraw);
	EXPORT void btSoftBodyHelpers_DrawClusterTree(btSoftBody* psb, btIDebugDraw* idraw, int mindepth, int maxdepth);
	EXPORT void btSoftBodyHelpers_DrawClusterTree2(btSoftBody* psb, btIDebugDraw* idraw, int mindepth);
	EXPORT void btSoftBodyHelpers_DrawClusterTree3(btSoftBody* psb, btIDebugDraw* idraw);
	EXPORT void btSoftBodyHelpers_DrawFaceTree(btSoftBody* psb, btIDebugDraw* idraw, int mindepth, int maxdepth);
	EXPORT void btSoftBodyHelpers_DrawFaceTree2(btSoftBody* psb, btIDebugDraw* idraw, int mindepth);
	EXPORT void btSoftBodyHelpers_DrawFaceTree3(btSoftBody* psb, btIDebugDraw* idraw);
	EXPORT void btSoftBodyHelpers_DrawFrame(btSoftBody* psb, btIDebugDraw* idraw);
	EXPORT void btSoftBodyHelpers_DrawInfos(btSoftBody* psb, btIDebugDraw* idraw, bool masses, bool areas, bool stress);
	EXPORT void btSoftBodyHelpers_DrawNodeTree(btSoftBody* psb, btIDebugDraw* idraw, int mindepth, int maxdepth);
	EXPORT void btSoftBodyHelpers_DrawNodeTree2(btSoftBody* psb, btIDebugDraw* idraw, int mindepth);
	EXPORT void btSoftBodyHelpers_DrawNodeTree3(btSoftBody* psb, btIDebugDraw* idraw);
}
