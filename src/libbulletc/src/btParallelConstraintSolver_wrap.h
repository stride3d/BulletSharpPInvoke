#include "main.h"

extern "C"
{/*
	EXPORT PfxParallelBatch* PfxParallelBatch_new();
	EXPORT uint16_t* PfxParallelBatch_getPairIndices(PfxParallelBatch* obj);
	EXPORT void PfxParallelBatch_setPairIndices(PfxParallelBatch* obj, uint16_t* value);
	EXPORT void PfxParallelBatch_delete(PfxParallelBatch* obj);

	EXPORT PfxParallelGroup* PfxParallelGroup_new();
	EXPORT uint16_t* PfxParallelGroup_getNumBatches(PfxParallelGroup* obj);
	EXPORT uint16_t* PfxParallelGroup_getNumPairs(PfxParallelGroup* obj);
	EXPORT uint16_t PfxParallelGroup_getNumPhases(PfxParallelGroup* obj);
	EXPORT void PfxParallelGroup_setNumBatches(PfxParallelGroup* obj, uint16_t* value);
	EXPORT void PfxParallelGroup_setNumPairs(PfxParallelGroup* obj, uint16_t* value);
	EXPORT void PfxParallelGroup_setNumPhases(PfxParallelGroup* obj, uint16_t value);
	EXPORT void PfxParallelGroup_delete(PfxParallelGroup* obj);

	EXPORT PfxSortData16* PfxSortData16_new();
	EXPORT uint16_t PfxSortData16_get16(PfxSortData16* obj, int elem);
	EXPORT uint32_t PfxSortData16_get32(PfxSortData16* obj, int elem);
	EXPORT uint8_t PfxSortData16_get8(PfxSortData16* obj, int elem);
	EXPORT void PfxSortData16_set16(PfxSortData16* obj, int elem, uint16_t data);
	EXPORT void PfxSortData16_set32(PfxSortData16* obj, int elem, uint32_t data);
	EXPORT void PfxSortData16_set8(PfxSortData16* obj, int elem, uint8_t data);
	EXPORT void PfxSortData16_delete(PfxSortData16* obj);

	EXPORT PfxSolverBody* PfxSolverBody_new();
	EXPORT float PfxSolverBody_getFriction(PfxSolverBody* obj);
	EXPORT btScalar* PfxSolverBody_getMDeltaAngularVelocity(PfxSolverBody* obj);
	EXPORT btScalar* PfxSolverBody_getMDeltaLinearVelocity(PfxSolverBody* obj);
	EXPORT Matrix3* PfxSolverBody_getMInertiaInv(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getMMassInv(PfxSolverBody* obj);
	EXPORT Quat* PfxSolverBody_getMOrientation(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getRestitution(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getUnused(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getUnused2(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getUnused3(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getUnused4(PfxSolverBody* obj);
	EXPORT float PfxSolverBody_getUnused5(PfxSolverBody* obj);
	EXPORT void PfxSolverBody_setFriction(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setMDeltaAngularVelocity(PfxSolverBody* obj, btScalar* value);
	EXPORT void PfxSolverBody_setMDeltaLinearVelocity(PfxSolverBody* obj, btScalar* value);
	EXPORT void PfxSolverBody_setMInertiaInv(PfxSolverBody* obj, Matrix3* value);
	EXPORT void PfxSolverBody_setMMassInv(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setMOrientation(PfxSolverBody* obj, Quat* value);
	EXPORT void PfxSolverBody_setRestitution(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setUnused(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setUnused2(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setUnused3(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setUnused4(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_setUnused5(PfxSolverBody* obj, float value);
	EXPORT void PfxSolverBody_delete(PfxSolverBody* obj);

	EXPORT PfxSetupContactConstraintsIO* PfxSetupContactConstraintsIO_new();
	EXPORT btCriticalSection* PfxSetupContactConstraintsIO_getCriticalSection(PfxSetupContactConstraintsIO* obj);
	EXPORT uint32_t PfxSetupContactConstraintsIO_getNumContactPairs1(PfxSetupContactConstraintsIO* obj);
	EXPORT uint32_t PfxSetupContactConstraintsIO_getNumRigidBodies(PfxSetupContactConstraintsIO* obj);
	EXPORT btConstraintRow* PfxSetupContactConstraintsIO_getOffsetContactConstraintRows(PfxSetupContactConstraintsIO* obj);
	EXPORT btPersistentManifold* PfxSetupContactConstraintsIO_getOffsetContactManifolds(PfxSetupContactConstraintsIO* obj);
	EXPORT PfxConstraintPair* PfxSetupContactConstraintsIO_getOffsetContactPairs(PfxSetupContactConstraintsIO* obj);
	EXPORT TrbState* PfxSetupContactConstraintsIO_getOffsetRigStates(PfxSetupContactConstraintsIO* obj);
	EXPORT PfxSolverBody* PfxSetupContactConstraintsIO_getOffsetSolverBodies(PfxSetupContactConstraintsIO* obj);
	EXPORT float PfxSetupContactConstraintsIO_getSeparateBias(PfxSetupContactConstraintsIO* obj);
	EXPORT float PfxSetupContactConstraintsIO_getTimeStep(PfxSetupContactConstraintsIO* obj);
	EXPORT void PfxSetupContactConstraintsIO_setCriticalSection(PfxSetupContactConstraintsIO* obj, btCriticalSection* value);
	EXPORT void PfxSetupContactConstraintsIO_setNumContactPairs1(PfxSetupContactConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSetupContactConstraintsIO_setNumRigidBodies(PfxSetupContactConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSetupContactConstraintsIO_setOffsetContactConstraintRows(PfxSetupContactConstraintsIO* obj, btConstraintRow* value);
	EXPORT void PfxSetupContactConstraintsIO_setOffsetContactManifolds(PfxSetupContactConstraintsIO* obj, btPersistentManifold* value);
	EXPORT void PfxSetupContactConstraintsIO_setOffsetContactPairs(PfxSetupContactConstraintsIO* obj, PfxConstraintPair* value);
	EXPORT void PfxSetupContactConstraintsIO_setOffsetRigStates(PfxSetupContactConstraintsIO* obj, TrbState* value);
	EXPORT void PfxSetupContactConstraintsIO_setOffsetSolverBodies(PfxSetupContactConstraintsIO* obj, PfxSolverBody* value);
	EXPORT void PfxSetupContactConstraintsIO_setSeparateBias(PfxSetupContactConstraintsIO* obj, float value);
	EXPORT void PfxSetupContactConstraintsIO_setTimeStep(PfxSetupContactConstraintsIO* obj, float value);
	EXPORT void PfxSetupContactConstraintsIO_delete(PfxSetupContactConstraintsIO* obj);

	EXPORT PfxSolveConstraintsIO* PfxSolveConstraintsIO_new();
	EXPORT btBarrier* PfxSolveConstraintsIO_getBarrier(PfxSolveConstraintsIO* obj);
	EXPORT PfxConstraintPair* PfxSolveConstraintsIO_getContactPairs(PfxSolveConstraintsIO* obj);
	EXPORT PfxParallelBatch* PfxSolveConstraintsIO_getContactParallelBatches(PfxSolveConstraintsIO* obj);
	EXPORT PfxParallelGroup* PfxSolveConstraintsIO_getContactParallelGroup(PfxSolveConstraintsIO* obj);
	EXPORT uint32_t PfxSolveConstraintsIO_getIteration(PfxSolveConstraintsIO* obj);
	EXPORT PfxConstraintPair* PfxSolveConstraintsIO_getJointPairs(PfxSolveConstraintsIO* obj);
	EXPORT PfxParallelBatch* PfxSolveConstraintsIO_getJointParallelBatches(PfxSolveConstraintsIO* obj);
	EXPORT PfxParallelGroup* PfxSolveConstraintsIO_getJointParallelGroup(PfxSolveConstraintsIO* obj);
	EXPORT uint32_t PfxSolveConstraintsIO_getNumContactPairs(PfxSolveConstraintsIO* obj);
	EXPORT uint32_t PfxSolveConstraintsIO_getNumJointPairs(PfxSolveConstraintsIO* obj);
	EXPORT uint32_t PfxSolveConstraintsIO_getNumRigidBodies(PfxSolveConstraintsIO* obj);
	EXPORT btConstraintRow* PfxSolveConstraintsIO_getOffsetContactConstraintRows(PfxSolveConstraintsIO* obj);
	EXPORT btPersistentManifold* PfxSolveConstraintsIO_getOffsetContactManifolds(PfxSolveConstraintsIO* obj);
	EXPORT TrbState* PfxSolveConstraintsIO_getOffsetRigStates1(PfxSolveConstraintsIO* obj);
	EXPORT PfxSolverBody* PfxSolveConstraintsIO_getOffsetSolverBodies(PfxSolveConstraintsIO* obj);
	EXPORT btSolverConstraint* PfxSolveConstraintsIO_getOffsetSolverConstraints(PfxSolveConstraintsIO* obj);
	EXPORT uint32_t PfxSolveConstraintsIO_getTaskId(PfxSolveConstraintsIO* obj);
	EXPORT void PfxSolveConstraintsIO_setBarrier(PfxSolveConstraintsIO* obj, btBarrier* value);
	EXPORT void PfxSolveConstraintsIO_setContactPairs(PfxSolveConstraintsIO* obj, PfxConstraintPair* value);
	EXPORT void PfxSolveConstraintsIO_setContactParallelBatches(PfxSolveConstraintsIO* obj, PfxParallelBatch* value);
	EXPORT void PfxSolveConstraintsIO_setContactParallelGroup(PfxSolveConstraintsIO* obj, PfxParallelGroup* value);
	EXPORT void PfxSolveConstraintsIO_setIteration(PfxSolveConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSolveConstraintsIO_setJointPairs(PfxSolveConstraintsIO* obj, PfxConstraintPair* value);
	EXPORT void PfxSolveConstraintsIO_setJointParallelBatches(PfxSolveConstraintsIO* obj, PfxParallelBatch* value);
	EXPORT void PfxSolveConstraintsIO_setJointParallelGroup(PfxSolveConstraintsIO* obj, PfxParallelGroup* value);
	EXPORT void PfxSolveConstraintsIO_setNumContactPairs(PfxSolveConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSolveConstraintsIO_setNumJointPairs(PfxSolveConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSolveConstraintsIO_setNumRigidBodies(PfxSolveConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSolveConstraintsIO_setOffsetContactConstraintRows(PfxSolveConstraintsIO* obj, btConstraintRow* value);
	EXPORT void PfxSolveConstraintsIO_setOffsetContactManifolds(PfxSolveConstraintsIO* obj, btPersistentManifold* value);
	EXPORT void PfxSolveConstraintsIO_setOffsetRigStates1(PfxSolveConstraintsIO* obj, TrbState* value);
	EXPORT void PfxSolveConstraintsIO_setOffsetSolverBodies(PfxSolveConstraintsIO* obj, PfxSolverBody* value);
	EXPORT void PfxSolveConstraintsIO_setOffsetSolverConstraints(PfxSolveConstraintsIO* obj, btSolverConstraint* value);
	EXPORT void PfxSolveConstraintsIO_setTaskId(PfxSolveConstraintsIO* obj, uint32_t value);
	EXPORT void PfxSolveConstraintsIO_delete(PfxSolveConstraintsIO* obj);

	EXPORT PfxPostSolverIO* PfxPostSolverIO_new();
	EXPORT uint32_t PfxPostSolverIO_getNumRigidBodies(PfxPostSolverIO* obj);
	EXPORT PfxSolverBody* PfxPostSolverIO_getSolverBodies(PfxPostSolverIO* obj);
	EXPORT TrbState* PfxPostSolverIO_getStates(PfxPostSolverIO* obj);
	EXPORT void PfxPostSolverIO_setNumRigidBodies(PfxPostSolverIO* obj, uint32_t value);
	EXPORT void PfxPostSolverIO_setSolverBodies(PfxPostSolverIO* obj, PfxSolverBody* value);
	EXPORT void PfxPostSolverIO_setStates(PfxPostSolverIO* obj, TrbState* value);
	EXPORT void PfxPostSolverIO_delete(PfxPostSolverIO* obj);

	EXPORT btConstraintSolverIO* btConstraintSolverIO_new();
	EXPORT uint32_t btConstraintSolverIO_getBarrierAddr2(btConstraintSolverIO* obj);
	EXPORT uint8_t btConstraintSolverIO_getCmd(btConstraintSolverIO* obj);
	EXPORT uint32_t btConstraintSolverIO_getCriticalsectionAddr2(btConstraintSolverIO* obj);
	EXPORT uint32_t btConstraintSolverIO_getMaxTasks1(btConstraintSolverIO* obj);
	EXPORT void btConstraintSolverIO_setBarrierAddr2(btConstraintSolverIO* obj, uint32_t value);
	EXPORT void btConstraintSolverIO_setCmd(btConstraintSolverIO* obj, uint8_t value);
	EXPORT void btConstraintSolverIO_setCriticalsectionAddr2(btConstraintSolverIO* obj, uint32_t value);
	EXPORT void btConstraintSolverIO_setMaxTasks1(btConstraintSolverIO* obj, uint32_t value);
	EXPORT void btConstraintSolverIO_delete(btConstraintSolverIO* obj);
*/
	EXPORT btParallelConstraintSolver* btParallelConstraintSolver_new(btThreadSupportInterface* solverThreadSupport);
}
