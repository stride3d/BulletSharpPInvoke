#include <BulletMultiThreaded/btParallelConstraintSolver.h>
#include <BulletMultiThreaded/btThreadSupportInterface.h>

#include "conversion.h"
#include "btParallelConstraintSolver_wrap.h"
/*
PfxParallelBatch* PfxParallelBatch_new()
{
	return new PfxParallelBatch();
}

uint16_t* PfxParallelBatch_getPairIndices(PfxParallelBatch* obj)
{
	return obj->pairIndices;
}

void PfxParallelBatch_setPairIndices(PfxParallelBatch* obj, uint16_t* value)
{
	obj->pairIndices = value;
}

void PfxParallelBatch_delete(PfxParallelBatch* obj)
{
	delete obj;
}

PfxParallelGroup* PfxParallelGroup_new()
{
	return new PfxParallelGroup();
}

uint16_t* PfxParallelGroup_getNumBatches(PfxParallelGroup* obj)
{
	return obj->numBatches;
}

uint16_t* PfxParallelGroup_getNumPairs(PfxParallelGroup* obj)
{
	return obj->numPairs;
}

uint16_t PfxParallelGroup_getNumPhases(PfxParallelGroup* obj)
{
	return obj->numPhases;
}

void PfxParallelGroup_setNumBatches(PfxParallelGroup* obj, uint16_t* value)
{
	obj->numBatches = value;
}

void PfxParallelGroup_setNumPairs(PfxParallelGroup* obj, uint16_t* value)
{
	obj->numPairs = value;
}

void PfxParallelGroup_setNumPhases(PfxParallelGroup* obj, uint16_t value)
{
	obj->numPhases = value;
}

void PfxParallelGroup_delete(PfxParallelGroup* obj)
{
	delete obj;
}

PfxSortData16* PfxSortData16_new()
{
	return new PfxSortData16();
}

uint16_t PfxSortData16_get16(PfxSortData16* obj, int elem)
{
	return obj->get16(elem);
}

uint32_t PfxSortData16_get32(PfxSortData16* obj, int elem)
{
	return obj->get32(elem);
}

uint8_t PfxSortData16_get8(PfxSortData16* obj, int elem)
{
	return obj->get8(elem);
}

void PfxSortData16_set16(PfxSortData16* obj, int elem, uint16_t data)
{
	obj->set16(elem, data);
}

void PfxSortData16_set32(PfxSortData16* obj, int elem, uint32_t data)
{
	obj->set32(elem, data);
}

void PfxSortData16_set8(PfxSortData16* obj, int elem, uint8_t data)
{
	obj->set8(elem, data);
}

void PfxSortData16_delete(PfxSortData16* obj)
{
	delete obj;
}

PfxSolverBody* PfxSolverBody_new()
{
	return new PfxSolverBody();
}

float PfxSolverBody_getFriction(PfxSolverBody* obj)
{
	return obj->friction;
}

btScalar* PfxSolverBody_getMDeltaAngularVelocity(PfxSolverBody* obj)
{
	return obj->mDeltaAngularVelocity;
}

btScalar* PfxSolverBody_getMDeltaLinearVelocity(PfxSolverBody* obj)
{
	return obj->mDeltaLinearVelocity;
}

Matrix3* PfxSolverBody_getMInertiaInv(PfxSolverBody* obj)
{
	return obj->mInertiaInv;
}

float PfxSolverBody_getMMassInv(PfxSolverBody* obj)
{
	return obj->mMassInv;
}

Quat* PfxSolverBody_getMOrientation(PfxSolverBody* obj)
{
	return obj->mOrientation;
}

float PfxSolverBody_getRestitution(PfxSolverBody* obj)
{
	return obj->restitution;
}

float PfxSolverBody_getUnused(PfxSolverBody* obj)
{
	return obj->unused;
}

float PfxSolverBody_getUnused2(PfxSolverBody* obj)
{
	return obj->unused2;
}

float PfxSolverBody_getUnused3(PfxSolverBody* obj)
{
	return obj->unused3;
}

float PfxSolverBody_getUnused4(PfxSolverBody* obj)
{
	return obj->unused4;
}

float PfxSolverBody_getUnused5(PfxSolverBody* obj)
{
	return obj->unused5;
}

void PfxSolverBody_setFriction(PfxSolverBody* obj, float value)
{
	obj->friction = value;
}

void PfxSolverBody_setMDeltaAngularVelocity(PfxSolverBody* obj, btScalar* value)
{
	obj->mDeltaAngularVelocity = value;
}

void PfxSolverBody_setMDeltaLinearVelocity(PfxSolverBody* obj, btScalar* value)
{
	obj->mDeltaLinearVelocity = value;
}

void PfxSolverBody_setMInertiaInv(PfxSolverBody* obj, Matrix3* value)
{
	obj->mInertiaInv = value;
}

void PfxSolverBody_setMMassInv(PfxSolverBody* obj, float value)
{
	obj->mMassInv = value;
}

void PfxSolverBody_setMOrientation(PfxSolverBody* obj, Quat* value)
{
	obj->mOrientation = value;
}

void PfxSolverBody_setRestitution(PfxSolverBody* obj, float value)
{
	obj->restitution = value;
}

void PfxSolverBody_setUnused(PfxSolverBody* obj, float value)
{
	obj->unused = value;
}

void PfxSolverBody_setUnused2(PfxSolverBody* obj, float value)
{
	obj->unused2 = value;
}

void PfxSolverBody_setUnused3(PfxSolverBody* obj, float value)
{
	obj->unused3 = value;
}

void PfxSolverBody_setUnused4(PfxSolverBody* obj, float value)
{
	obj->unused4 = value;
}

void PfxSolverBody_setUnused5(PfxSolverBody* obj, float value)
{
	obj->unused5 = value;
}

void PfxSolverBody_delete(PfxSolverBody* obj)
{
	delete obj;
}

PfxSetupContactConstraintsIO* PfxSetupContactConstraintsIO_new()
{
	return new PfxSetupContactConstraintsIO();
}

btCriticalSection* PfxSetupContactConstraintsIO_getCriticalSection(PfxSetupContactConstraintsIO* obj)
{
	return obj->criticalSection;
}

uint32_t PfxSetupContactConstraintsIO_getNumContactPairs1(PfxSetupContactConstraintsIO* obj)
{
	return obj->numContactPairs1;
}

uint32_t PfxSetupContactConstraintsIO_getNumRigidBodies(PfxSetupContactConstraintsIO* obj)
{
	return obj->numRigidBodies;
}

btConstraintRow* PfxSetupContactConstraintsIO_getOffsetContactConstraintRows(PfxSetupContactConstraintsIO* obj)
{
	return obj->offsetContactConstraintRows;
}

btPersistentManifold* PfxSetupContactConstraintsIO_getOffsetContactManifolds(PfxSetupContactConstraintsIO* obj)
{
	return obj->offsetContactManifolds;
}

PfxConstraintPair* PfxSetupContactConstraintsIO_getOffsetContactPairs(PfxSetupContactConstraintsIO* obj)
{
	return obj->offsetContactPairs;
}

TrbState* PfxSetupContactConstraintsIO_getOffsetRigStates(PfxSetupContactConstraintsIO* obj)
{
	return obj->offsetRigStates;
}

PfxSolverBody* PfxSetupContactConstraintsIO_getOffsetSolverBodies(PfxSetupContactConstraintsIO* obj)
{
	return obj->offsetSolverBodies;
}

float PfxSetupContactConstraintsIO_getSeparateBias(PfxSetupContactConstraintsIO* obj)
{
	return obj->separateBias;
}

float PfxSetupContactConstraintsIO_getTimeStep(PfxSetupContactConstraintsIO* obj)
{
	return obj->timeStep;
}

void PfxSetupContactConstraintsIO_setCriticalSection(PfxSetupContactConstraintsIO* obj, btCriticalSection* value)
{
	obj->criticalSection = value;
}

void PfxSetupContactConstraintsIO_setNumContactPairs1(PfxSetupContactConstraintsIO* obj, uint32_t value)
{
	obj->numContactPairs1 = value;
}

void PfxSetupContactConstraintsIO_setNumRigidBodies(PfxSetupContactConstraintsIO* obj, uint32_t value)
{
	obj->numRigidBodies = value;
}

void PfxSetupContactConstraintsIO_setOffsetContactConstraintRows(PfxSetupContactConstraintsIO* obj, btConstraintRow* value)
{
	obj->offsetContactConstraintRows = value;
}

void PfxSetupContactConstraintsIO_setOffsetContactManifolds(PfxSetupContactConstraintsIO* obj, btPersistentManifold* value)
{
	obj->offsetContactManifolds = value;
}

void PfxSetupContactConstraintsIO_setOffsetContactPairs(PfxSetupContactConstraintsIO* obj, PfxConstraintPair* value)
{
	obj->offsetContactPairs = value;
}

void PfxSetupContactConstraintsIO_setOffsetRigStates(PfxSetupContactConstraintsIO* obj, TrbState* value)
{
	obj->offsetRigStates = value;
}

void PfxSetupContactConstraintsIO_setOffsetSolverBodies(PfxSetupContactConstraintsIO* obj, PfxSolverBody* value)
{
	obj->offsetSolverBodies = value;
}

void PfxSetupContactConstraintsIO_setSeparateBias(PfxSetupContactConstraintsIO* obj, float value)
{
	obj->separateBias = value;
}

void PfxSetupContactConstraintsIO_setTimeStep(PfxSetupContactConstraintsIO* obj, float value)
{
	obj->timeStep = value;
}

void PfxSetupContactConstraintsIO_delete(PfxSetupContactConstraintsIO* obj)
{
	delete obj;
}

PfxSolveConstraintsIO* PfxSolveConstraintsIO_new()
{
	return new PfxSolveConstraintsIO();
}

btBarrier* PfxSolveConstraintsIO_getBarrier(PfxSolveConstraintsIO* obj)
{
	return obj->barrier;
}

PfxConstraintPair* PfxSolveConstraintsIO_getContactPairs(PfxSolveConstraintsIO* obj)
{
	return obj->contactPairs;
}

PfxParallelBatch* PfxSolveConstraintsIO_getContactParallelBatches(PfxSolveConstraintsIO* obj)
{
	return obj->contactParallelBatches;
}

PfxParallelGroup* PfxSolveConstraintsIO_getContactParallelGroup(PfxSolveConstraintsIO* obj)
{
	return obj->contactParallelGroup;
}

uint32_t PfxSolveConstraintsIO_getIteration(PfxSolveConstraintsIO* obj)
{
	return obj->iteration;
}

PfxConstraintPair* PfxSolveConstraintsIO_getJointPairs(PfxSolveConstraintsIO* obj)
{
	return obj->jointPairs;
}

PfxParallelBatch* PfxSolveConstraintsIO_getJointParallelBatches(PfxSolveConstraintsIO* obj)
{
	return obj->jointParallelBatches;
}

PfxParallelGroup* PfxSolveConstraintsIO_getJointParallelGroup(PfxSolveConstraintsIO* obj)
{
	return obj->jointParallelGroup;
}

uint32_t PfxSolveConstraintsIO_getNumContactPairs(PfxSolveConstraintsIO* obj)
{
	return obj->numContactPairs;
}

uint32_t PfxSolveConstraintsIO_getNumJointPairs(PfxSolveConstraintsIO* obj)
{
	return obj->numJointPairs;
}

uint32_t PfxSolveConstraintsIO_getNumRigidBodies(PfxSolveConstraintsIO* obj)
{
	return obj->numRigidBodies;
}

btConstraintRow* PfxSolveConstraintsIO_getOffsetContactConstraintRows(PfxSolveConstraintsIO* obj)
{
	return obj->offsetContactConstraintRows;
}

btPersistentManifold* PfxSolveConstraintsIO_getOffsetContactManifolds(PfxSolveConstraintsIO* obj)
{
	return obj->offsetContactManifolds;
}

TrbState* PfxSolveConstraintsIO_getOffsetRigStates1(PfxSolveConstraintsIO* obj)
{
	return obj->offsetRigStates1;
}

PfxSolverBody* PfxSolveConstraintsIO_getOffsetSolverBodies(PfxSolveConstraintsIO* obj)
{
	return obj->offsetSolverBodies;
}

btSolverConstraint* PfxSolveConstraintsIO_getOffsetSolverConstraints(PfxSolveConstraintsIO* obj)
{
	return obj->offsetSolverConstraints;
}

uint32_t PfxSolveConstraintsIO_getTaskId(PfxSolveConstraintsIO* obj)
{
	return obj->taskId;
}

void PfxSolveConstraintsIO_setBarrier(PfxSolveConstraintsIO* obj, btBarrier* value)
{
	obj->barrier = value;
}

void PfxSolveConstraintsIO_setContactPairs(PfxSolveConstraintsIO* obj, PfxConstraintPair* value)
{
	obj->contactPairs = value;
}

void PfxSolveConstraintsIO_setContactParallelBatches(PfxSolveConstraintsIO* obj, PfxParallelBatch* value)
{
	obj->contactParallelBatches = value;
}

void PfxSolveConstraintsIO_setContactParallelGroup(PfxSolveConstraintsIO* obj, PfxParallelGroup* value)
{
	obj->contactParallelGroup = value;
}

void PfxSolveConstraintsIO_setIteration(PfxSolveConstraintsIO* obj, uint32_t value)
{
	obj->iteration = value;
}

void PfxSolveConstraintsIO_setJointPairs(PfxSolveConstraintsIO* obj, PfxConstraintPair* value)
{
	obj->jointPairs = value;
}

void PfxSolveConstraintsIO_setJointParallelBatches(PfxSolveConstraintsIO* obj, PfxParallelBatch* value)
{
	obj->jointParallelBatches = value;
}

void PfxSolveConstraintsIO_setJointParallelGroup(PfxSolveConstraintsIO* obj, PfxParallelGroup* value)
{
	obj->jointParallelGroup = value;
}

void PfxSolveConstraintsIO_setNumContactPairs(PfxSolveConstraintsIO* obj, uint32_t value)
{
	obj->numContactPairs = value;
}

void PfxSolveConstraintsIO_setNumJointPairs(PfxSolveConstraintsIO* obj, uint32_t value)
{
	obj->numJointPairs = value;
}

void PfxSolveConstraintsIO_setNumRigidBodies(PfxSolveConstraintsIO* obj, uint32_t value)
{
	obj->numRigidBodies = value;
}

void PfxSolveConstraintsIO_setOffsetContactConstraintRows(PfxSolveConstraintsIO* obj, btConstraintRow* value)
{
	obj->offsetContactConstraintRows = value;
}

void PfxSolveConstraintsIO_setOffsetContactManifolds(PfxSolveConstraintsIO* obj, btPersistentManifold* value)
{
	obj->offsetContactManifolds = value;
}

void PfxSolveConstraintsIO_setOffsetRigStates1(PfxSolveConstraintsIO* obj, TrbState* value)
{
	obj->offsetRigStates1 = value;
}

void PfxSolveConstraintsIO_setOffsetSolverBodies(PfxSolveConstraintsIO* obj, PfxSolverBody* value)
{
	obj->offsetSolverBodies = value;
}

void PfxSolveConstraintsIO_setOffsetSolverConstraints(PfxSolveConstraintsIO* obj, btSolverConstraint* value)
{
	obj->offsetSolverConstraints = value;
}

void PfxSolveConstraintsIO_setTaskId(PfxSolveConstraintsIO* obj, uint32_t value)
{
	obj->taskId = value;
}

void PfxSolveConstraintsIO_delete(PfxSolveConstraintsIO* obj)
{
	delete obj;
}

PfxPostSolverIO* PfxPostSolverIO_new()
{
	return new PfxPostSolverIO();
}

uint32_t PfxPostSolverIO_getNumRigidBodies(PfxPostSolverIO* obj)
{
	return obj->numRigidBodies;
}

PfxSolverBody* PfxPostSolverIO_getSolverBodies(PfxPostSolverIO* obj)
{
	return obj->solverBodies;
}

TrbState* PfxPostSolverIO_getStates(PfxPostSolverIO* obj)
{
	return obj->states;
}

void PfxPostSolverIO_setNumRigidBodies(PfxPostSolverIO* obj, uint32_t value)
{
	obj->numRigidBodies = value;
}

void PfxPostSolverIO_setSolverBodies(PfxPostSolverIO* obj, PfxSolverBody* value)
{
	obj->solverBodies = value;
}

void PfxPostSolverIO_setStates(PfxPostSolverIO* obj, TrbState* value)
{
	obj->states = value;
}

void PfxPostSolverIO_delete(PfxPostSolverIO* obj)
{
	delete obj;
}

btConstraintSolverIO* btConstraintSolverIO_new()
{
	return new btConstraintSolverIO();
}

uint32_t btConstraintSolverIO_getBarrierAddr2(btConstraintSolverIO* obj)
{
	return obj->barrierAddr2;
}

uint8_t btConstraintSolverIO_getCmd(btConstraintSolverIO* obj)
{
	return obj->cmd;
}

uint32_t btConstraintSolverIO_getCriticalsectionAddr2(btConstraintSolverIO* obj)
{
	return obj->criticalsectionAddr2;
}

uint32_t btConstraintSolverIO_getMaxTasks1(btConstraintSolverIO* obj)
{
	return obj->maxTasks1;
}

void btConstraintSolverIO_setBarrierAddr2(btConstraintSolverIO* obj, uint32_t value)
{
	obj->barrierAddr2 = value;
}

void btConstraintSolverIO_setCmd(btConstraintSolverIO* obj, uint8_t value)
{
	obj->cmd = value;
}

void btConstraintSolverIO_setCriticalsectionAddr2(btConstraintSolverIO* obj, uint32_t value)
{
	obj->criticalsectionAddr2 = value;
}

void btConstraintSolverIO_setMaxTasks1(btConstraintSolverIO* obj, uint32_t value)
{
	obj->maxTasks1 = value;
}

void btConstraintSolverIO_delete(btConstraintSolverIO* obj)
{
	delete obj;
}
*/
btParallelConstraintSolver* btParallelConstraintSolver_new(btThreadSupportInterface* solverThreadSupport)
{
	return new btParallelConstraintSolver(solverThreadSupport);
}
