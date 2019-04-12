#include "main.h"

extern "C"
{
	EXPORT btBoxBoxCollisionAlgorithm_CreateFunc* btBoxBoxCollisionAlgorithm_CreateFunc_new();
	EXPORT btBoxBoxCollisionAlgorithm* btBoxBoxCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci);
	EXPORT btBoxBoxCollisionAlgorithm* btBoxBoxCollisionAlgorithm_new2(btPersistentManifold* mf, btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap);
}
