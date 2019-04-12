#include <BulletSoftBody/btSoftBodyRigidBodyCollisionConfiguration.h>

#include "btSoftBodyRigidBodyCollisionConfiguration_wrap.h"

btSoftBodyRigidBodyCollisionConfiguration* btSoftBodyRigidBodyCollisionConfiguration_new(btDefaultCollisionConstructionInfo* constructionInfo)
{
	return new btSoftBodyRigidBodyCollisionConfiguration(*constructionInfo);
}

btSoftBodyRigidBodyCollisionConfiguration* btSoftBodyRigidBodyCollisionConfiguration_new2()
{
	return new btSoftBodyRigidBodyCollisionConfiguration();
}
