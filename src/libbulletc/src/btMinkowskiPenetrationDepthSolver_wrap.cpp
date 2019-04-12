#include <BulletCollision/NarrowPhaseCollision/btMinkowskiPenetrationDepthSolver.h>

#include "conversion.h"
#include "btMinkowskiPenetrationDepthSolver_wrap.h"

btMinkowskiPenetrationDepthSolver* btMinkowskiPenetrationDepthSolver_new()
{
	return new btMinkowskiPenetrationDepthSolver();
}
