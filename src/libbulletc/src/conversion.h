#pragma once

#include <LinearMath/btAlignedAllocator.h>
#include <LinearMath/btVector3.h>
#include <LinearMath/btMatrix3x3.h>
#include <LinearMath/btQuickprof.h>
#include "LinearMath/btTransform.h"
#include <btBulletCollisionCommon.h>
#include <btBulletDynamicsCommon.h>

//#define BTTRANSFORM_TRANSPOSE
#define BTTRANSFORM_TO4X4

inline void btVector3ToVector3(const btVector3* v, btScalar* s)
{
	s[0] = v->getX();
	s[1] = v->getY();
	s[2] = v->getZ();
}

inline void btVector3ToVector3(const btVector3& v, btScalar* s)
{
	s[0] = v.getX();
	s[1] = v.getY();
	s[2] = v.getZ();
}

inline void Vector3TobtVector3(const btScalar* s, btVector3* v)
{
	v->setX(s[0]);
	v->setY(s[1]);
	v->setZ(s[2]);
}

inline void btVector4ToVector4(const btVector4* v, btScalar* s)
{
	s[0] = v->getX();
	s[1] = v->getY();
	s[2] = v->getZ();
	s[3] = v->getW();
}

inline void btQuaternionToQuaternion(const btQuaternion* q, btScalar* s)
{
	s[0] = q->getX();
	s[1] = q->getY();
	s[2] = q->getZ();
	s[3] = q->getW();
}

inline void btQuaternionToQuaternion(const btQuaternion& q, btScalar* s)
{
	s[0] = q.getX();
	s[1] = q.getY();
	s[2] = q.getZ();
	s[3] = q.getW();
}

inline void QuaternionTobtQuaternion(const btScalar* s, btQuaternion* v)
{
	v->setX(s[0]);
	v->setY(s[1]);
	v->setZ(s[2]);
	v->setW(s[3]);
}

inline void btTransformToMatrix(const btTransform* t, btScalar* m)
{
#ifdef BTTRANSFORM_TO4X4
#ifdef BTTRANSFORM_TRANSPOSE
	m[0] = t->getBasis().getRow(0).getX();
	m[4] = t->getBasis().getRow(0).getY();
	m[8] = t->getBasis().getRow(0).getZ();
	m[1] = t->getBasis().getRow(1).getX();
	m[5] = t->getBasis().getRow(1).getY();
	m[9] = t->getBasis().getRow(1).getZ();
	m[2] = t->getBasis().getRow(2).getX();
	m[6] = t->getBasis().getRow(2).getY();
	m[10] = t->getBasis().getRow(2).getZ();
#else
	m[0] = t->getBasis().getRow(0).getX();
	m[1] = t->getBasis().getRow(0).getY();
	m[2] = t->getBasis().getRow(0).getZ();
	m[4] = t->getBasis().getRow(1).getX();
	m[5] = t->getBasis().getRow(1).getY();
	m[6] = t->getBasis().getRow(1).getZ();
	m[8] = t->getBasis().getRow(2).getX();
	m[9] = t->getBasis().getRow(2).getY();
	m[10] = t->getBasis().getRow(2).getZ();
#endif
	/*
	m[3] = 0;
	m[7] = 0;
	m[11] = 0;
	m[12] = t->getOrigin().getX();
	m[13] = t->getOrigin().getY();
	m[14] = t->getOrigin().getZ();
	m[15] = 1;
	*/
	m[3] = t->getOrigin().getX();
	m[7] = t->getOrigin().getY();
	m[11] = t->getOrigin().getZ();
	m[12] = 0;
	m[13] = 0;
	m[14] = 0;
	m[15] = 1;
#else
#ifdef BTTRANSFORM_TRANSPOSE
	m[0] = t->getBasis().getRow(0).getX();
	m[3] = t->getBasis().getRow(0).getY();
	m[6] = t->getBasis().getRow(0).getZ();
	m[1] = t->getBasis().getRow(1).getX();
	m[4] = t->getBasis().getRow(1).getY();
	m[7] = t->getBasis().getRow(1).getZ();
	m[2] = t->getBasis().getRow(2).getX();
	m[5] = t->getBasis().getRow(2).getY();
	m[8] = t->getBasis().getRow(2).getZ();
#else
	m[0] = t->getBasis().getRow(0).getX();
	m[1] = t->getBasis().getRow(0).getY();
	m[2] = t->getBasis().getRow(0).getZ();
	m[3] = t->getBasis().getRow(1).getX();
	m[4] = t->getBasis().getRow(1).getY();
	m[5] = t->getBasis().getRow(1).getZ();
	m[6] = t->getBasis().getRow(2).getX();
	m[7] = t->getBasis().getRow(2).getY();
	m[8] = t->getBasis().getRow(2).getZ();
#endif
	m[9] = t->getOrigin().getX();
	m[10] = t->getOrigin().getY();
	m[11] = t->getOrigin().getZ();
#endif
}

inline void MatrixTobtTransform(const btScalar* m, btTransform* t)
{
#ifdef BTTRANSFORM_TO4X4
#ifdef BTTRANSFORM_TRANSPOSE
	t->getBasis().setValue(m[0],m[4],m[8],m[1],m[5],m[9],m[2],m[6],m[10]);
#else
	t->getBasis().setValue(m[0],m[1],m[2],m[4],m[5],m[6],m[8],m[9],m[10]);
#endif
	//t->getOrigin().setX(m[12]);
	//t->getOrigin().setY(m[13]);
	//t->getOrigin().setZ(m[14]);
	t->getOrigin().setX(m[3]);
	t->getOrigin().setY(m[7]);
	t->getOrigin().setZ(m[11]);
#else
#ifdef BTTRANSFORM_TRANSPOSE
	t->getBasis().setValue(m[0],m[3],m[6],m[1],m[4],m[7],m[2],m[5],m[8]);
#else
	t->getBasis().setValue(m[0],m[1],m[2],m[3],m[4],m[5],m[6],m[7],m[8]);
#endif
	t->getOrigin().setX(m[9]);
	t->getOrigin().setY(m[10]);
	t->getOrigin().setZ(m[11]);
#endif
}

inline void btMatrix3x3ToMatrix(const btMatrix3x3* t, btScalar* m)
{
#ifdef BTTRANSFORM_TO4X4
#ifdef BTTRANSFORM_TRANSPOSE
	m[0] = t->getRow(0).getX();
	m[4] = t->getRow(0).getY();
	m[8] = t->getRow(0).getZ();
	m[1] = t->getRow(1).getX();
	m[5] = t->getRow(1).getY();
	m[9] = t->getRow(1).getZ();
	m[2] = t->getRow(2).getX();
	m[6] = t->getRow(2).getY();
	m[10] = t->getRow(2).getZ();
#else
	m[0] = t->getRow(0).getX();
	m[1] = t->getRow(0).getY();
	m[2] = t->getRow(0).getZ();
	m[4] = t->getRow(1).getX();
	m[5] = t->getRow(1).getY();
	m[6] = t->getRow(1).getZ();
	m[8] = t->getRow(2).getX();
	m[9] = t->getRow(2).getY();
	m[10] = t->getRow(2).getZ();
#endif
	//m[12] = 0;
	//m[13] = 0;
	//m[14] = 0;
	m[15] = 1;
#else
#ifdef BTTRANSFORM_TRANSPOSE
	m[0] = t->getRow(0).getX();
	m[3] = t->getRow(0).getY();
	m[6] = t->getRow(0).getZ();
	m[1] = t->getRow(1).getX();
	m[4] = t->getRow(1).getY();
	m[7] = t->getRow(1).getZ();
	m[2] = t->getRow(2).getX();
	m[5] = t->getRow(2).getY();
	m[8] = t->getRow(2).getZ();
#else
	m[0] = t->getRow(0).getX();
	m[1] = t->getRow(0).getY();
	m[2] = t->getRow(0).getZ();
	m[3] = t->getRow(1).getX();
	m[4] = t->getRow(1).getY();
	m[5] = t->getRow(1).getZ();
	m[6] = t->getRow(2).getX();
	m[7] = t->getRow(2).getY();
	m[8] = t->getRow(2).getZ();
#endif
	//m[9] = 0;
	//m[10] = 0;
	//m[11] = 0;
#endif
}

inline void MatrixTobtMatrix3x3(const btScalar* m, btMatrix3x3* t)
{
#ifdef BTTRANSFORM_TO4X4
#ifdef BTTRANSFORM_TRANSPOSE
	t->setValue(m[0],m[4],m[8],m[1],m[5],m[9],m[2],m[6],m[10]);
#else
	t->setValue(m[0],m[1],m[2],m[4],m[5],m[6],m[8],m[9],m[10]);
#endif
#else
#ifdef BTTRANSFORM_TRANSPOSE
	t->.setValue(m[0],m[3],m[6],m[1],m[4],m[7],m[2],m[5],m[8]);
#else
	t->setValue(m[0],m[1],m[2],m[3],m[4],m[5],m[6],m[7],m[8]);
#endif
#endif
}


#define ALIGNED_NEW_FORCE(targetClass) new (btAlignedAlloc(sizeof(targetClass), 16)) targetClass
#define ALIGNED_FREE_FORCE(target) btAlignedFree(target)

#if defined(BT_USE_SIMD_VECTOR3) && defined(BT_USE_SSE_IN_API) && defined(BT_USE_SSE)
#define ALIGNED_NEW(targetClass) ALIGNED_NEW_FORCE(targetClass)
#define ALIGNED_FREE(target) ALIGNED_FREE_FORCE(target)
#else
#define ALIGNED_NEW(targetClass) new targetClass
#define ALIGNED_FREE(target) delete target
#endif


// SSE requires math structs to be aligned to 16-byte boundaries.
// Alignment cannot be guaranteed in .NET, so aligned temporary intermediate variables
// must be used to exchange vectors and transforms with Bullet (if SSE is enabled).
#define TEMP(var) var ## Temp
#if defined(BT_FORCING_ALIGNMENT) || defined(BT_USE_SSE) || defined(BT_USE_NEON) //&& defined(BT_USE_SSE_IN_API) && defined(BT_USE_SIMD_VECTOR3)
#define VECTOR3_DEF(vec) ATTRIBUTE_ALIGNED16(btVector3) TEMP(vec)
#define VECTOR3_IN(invec, vec) Vector3TobtVector3(invec, vec)
#define VECTOR3_CONV(vec) VECTOR3_DEF(vec); VECTOR3_IN(vec, &TEMP(vec))
#define VECTOR3_USE(vec) TEMP(vec)
#define VECTOR3_OUT(vec, outvec) btVector3ToVector3(vec, outvec)
#define VECTOR3_OUT2(vec, outvec) btVector3ToVector3(vec, outvec)
#define VECTOR3_DEF_OUT(vec) VECTOR3_OUT(&TEMP(vec), vec)
#define TRANSFORM_DEF(tr) ATTRIBUTE_ALIGNED16(btTransform) TEMP(tr)
#define MATRIX3X3_DEF(tr) ATTRIBUTE_ALIGNED16(btMatrix3x3) TEMP(tr)
#define QUATERNION_DEF(quat) ATTRIBUTE_ALIGNED16(btQuaternion) TEMP(quat)
#define QUATERNION_IN(inquat, quat) QuaternionTobtQuaternion(inquat, quat)
#define QUATERNION_CONV(quat) QUATERNION_DEF(quat); QUATERNION_IN(quat, &TEMP(quat))
#define QUATERNION_USE(quat) TEMP(quat)
#define QUATERNION_OUT(quat, outquat) btQuaternionToQuaternion(&quat, outquat)
#define QUATERNION_OUT2(quat, outquat) btQuaternionToQuaternion(quat, outquat)
#else
#define VECTOR3_DEF(vec)
#define VECTOR3_IN(invec, vec) *vec = *(btVector3*)invec
#define VECTOR3_CONV(vec)
#define VECTOR3_USE(vec) *(btVector3*)vec
#define VECTOR3_OUT(vec, outvec) *(btVector3*)outvec = *vec
#define VECTOR3_OUT2(vec, outvec) *(btVector3*)outvec = vec
#define VECTOR3_DEF_OUT(vec)
#define TRANSFORM_DEF(tr) btTransform TEMP(tr)
#define MATRIX3X3_DEF(tr) btMatrix3x3 TEMP(tr)
#define QUATERNION_DEF(quat)
#define QUATERNION_IN(inquat, quat) *quat = *(btQuaternion*)inquat
#define QUATERNION_CONV(quat)
#define QUATERNION_USE(quat) *(btQuaternion*)quat
#define QUATERNION_OUT(quat, outquat) *(btQuaternion*)outquat = quat
#define QUATERNION_OUT2(quat, outquat) *(btQuaternion*)outquat = quat
#endif
#define TRANSFORM_CONV(tr) TRANSFORM_DEF(tr); MatrixTobtTransform(tr, &TEMP(tr))
#define TRANSFORM_USE(tr) TEMP(tr)
#define TRANSFORM_OUT(tr, outtr) btTransformToMatrix(tr, outtr)
#define TRANSFORM_DEF_OUT(tr) TRANSFORM_OUT(&TEMP(tr), tr)
#define MATRIX3X3_IN(intr, tr) MatrixTobtMatrix3x3(intr, tr)
#define MATRIX3X3_OUT(tr, outtr) btMatrix3x3ToMatrix(tr, outtr)
#define MATRIX3X3_DEF_OUT(tr) MATRIX3X3_OUT(&TEMP(tr), tr)
