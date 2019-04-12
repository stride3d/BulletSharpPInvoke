#include "main.h"

extern "C"
{
	EXPORT BT_BOX_BOX_TRANSFORM_CACHE* BT_BOX_BOX_TRANSFORM_CACHE_new();
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_calc_absolute_matrix(BT_BOX_BOX_TRANSFORM_CACHE* obj);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_calc_from_full_invert(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* trans0, btScalar* trans1);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_calc_from_homogenic(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* trans0, btScalar* trans1);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_getAR(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_getR1to0(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_getT1to0(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_setAR(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_setR1to0(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_setT1to0(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_transform(BT_BOX_BOX_TRANSFORM_CACHE* obj, btScalar* point, btScalar* value);
	EXPORT void BT_BOX_BOX_TRANSFORM_CACHE_delete(BT_BOX_BOX_TRANSFORM_CACHE* obj);

	EXPORT btAABB* btAABB_new();
	EXPORT btAABB* btAABB_new2(btScalar* V1, btScalar* V2, btScalar* V3);
	EXPORT btAABB* btAABB_new3(btScalar* V1, btScalar* V2, btScalar* V3, btScalar margin);
	EXPORT btAABB* btAABB_new4(btAABB* other);
	EXPORT btAABB* btAABB_new5(btAABB* other, btScalar margin);
	EXPORT void btAABB_appy_transform(btAABB* obj, btScalar* trans);
	EXPORT void btAABB_appy_transform_trans_cache(btAABB* obj, BT_BOX_BOX_TRANSFORM_CACHE* trans);
	EXPORT bool btAABB_collide_plane(btAABB* obj, btVector4* plane);
	EXPORT bool btAABB_collide_ray(btAABB* obj, btScalar* vorigin, btScalar* vdir);
	EXPORT bool btAABB_collide_triangle_exact(btAABB* obj, btScalar* p1, btScalar* p2, btScalar* p3, btVector4* triangle_plane);
	EXPORT void btAABB_copy_with_margin(btAABB* obj, btAABB* other, btScalar margin);
	EXPORT void btAABB_find_intersection(btAABB* obj, btAABB* other, btAABB* intersection);
	EXPORT void btAABB_get_center_extend(btAABB* obj, btScalar* center, btScalar* extend);
	EXPORT void btAABB_getMax(btAABB* obj, btScalar* value);
	EXPORT void btAABB_getMin(btAABB* obj, btScalar* value);
	EXPORT bool btAABB_has_collision(btAABB* obj, btAABB* other);
	EXPORT void btAABB_increment_margin(btAABB* obj, btScalar margin);
	EXPORT void btAABB_invalidate(btAABB* obj);
	EXPORT void btAABB_merge(btAABB* obj, btAABB* box);
	EXPORT bool btAABB_overlapping_trans_cache(btAABB* obj, btAABB* box, BT_BOX_BOX_TRANSFORM_CACHE* transcache, bool fulltest);
	EXPORT bool btAABB_overlapping_trans_conservative(btAABB* obj, btAABB* box, btScalar* trans1_to_0);
	EXPORT bool btAABB_overlapping_trans_conservative2(btAABB* obj, btAABB* box, BT_BOX_BOX_TRANSFORM_CACHE* trans1_to_0);
	EXPORT eBT_PLANE_INTERSECTION_TYPE btAABB_plane_classify(btAABB* obj, btVector4* plane);
	EXPORT void btAABB_projection_interval(btAABB* obj, btScalar* direction, btScalar* vmin, btScalar* vmax);
	EXPORT void btAABB_setMax(btAABB* obj, btScalar* value);
	EXPORT void btAABB_setMin(btAABB* obj, btScalar* value);
	EXPORT void btAABB_delete(btAABB* obj);
}
