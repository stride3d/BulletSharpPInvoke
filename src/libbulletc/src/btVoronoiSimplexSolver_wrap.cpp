#include <BulletCollision/NarrowPhaseCollision/btVoronoiSimplexSolver.h>

#include "conversion.h"
#include "btVoronoiSimplexSolver_wrap.h"

btUsageBitfield* btUsageBitfield_new()
{
	return new btUsageBitfield();
}

unsigned short btUsageBitfield_getUnused1(btUsageBitfield* obj)
{
	return obj->unused1;
}

unsigned short btUsageBitfield_getUnused2(btUsageBitfield* obj)
{
	return obj->unused2;
}

unsigned short btUsageBitfield_getUnused3(btUsageBitfield* obj)
{
	return obj->unused3;
}

unsigned short btUsageBitfield_getUnused4(btUsageBitfield* obj)
{
	return obj->unused4;
}

unsigned short btUsageBitfield_getUsedVertexA(btUsageBitfield* obj)
{
	return obj->usedVertexA;
}

unsigned short btUsageBitfield_getUsedVertexB(btUsageBitfield* obj)
{
	return obj->usedVertexB;
}

unsigned short btUsageBitfield_getUsedVertexC(btUsageBitfield* obj)
{
	return obj->usedVertexC;
}

unsigned short btUsageBitfield_getUsedVertexD(btUsageBitfield* obj)
{
	return obj->usedVertexD;
}

void btUsageBitfield_reset(btUsageBitfield* obj)
{
	obj->reset();
}

void btUsageBitfield_setUnused1(btUsageBitfield* obj, unsigned short value)
{
	obj->unused1 = value;
}

void btUsageBitfield_setUnused2(btUsageBitfield* obj, unsigned short value)
{
	obj->unused2 = value;
}

void btUsageBitfield_setUnused3(btUsageBitfield* obj, unsigned short value)
{
	obj->unused3 = value;
}

void btUsageBitfield_setUnused4(btUsageBitfield* obj, unsigned short value)
{
	obj->unused4 = value;
}

void btUsageBitfield_setUsedVertexA(btUsageBitfield* obj, unsigned short value)
{
	obj->usedVertexA = value;
}

void btUsageBitfield_setUsedVertexB(btUsageBitfield* obj, unsigned short value)
{
	obj->usedVertexB = value;
}

void btUsageBitfield_setUsedVertexC(btUsageBitfield* obj, unsigned short value)
{
	obj->usedVertexC = value;
}

void btUsageBitfield_setUsedVertexD(btUsageBitfield* obj, unsigned short value)
{
	obj->usedVertexD = value;
}

void btUsageBitfield_delete(btUsageBitfield* obj)
{
	delete obj;
}

btSubSimplexClosestResult* btSubSimplexClosestResult_new()
{
	return new btSubSimplexClosestResult();
}

btScalar* btSubSimplexClosestResult_getBarycentricCoords(btSubSimplexClosestResult* obj)
{
	return obj->m_barycentricCoords;
}

void btSubSimplexClosestResult_getClosestPointOnSimplex(btSubSimplexClosestResult* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_closestPointOnSimplex, value);
}

bool btSubSimplexClosestResult_getDegenerate(btSubSimplexClosestResult* obj)
{
	return obj->m_degenerate;
}

btUsageBitfield* btSubSimplexClosestResult_getUsedVertices(btSubSimplexClosestResult* obj)
{
	return &obj->m_usedVertices;
}

bool btSubSimplexClosestResult_isValid(btSubSimplexClosestResult* obj)
{
	return obj->isValid();
}

void btSubSimplexClosestResult_reset(btSubSimplexClosestResult* obj)
{
	obj->reset();
}

void btSubSimplexClosestResult_setBarycentricCoordinates(btSubSimplexClosestResult* obj, btScalar a, btScalar b, btScalar c, btScalar d)
{
	obj->setBarycentricCoordinates(a, b, c, d);
}

void btSubSimplexClosestResult_setBarycentricCoordinates2(btSubSimplexClosestResult* obj, btScalar a, btScalar b, btScalar c)
{
	obj->setBarycentricCoordinates(a, b, c);
}

void btSubSimplexClosestResult_setBarycentricCoordinates3(btSubSimplexClosestResult* obj, btScalar a, btScalar b)
{
	obj->setBarycentricCoordinates(a, b);
}

void btSubSimplexClosestResult_setBarycentricCoordinates4(btSubSimplexClosestResult* obj, btScalar a)
{
	obj->setBarycentricCoordinates(a);
}

void btSubSimplexClosestResult_setBarycentricCoordinates5(btSubSimplexClosestResult* obj)
{
	obj->setBarycentricCoordinates();
}
/*
void btSubSimplexClosestResult_setBarycentricCoords(btSubSimplexClosestResult* obj, btScalar* value)
{
	obj->m_barycentricCoords = value;
}
*/
void btSubSimplexClosestResult_setClosestPointOnSimplex(btSubSimplexClosestResult* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_closestPointOnSimplex);
}

void btSubSimplexClosestResult_setDegenerate(btSubSimplexClosestResult* obj, bool value)
{
	obj->m_degenerate = value;
}
/*
void btSubSimplexClosestResult_setUsedVertices(btSubSimplexClosestResult* obj, void value)
{
	obj->m_usedVertices = value;
}
*/
void btSubSimplexClosestResult_delete(btSubSimplexClosestResult* obj)
{
	delete obj;
}

btVoronoiSimplexSolver* btVoronoiSimplexSolver_new()
{
	return new btVoronoiSimplexSolver();
}

void btVoronoiSimplexSolver_addVertex(btVoronoiSimplexSolver* obj, btScalar* w, btScalar* p, btScalar* q)
{
	VECTOR3_CONV(w);
	VECTOR3_CONV(p);
	VECTOR3_CONV(q);
	obj->addVertex(VECTOR3_USE(w), VECTOR3_USE(p), VECTOR3_USE(q));
}

void btVoronoiSimplexSolver_backup_closest(btVoronoiSimplexSolver* obj, btScalar* v)
{
	VECTOR3_CONV(v);
	obj->backup_closest(VECTOR3_USE(v));
}

bool btVoronoiSimplexSolver_closest(btVoronoiSimplexSolver* obj, btScalar* v)
{
	VECTOR3_CONV(v);
	return obj->closest(VECTOR3_USE(v));
}

bool btVoronoiSimplexSolver_closestPtPointTetrahedron(btVoronoiSimplexSolver* obj, btScalar* p, btScalar* a, btScalar* b, btScalar* c, btScalar* d, btSubSimplexClosestResult* finalResult)
{
	VECTOR3_CONV(p);
	VECTOR3_CONV(a);
	VECTOR3_CONV(b);
	VECTOR3_CONV(c);
	VECTOR3_CONV(d);
	return obj->closestPtPointTetrahedron(VECTOR3_USE(p), VECTOR3_USE(a), VECTOR3_USE(b), VECTOR3_USE(c), VECTOR3_USE(d), *finalResult);
}

bool btVoronoiSimplexSolver_closestPtPointTriangle(btVoronoiSimplexSolver* obj, btScalar* p, btScalar* a, btScalar* b, btScalar* c, btSubSimplexClosestResult* result)
{
	VECTOR3_CONV(p);
	VECTOR3_CONV(a);
	VECTOR3_CONV(b);
	VECTOR3_CONV(c);
	return obj->closestPtPointTriangle(VECTOR3_USE(p), VECTOR3_USE(a), VECTOR3_USE(b), VECTOR3_USE(c), *result);
}

void btVoronoiSimplexSolver_compute_points(btVoronoiSimplexSolver* obj, btScalar* p1, btScalar* p2)
{
	VECTOR3_DEF(p1);
	VECTOR3_DEF(p2);
	obj->compute_points(VECTOR3_USE(p1), VECTOR3_USE(p2));
	VECTOR3_DEF_OUT(p1);
	VECTOR3_DEF_OUT(p2);
}

bool btVoronoiSimplexSolver_emptySimplex(btVoronoiSimplexSolver* obj)
{
	return obj->emptySimplex();
}

bool btVoronoiSimplexSolver_fullSimplex(btVoronoiSimplexSolver* obj)
{
	return obj->fullSimplex();
}

btSubSimplexClosestResult* btVoronoiSimplexSolver_getCachedBC(btVoronoiSimplexSolver* obj)
{
	return &obj->m_cachedBC;
}

void btVoronoiSimplexSolver_getCachedP1(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_cachedP1, value);
}

void btVoronoiSimplexSolver_getCachedP2(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_cachedP2, value);
}

void btVoronoiSimplexSolver_getCachedV(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_cachedV, value);
}

bool btVoronoiSimplexSolver_getCachedValidClosest(btVoronoiSimplexSolver* obj)
{
	return obj->m_cachedValidClosest;
}

btScalar btVoronoiSimplexSolver_getEqualVertexThreshold(btVoronoiSimplexSolver* obj)
{
	return obj->getEqualVertexThreshold();
}

btScalar btVoronoiSimplexSolver_getEqualVertexThreshold2(btVoronoiSimplexSolver* obj)
{
	return obj->m_equalVertexThreshold;
}

void btVoronoiSimplexSolver_getLastW(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_lastW, value);
}

bool btVoronoiSimplexSolver_getNeedsUpdate(btVoronoiSimplexSolver* obj)
{
	return obj->m_needsUpdate;
}

int btVoronoiSimplexSolver_getNumVertices(btVoronoiSimplexSolver* obj)
{
	return obj->numVertices();
}

int btVoronoiSimplexSolver_getSimplex(btVoronoiSimplexSolver* obj, btScalar* pBuf, btScalar* qBuf, btScalar* yBuf)
{
	VECTOR3_DEF(pBuf);
	VECTOR3_DEF(qBuf);
	VECTOR3_DEF(yBuf);
	int ret = obj->getSimplex(&VECTOR3_USE(pBuf), &VECTOR3_USE(qBuf), &VECTOR3_USE(yBuf));
	VECTOR3_DEF_OUT(pBuf);
	VECTOR3_DEF_OUT(qBuf);
	VECTOR3_DEF_OUT(yBuf);
	return ret;
}

btVector3* btVoronoiSimplexSolver_getSimplexPointsP(btVoronoiSimplexSolver* obj)
{
	return obj->m_simplexPointsP;
}

btVector3* btVoronoiSimplexSolver_getSimplexPointsQ(btVoronoiSimplexSolver* obj)
{
	return obj->m_simplexPointsQ;
}

btVector3* btVoronoiSimplexSolver_getSimplexVectorW(btVoronoiSimplexSolver* obj)
{
	return obj->m_simplexVectorW;
}

bool btVoronoiSimplexSolver_inSimplex(btVoronoiSimplexSolver* obj, btScalar* w)
{
	VECTOR3_CONV(w);
	return obj->inSimplex(VECTOR3_USE(w));
}

btScalar btVoronoiSimplexSolver_maxVertex(btVoronoiSimplexSolver* obj)
{
	return obj->maxVertex();
}

int btVoronoiSimplexSolver_numVertices(btVoronoiSimplexSolver* obj)
{
	return obj->numVertices();
}

int btVoronoiSimplexSolver_pointOutsideOfPlane(btVoronoiSimplexSolver* obj, btScalar* p, btScalar* a, btScalar* b, btScalar* c, btScalar* d)
{
	VECTOR3_CONV(p);
	VECTOR3_CONV(a);
	VECTOR3_CONV(b);
	VECTOR3_CONV(c);
	VECTOR3_CONV(d);
	return obj->pointOutsideOfPlane(VECTOR3_USE(p), VECTOR3_USE(a), VECTOR3_USE(b), VECTOR3_USE(c), VECTOR3_USE(d));
}

void btVoronoiSimplexSolver_reduceVertices(btVoronoiSimplexSolver* obj, btUsageBitfield* usedVerts)
{
	obj->reduceVertices(*usedVerts);
}

void btVoronoiSimplexSolver_removeVertex(btVoronoiSimplexSolver* obj, int index)
{
	obj->removeVertex(index);
}

void btVoronoiSimplexSolver_reset(btVoronoiSimplexSolver* obj)
{
	obj->reset();
}

void btVoronoiSimplexSolver_setCachedBC(btVoronoiSimplexSolver* obj, btSubSimplexClosestResult* value)
{
	obj->m_cachedBC = *value;
}

void btVoronoiSimplexSolver_setCachedP1(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_cachedP1);
}

void btVoronoiSimplexSolver_setCachedP2(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_cachedP2);
}

void btVoronoiSimplexSolver_setCachedV(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_cachedV);
}

void btVoronoiSimplexSolver_setCachedValidClosest(btVoronoiSimplexSolver* obj, bool value)
{
	obj->m_cachedValidClosest = value;
}

void btVoronoiSimplexSolver_setEqualVertexThreshold(btVoronoiSimplexSolver* obj, btScalar threshold)
{
	obj->setEqualVertexThreshold(threshold);
}

void btVoronoiSimplexSolver_setEqualVertexThreshold2(btVoronoiSimplexSolver* obj, btScalar value)
{
	obj->m_equalVertexThreshold = value;
}

void btVoronoiSimplexSolver_setLastW(btVoronoiSimplexSolver* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_lastW);
}

void btVoronoiSimplexSolver_setNeedsUpdate(btVoronoiSimplexSolver* obj, bool value)
{
	obj->m_needsUpdate = value;
}

void btVoronoiSimplexSolver_setNumVertices(btVoronoiSimplexSolver* obj, int value)
{
	obj->m_numVertices = value;
}
/*
void btVoronoiSimplexSolver_setSimplexPointsP(btVoronoiSimplexSolver* obj, btVector3* value)
{
	VECTOR3_CONV(value);
	obj->m_simplexPointsP = value;
}

void btVoronoiSimplexSolver_setSimplexPointsQ(btVoronoiSimplexSolver* obj, btVector3* value)
{
	VECTOR3_CONV(value);
	obj->m_simplexPointsQ = value;
}

void btVoronoiSimplexSolver_setSimplexVectorW(btVoronoiSimplexSolver* obj, btVector3* value)
{
	VECTOR3_CONV(value);
	obj->m_simplexVectorW = value;
}
*/
bool btVoronoiSimplexSolver_updateClosestVectorAndPoints(btVoronoiSimplexSolver* obj)
{
	return obj->updateClosestVectorAndPoints();
}

void btVoronoiSimplexSolver_delete(btVoronoiSimplexSolver* obj)
{
	delete obj;
}
