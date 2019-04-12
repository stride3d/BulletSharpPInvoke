#include <LinearMath/btPolarDecomposition.h>

#include "conversion.h"
#include "btPolarDecomposition_wrap.h"

btPolarDecomposition* btPolarDecomposition_new(btScalar tolerance, unsigned int maxIterations)
{
	return new btPolarDecomposition(tolerance, maxIterations);
}

btPolarDecomposition* btPolarDecomposition_new2(btScalar tolerance)
{
	return new btPolarDecomposition(tolerance);
}

btPolarDecomposition* btPolarDecomposition_new3()
{
	return new btPolarDecomposition();
}

unsigned int btPolarDecomposition_decompose(btPolarDecomposition* obj, btMatrix3x3* a, btMatrix3x3* u, btMatrix3x3* h)
{
	return obj->decompose(*a, *u, *h);
}

unsigned int btPolarDecomposition_maxIterations(btPolarDecomposition* obj)
{
	return obj->maxIterations();
}

void btPolarDecomposition_delete(btPolarDecomposition* obj)
{
	delete obj;
}
