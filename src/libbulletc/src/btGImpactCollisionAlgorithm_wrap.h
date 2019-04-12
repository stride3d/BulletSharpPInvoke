#include "main.h"

extern "C"
{
	EXPORT btGImpactCollisionAlgorithm::CreateFunc* btGImpactCollisionAlgorithm_CreateFunc_new();
	EXPORT btGImpactCollisionAlgorithm* btGImpactCollisionAlgorithm_new(btCollisionAlgorithmConstructionInfo* ci, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap);
	EXPORT int btGImpactCollisionAlgorithm_getFace0(btGImpactCollisionAlgorithm* obj);
	EXPORT int btGImpactCollisionAlgorithm_getFace1(btGImpactCollisionAlgorithm* obj);
	EXPORT int btGImpactCollisionAlgorithm_getPart0(btGImpactCollisionAlgorithm* obj);
	EXPORT int btGImpactCollisionAlgorithm_getPart1(btGImpactCollisionAlgorithm* obj);
	EXPORT void btGImpactCollisionAlgorithm_gimpact_vs_compoundshape(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btCompoundShape* shape1, bool swapped);
	EXPORT void btGImpactCollisionAlgorithm_gimpact_vs_concave(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btConcaveShape* shape1, bool swapped);
	EXPORT void btGImpactCollisionAlgorithm_gimpact_vs_gimpact(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btGImpactShapeInterface* shape1);
	EXPORT void btGImpactCollisionAlgorithm_gimpact_vs_shape(btGImpactCollisionAlgorithm* obj, btCollisionObjectWrapper* body0Wrap, btCollisionObjectWrapper* body1Wrap, btGImpactShapeInterface* shape0, btCollisionShape* shape1, bool swapped);
	EXPORT btManifoldResult* btGImpactCollisionAlgorithm_internalGetResultOut(btGImpactCollisionAlgorithm* obj);
	EXPORT void btGImpactCollisionAlgorithm_registerAlgorithm(btCollisionDispatcher* dispatcher);
	EXPORT void btGImpactCollisionAlgorithm_setFace0(btGImpactCollisionAlgorithm* obj, int value);
	EXPORT void btGImpactCollisionAlgorithm_setFace1(btGImpactCollisionAlgorithm* obj, int value);
	EXPORT void btGImpactCollisionAlgorithm_setPart0(btGImpactCollisionAlgorithm* obj, int value);
	EXPORT void btGImpactCollisionAlgorithm_setPart1(btGImpactCollisionAlgorithm* obj, int value);
}
