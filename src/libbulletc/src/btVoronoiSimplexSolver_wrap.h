#include "main.h"

extern "C"
{
	EXPORT btUsageBitfield* btUsageBitfield_new();
	EXPORT unsigned short btUsageBitfield_getUnused1(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUnused2(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUnused3(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUnused4(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUsedVertexA(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUsedVertexB(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUsedVertexC(btUsageBitfield* obj);
	EXPORT unsigned short btUsageBitfield_getUsedVertexD(btUsageBitfield* obj);
	EXPORT void btUsageBitfield_reset(btUsageBitfield* obj);
	EXPORT void btUsageBitfield_setUnused1(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUnused2(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUnused3(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUnused4(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUsedVertexA(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUsedVertexB(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUsedVertexC(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_setUsedVertexD(btUsageBitfield* obj, unsigned short value);
	EXPORT void btUsageBitfield_delete(btUsageBitfield* obj);

	EXPORT btSubSimplexClosestResult* btSubSimplexClosestResult_new();
	EXPORT btScalar* btSubSimplexClosestResult_getBarycentricCoords(btSubSimplexClosestResult* obj);
	EXPORT void btSubSimplexClosestResult_getClosestPointOnSimplex(btSubSimplexClosestResult* obj, btScalar* value);
	EXPORT bool btSubSimplexClosestResult_getDegenerate(btSubSimplexClosestResult* obj);
	EXPORT btUsageBitfield* btSubSimplexClosestResult_getUsedVertices(btSubSimplexClosestResult* obj);
	EXPORT bool btSubSimplexClosestResult_isValid(btSubSimplexClosestResult* obj);
	EXPORT void btSubSimplexClosestResult_reset(btSubSimplexClosestResult* obj);
	EXPORT void btSubSimplexClosestResult_setBarycentricCoordinates(btSubSimplexClosestResult* obj, btScalar a, btScalar b, btScalar c, btScalar d);
	EXPORT void btSubSimplexClosestResult_setBarycentricCoordinates2(btSubSimplexClosestResult* obj, btScalar a, btScalar b, btScalar c);
	EXPORT void btSubSimplexClosestResult_setBarycentricCoordinates3(btSubSimplexClosestResult* obj, btScalar a, btScalar b);
	EXPORT void btSubSimplexClosestResult_setBarycentricCoordinates4(btSubSimplexClosestResult* obj, btScalar a);
	EXPORT void btSubSimplexClosestResult_setBarycentricCoordinates5(btSubSimplexClosestResult* obj);
	//EXPORT void btSubSimplexClosestResult_setBarycentricCoords(btSubSimplexClosestResult* obj, btScalar* value);
	EXPORT void btSubSimplexClosestResult_setClosestPointOnSimplex(btSubSimplexClosestResult* obj, btScalar* value);
	EXPORT void btSubSimplexClosestResult_setDegenerate(btSubSimplexClosestResult* obj, bool value);
	//EXPORT void btSubSimplexClosestResult_setUsedVertices(btSubSimplexClosestResult* obj, void value);
	EXPORT void btSubSimplexClosestResult_delete(btSubSimplexClosestResult* obj);

	EXPORT btVoronoiSimplexSolver* btVoronoiSimplexSolver_new();
	EXPORT void btVoronoiSimplexSolver_addVertex(btVoronoiSimplexSolver* obj, btScalar* w, btScalar* p, btScalar* q);
	EXPORT void btVoronoiSimplexSolver_backup_closest(btVoronoiSimplexSolver* obj, btScalar* v);
	EXPORT bool btVoronoiSimplexSolver_closest(btVoronoiSimplexSolver* obj, btScalar* v);
	EXPORT bool btVoronoiSimplexSolver_closestPtPointTetrahedron(btVoronoiSimplexSolver* obj, btScalar* p, btScalar* a, btScalar* b, btScalar* c, btScalar* d, btSubSimplexClosestResult* finalResult);
	EXPORT bool btVoronoiSimplexSolver_closestPtPointTriangle(btVoronoiSimplexSolver* obj, btScalar* p, btScalar* a, btScalar* b, btScalar* c, btSubSimplexClosestResult* result);
	EXPORT void btVoronoiSimplexSolver_compute_points(btVoronoiSimplexSolver* obj, btScalar* p1, btScalar* p2);
	EXPORT bool btVoronoiSimplexSolver_emptySimplex(btVoronoiSimplexSolver* obj);
	EXPORT bool btVoronoiSimplexSolver_fullSimplex(btVoronoiSimplexSolver* obj);
	EXPORT btSubSimplexClosestResult* btVoronoiSimplexSolver_getCachedBC(btVoronoiSimplexSolver* obj);
	EXPORT void btVoronoiSimplexSolver_getCachedP1(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT void btVoronoiSimplexSolver_getCachedP2(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT void btVoronoiSimplexSolver_getCachedV(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT bool btVoronoiSimplexSolver_getCachedValidClosest(btVoronoiSimplexSolver* obj);
	EXPORT btScalar btVoronoiSimplexSolver_getEqualVertexThreshold(btVoronoiSimplexSolver* obj);
	EXPORT btScalar btVoronoiSimplexSolver_getEqualVertexThreshold2(btVoronoiSimplexSolver* obj);
	EXPORT void btVoronoiSimplexSolver_getLastW(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT bool btVoronoiSimplexSolver_getNeedsUpdate(btVoronoiSimplexSolver* obj);
	EXPORT int btVoronoiSimplexSolver_getNumVertices(btVoronoiSimplexSolver* obj);
	EXPORT int btVoronoiSimplexSolver_getSimplex(btVoronoiSimplexSolver* obj, btScalar* pBuf, btScalar* qBuf, btScalar* yBuf);
	EXPORT btVector3* btVoronoiSimplexSolver_getSimplexPointsP(btVoronoiSimplexSolver* obj);
	EXPORT btVector3* btVoronoiSimplexSolver_getSimplexPointsQ(btVoronoiSimplexSolver* obj);
	EXPORT btVector3* btVoronoiSimplexSolver_getSimplexVectorW(btVoronoiSimplexSolver* obj);
	EXPORT bool btVoronoiSimplexSolver_inSimplex(btVoronoiSimplexSolver* obj, btScalar* w);
	EXPORT btScalar btVoronoiSimplexSolver_maxVertex(btVoronoiSimplexSolver* obj);
	EXPORT int btVoronoiSimplexSolver_numVertices(btVoronoiSimplexSolver* obj);
	EXPORT int btVoronoiSimplexSolver_pointOutsideOfPlane(btVoronoiSimplexSolver* obj, btScalar* p, btScalar* a, btScalar* b, btScalar* c, btScalar* d);
	EXPORT void btVoronoiSimplexSolver_reduceVertices(btVoronoiSimplexSolver* obj, btUsageBitfield* usedVerts);
	EXPORT void btVoronoiSimplexSolver_removeVertex(btVoronoiSimplexSolver* obj, int index);
	EXPORT void btVoronoiSimplexSolver_reset(btVoronoiSimplexSolver* obj);
	EXPORT void btVoronoiSimplexSolver_setCachedBC(btVoronoiSimplexSolver* obj, btSubSimplexClosestResult* value);
	EXPORT void btVoronoiSimplexSolver_setCachedP1(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT void btVoronoiSimplexSolver_setCachedP2(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT void btVoronoiSimplexSolver_setCachedV(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT void btVoronoiSimplexSolver_setCachedValidClosest(btVoronoiSimplexSolver* obj, bool value);
	EXPORT void btVoronoiSimplexSolver_setEqualVertexThreshold(btVoronoiSimplexSolver* obj, btScalar threshold);
	EXPORT void btVoronoiSimplexSolver_setEqualVertexThreshold2(btVoronoiSimplexSolver* obj, btScalar value);
	EXPORT void btVoronoiSimplexSolver_setLastW(btVoronoiSimplexSolver* obj, btScalar* value);
	EXPORT void btVoronoiSimplexSolver_setNeedsUpdate(btVoronoiSimplexSolver* obj, bool value);
	EXPORT void btVoronoiSimplexSolver_setNumVertices(btVoronoiSimplexSolver* obj, int value);
	/*EXPORT void btVoronoiSimplexSolver_setSimplexPointsP(btVoronoiSimplexSolver* obj, btVector3* value);
	EXPORT void btVoronoiSimplexSolver_setSimplexPointsQ(btVoronoiSimplexSolver* obj, btVector3* value);
	EXPORT void btVoronoiSimplexSolver_setSimplexVectorW(btVoronoiSimplexSolver* obj, btVector3* value);*/
	EXPORT bool btVoronoiSimplexSolver_updateClosestVectorAndPoints(btVoronoiSimplexSolver* obj);
	EXPORT void btVoronoiSimplexSolver_delete(btVoronoiSimplexSolver* obj);
}
