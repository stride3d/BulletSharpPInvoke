#include <iostream>

#include <bulletc.h>

using namespace std;

int main(int argc, char* argv[])
{
	btDbvtBroadphase* broadphase = btDbvtBroadphase_new2();
	btDefaultCollisionConfiguration* collisionConfiguration = btDefaultCollisionConfiguration_new2();
	btCollisionDispatcher* dispatcher = btCollisionDispatcher_new(collisionConfiguration);
	btSequentialImpulseConstraintSolver* solver = btSequentialImpulseConstraintSolver_new();
	btDiscreteDynamicsWorld* world = btDiscreteDynamicsWorld_new(dispatcher,broadphase,solver,collisionConfiguration);
	btSphereShape* shape = btSphereShape_new(1);
	btDefaultMotionState* ms = btDefaultMotionState_new();
	btRigidBody_btRigidBodyConstructionInfo* ci = btRigidBody_btRigidBodyConstructionInfo_new2(0,ms,shape);
	btRigidBody* body = btRigidBody_new(ci);
	btDynamicsWorld_addRigidBody(world,body);
	btDynamicsWorld_removeRigidBody(world,body);

	btBroadphaseInterface_delete(broadphase);
	btCollisionConfiguration_delete(collisionConfiguration);
	btDispatcher_delete(dispatcher);
	btConstraintSolver_delete(solver);
	btCollisionWorld_delete(world);
	btCollisionShape_delete(shape);
	btMotionState_delete(ms);
	btRigidBody_btRigidBodyConstructionInfo_delete(ci);
	btCollisionObject_delete(body);

	cout << "OK";
	cin.get();
	return 0;
}
