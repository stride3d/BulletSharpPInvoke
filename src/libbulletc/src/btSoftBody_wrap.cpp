#include <BulletSoftBody/btSoftBody.h>
#include <BulletSoftBody/btSoftBodySolvers.h>

#include "conversion.h"
#include "btSoftBody_wrap.h"

btSoftBodyWorldInfo* btSoftBodyWorldInfo_new()
{
	return new btSoftBodyWorldInfo();
}

btScalar btSoftBodyWorldInfo_getAir_density(btSoftBodyWorldInfo* obj)
{
	return obj->air_density;
}

btBroadphaseInterface* btSoftBodyWorldInfo_getBroadphase(btSoftBodyWorldInfo* obj)
{
	return obj->m_broadphase;
}

btDispatcher* btSoftBodyWorldInfo_getDispatcher(btSoftBodyWorldInfo* obj)
{
	return obj->m_dispatcher;
}

void btSoftBodyWorldInfo_getGravity(btSoftBodyWorldInfo* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->m_gravity, value);
}

void btSoftBodyWorldInfo_getSparsesdf(btSoftBodyWorldInfo* obj)
{
	obj->m_sparsesdf;
}

btScalar btSoftBodyWorldInfo_getWater_density(btSoftBodyWorldInfo* obj)
{
	return obj->water_density;
}

void btSoftBodyWorldInfo_getWater_normal(btSoftBodyWorldInfo* obj, btScalar* value)
{
	VECTOR3_OUT(&obj->water_normal, value);
}

btScalar btSoftBodyWorldInfo_getWater_offset(btSoftBodyWorldInfo* obj)
{
	return obj->water_offset;
}

void btSoftBodyWorldInfo_setAir_density(btSoftBodyWorldInfo* obj, btScalar value)
{
	obj->air_density = value;
}

void btSoftBodyWorldInfo_setBroadphase(btSoftBodyWorldInfo* obj, btBroadphaseInterface* value)
{
	obj->m_broadphase = value;
}

void btSoftBodyWorldInfo_setDispatcher(btSoftBodyWorldInfo* obj, btDispatcher* value)
{
	obj->m_dispatcher = value;
}

void btSoftBodyWorldInfo_setGravity(btSoftBodyWorldInfo* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->m_gravity);
}
/*
void btSoftBodyWorldInfo_setSparsesdf(btSoftBodyWorldInfo* obj, void value)
{
	obj->m_sparsesdf = value;
}
*/
void btSoftBodyWorldInfo_setWater_density(btSoftBodyWorldInfo* obj, btScalar value)
{
	obj->water_density = value;
}

void btSoftBodyWorldInfo_setWater_normal(btSoftBodyWorldInfo* obj, btScalar* value)
{
	VECTOR3_IN(value, &obj->water_normal);
}

void btSoftBodyWorldInfo_setWater_offset(btSoftBodyWorldInfo* obj, btScalar value)
{
	obj->water_offset = value;
}

void btSoftBodyWorldInfo_delete(btSoftBodyWorldInfo* obj)
{
	delete obj;
}

btSoftBody_sRayCast* btSoftBody_sRayCast_new()
{
	return new btSoftBody_sRayCast();
}

btSoftBody* btSoftBody_sRayCast_getBody(btSoftBody_sRayCast* obj)
{
	return obj->body;
}

void btSoftBody_sRayCast_getFeature(btSoftBody_sRayCast* obj)
{
	obj->feature;
}

btScalar btSoftBody_sRayCast_getFraction(btSoftBody_sRayCast* obj)
{
	return obj->fraction;
}

int btSoftBody_sRayCast_getIndex(btSoftBody_sRayCast* obj)
{
	return obj->index;
}

void btSoftBody_sRayCast_setBody(btSoftBody_sRayCast* obj, btSoftBody* value)
{
	obj->body = value;
}
/*
void btSoftBody_sRayCast_setFeature(btSoftBody_sRayCast* obj, void value)
{
	obj->feature = value;
}
*/
void btSoftBody_sRayCast_setFraction(btSoftBody_sRayCast* obj, btScalar value)
{
	obj->fraction = value;
}

void btSoftBody_sRayCast_setIndex(btSoftBody_sRayCast* obj, int value)
{
	obj->index = value;
}

void btSoftBody_sRayCast_delete(btSoftBody_sRayCast* obj)
{
	delete obj;
}

btScalar btSoftBody_ImplicitFn_Eval(btSoftBody_ImplicitFn* obj, btScalar* x)
{
	VECTOR3_CONV(x);
	return obj->Eval(VECTOR3_USE(x));
}

void btSoftBody_ImplicitFn_delete(btSoftBody_ImplicitFn* obj)
{
	delete obj;
}

btSoftBody_sCti* btSoftBody_sCti_new()
{
	return new btSoftBody_sCti();
}
/*
btCollisionObject* btSoftBody_sCti_getColObj(btSoftBody_sCti* obj)
{
	return obj->m_colObj;
}
*/
void btSoftBody_sCti_getNormal(btSoftBody_sCti* obj)
{
	obj->m_normal;
}

btScalar btSoftBody_sCti_getOffset(btSoftBody_sCti* obj)
{
	return obj->m_offset;
}

void btSoftBody_sCti_setColObj(btSoftBody_sCti* obj, btCollisionObject* value)
{
	obj->m_colObj = value;
}
/*
void btSoftBody_sCti_setNormal(btSoftBody_sCti* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_normal = value;
}
*/
void btSoftBody_sCti_setOffset(btSoftBody_sCti* obj, btScalar value)
{
	obj->m_offset = value;
}

void btSoftBody_sCti_delete(btSoftBody_sCti* obj)
{
	delete obj;
}

btSoftBody_sMedium* btSoftBody_sMedium_new()
{
	return new btSoftBody_sMedium();
}

btScalar btSoftBody_sMedium_getDensity(btSoftBody_sMedium* obj)
{
	return obj->m_density;
}

btScalar btSoftBody_sMedium_getPressure(btSoftBody_sMedium* obj)
{
	return obj->m_pressure;
}

void btSoftBody_sMedium_getVelocity(btSoftBody_sMedium* obj)
{
	obj->m_velocity;
}

void btSoftBody_sMedium_setDensity(btSoftBody_sMedium* obj, btScalar value)
{
	obj->m_density = value;
}

void btSoftBody_sMedium_setPressure(btSoftBody_sMedium* obj, btScalar value)
{
	obj->m_pressure = value;
}
/*
void btSoftBody_sMedium_setVelocity(btSoftBody_sMedium* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_velocity = value;
}
*/
void btSoftBody_sMedium_delete(btSoftBody_sMedium* obj)
{
	delete obj;
}

btSoftBody_Element* btSoftBody_Element_new()
{
	return new btSoftBody_Element();
}

void* btSoftBody_Element_getTag(btSoftBody_Element* obj)
{
	return obj->m_tag;
}

void btSoftBody_Element_setTag(btSoftBody_Element* obj, void* value)
{
	obj->m_tag = value;
}

void btSoftBody_Element_delete(btSoftBody_Element* obj)
{
	delete obj;
}

btSoftBody_Material* btSoftBody_Material_new()
{
	return new btSoftBody_Material();
}

int btSoftBody_Material_getFlags(btSoftBody_Material* obj)
{
	return obj->m_flags;
}

btScalar btSoftBody_Material_getKAST(btSoftBody_Material* obj)
{
	return obj->m_kAST;
}

btScalar btSoftBody_Material_getKLST(btSoftBody_Material* obj)
{
	return obj->m_kLST;
}

btScalar btSoftBody_Material_getKVST(btSoftBody_Material* obj)
{
	return obj->m_kVST;
}

void btSoftBody_Material_setFlags(btSoftBody_Material* obj, int value)
{
	obj->m_flags = value;
}

void btSoftBody_Material_setKAST(btSoftBody_Material* obj, btScalar value)
{
	obj->m_kAST = value;
}

void btSoftBody_Material_setKLST(btSoftBody_Material* obj, btScalar value)
{
	obj->m_kLST = value;
}

void btSoftBody_Material_setKVST(btSoftBody_Material* obj, btScalar value)
{
	obj->m_kVST = value;
}

btSoftBody_Feature* btSoftBody_Feature_new()
{
	return new btSoftBody_Feature();
}

btSoftBody_Material* btSoftBody_Feature_getMaterial(btSoftBody_Feature* obj)
{
	return obj->m_material;
}

void btSoftBody_Feature_setMaterial(btSoftBody_Feature* obj, btSoftBody_Material* value)
{
	obj->m_material = value;
}

btSoftBody_Node* btSoftBody_Node_new()
{
	return new btSoftBody_Node();
}

btScalar btSoftBody_Node_getArea(btSoftBody_Node* obj)
{
	return obj->m_area;
}

int btSoftBody_Node_getBattach(btSoftBody_Node* obj)
{
	return obj->m_battach;
}

void btSoftBody_Node_getF(btSoftBody_Node* obj)
{
	obj->m_f;
}

btScalar btSoftBody_Node_getIm(btSoftBody_Node* obj)
{
	return obj->m_im;
}

btDbvtNode* btSoftBody_Node_getLeaf(btSoftBody_Node* obj)
{
	return obj->m_leaf;
}

void btSoftBody_Node_getN(btSoftBody_Node* obj)
{
	obj->m_n;
}

void btSoftBody_Node_getQ(btSoftBody_Node* obj)
{
	obj->m_q;
}

void btSoftBody_Node_getV(btSoftBody_Node* obj)
{
	obj->m_v;
}

void btSoftBody_Node_getX(btSoftBody_Node* obj)
{
	obj->m_x;
}

void btSoftBody_Node_setArea(btSoftBody_Node* obj, btScalar value)
{
	obj->m_area = value;
}

void btSoftBody_Node_setBattach(btSoftBody_Node* obj, int value)
{
	obj->m_battach = value;
}
/*
void btSoftBody_Node_setF(btSoftBody_Node* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_f = value;
}
*/
void btSoftBody_Node_setIm(btSoftBody_Node* obj, btScalar value)
{
	obj->m_im = value;
}

void btSoftBody_Node_setLeaf(btSoftBody_Node* obj, btDbvtNode* value)
{
	obj->m_leaf = value;
}
/*
void btSoftBody_Node_setN(btSoftBody_Node* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_n = value;
}

void btSoftBody_Node_setQ(btSoftBody_Node* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_q = value;
}

void btSoftBody_Node_setV(btSoftBody_Node* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_v = value;
}

void btSoftBody_Node_setX(btSoftBody_Node* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_x = value;
}
*/
btSoftBody_Link* btSoftBody_Link_new()
{
	return new btSoftBody_Link();
}

int btSoftBody_Link_getBbending(btSoftBody_Link* obj)
{
	return obj->m_bbending;
}

btScalar btSoftBody_Link_getC0(btSoftBody_Link* obj)
{
	return obj->m_c0;
}

btScalar btSoftBody_Link_getC1(btSoftBody_Link* obj)
{
	return obj->m_c1;
}

btScalar btSoftBody_Link_getC2(btSoftBody_Link* obj)
{
	return obj->m_c2;
}

void btSoftBody_Link_getC3(btSoftBody_Link* obj)
{
	obj->m_c3;
}
/*
* btSoftBody_Link_getN(btSoftBody_Link* obj)
{
	return obj->m_n;
}
*/
btScalar btSoftBody_Link_getRl(btSoftBody_Link* obj)
{
	return obj->m_rl;
}

void btSoftBody_Link_setBbending(btSoftBody_Link* obj, int value)
{
	obj->m_bbending = value;
}

void btSoftBody_Link_setC0(btSoftBody_Link* obj, btScalar value)
{
	obj->m_c0 = value;
}

void btSoftBody_Link_setC1(btSoftBody_Link* obj, btScalar value)
{
	obj->m_c1 = value;
}

void btSoftBody_Link_setC2(btSoftBody_Link* obj, btScalar value)
{
	obj->m_c2 = value;
}
/*
void btSoftBody_Link_setC3(btSoftBody_Link* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_c3 = value;
}

void btSoftBody_Link_setN(btSoftBody_Link* obj, * value)
{
	obj->m_n = value;
}
*/
void btSoftBody_Link_setRl(btSoftBody_Link* obj, btScalar value)
{
	obj->m_rl = value;
}

btSoftBody_Face* btSoftBody_Face_new()
{
	return new btSoftBody_Face();
}

btDbvtNode* btSoftBody_Face_getLeaf(btSoftBody_Face* obj)
{
	return obj->m_leaf;
}
/*
* btSoftBody_Face_getN(btSoftBody_Face* obj)
{
	return obj->m_n;
}
*/
void btSoftBody_Face_getNormal(btSoftBody_Face* obj)
{
	obj->m_normal;
}

btScalar btSoftBody_Face_getRa(btSoftBody_Face* obj)
{
	return obj->m_ra;
}

void btSoftBody_Face_setLeaf(btSoftBody_Face* obj, btDbvtNode* value)
{
	obj->m_leaf = value;
}
/*
void btSoftBody_Face_setN(btSoftBody_Face* obj, * value)
{
	obj->m_n = value;
}

void btSoftBody_Face_setNormal(btSoftBody_Face* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_normal = value;
}
*/
void btSoftBody_Face_setRa(btSoftBody_Face* obj, btScalar value)
{
	obj->m_ra = value;
}

btSoftBody_Tetra* btSoftBody_Tetra_new()
{
	return new btSoftBody_Tetra();
}
/*
btScalar* btSoftBody_Tetra_getC0(btSoftBody_Tetra* obj)
{
	return obj->m_c0;
}
*/
btScalar btSoftBody_Tetra_getC1(btSoftBody_Tetra* obj)
{
	return obj->m_c1;
}

btScalar btSoftBody_Tetra_getC2(btSoftBody_Tetra* obj)
{
	return obj->m_c2;
}

btDbvtNode* btSoftBody_Tetra_getLeaf(btSoftBody_Tetra* obj)
{
	return obj->m_leaf;
}
/*
* btSoftBody_Tetra_getN(btSoftBody_Tetra* obj)
{
	return obj->m_n;
}
*/
btScalar btSoftBody_Tetra_getRv(btSoftBody_Tetra* obj)
{
	return obj->m_rv;
}
/*
void btSoftBody_Tetra_setC0(btSoftBody_Tetra* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_c0 = value;
}
*/
void btSoftBody_Tetra_setC1(btSoftBody_Tetra* obj, btScalar value)
{
	obj->m_c1 = value;
}

void btSoftBody_Tetra_setC2(btSoftBody_Tetra* obj, btScalar value)
{
	obj->m_c2 = value;
}

void btSoftBody_Tetra_setLeaf(btSoftBody_Tetra* obj, btDbvtNode* value)
{
	obj->m_leaf = value;
}
/*
void btSoftBody_Tetra_setN(btSoftBody_Tetra* obj, * value)
{
	obj->m_n = value;
}
*/
void btSoftBody_Tetra_setRv(btSoftBody_Tetra* obj, btScalar value)
{
	obj->m_rv = value;
}

btSoftBody_RContact* btSoftBody_RContact_new()
{
	return new btSoftBody_RContact();
}

void btSoftBody_RContact_getC0(btSoftBody_RContact* obj)
{
	obj->m_c0;
}

void btSoftBody_RContact_getC1(btSoftBody_RContact* obj)
{
	obj->m_c1;
}

btScalar btSoftBody_RContact_getC2(btSoftBody_RContact* obj)
{
	return obj->m_c2;
}

btScalar btSoftBody_RContact_getC3(btSoftBody_RContact* obj)
{
	return obj->m_c3;
}

btScalar btSoftBody_RContact_getC4(btSoftBody_RContact* obj)
{
	return obj->m_c4;
}

void btSoftBody_RContact_getCti(btSoftBody_RContact* obj)
{
	obj->m_cti;
}

btSoftBody_Node* btSoftBody_RContact_getNode(btSoftBody_RContact* obj)
{
	return obj->m_node;
}
/*
void btSoftBody_RContact_setC0(btSoftBody_RContact* obj, void value)
{
	obj->m_c0 = value;
}

void btSoftBody_RContact_setC1(btSoftBody_RContact* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_c1 = value;
}
*/
void btSoftBody_RContact_setC2(btSoftBody_RContact* obj, btScalar value)
{
	obj->m_c2 = value;
}

void btSoftBody_RContact_setC3(btSoftBody_RContact* obj, btScalar value)
{
	obj->m_c3 = value;
}

void btSoftBody_RContact_setC4(btSoftBody_RContact* obj, btScalar value)
{
	obj->m_c4 = value;
}
/*
void btSoftBody_RContact_setCti(btSoftBody_RContact* obj, void value)
{
	obj->m_cti = value;
}
*/
void btSoftBody_RContact_setNode(btSoftBody_RContact* obj, btSoftBody_Node* value)
{
	obj->m_node = value;
}

void btSoftBody_RContact_delete(btSoftBody_RContact* obj)
{
	delete obj;
}

btSoftBody_SContact* btSoftBody_SContact_new()
{
	return new btSoftBody_SContact();
}

btScalar* btSoftBody_SContact_getCfm(btSoftBody_SContact* obj)
{
	return obj->m_cfm;
}

btSoftBody_Face* btSoftBody_SContact_getFace(btSoftBody_SContact* obj)
{
	return obj->m_face;
}

btScalar btSoftBody_SContact_getFriction(btSoftBody_SContact* obj)
{
	return obj->m_friction;
}

btScalar btSoftBody_SContact_getMargin(btSoftBody_SContact* obj)
{
	return obj->m_margin;
}

btSoftBody_Node* btSoftBody_SContact_getNode(btSoftBody_SContact* obj)
{
	return obj->m_node;
}

void btSoftBody_SContact_getNormal(btSoftBody_SContact* obj)
{
	obj->m_normal;
}

void btSoftBody_SContact_getWeights(btSoftBody_SContact* obj)
{
	obj->m_weights;
}
/*
void btSoftBody_SContact_setCfm(btSoftBody_SContact* obj, btScalar* value)
{
	obj->m_cfm = value;
}
*/
void btSoftBody_SContact_setFace(btSoftBody_SContact* obj, btSoftBody_Face* value)
{
	obj->m_face = value;
}

void btSoftBody_SContact_setFriction(btSoftBody_SContact* obj, btScalar value)
{
	obj->m_friction = value;
}

void btSoftBody_SContact_setMargin(btSoftBody_SContact* obj, btScalar value)
{
	obj->m_margin = value;
}

void btSoftBody_SContact_setNode(btSoftBody_SContact* obj, btSoftBody_Node* value)
{
	obj->m_node = value;
}
/*
void btSoftBody_SContact_setNormal(btSoftBody_SContact* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_normal = value;
}

void btSoftBody_SContact_setWeights(btSoftBody_SContact* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_weights = value;
}
*/
void btSoftBody_SContact_delete(btSoftBody_SContact* obj)
{
	delete obj;
}

btSoftBody_Anchor* btSoftBody_Anchor_new()
{
	return new btSoftBody_Anchor();
}

btRigidBody* btSoftBody_Anchor_getBody(btSoftBody_Anchor* obj)
{
	return obj->m_body;
}

void btSoftBody_Anchor_getC0(btSoftBody_Anchor* obj)
{
	obj->m_c0;
}

void btSoftBody_Anchor_getC1(btSoftBody_Anchor* obj)
{
	obj->m_c1;
}

btScalar btSoftBody_Anchor_getC2(btSoftBody_Anchor* obj)
{
	return obj->m_c2;
}

btScalar btSoftBody_Anchor_getInfluence(btSoftBody_Anchor* obj)
{
	return obj->m_influence;
}

void btSoftBody_Anchor_getLocal(btSoftBody_Anchor* obj)
{
	obj->m_local;
}

btSoftBody_Node* btSoftBody_Anchor_getNode(btSoftBody_Anchor* obj)
{
	return obj->m_node;
}

void btSoftBody_Anchor_setBody(btSoftBody_Anchor* obj, btRigidBody* value)
{
	obj->m_body = value;
}
/*
void btSoftBody_Anchor_setC0(btSoftBody_Anchor* obj, void value)
{
	obj->m_c0 = value;
}

void btSoftBody_Anchor_setC1(btSoftBody_Anchor* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_c1 = value;
}
*/
void btSoftBody_Anchor_setC2(btSoftBody_Anchor* obj, btScalar value)
{
	obj->m_c2 = value;
}

void btSoftBody_Anchor_setInfluence(btSoftBody_Anchor* obj, btScalar value)
{
	obj->m_influence = value;
}
/*
void btSoftBody_Anchor_setLocal(btSoftBody_Anchor* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_local = value;
}
*/
void btSoftBody_Anchor_setNode(btSoftBody_Anchor* obj, btSoftBody_Node* value)
{
	obj->m_node = value;
}

void btSoftBody_Anchor_delete(btSoftBody_Anchor* obj)
{
	delete obj;
}

btSoftBody_Note* btSoftBody_Note_new()
{
	return new btSoftBody_Note();
}

btScalar* btSoftBody_Note_getCoords(btSoftBody_Note* obj)
{
	return obj->m_coords;
}
/*
* btSoftBody_Note_getNodes(btSoftBody_Note* obj)
{
	return obj->m_nodes;
}
*/
void btSoftBody_Note_getOffset(btSoftBody_Note* obj)
{
	obj->m_offset;
}

int btSoftBody_Note_getRank(btSoftBody_Note* obj)
{
	return obj->m_rank;
}

const char* btSoftBody_Note_getText(btSoftBody_Note* obj)
{
	return obj->m_text;
}
/*
void btSoftBody_Note_setCoords(btSoftBody_Note* obj, btScalar* value)
{
	obj->m_coords = value;
}

void btSoftBody_Note_setNodes(btSoftBody_Note* obj, * value)
{
	obj->m_nodes = value;
}

void btSoftBody_Note_setOffset(btSoftBody_Note* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_offset = value;
}
*/
void btSoftBody_Note_setRank(btSoftBody_Note* obj, int value)
{
	obj->m_rank = value;
}

void btSoftBody_Note_setText(btSoftBody_Note* obj, char* value)
{
	obj->m_text = value;
}

btSoftBody_Pose* btSoftBody_Pose_new()
{
	return new btSoftBody_Pose();
}

void btSoftBody_Pose_getAqq(btSoftBody_Pose* obj)
{
	obj->m_aqq;
}

bool btSoftBody_Pose_getBframe(btSoftBody_Pose* obj)
{
	return obj->m_bframe;
}

bool btSoftBody_Pose_getBvolume(btSoftBody_Pose* obj)
{
	return obj->m_bvolume;
}

void btSoftBody_Pose_getCom(btSoftBody_Pose* obj)
{
	obj->m_com;
}
/*
btAlignedObjectArray* btSoftBody_Pose_getPos(btSoftBody_Pose* obj)
{
	return obj->m_pos;
}
*/
void btSoftBody_Pose_getRot(btSoftBody_Pose* obj)
{
	obj->m_rot;
}

void btSoftBody_Pose_getScl(btSoftBody_Pose* obj)
{
	obj->m_scl;
}
/*
btAlignedObjectArray* btSoftBody_Pose_getWgh(btSoftBody_Pose* obj)
{
	return obj->m_wgh;
}
*/
btScalar btSoftBody_Pose_getVolume(btSoftBody_Pose* obj)
{
	return obj->m_volume;
}
/*
void btSoftBody_Pose_setAqq(btSoftBody_Pose* obj, void value)
{
	obj->m_aqq = value;
}
*/
void btSoftBody_Pose_setBframe(btSoftBody_Pose* obj, bool value)
{
	obj->m_bframe = value;
}

void btSoftBody_Pose_setBvolume(btSoftBody_Pose* obj, bool value)
{
	obj->m_bvolume = value;
}
/*
void btSoftBody_Pose_setCom(btSoftBody_Pose* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_com = value;
}

void btSoftBody_Pose_setPos(btSoftBody_Pose* obj, btAlignedObjectArray* value)
{
	obj->m_pos = value;
}

void btSoftBody_Pose_setRot(btSoftBody_Pose* obj, void value)
{
	obj->m_rot = value;
}

void btSoftBody_Pose_setScl(btSoftBody_Pose* obj, void value)
{
	obj->m_scl = value;
}

void btSoftBody_Pose_setWgh(btSoftBody_Pose* obj, btAlignedObjectArray* value)
{
	obj->m_wgh = value;
}
*/
void btSoftBody_Pose_setVolume(btSoftBody_Pose* obj, btScalar value)
{
	obj->m_volume = value;
}

void btSoftBody_Pose_delete(btSoftBody_Pose* obj)
{
	delete obj;
}

btSoftBody_Cluster* btSoftBody_Cluster_new()
{
	return new btSoftBody_Cluster();
}

btScalar btSoftBody_Cluster_getAdamping(btSoftBody_Cluster* obj)
{
	return obj->m_adamping;
}

void btSoftBody_Cluster_getAv(btSoftBody_Cluster* obj)
{
	obj->m_av;
}

int btSoftBody_Cluster_getClusterIndex(btSoftBody_Cluster* obj)
{
	return obj->m_clusterIndex;
}

bool btSoftBody_Cluster_getCollide(btSoftBody_Cluster* obj)
{
	return obj->m_collide;
}

void btSoftBody_Cluster_getCom(btSoftBody_Cluster* obj)
{
	obj->m_com;
}

bool btSoftBody_Cluster_getContainsAnchor(btSoftBody_Cluster* obj)
{
	return obj->m_containsAnchor;
}
/*
btScalar* btSoftBody_Cluster_getDimpulses(btSoftBody_Cluster* obj)
{
	return obj->m_dimpulses;
}

btAlignedObjectArray* btSoftBody_Cluster_getFramerefs(btSoftBody_Cluster* obj)
{
	return obj->m_framerefs;
}
*/
void btSoftBody_Cluster_getFramexform(btSoftBody_Cluster* obj)
{
	obj->m_framexform;
}

btScalar btSoftBody_Cluster_getIdmass(btSoftBody_Cluster* obj)
{
	return obj->m_idmass;
}

btScalar btSoftBody_Cluster_getImass(btSoftBody_Cluster* obj)
{
	return obj->m_imass;
}

void btSoftBody_Cluster_getInvwi(btSoftBody_Cluster* obj)
{
	obj->m_invwi;
}

btScalar btSoftBody_Cluster_getLdamping(btSoftBody_Cluster* obj)
{
	return obj->m_ldamping;
}

btDbvtNode* btSoftBody_Cluster_getLeaf(btSoftBody_Cluster* obj)
{
	return obj->m_leaf;
}

void btSoftBody_Cluster_getLocii(btSoftBody_Cluster* obj)
{
	obj->m_locii;
}

void btSoftBody_Cluster_getLv(btSoftBody_Cluster* obj)
{
	obj->m_lv;
}
/*
btAlignedObjectArray* btSoftBody_Cluster_getMasses(btSoftBody_Cluster* obj)
{
	return obj->m_masses;
}
*/
btScalar btSoftBody_Cluster_getMatching(btSoftBody_Cluster* obj)
{
	return obj->m_matching;
}

btScalar btSoftBody_Cluster_getMaxSelfCollisionImpulse(btSoftBody_Cluster* obj)
{
	return obj->m_maxSelfCollisionImpulse;
}

btScalar btSoftBody_Cluster_getNdamping(btSoftBody_Cluster* obj)
{
	return obj->m_ndamping;
}

int btSoftBody_Cluster_getNdimpulses(btSoftBody_Cluster* obj)
{
	return obj->m_ndimpulses;
}

void btSoftBody_Cluster_getNodes(btSoftBody_Cluster* obj)
{
	obj->m_nodes;
}

int btSoftBody_Cluster_getNvimpulses(btSoftBody_Cluster* obj)
{
	return obj->m_nvimpulses;
}

btScalar btSoftBody_Cluster_getSelfCollisionImpulseFactor(btSoftBody_Cluster* obj)
{
	return obj->m_selfCollisionImpulseFactor;
}
/*
btScalar* btSoftBody_Cluster_getVimpulses(btSoftBody_Cluster* obj)
{
	return obj->m_vimpulses;
}
*/
void btSoftBody_Cluster_setAdamping(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_adamping = value;
}
/*
void btSoftBody_Cluster_setAv(btSoftBody_Cluster* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_av = value;
}*/

void btSoftBody_Cluster_setClusterIndex(btSoftBody_Cluster* obj, int value)
{
	obj->m_clusterIndex = value;
}

void btSoftBody_Cluster_setCollide(btSoftBody_Cluster* obj, bool value)
{
	obj->m_collide = value;
}
/*
void btSoftBody_Cluster_setCom(btSoftBody_Cluster* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_com = value;
}
*/
void btSoftBody_Cluster_setContainsAnchor(btSoftBody_Cluster* obj, bool value)
{
	obj->m_containsAnchor = value;
}
/*
void btSoftBody_Cluster_setDimpulses(btSoftBody_Cluster* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_dimpulses = value;
}

void btSoftBody_Cluster_setFramerefs(btSoftBody_Cluster* obj, btAlignedObjectArray* value)
{
	obj->m_framerefs = value;
}

void btSoftBody_Cluster_setFramexform(btSoftBody_Cluster* obj, void value)
{
	TRANSFORM_CONV(value);
	obj->m_framexform = value;
}
*/
void btSoftBody_Cluster_setIdmass(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_idmass = value;
}

void btSoftBody_Cluster_setImass(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_imass = value;
}
/*
void btSoftBody_Cluster_setInvwi(btSoftBody_Cluster* obj, void value)
{
	obj->m_invwi = value;
}
*/
void btSoftBody_Cluster_setLdamping(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_ldamping = value;
}

void btSoftBody_Cluster_setLeaf(btSoftBody_Cluster* obj, btDbvtNode* value)
{
	obj->m_leaf = value;
}
/*
void btSoftBody_Cluster_setLocii(btSoftBody_Cluster* obj, void value)
{
	obj->m_locii = value;
}

void btSoftBody_Cluster_setLv(btSoftBody_Cluster* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_lv = value;
}

void btSoftBody_Cluster_setMasses(btSoftBody_Cluster* obj, btAlignedObjectArray* value)
{
	obj->m_masses = value;
}
*/
void btSoftBody_Cluster_setMatching(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_matching = value;
}

void btSoftBody_Cluster_setMaxSelfCollisionImpulse(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_maxSelfCollisionImpulse = value;
}

void btSoftBody_Cluster_setNdamping(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_ndamping = value;
}

void btSoftBody_Cluster_setNdimpulses(btSoftBody_Cluster* obj, int value)
{
	obj->m_ndimpulses = value;
}
/*
void btSoftBody_Cluster_setNodes(btSoftBody_Cluster* obj, void value)
{
	obj->m_nodes = value;
}
*/
void btSoftBody_Cluster_setNvimpulses(btSoftBody_Cluster* obj, int value)
{
	obj->m_nvimpulses = value;
}

void btSoftBody_Cluster_setSelfCollisionImpulseFactor(btSoftBody_Cluster* obj, btScalar value)
{
	obj->m_selfCollisionImpulseFactor = value;
}
/*
void btSoftBody_Cluster_setVimpulses(btSoftBody_Cluster* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_vimpulses = value;
}
*/
void btSoftBody_Cluster_delete(btSoftBody_Cluster* obj)
{
	delete obj;
}

btSoftBody_Impulse* btSoftBody_Impulse_new()
{
	return new btSoftBody_Impulse();
}

int btSoftBody_Impulse_getAsDrift(btSoftBody_Impulse* obj)
{
	return obj->m_asDrift;
}

int btSoftBody_Impulse_getAsVelocity(btSoftBody_Impulse* obj)
{
	return obj->m_asVelocity;
}

void btSoftBody_Impulse_getDrift(btSoftBody_Impulse* obj)
{
	obj->m_drift;
}

void btSoftBody_Impulse_getVelocity(btSoftBody_Impulse* obj)
{
	obj->m_velocity;
}

void btSoftBody_Impulse_operator_n(btSoftBody_Impulse* obj)
{
	obj->operator-();
}

void btSoftBody_Impulse_operator_m(btSoftBody_Impulse* obj, btScalar x)
{
	obj->operator*(x);
}

void btSoftBody_Impulse_setAsDrift(btSoftBody_Impulse* obj, int value)
{
	obj->m_asDrift = value;
}

void btSoftBody_Impulse_setAsVelocity(btSoftBody_Impulse* obj, int value)
{
	obj->m_asVelocity = value;
}
/*
void btSoftBody_Impulse_setDrift(btSoftBody_Impulse* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_drift = value;
}

void btSoftBody_Impulse_setVelocity(btSoftBody_Impulse* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_velocity = value;
}
*/
void btSoftBody_Impulse_delete(btSoftBody_Impulse* obj)
{
	delete obj;
}

btSoftBody_Body* btSoftBody_Body_new()
{
	return new btSoftBody_Body();
}

btSoftBody_Body* btSoftBody_Body_new2(btCollisionObject* colObj)
{
	return new btSoftBody_Body(colObj);
}

btSoftBody_Body* btSoftBody_Body_new3(btSoftBody_Cluster* p)
{
	return new btSoftBody_Body(p);
}

void btSoftBody_Body_activate(btSoftBody_Body* obj)
{
	obj->activate();
}

void btSoftBody_Body_angularVelocity(btSoftBody_Body* obj, btScalar* rpos)
{
	VECTOR3_CONV(rpos);
	obj->angularVelocity(VECTOR3_USE(rpos));
}

void btSoftBody_Body_angularVelocity2(btSoftBody_Body* obj)
{
	obj->angularVelocity();
}

void btSoftBody_Body_applyAImpulse(btSoftBody_Body* obj, btSoftBody_Impulse* impulse)
{
	obj->applyAImpulse(*impulse);
}

void btSoftBody_Body_applyDAImpulse(btSoftBody_Body* obj, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	obj->applyDAImpulse(VECTOR3_USE(impulse));
}

void btSoftBody_Body_applyDCImpulse(btSoftBody_Body* obj, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	obj->applyDCImpulse(VECTOR3_USE(impulse));
}

void btSoftBody_Body_applyDImpulse(btSoftBody_Body* obj, btScalar* impulse, btScalar* rpos)
{
	VECTOR3_CONV(impulse);
	VECTOR3_CONV(rpos);
	obj->applyDImpulse(VECTOR3_USE(impulse), VECTOR3_USE(rpos));
}

void btSoftBody_Body_applyImpulse(btSoftBody_Body* obj, btSoftBody_Impulse* impulse, btScalar* rpos)
{
	VECTOR3_CONV(rpos);
	obj->applyImpulse(*impulse, VECTOR3_USE(rpos));
}

void btSoftBody_Body_applyVAImpulse(btSoftBody_Body* obj, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	obj->applyVAImpulse(VECTOR3_USE(impulse));
}

void btSoftBody_Body_applyVImpulse(btSoftBody_Body* obj, btScalar* impulse, btScalar* rpos)
{
	VECTOR3_CONV(impulse);
	VECTOR3_CONV(rpos);
	obj->applyVImpulse(VECTOR3_USE(impulse), VECTOR3_USE(rpos));
}
/*
btCollisionObject* btSoftBody_Body_getCollisionObject(btSoftBody_Body* obj)
{
	return obj->m_collisionObject;
}
*/
btRigidBody* btSoftBody_Body_getRigid(btSoftBody_Body* obj)
{
	return obj->m_rigid;
}

btSoftBody_Cluster* btSoftBody_Body_getSoft(btSoftBody_Body* obj)
{
	return obj->m_soft;
}

btScalar btSoftBody_Body_invMass(btSoftBody_Body* obj)
{
	return obj->invMass();
}
/*
btMatrix3x3* btSoftBody_Body_invWorldInertia(btSoftBody_Body* obj)
{
	return &obj->invWorldInertia();
}
*/
void btSoftBody_Body_linearVelocity(btSoftBody_Body* obj)
{
	obj->linearVelocity();
}

void btSoftBody_Body_setCollisionObject(btSoftBody_Body* obj, btCollisionObject* value)
{
	obj->m_collisionObject = value;
}

void btSoftBody_Body_setRigid(btSoftBody_Body* obj, btRigidBody* value)
{
	obj->m_rigid = value;
}

void btSoftBody_Body_setSoft(btSoftBody_Body* obj, btSoftBody_Cluster* value)
{
	obj->m_soft = value;
}

void btSoftBody_Body_velocity(btSoftBody_Body* obj, btScalar* rpos)
{
	VECTOR3_CONV(rpos);
	obj->velocity(VECTOR3_USE(rpos));
}
/*
btScalar* btSoftBody_Body_xform(btSoftBody_Body* obj)
{
	return &obj->xform();
}
*/
void btSoftBody_Body_delete(btSoftBody_Body* obj)
{
	delete obj;
}

btSoftBody_Joint_eType* btSoftBody_Joint_eType_new()
{
	return new btSoftBody_Joint_eType();
}

void btSoftBody_Joint_eType_delete(btSoftBody_Joint_eType* obj)
{
	delete obj;
}

btSoftBody_Joint_Specs* btSoftBody_Joint_Specs_new()
{
	return new btSoftBody_Joint_Specs();
}

btScalar btSoftBody_Joint_Specs_getCfm(btSoftBody_Joint_Specs* obj)
{
	return obj->cfm;
}

btScalar btSoftBody_Joint_Specs_getErp(btSoftBody_Joint_Specs* obj)
{
	return obj->erp;
}

btScalar btSoftBody_Joint_Specs_getSplit(btSoftBody_Joint_Specs* obj)
{
	return obj->split;
}

void btSoftBody_Joint_Specs_setCfm(btSoftBody_Joint_Specs* obj, btScalar value)
{
	obj->cfm = value;
}

void btSoftBody_Joint_Specs_setErp(btSoftBody_Joint_Specs* obj, btScalar value)
{
	obj->erp = value;
}

void btSoftBody_Joint_Specs_setSplit(btSoftBody_Joint_Specs* obj, btScalar value)
{
	obj->split = value;
}

void btSoftBody_Joint_Specs_delete(btSoftBody_Joint_Specs* obj)
{
	delete obj;
}

btSoftBody_Body* btSoftBody_Joint_getBodies(btSoftBody_Joint* obj)
{
	return obj->m_bodies;
}

btScalar btSoftBody_Joint_getCfm(btSoftBody_Joint* obj)
{
	return obj->m_cfm;
}

bool btSoftBody_Joint_getDelete(btSoftBody_Joint* obj)
{
	return obj->m_delete;
}

void btSoftBody_Joint_getDrift(btSoftBody_Joint* obj)
{
	obj->m_drift;
}

btScalar btSoftBody_Joint_getErp(btSoftBody_Joint* obj)
{
	return obj->m_erp;
}

void btSoftBody_Joint_getMassmatrix(btSoftBody_Joint* obj)
{
	obj->m_massmatrix;
}
/*
btScalar* btSoftBody_Joint_getRefs(btSoftBody_Joint* obj)
{
	return obj->m_refs;
}
*/
void btSoftBody_Joint_getSdrift(btSoftBody_Joint* obj)
{
	obj->m_sdrift;
}

btScalar btSoftBody_Joint_getSplit(btSoftBody_Joint* obj)
{
	return obj->m_split;
}

void btSoftBody_Joint_Prepare(btSoftBody_Joint* obj, btScalar dt, int iterations)
{
	obj->Prepare(dt, iterations);
}
/*
void btSoftBody_Joint_setBodies(btSoftBody_Joint* obj, btSoftBody_Body* value)
{
	obj->m_bodies = value;
}
*/
void btSoftBody_Joint_setCfm(btSoftBody_Joint* obj, btScalar value)
{
	obj->m_cfm = value;
}

void btSoftBody_Joint_setDelete(btSoftBody_Joint* obj, bool value)
{
	obj->m_delete = value;
}
/*
void btSoftBody_Joint_setDrift(btSoftBody_Joint* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_drift = value;
}
*/
void btSoftBody_Joint_setErp(btSoftBody_Joint* obj, btScalar value)
{
	obj->m_erp = value;
}
/*
void btSoftBody_Joint_setMassmatrix(btSoftBody_Joint* obj, void value)
{
	obj->m_massmatrix = value;
}

void btSoftBody_Joint_setRefs(btSoftBody_Joint* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_refs = value;
}

void btSoftBody_Joint_setSdrift(btSoftBody_Joint* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_sdrift = value;
}
*/
void btSoftBody_Joint_setSplit(btSoftBody_Joint* obj, btScalar value)
{
	obj->m_split = value;
}

void btSoftBody_Joint_Solve(btSoftBody_Joint* obj, btScalar dt, btScalar sor)
{
	obj->Solve(dt, sor);
}

void btSoftBody_Joint_Terminate(btSoftBody_Joint* obj, btScalar dt)
{
	obj->Terminate(dt);
}

void btSoftBody_Joint_Type(btSoftBody_Joint* obj)
{
	obj->Type();
}

void btSoftBody_Joint_delete(btSoftBody_Joint* obj)
{
	delete obj;
}

btSoftBody_LJoint* btSoftBody_LJoint_new()
{
	return new btSoftBody_LJoint();
}
/*
btScalar* btSoftBody_LJoint_getRpos(btSoftBody_LJoint* obj)
{
	return obj->m_rpos;
}

void btSoftBody_LJoint_setRpos(btSoftBody_LJoint* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_rpos = value;
}
*/
btSoftBody_AJoint_IControl* btSoftBody_AJoint_IControl_new()
{
	return new btSoftBody_AJoint_IControl();
}

btSoftBody_AJoint_IControl* btSoftBody_AJoint_IControl_Default()
{
	return btSoftBody_AJoint_IControl::Default();
}

void btSoftBody_AJoint_IControl_Prepare(btSoftBody_AJoint_IControl* obj, btSoftBody_AJoint* __unnamed0)
{
	obj->Prepare(__unnamed0);
}

btScalar btSoftBody_AJoint_IControl_Speed(btSoftBody_AJoint_IControl* obj, btSoftBody_AJoint* __unnamed0, btScalar current)
{
	return obj->Speed(__unnamed0, current);
}

void btSoftBody_AJoint_IControl_delete(btSoftBody_AJoint_IControl* obj)
{
	delete obj;
}

btSoftBody_AJoint* btSoftBody_AJoint_new()
{
	return new btSoftBody_AJoint();
}
/*
btScalar* btSoftBody_AJoint_getAxis(btSoftBody_AJoint* obj)
{
	return obj->m_axis;
}
*/
btSoftBody_AJoint_IControl* btSoftBody_AJoint_getIcontrol(btSoftBody_AJoint* obj)
{
	return obj->m_icontrol;
}
/*
void btSoftBody_AJoint_setAxis(btSoftBody_AJoint* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_axis = value;
}
*/
void btSoftBody_AJoint_setIcontrol(btSoftBody_AJoint* obj, btSoftBody_AJoint_IControl* value)
{
	obj->m_icontrol = value;
}

btSoftBody_CJoint* btSoftBody_CJoint_new()
{
	return new btSoftBody_CJoint();
}

btScalar btSoftBody_CJoint_getFriction(btSoftBody_CJoint* obj)
{
	return obj->m_friction;
}

int btSoftBody_CJoint_getLife(btSoftBody_CJoint* obj)
{
	return obj->m_life;
}

int btSoftBody_CJoint_getMaxlife(btSoftBody_CJoint* obj)
{
	return obj->m_maxlife;
}

void btSoftBody_CJoint_getNormal(btSoftBody_CJoint* obj)
{
	obj->m_normal;
}
/*
btScalar* btSoftBody_CJoint_getRpos(btSoftBody_CJoint* obj)
{
	return obj->m_rpos;
}
*/
void btSoftBody_CJoint_setFriction(btSoftBody_CJoint* obj, btScalar value)
{
	obj->m_friction = value;
}

void btSoftBody_CJoint_setLife(btSoftBody_CJoint* obj, int value)
{
	obj->m_life = value;
}

void btSoftBody_CJoint_setMaxlife(btSoftBody_CJoint* obj, int value)
{
	obj->m_maxlife = value;
}
/*
void btSoftBody_CJoint_setNormal(btSoftBody_CJoint* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_normal = value;
}

void btSoftBody_CJoint_setRpos(btSoftBody_CJoint* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_rpos = value;
}
*/
btSoftBody_Config* btSoftBody_Config_new()
{
	return new btSoftBody_Config();
}

void btSoftBody_Config_getAeromodel(btSoftBody_Config* obj)
{
	obj->aeromodel;
}

int btSoftBody_Config_getCiterations(btSoftBody_Config* obj)
{
	return obj->citerations;
}

int btSoftBody_Config_getCollisions(btSoftBody_Config* obj)
{
	return obj->collisions;
}

int btSoftBody_Config_getDiterations(btSoftBody_Config* obj)
{
	return obj->diterations;
}
/*
btAlignedObjectArray* btSoftBody_Config_getDsequence(btSoftBody_Config* obj)
{
	return obj->m_dsequence;
}
*/
btScalar btSoftBody_Config_getKAHR(btSoftBody_Config* obj)
{
	return obj->kAHR;
}

btScalar btSoftBody_Config_getKCHR(btSoftBody_Config* obj)
{
	return obj->kCHR;
}

btScalar btSoftBody_Config_getKDF(btSoftBody_Config* obj)
{
	return obj->kDF;
}

btScalar btSoftBody_Config_getKDG(btSoftBody_Config* obj)
{
	return obj->kDG;
}

btScalar btSoftBody_Config_getKDP(btSoftBody_Config* obj)
{
	return obj->kDP;
}

btScalar btSoftBody_Config_getKKHR(btSoftBody_Config* obj)
{
	return obj->kKHR;
}

btScalar btSoftBody_Config_getKLF(btSoftBody_Config* obj)
{
	return obj->kLF;
}

btScalar btSoftBody_Config_getKMT(btSoftBody_Config* obj)
{
	return obj->kMT;
}

btScalar btSoftBody_Config_getKPR(btSoftBody_Config* obj)
{
	return obj->kPR;
}

btScalar btSoftBody_Config_getKSHR(btSoftBody_Config* obj)
{
	return obj->kSHR;
}

btScalar btSoftBody_Config_getKSK_SPLT_CL(btSoftBody_Config* obj)
{
	return obj->kSK_SPLT_CL;
}

btScalar btSoftBody_Config_getKSKHR_CL(btSoftBody_Config* obj)
{
	return obj->kSKHR_CL;
}

btScalar btSoftBody_Config_getKSR_SPLT_CL(btSoftBody_Config* obj)
{
	return obj->kSR_SPLT_CL;
}

btScalar btSoftBody_Config_getKSRHR_CL(btSoftBody_Config* obj)
{
	return obj->kSRHR_CL;
}

btScalar btSoftBody_Config_getKSS_SPLT_CL(btSoftBody_Config* obj)
{
	return obj->kSS_SPLT_CL;
}

btScalar btSoftBody_Config_getKSSHR_CL(btSoftBody_Config* obj)
{
	return obj->kSSHR_CL;
}

btScalar btSoftBody_Config_getKVC(btSoftBody_Config* obj)
{
	return obj->kVC;
}

btScalar btSoftBody_Config_getKVCF(btSoftBody_Config* obj)
{
	return obj->kVCF;
}

btScalar btSoftBody_Config_getMaxvolume(btSoftBody_Config* obj)
{
	return obj->maxvolume;
}

int btSoftBody_Config_getPiterations(btSoftBody_Config* obj)
{
	return obj->piterations;
}
/*
btAlignedObjectArray* btSoftBody_Config_getPsequence(btSoftBody_Config* obj)
{
	return obj->m_psequence;
}
*/
btScalar btSoftBody_Config_getTimescale(btSoftBody_Config* obj)
{
	return obj->timescale;
}

int btSoftBody_Config_getViterations(btSoftBody_Config* obj)
{
	return obj->viterations;
}
/*
btAlignedObjectArray* btSoftBody_Config_getVsequence(btSoftBody_Config* obj)
{
	return obj->m_vsequence;
}

void btSoftBody_Config_setAeromodel(btSoftBody_Config* obj, void value)
{
	obj->aeromodel = value;
}
*/
void btSoftBody_Config_setCiterations(btSoftBody_Config* obj, int value)
{
	obj->citerations = value;
}

void btSoftBody_Config_setCollisions(btSoftBody_Config* obj, int value)
{
	obj->collisions = value;
}

void btSoftBody_Config_setDiterations(btSoftBody_Config* obj, int value)
{
	obj->diterations = value;
}
/*
void btSoftBody_Config_setDsequence(btSoftBody_Config* obj, btAlignedObjectArray* value)
{
	obj->m_dsequence = value;
}
*/
void btSoftBody_Config_setKAHR(btSoftBody_Config* obj, btScalar value)
{
	obj->kAHR = value;
}

void btSoftBody_Config_setKCHR(btSoftBody_Config* obj, btScalar value)
{
	obj->kCHR = value;
}

void btSoftBody_Config_setKDF(btSoftBody_Config* obj, btScalar value)
{
	obj->kDF = value;
}

void btSoftBody_Config_setKDG(btSoftBody_Config* obj, btScalar value)
{
	obj->kDG = value;
}

void btSoftBody_Config_setKDP(btSoftBody_Config* obj, btScalar value)
{
	obj->kDP = value;
}

void btSoftBody_Config_setKKHR(btSoftBody_Config* obj, btScalar value)
{
	obj->kKHR = value;
}

void btSoftBody_Config_setKLF(btSoftBody_Config* obj, btScalar value)
{
	obj->kLF = value;
}

void btSoftBody_Config_setKMT(btSoftBody_Config* obj, btScalar value)
{
	obj->kMT = value;
}

void btSoftBody_Config_setKPR(btSoftBody_Config* obj, btScalar value)
{
	obj->kPR = value;
}

void btSoftBody_Config_setKSHR(btSoftBody_Config* obj, btScalar value)
{
	obj->kSHR = value;
}

void btSoftBody_Config_setKSK_SPLT_CL(btSoftBody_Config* obj, btScalar value)
{
	obj->kSK_SPLT_CL = value;
}

void btSoftBody_Config_setKSKHR_CL(btSoftBody_Config* obj, btScalar value)
{
	obj->kSKHR_CL = value;
}

void btSoftBody_Config_setKSR_SPLT_CL(btSoftBody_Config* obj, btScalar value)
{
	obj->kSR_SPLT_CL = value;
}

void btSoftBody_Config_setKSRHR_CL(btSoftBody_Config* obj, btScalar value)
{
	obj->kSRHR_CL = value;
}

void btSoftBody_Config_setKSS_SPLT_CL(btSoftBody_Config* obj, btScalar value)
{
	obj->kSS_SPLT_CL = value;
}

void btSoftBody_Config_setKSSHR_CL(btSoftBody_Config* obj, btScalar value)
{
	obj->kSSHR_CL = value;
}

void btSoftBody_Config_setKVC(btSoftBody_Config* obj, btScalar value)
{
	obj->kVC = value;
}

void btSoftBody_Config_setKVCF(btSoftBody_Config* obj, btScalar value)
{
	obj->kVCF = value;
}

void btSoftBody_Config_setMaxvolume(btSoftBody_Config* obj, btScalar value)
{
	obj->maxvolume = value;
}

void btSoftBody_Config_setPiterations(btSoftBody_Config* obj, int value)
{
	obj->piterations = value;
}
/*
void btSoftBody_Config_setPsequence(btSoftBody_Config* obj, btAlignedObjectArray* value)
{
	obj->m_psequence = value;
}
*/
void btSoftBody_Config_setTimescale(btSoftBody_Config* obj, btScalar value)
{
	obj->timescale = value;
}

void btSoftBody_Config_setViterations(btSoftBody_Config* obj, int value)
{
	obj->viterations = value;
}
/*
void btSoftBody_Config_setVsequence(btSoftBody_Config* obj, btAlignedObjectArray* value)
{
	obj->m_vsequence = value;
}
*/
void btSoftBody_Config_delete(btSoftBody_Config* obj)
{
	delete obj;
}

btSoftBody_SolverState* btSoftBody_SolverState_new()
{
	return new btSoftBody_SolverState();
}

btScalar btSoftBody_SolverState_getIsdt(btSoftBody_SolverState* obj)
{
	return obj->isdt;
}

btScalar btSoftBody_SolverState_getRadmrg(btSoftBody_SolverState* obj)
{
	return obj->radmrg;
}

btScalar btSoftBody_SolverState_getSdt(btSoftBody_SolverState* obj)
{
	return obj->sdt;
}

btScalar btSoftBody_SolverState_getUpdmrg(btSoftBody_SolverState* obj)
{
	return obj->updmrg;
}

btScalar btSoftBody_SolverState_getVelmrg(btSoftBody_SolverState* obj)
{
	return obj->velmrg;
}

void btSoftBody_SolverState_setIsdt(btSoftBody_SolverState* obj, btScalar value)
{
	obj->isdt = value;
}

void btSoftBody_SolverState_setRadmrg(btSoftBody_SolverState* obj, btScalar value)
{
	obj->radmrg = value;
}

void btSoftBody_SolverState_setSdt(btSoftBody_SolverState* obj, btScalar value)
{
	obj->sdt = value;
}

void btSoftBody_SolverState_setUpdmrg(btSoftBody_SolverState* obj, btScalar value)
{
	obj->updmrg = value;
}

void btSoftBody_SolverState_setVelmrg(btSoftBody_SolverState* obj, btScalar value)
{
	obj->velmrg = value;
}

void btSoftBody_SolverState_delete(btSoftBody_SolverState* obj)
{
	delete obj;
}

btSoftBody_RayFromToCaster* btSoftBody_RayFromToCaster_new(btScalar* rayFrom, btScalar* rayTo, btScalar mxt)
{
	VECTOR3_CONV(rayFrom);
	VECTOR3_CONV(rayTo);
	return new btSoftBody_RayFromToCaster(VECTOR3_USE(rayFrom), VECTOR3_USE(rayTo), mxt);
}

btSoftBody_Face* btSoftBody_RayFromToCaster_getFace(btSoftBody_RayFromToCaster* obj)
{
	return obj->m_face;
}

btScalar btSoftBody_RayFromToCaster_getMint(btSoftBody_RayFromToCaster* obj)
{
	return obj->m_mint;
}

void btSoftBody_RayFromToCaster_getRayFrom(btSoftBody_RayFromToCaster* obj)
{
	obj->m_rayFrom;
}

void btSoftBody_RayFromToCaster_getRayNormalizedDirection(btSoftBody_RayFromToCaster* obj)
{
	obj->m_rayNormalizedDirection;
}

void btSoftBody_RayFromToCaster_getRayTo(btSoftBody_RayFromToCaster* obj)
{
	obj->m_rayTo;
}

int btSoftBody_RayFromToCaster_getTests(btSoftBody_RayFromToCaster* obj)
{
	return obj->m_tests;
}
/*
btScalar btSoftBody_RayFromToCaster_rayFromToTriangle(btScalar* rayFrom, btScalar* rayTo, btScalar* rayNormalizedDirection, btScalar* a, btScalar* b, btScalar* c, btScalar maxt)
{
	VECTOR3_CONV(rayFrom);
	VECTOR3_CONV(rayTo);
	VECTOR3_CONV(rayNormalizedDirection);
	VECTOR3_CONV(a);
	VECTOR3_CONV(b);
	VECTOR3_CONV(c);
	return btSoftBody_RayFromToCaster_rayFromToTriangle(VECTOR3_USE(rayFrom), VECTOR3_USE(rayTo), VECTOR3_USE(rayNormalizedDirection), VECTOR3_USE(a), VECTOR3_USE(b), VECTOR3_USE(c), maxt);
}

btScalar btSoftBody_RayFromToCaster_rayFromToTriangle2(btScalar* rayFrom, btScalar* rayTo, btScalar* rayNormalizedDirection, btScalar* a, btScalar* b, btScalar* c)
{
	VECTOR3_CONV(rayFrom);
	VECTOR3_CONV(rayTo);
	VECTOR3_CONV(rayNormalizedDirection);
	VECTOR3_CONV(a);
	VECTOR3_CONV(b);
	VECTOR3_CONV(c);
	return btSoftBody_RayFromToCaster_rayFromToTriangle(VECTOR3_USE(rayFrom), VECTOR3_USE(rayTo), VECTOR3_USE(rayNormalizedDirection), VECTOR3_USE(a), VECTOR3_USE(b), VECTOR3_USE(c));
}
*/
void btSoftBody_RayFromToCaster_setFace(btSoftBody_RayFromToCaster* obj, btSoftBody_Face* value)
{
	obj->m_face = value;
}

void btSoftBody_RayFromToCaster_setMint(btSoftBody_RayFromToCaster* obj, btScalar value)
{
	obj->m_mint = value;
}
/*
void btSoftBody_RayFromToCaster_setRayFrom(btSoftBody_RayFromToCaster* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_rayFrom = value;
}

void btSoftBody_RayFromToCaster_setRayNormalizedDirection(btSoftBody_RayFromToCaster* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_rayNormalizedDirection = value;
}

void btSoftBody_RayFromToCaster_setRayTo(btSoftBody_RayFromToCaster* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_rayTo = value;
}
*/
void btSoftBody_RayFromToCaster_setTests(btSoftBody_RayFromToCaster* obj, int value)
{
	obj->m_tests = value;
}
/*
btSoftBody* btSoftBody_new(btSoftBodyWorldInfo* worldInfo, int node_count, btScalar* x, btScalar* m)
{
	VECTOR3_CONV(x);
	return new btSoftBody(worldInfo, node_count, VECTOR3_USE(x), m);
}
*/
btSoftBody* btSoftBody_new2(btSoftBodyWorldInfo* worldInfo)
{
	return new btSoftBody(worldInfo);
}

void btSoftBody_addAeroForceToFace(btSoftBody* obj, btScalar* windVelocity, int faceIndex)
{
	VECTOR3_CONV(windVelocity);
	obj->addAeroForceToFace(VECTOR3_USE(windVelocity), faceIndex);
}

void btSoftBody_addAeroForceToNode(btSoftBody* obj, btScalar* windVelocity, int nodeIndex)
{
	VECTOR3_CONV(windVelocity);
	obj->addAeroForceToNode(VECTOR3_USE(windVelocity), nodeIndex);
}

void btSoftBody_addForce(btSoftBody* obj, btScalar* force)
{
	VECTOR3_CONV(force);
	obj->addForce(VECTOR3_USE(force));
}

void btSoftBody_addForce2(btSoftBody* obj, btScalar* force, int node)
{
	VECTOR3_CONV(force);
	obj->addForce(VECTOR3_USE(force), node);
}

void btSoftBody_addVelocity(btSoftBody* obj, btScalar* velocity, int node)
{
	VECTOR3_CONV(velocity);
	obj->addVelocity(VECTOR3_USE(velocity), node);
}

void btSoftBody_addVelocity2(btSoftBody* obj, btScalar* velocity)
{
	VECTOR3_CONV(velocity);
	obj->addVelocity(VECTOR3_USE(velocity));
}

void btSoftBody_appendAnchor(btSoftBody* obj, int node, btRigidBody* body, btScalar* localPivot, bool disableCollisionBetweenLinkedBodies, btScalar influence)
{
	VECTOR3_CONV(localPivot);
	obj->appendAnchor(node, body, VECTOR3_USE(localPivot), disableCollisionBetweenLinkedBodies, influence);
}

void btSoftBody_appendAnchor2(btSoftBody* obj, int node, btRigidBody* body, btScalar* localPivot, bool disableCollisionBetweenLinkedBodies)
{
	VECTOR3_CONV(localPivot);
	obj->appendAnchor(node, body, VECTOR3_USE(localPivot), disableCollisionBetweenLinkedBodies);
}

void btSoftBody_appendAnchor3(btSoftBody* obj, int node, btRigidBody* body, btScalar* localPivot)
{
	VECTOR3_CONV(localPivot);
	obj->appendAnchor(node, body, VECTOR3_USE(localPivot));
}

void btSoftBody_appendAnchor4(btSoftBody* obj, int node, btRigidBody* body, bool disableCollisionBetweenLinkedBodies, btScalar influence)
{
	obj->appendAnchor(node, body, disableCollisionBetweenLinkedBodies, influence);
}

void btSoftBody_appendAnchor5(btSoftBody* obj, int node, btRigidBody* body, bool disableCollisionBetweenLinkedBodies)
{
	obj->appendAnchor(node, body, disableCollisionBetweenLinkedBodies);
}

void btSoftBody_appendAnchor6(btSoftBody* obj, int node, btRigidBody* body)
{
	obj->appendAnchor(node, body);
}

void btSoftBody_appendAngularJoint(btSoftBody* obj, btSoftBody_AJoint_Specs* specs, btSoftBody::Body* body)
{
	obj->appendAngularJoint(*specs, *body);
}

void btSoftBody_appendAngularJoint2(btSoftBody* obj, btSoftBody_AJoint_Specs* specs)
{
	obj->appendAngularJoint(*specs);
}

void btSoftBody_appendAngularJoint3(btSoftBody* obj, btSoftBody_AJoint_Specs* specs, btSoftBody_Cluster* body0, btSoftBody::Body* body1)
{
	obj->appendAngularJoint(*specs, body0, *body1);
}

void btSoftBody_appendAngularJoint4(btSoftBody* obj, btSoftBody_AJoint_Specs* specs, btSoftBody* body)
{
	obj->appendAngularJoint(*specs, body);
}

void btSoftBody_appendFace(btSoftBody* obj, int model, btSoftBody_Material* mat)
{
	obj->appendFace(model, mat);
}

void btSoftBody_appendFace2(btSoftBody* obj, int model)
{
	obj->appendFace(model);
}

void btSoftBody_appendFace3(btSoftBody* obj)
{
	obj->appendFace();
}

void btSoftBody_appendFace4(btSoftBody* obj, int node0, int node1, int node2, btSoftBody_Material* mat)
{
	obj->appendFace(node0, node1, node2, mat);
}

void btSoftBody_appendFace5(btSoftBody* obj, int node0, int node1, int node2)
{
	obj->appendFace(node0, node1, node2);
}

void btSoftBody_appendLinearJoint(btSoftBody* obj, btSoftBody_LJoint_Specs* specs, btSoftBody* body)
{
	obj->appendLinearJoint(*specs, body);
}

void btSoftBody_appendLinearJoint2(btSoftBody* obj, btSoftBody_LJoint_Specs* specs, btSoftBody::Body* body)
{
	obj->appendLinearJoint(*specs, *body);
}

void btSoftBody_appendLinearJoint3(btSoftBody* obj, btSoftBody_LJoint_Specs* specs)
{
	obj->appendLinearJoint(*specs);
}

void btSoftBody_appendLinearJoint4(btSoftBody* obj, btSoftBody_LJoint_Specs* specs, btSoftBody_Cluster* body0, btSoftBody::Body* body1)
{
	obj->appendLinearJoint(*specs, body0, *body1);
}

void btSoftBody_appendLink(btSoftBody* obj, int node0, int node1, btSoftBody_Material* mat, bool bcheckexist)
{
	obj->appendLink(node0, node1, mat, bcheckexist);
}

void btSoftBody_appendLink2(btSoftBody* obj, int node0, int node1, btSoftBody_Material* mat)
{
	obj->appendLink(node0, node1, mat);
}

void btSoftBody_appendLink3(btSoftBody* obj, int node0, int node1)
{
	obj->appendLink(node0, node1);
}

void btSoftBody_appendLink4(btSoftBody* obj, int model, btSoftBody_Material* mat)
{
	obj->appendLink(model, mat);
}

void btSoftBody_appendLink5(btSoftBody* obj, int model)
{
	obj->appendLink(model);
}

void btSoftBody_appendLink6(btSoftBody* obj)
{
	obj->appendLink();
}

void btSoftBody_appendLink7(btSoftBody* obj, btSoftBody_Node* node0, btSoftBody_Node* node1, btSoftBody_Material* mat, bool bcheckexist)
{
	obj->appendLink(node0, node1, mat, bcheckexist);
}

void btSoftBody_appendLink8(btSoftBody* obj, btSoftBody_Node* node0, btSoftBody_Node* node1, btSoftBody_Material* mat)
{
	obj->appendLink(node0, node1, mat);
}

void btSoftBody_appendLink9(btSoftBody* obj, btSoftBody_Node* node0, btSoftBody_Node* node1)
{
	obj->appendLink(node0, node1);
}

btSoftBody_Material* btSoftBody_appendMaterial(btSoftBody* obj)
{
	return obj->appendMaterial();
}

void btSoftBody_appendNode(btSoftBody* obj, btScalar* x, btScalar m)
{
	VECTOR3_CONV(x);
	obj->appendNode(VECTOR3_USE(x), m);
}

void btSoftBody_appendNote(btSoftBody* obj, char* text, btScalar* o, btSoftBody_Face* feature)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), feature);
}

void btSoftBody_appendNote2(btSoftBody* obj, char* text, btScalar* o, btSoftBody_Link* feature)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), feature);
}

void btSoftBody_appendNote3(btSoftBody* obj, char* text, btScalar* o, btSoftBody_Node* feature)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), feature);
}

void btSoftBody_appendNote4(btSoftBody* obj, char* text, btScalar* o, btVector4* c, btSoftBody_Node* n0, btSoftBody_Node* n1, btSoftBody_Node* n2, btSoftBody_Node* n3)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), *c, n0, n1, n2, n3);
}

void btSoftBody_appendNote5(btSoftBody* obj, char* text, btScalar* o, btVector4* c, btSoftBody_Node* n0, btSoftBody_Node* n1, btSoftBody_Node* n2)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), *c, n0, n1, n2);
}

void btSoftBody_appendNote6(btSoftBody* obj, char* text, btScalar* o, btVector4* c, btSoftBody_Node* n0, btSoftBody_Node* n1)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), *c, n0, n1);
}

void btSoftBody_appendNote7(btSoftBody* obj, char* text, btScalar* o, btVector4* c, btSoftBody_Node* n0)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), *c, n0);
}

void btSoftBody_appendNote8(btSoftBody* obj, char* text, btScalar* o, btVector4* c)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o), *c);
}

void btSoftBody_appendNote9(btSoftBody* obj, char* text, btScalar* o)
{
	VECTOR3_CONV(o);
	obj->appendNote(text, VECTOR3_USE(o));
}

void btSoftBody_appendTetra(btSoftBody* obj, int model, btSoftBody_Material* mat)
{
	obj->appendTetra(model, mat);
}

void btSoftBody_appendTetra2(btSoftBody* obj, int node0, int node1, int node2, int node3, btSoftBody_Material* mat)
{
	obj->appendTetra(node0, node1, node2, node3, mat);
}

void btSoftBody_appendTetra3(btSoftBody* obj, int node0, int node1, int node2, int node3)
{
	obj->appendTetra(node0, node1, node2, node3);
}

void btSoftBody_applyClusters(btSoftBody* obj, bool drift)
{
	obj->applyClusters(drift);
}

void btSoftBody_applyForces(btSoftBody* obj)
{
	obj->applyForces();
}

bool btSoftBody_checkContact(btSoftBody* obj, btCollisionObjectWrapper* colObjWrap, btScalar* x, btScalar margin, btSoftBody_sCti* cti)
{
	VECTOR3_CONV(x);
	return obj->checkContact(colObjWrap, VECTOR3_USE(x), margin, *cti);
}

bool btSoftBody_checkFace(btSoftBody* obj, int node0, int node1, int node2)
{
	return obj->checkFace(node0, node1, node2);
}

bool btSoftBody_checkLink(btSoftBody* obj, btSoftBody_Node* node0, btSoftBody_Node* node1)
{
	return obj->checkLink(node0, node1);
}

bool btSoftBody_checkLink2(btSoftBody* obj, int node0, int node1)
{
	return obj->checkLink(node0, node1);
}

void btSoftBody_cleanupClusters(btSoftBody* obj)
{
	obj->cleanupClusters();
}

void btSoftBody_clusterAImpulse(btSoftBody_Cluster* cluster, btSoftBody_Impulse* impulse)
{
	btSoftBody::clusterAImpulse(cluster, *impulse);
}

void btSoftBody_clusterCom(btSoftBody_Cluster* cluster)
{
	btSoftBody::clusterCom(cluster);
}

void btSoftBody_clusterCom2(btSoftBody* obj, int cluster)
{
	obj->clusterCom(cluster);
}

int btSoftBody_clusterCount(btSoftBody* obj)
{
	return obj->clusterCount();
}

void btSoftBody_clusterDAImpulse(btSoftBody_Cluster* cluster, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	btSoftBody::clusterDAImpulse(cluster, VECTOR3_USE(impulse));
}

void btSoftBody_clusterDCImpulse(btSoftBody_Cluster* cluster, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	btSoftBody::clusterDCImpulse(cluster, VECTOR3_USE(impulse));
}

void btSoftBody_clusterDImpulse(btSoftBody_Cluster* cluster, btScalar* rpos, btScalar* impulse)
{
	VECTOR3_CONV(rpos);
	VECTOR3_CONV(impulse);
	btSoftBody::clusterDImpulse(cluster, VECTOR3_USE(rpos), VECTOR3_USE(impulse));
}

void btSoftBody_clusterImpulse(btSoftBody_Cluster* cluster, btScalar* rpos, btSoftBody_Impulse* impulse)
{
	VECTOR3_CONV(rpos);
	btSoftBody::clusterImpulse(cluster, VECTOR3_USE(rpos), *impulse);
}

void btSoftBody_clusterVAImpulse(btSoftBody_Cluster* cluster, btScalar* impulse)
{
	VECTOR3_CONV(impulse);
	btSoftBody::clusterVAImpulse(cluster, VECTOR3_USE(impulse));
}

void btSoftBody_clusterVelocity(btSoftBody_Cluster* cluster, btScalar* rpos)
{
	VECTOR3_CONV(rpos);
	btSoftBody::clusterVelocity(cluster, VECTOR3_USE(rpos));
}

void btSoftBody_clusterVImpulse(btSoftBody_Cluster* cluster, btScalar* rpos, btScalar* impulse)
{
	VECTOR3_CONV(rpos);
	VECTOR3_CONV(impulse);
	btSoftBody::clusterVImpulse(cluster, VECTOR3_USE(rpos), VECTOR3_USE(impulse));
}

bool btSoftBody_cutLink(btSoftBody* obj, int node0, int node1, btScalar position)
{
	return obj->cutLink(node0, node1, position);
}

bool btSoftBody_cutLink2(btSoftBody* obj, btSoftBody_Node* node0, btSoftBody_Node* node1, btScalar position)
{
	return obj->cutLink(node0, node1, position);
}

void btSoftBody_dampClusters(btSoftBody* obj)
{
	obj->dampClusters();
}

void btSoftBody_defaultCollisionHandler(btSoftBody* obj, btCollisionObjectWrapper* pcoWrap)
{
	obj->defaultCollisionHandler(pcoWrap);
}

void btSoftBody_defaultCollisionHandler2(btSoftBody* obj, btSoftBody* psb)
{
	obj->defaultCollisionHandler(psb);
}

void btSoftBody_evaluateCom(btSoftBody* obj)
{
	obj->evaluateCom();
}

int btSoftBody_generateBendingConstraints(btSoftBody* obj, int distance, btSoftBody_Material* mat)
{
	return obj->generateBendingConstraints(distance, mat);
}

int btSoftBody_generateBendingConstraints2(btSoftBody* obj, int distance)
{
	return obj->generateBendingConstraints(distance);
}

int btSoftBody_generateClusters(btSoftBody* obj, int k, int maxiterations)
{
	return obj->generateClusters(k, maxiterations);
}

int btSoftBody_generateClusters2(btSoftBody* obj, int k)
{
	return obj->generateClusters(k);
}

void btSoftBody_getAabb(btSoftBody* obj, btScalar* aabbMin, btScalar* aabbMax)
{
	VECTOR3_CONV(aabbMin);
	VECTOR3_CONV(aabbMax);
	obj->getAabb(VECTOR3_USE(aabbMin), VECTOR3_USE(aabbMax));
}
/*
btAlignedObjectArray* btSoftBody_getAnchors(btSoftBody* obj)
{
	return obj->m_anchors;
}

btScalar* btSoftBody_getBounds(btSoftBody* obj)
{
	return obj->m_bounds;
}
*/
bool btSoftBody_getBUpdateRtCst(btSoftBody* obj)
{
	return obj->m_bUpdateRtCst;
}

void btSoftBody_getCdbvt(btSoftBody* obj)
{
	obj->m_cdbvt;
}

void btSoftBody_getCfg(btSoftBody* obj)
{
	obj->m_cfg;
}

void btSoftBody_getClusterConnectivity(btSoftBody* obj)
{
	obj->m_clusterConnectivity;
}
/*
btAlignedObjectArray* btSoftBody_getClusters(btSoftBody* obj)
{
	return obj->m_clusters;
}
*/
void btSoftBody_getCollisionDisabledObjects(btSoftBody* obj)
{
	obj->m_collisionDisabledObjects;
}
/*
btAlignedObjectArray* btSoftBody_getFaces(btSoftBody* obj)
{
	return obj->m_faces;
}
*/
void btSoftBody_getFdbvt(btSoftBody* obj)
{
	obj->m_fdbvt;
}

void btSoftBody_getInitialWorldTransform(btSoftBody* obj)
{
	obj->m_initialWorldTransform;
}
/*
btAlignedObjectArray* btSoftBody_getJoints(btSoftBody* obj)
{
	return obj->m_joints;
}

btAlignedObjectArray* btSoftBody_getLinks(btSoftBody* obj)
{
	return obj->m_links;
}

btScalar btSoftBody_getMass(btSoftBody* obj, int node)
{
	return obj->getMass(node);
}

btAlignedObjectArray* btSoftBody_getMaterials(btSoftBody* obj)
{
	return obj->m_materials;
}

void btSoftBody_getNdbvt(btSoftBody* obj)
{
	obj->m_ndbvt;
}

btAlignedObjectArray* btSoftBody_getNodes(btSoftBody* obj)
{
	return obj->m_nodes;
}

btAlignedObjectArray* btSoftBody_getNotes(btSoftBody* obj)
{
	return obj->m_notes;
}

void btSoftBody_getPose(btSoftBody* obj)
{
	obj->m_pose;
}

btAlignedObjectArray* btSoftBody_getRcontacts(btSoftBody* obj)
{
	return obj->m_rcontacts;
}
*/
btScalar btSoftBody_getRestLengthScale(btSoftBody* obj)
{
	return obj->getRestLengthScale();
}

btScalar btSoftBody_getRestLengthScale2(btSoftBody* obj)
{
	return obj->m_restLengthScale;
}
/*
btAlignedObjectArray* btSoftBody_getScontacts(btSoftBody* obj)
{
	return obj->m_scontacts;
}
*/
btSoftBodySolver* btSoftBody_getSoftBodySolver(btSoftBody* obj)
{
	return obj->m_softBodySolver;
}

btSoftBodySolver* btSoftBody_getSoftBodySolver2(btSoftBody* obj)
{
	return obj->getSoftBodySolver();
}
/*
* btSoftBody_getSolver(void solver)
{
	return btSoftBody::getSolver(solver);
}

* btSoftBody_getSolver2(void solver)
{
	return btSoftBody::getSolver(solver);
}

void btSoftBody_getSst(btSoftBody* obj)
{
	obj->m_sst;
}
*/
void* btSoftBody_getTag(btSoftBody* obj)
{
	return obj->m_tag;
}
/*
btAlignedObjectArray* btSoftBody_getTetras(btSoftBody* obj)
{
	return obj->m_tetras;
}
*/
btScalar btSoftBody_getTimeacc(btSoftBody* obj)
{
	return obj->m_timeacc;
}

btScalar btSoftBody_getTotalMass(btSoftBody* obj)
{
	return obj->getTotalMass();
}

void btSoftBody_getUserIndexMapping(btSoftBody* obj)
{
	obj->m_userIndexMapping;
}

void btSoftBody_getWindVelocity(btSoftBody* obj)
{
	obj->m_windVelocity;
}
/*
btScalar* btSoftBody_getWindVelocity2(btSoftBody* obj)
{
	return &obj->getWindVelocity();
}
*/
btScalar btSoftBody_getVolume(btSoftBody* obj)
{
	return obj->getVolume();
}

btSoftBodyWorldInfo* btSoftBody_getWorldInfo(btSoftBody* obj)
{
	return obj->getWorldInfo();
}

btSoftBodyWorldInfo* btSoftBody_getWorldInfo2(btSoftBody* obj)
{
	return obj->m_worldInfo;
}

void btSoftBody_indicesToPointers(btSoftBody* obj, int* map)
{
	obj->indicesToPointers(map);
}

void btSoftBody_indicesToPointers2(btSoftBody* obj)
{
	obj->indicesToPointers();
}

void btSoftBody_initDefaults(btSoftBody* obj)
{
	obj->initDefaults();
}

void btSoftBody_initializeClusters(btSoftBody* obj)
{
	obj->initializeClusters();
}

void btSoftBody_initializeFaceTree(btSoftBody* obj)
{
	obj->initializeFaceTree();
}

void btSoftBody_integrateMotion(btSoftBody* obj)
{
	obj->integrateMotion();
}

void btSoftBody_pointersToIndices(btSoftBody* obj)
{
	obj->pointersToIndices();
}

void btSoftBody_predictMotion(btSoftBody* obj, btScalar dt)
{
	obj->predictMotion(dt);
}

void btSoftBody_prepareClusters(btSoftBody* obj, int iterations)
{
	obj->prepareClusters(iterations);
}

void btSoftBody_PSolve_Anchors(btSoftBody* psb, btScalar kst, btScalar ti)
{
	btSoftBody::PSolve_Anchors(psb, kst, ti);
}

void btSoftBody_PSolve_Links(btSoftBody* psb, btScalar kst, btScalar ti)
{
	btSoftBody::PSolve_Links(psb, kst, ti);
}

void btSoftBody_PSolve_RContacts(btSoftBody* psb, btScalar kst, btScalar ti)
{
	btSoftBody::PSolve_RContacts(psb, kst, ti);
}

void btSoftBody_PSolve_SContacts(btSoftBody* psb, btScalar __unnamed1, btScalar ti)
{
	btSoftBody::PSolve_SContacts(psb, __unnamed1, ti);
}

void btSoftBody_randomizeConstraints(btSoftBody* obj)
{
	obj->randomizeConstraints();
}
/*
int btSoftBody_rayTest(btSoftBody* obj, btScalar* rayFrom, btScalar* rayTo, btScalar* mint, _* feature, int* index, bool bcountonly)
{
	VECTOR3_CONV(rayFrom);
	VECTOR3_CONV(rayTo);
	return obj->rayTest(VECTOR3_USE(rayFrom), VECTOR3_USE(rayTo), *mint, *feature, *index, bcountonly);
}
*/
bool btSoftBody_rayTest2(btSoftBody* obj, btScalar* rayFrom, btScalar* rayTo, btSoftBody_sRayCast* results)
{
	VECTOR3_CONV(rayFrom);
	VECTOR3_CONV(rayTo);
	return obj->rayTest(VECTOR3_USE(rayFrom), VECTOR3_USE(rayTo), *results);
}

void btSoftBody_refine(btSoftBody* obj, btSoftBody_ImplicitFn* ifn, btScalar accurary, bool cut)
{
	obj->refine(ifn, accurary, cut);
}

void btSoftBody_releaseCluster(btSoftBody* obj, int index)
{
	obj->releaseCluster(index);
}

void btSoftBody_releaseClusters(btSoftBody* obj)
{
	obj->releaseClusters();
}

void btSoftBody_resetLinkRestLengths(btSoftBody* obj)
{
	obj->resetLinkRestLengths();
}

void btSoftBody_rotate(btSoftBody* obj, btQuaternion* rot)
{
	obj->rotate(*rot);
}

void btSoftBody_scale(btSoftBody* obj, btScalar* scl)
{
	VECTOR3_CONV(scl);
	obj->scale(VECTOR3_USE(scl));
}
/*
void btSoftBody_setAnchors(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_anchors = value;
}

void btSoftBody_setBounds(btSoftBody* obj, btScalar* value)
{
	VECTOR3_CONV(value);
	obj->m_bounds = value;
}
*/
void btSoftBody_setBUpdateRtCst(btSoftBody* obj, bool value)
{
	obj->m_bUpdateRtCst = value;
}
/*
void btSoftBody_setCdbvt(btSoftBody* obj, void value)
{
	obj->m_cdbvt = value;
}

void btSoftBody_setCfg(btSoftBody* obj, void value)
{
	obj->m_cfg = value;
}

void btSoftBody_setClusterConnectivity(btSoftBody* obj, void value)
{
	obj->m_clusterConnectivity = value;
}

void btSoftBody_setClusters(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_clusters = value;
}

void btSoftBody_setCollisionDisabledObjects(btSoftBody* obj, void value)
{
	obj->m_collisionDisabledObjects = value;
}

void btSoftBody_setFaces(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_faces = value;
}

void btSoftBody_setFdbvt(btSoftBody* obj, void value)
{
	obj->m_fdbvt = value;
}

void btSoftBody_setInitialWorldTransform(btSoftBody* obj, void value)
{
	TRANSFORM_CONV(value);
	obj->m_initialWorldTransform = value;
}

void btSoftBody_setJoints(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_joints = value;
}

void btSoftBody_setLinks(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_links = value;
}
*/
void btSoftBody_setMass(btSoftBody* obj, int node, btScalar mass)
{
	obj->setMass(node, mass);
}
/*
void btSoftBody_setMaterials(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_materials = value;
}

void btSoftBody_setNdbvt(btSoftBody* obj, void value)
{
	obj->m_ndbvt = value;
}

void btSoftBody_setNodes(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_nodes = value;
}

void btSoftBody_setNotes(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_notes = value;
}

void btSoftBody_setPose(btSoftBody* obj, void value)
{
	obj->m_pose = value;
}
*/
void btSoftBody_setPose2(btSoftBody* obj, bool bvolume, bool bframe)
{
	obj->setPose(bvolume, bframe);
}
/*
void btSoftBody_setRcontacts(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_rcontacts = value;
}
*/
void btSoftBody_setRestLengthScale(btSoftBody* obj, btScalar restLength)
{
	obj->setRestLengthScale(restLength);
}

void btSoftBody_setRestLengthScale2(btSoftBody* obj, btScalar value)
{
	obj->m_restLengthScale = value;
}
/*
void btSoftBody_setScontacts(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_scontacts = value;
}
*/
void btSoftBody_setSoftBodySolver(btSoftBody* obj, btSoftBodySolver* softBodySolver)
{
	obj->setSoftBodySolver(softBodySolver);
}

void btSoftBody_setSoftBodySolver2(btSoftBody* obj, btSoftBodySolver* value)
{
	obj->m_softBodySolver = value;
}
/*
void btSoftBody_setSolver(btSoftBody* obj, void preset)
{
	obj->setSolver(preset);
}

void btSoftBody_setSst(btSoftBody* obj, void value)
{
	obj->m_sst = value;
}
*/
void btSoftBody_setTag(btSoftBody* obj, void* value)
{
	obj->m_tag = value;
}
/*
void btSoftBody_setTetras(btSoftBody* obj, btAlignedObjectArray* value)
{
	obj->m_tetras = value;
}
*/
void btSoftBody_setTimeacc(btSoftBody* obj, btScalar value)
{
	obj->m_timeacc = value;
}

void btSoftBody_setTotalDensity(btSoftBody* obj, btScalar density)
{
	obj->setTotalDensity(density);
}

void btSoftBody_setTotalMass(btSoftBody* obj, btScalar mass, bool fromfaces)
{
	obj->setTotalMass(mass, fromfaces);
}

void btSoftBody_setTotalMass2(btSoftBody* obj, btScalar mass)
{
	obj->setTotalMass(mass);
}
/*
void btSoftBody_setUserIndexMapping(btSoftBody* obj, void value)
{
	obj->m_userIndexMapping = value;
}
*/
void btSoftBody_setVelocity(btSoftBody* obj, btScalar* velocity)
{
	VECTOR3_CONV(velocity);
	obj->setVelocity(VECTOR3_USE(velocity));
}

void btSoftBody_setWindVelocity(btSoftBody* obj, btScalar* velocity)
{
	VECTOR3_CONV(velocity);
	obj->setWindVelocity(VECTOR3_USE(velocity));
}
/*
void btSoftBody_setWindVelocity2(btSoftBody* obj, void value)
{
	VECTOR3_CONV(value);
	obj->m_windVelocity = value;
}
*/
void btSoftBody_setVolumeDensity(btSoftBody* obj, btScalar density)
{
	obj->setVolumeDensity(density);
}

void btSoftBody_setVolumeMass(btSoftBody* obj, btScalar mass)
{
	obj->setVolumeMass(mass);
}

void btSoftBody_setWorldInfo(btSoftBody* obj, btSoftBodyWorldInfo* value)
{
	obj->m_worldInfo = value;
}
/*
void btSoftBody_solveClusters(btAlignedObjectArray* bodies)
{
	btSoftBody_solveClusters(*bodies);
}
*/
void btSoftBody_solveClusters2(btSoftBody* obj, btScalar sor)
{
	obj->solveClusters(sor);
}
/*
void btSoftBody_solveCommonConstraints(* bodies, int count, int iterations)
{
	btSoftBody_solveCommonConstraints(bodies, count, iterations);
}
*/
void btSoftBody_solveConstraints(btSoftBody* obj)
{
	obj->solveConstraints();
}

void btSoftBody_staticSolve(btSoftBody* obj, int iterations)
{
	obj->staticSolve(iterations);
}

void btSoftBody_transform(btSoftBody* obj, btScalar* trs)
{
	TRANSFORM_CONV(trs);
	obj->transform(TRANSFORM_USE(trs));
}

void btSoftBody_translate(btSoftBody* obj, btScalar* trs)
{
	VECTOR3_CONV(trs);
	obj->translate(VECTOR3_USE(trs));
}

btSoftBody* btSoftBody_upcast(btCollisionObject* colObj)
{
	return btSoftBody::upcast(colObj);
}

void btSoftBody_updateArea(btSoftBody* obj, bool averageArea)
{
	obj->updateArea(averageArea);
}

void btSoftBody_updateArea2(btSoftBody* obj)
{
	obj->updateArea();
}

void btSoftBody_updateBounds(btSoftBody* obj)
{
	obj->updateBounds();
}

void btSoftBody_updateClusters(btSoftBody* obj)
{
	obj->updateClusters();
}

void btSoftBody_updateConstants(btSoftBody* obj)
{
	obj->updateConstants();
}

void btSoftBody_updateLinkConstants(btSoftBody* obj)
{
	obj->updateLinkConstants();
}

void btSoftBody_updateNormals(btSoftBody* obj)
{
	obj->updateNormals();
}

void btSoftBody_updatePose(btSoftBody* obj)
{
	obj->updatePose();
}

void btSoftBody_VSolve_Links(btSoftBody* psb, btScalar kst)
{
	btSoftBody::VSolve_Links(psb, kst);
}
