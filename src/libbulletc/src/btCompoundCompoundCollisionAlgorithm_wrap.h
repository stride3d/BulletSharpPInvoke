#include "main.h"

extern "C"
{
	EXPORT btCompoundCompoundCollisionAlgorithm_CreateFunc* btCompoundCompoundCollisionAlgorithm_CreateFunc_new();

	EXPORT btCompoundCompoundCollisionAlgorithm_SwappedCreateFunc* btCompoundCompoundCollisionAlgorithm_SwappedCreateFunc_new();
	EXPORT btCompoundCompoundCollisionAlgorithm* btCompoundCompoundCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, bool isSwapped);
}
