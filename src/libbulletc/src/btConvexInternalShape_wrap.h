#include "main.h"

extern "C"
{
	EXPORT btScalar* btConvexInternalShape_getImplicitShapeDimensions(btConvexInternalShape* obj);
	EXPORT btScalar* btConvexInternalShape_getLocalScalingNV(btConvexInternalShape* obj);
	EXPORT btScalar btConvexInternalShape_getMarginNV(btConvexInternalShape* obj);
	EXPORT void btConvexInternalShape_setImplicitShapeDimensions(btConvexInternalShape* obj, btScalar* dimensions);
	EXPORT void btConvexInternalShape_setSafeMargin(btConvexInternalShape* obj, btScalar minDimension, btScalar defaultMarginMultiplier);
	EXPORT void btConvexInternalShape_setSafeMargin2(btConvexInternalShape* obj, btScalar minDimension);
	EXPORT void btConvexInternalShape_setSafeMargin3(btConvexInternalShape* obj, btScalar* halfExtents, btScalar defaultMarginMultiplier);
	EXPORT void btConvexInternalShape_setSafeMargin4(btConvexInternalShape* obj, btScalar* halfExtents);

	EXPORT void btConvexInternalAabbCachingShape_recalcLocalAabb(btConvexInternalAabbCachingShape* obj);
}
