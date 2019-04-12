#include "main.h"

extern "C"
{
	EXPORT void SharpMotionState_Setup(void* getTransform, void* setTransform);
	EXPORT void* SharpMotionState_new(void* sharpReference);
	EXPORT void SharpMotionState_delete(void* instance);
}
