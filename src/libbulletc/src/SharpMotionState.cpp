#include "conversion.h"
#include "SharpMotionState.h"

typedef float (*TransformCallback)(const void* sharpReference, btScalar* inOutTransform);

class SharpMotionState : public btMotionState
{
public:
	SharpMotionState(void* sharpReference) : mSharpReference(sharpReference)
	{
	}

	virtual ~SharpMotionState()
	{
	}

	static void SharpMotionState_Setup(TransformCallback getTransform,  TransformCallback setTransform);

	virtual void getWorldTransform(btTransform& worldTrans) const
	{
		btScalar matrix[16];
		sGetTransform(mSharpReference, matrix);
		MatrixTobtTransform(matrix, &worldTrans);
	}

	virtual void setWorldTransform(const btTransform& worldTrans)
	{
		btScalar matrix[16];
		btTransformToMatrix(&worldTrans, matrix);
		sSetTransform(mSharpReference, matrix);
	}

private:
	static TransformCallback sGetTransform, sSetTransform;
	void* mSharpReference;
};

TransformCallback SharpMotionState::sGetTransform = NULL;
TransformCallback SharpMotionState::sSetTransform = NULL;

void SharpMotionState::SharpMotionState_Setup(TransformCallback getTransform,  TransformCallback setTransform)
{
	sGetTransform = getTransform;
	sSetTransform = setTransform;
}

void SharpMotionState_Setup(void* getTransform, void* setTransform)
{
	SharpMotionState::SharpMotionState_Setup((TransformCallback)getTransform, (TransformCallback)setTransform);
}

void* SharpMotionState_new(void* sharpReference)
{
	return ALIGNED_NEW(SharpMotionState)(sharpReference);
}

void SharpMotionState_delete(void* instance)
{
	SharpMotionState* obj = (SharpMotionState*)instance;
	ALIGNED_FREE(obj);
}

btDefaultMotionState* btDefaultMotionState_new()
{
	return ALIGNED_NEW(btDefaultMotionState) ();
}

btDefaultMotionState* btDefaultMotionState_new2(btScalar* startTrans)
{
	TRANSFORM_CONV(startTrans);
	return ALIGNED_NEW(btDefaultMotionState) (TRANSFORM_USE(startTrans));
}

btDefaultMotionState* btDefaultMotionState_new3(btScalar* startTrans, btScalar* centerOfMassOffset)
{
	TRANSFORM_CONV(startTrans);
	TRANSFORM_CONV(centerOfMassOffset);
	return ALIGNED_NEW(btDefaultMotionState) (TRANSFORM_USE(startTrans), TRANSFORM_USE(centerOfMassOffset));
}

void btDefaultMotionState_getCenterOfMassOffset(btDefaultMotionState* obj, btScalar* value)
{
	btTransformToMatrix(&obj->m_centerOfMassOffset, value);
}

void btDefaultMotionState_getGraphicsWorldTrans(btDefaultMotionState* obj, btScalar* value)
{
	btTransformToMatrix(&obj->m_graphicsWorldTrans, value);
}

void btDefaultMotionState_getStartWorldTrans(btDefaultMotionState* obj, btScalar* value)
{
	btTransformToMatrix(&obj->m_startWorldTrans, value);
}

void* btDefaultMotionState_getUserPointer(btDefaultMotionState* obj)
{
	return obj->m_userPointer;
}

void btDefaultMotionState_setCenterOfMassOffset(btDefaultMotionState* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_centerOfMassOffset);
}

void btDefaultMotionState_setGraphicsWorldTrans(btDefaultMotionState* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_graphicsWorldTrans);
}

void btDefaultMotionState_setStartWorldTrans(btDefaultMotionState* obj, btScalar* value)
{
	MatrixTobtTransform(value, &obj->m_startWorldTrans);
}

void btDefaultMotionState_setUserPointer(btDefaultMotionState* obj, void* value)
{
	obj->m_userPointer = value;
}

void btMotionState_getWorldTransform(btMotionState* obj, btScalar* outTransform)
{
	TRANSFORM_DEF(outTransform);
	obj->getWorldTransform(TRANSFORM_USE(outTransform));
	TRANSFORM_DEF_OUT(outTransform);
}

void btMotionState_setWorldTransform(btMotionState* obj, btScalar* transform)
{
	TRANSFORM_CONV(transform);
	obj->setWorldTransform(TRANSFORM_USE(transform));
}

void btMotionState_delete(btMotionState* obj)
{
	ALIGNED_FREE(obj);
}
