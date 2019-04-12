using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class GIM_PAIR
	{
		internal IntPtr _native;

		internal GIM_PAIR(IntPtr native)
		{
			_native = native;
		}

		public GIM_PAIR()
		{
			_native = GIM_PAIR_new();
		}

		public GIM_PAIR(GIM_PAIR p)
		{
			_native = GIM_PAIR_new2(p._native);
		}

		public GIM_PAIR(int index1, int index2)
		{
			_native = GIM_PAIR_new3(index1, index2);
		}

		public int Index1
		{
			get { return GIM_PAIR_getIndex1(_native); }
			set { GIM_PAIR_setIndex1(_native, value); }
		}

		public int Index2
		{
			get { return GIM_PAIR_getIndex2(_native); }
			set { GIM_PAIR_setIndex2(_native, value); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				GIM_PAIR_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~GIM_PAIR()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_PAIR_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_PAIR_new2(IntPtr p);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_PAIR_new3(int index1, int index2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int GIM_PAIR_getIndex1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int GIM_PAIR_getIndex2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_PAIR_setIndex1(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_PAIR_setIndex2(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_PAIR_delete(IntPtr obj);
	}

	public class PairSet : AlignedObjectArray
	{
		internal PairSet(IntPtr native)
			: base(native)
		{
		}

		public PairSet()
			: base(btPairSet_new())
		{
		}

		public void Push_pair(int index1, int index2)
		{
			btPairSet_push_pair(_native, index1, index2);
		}

		public void Push_pair_inv(int index1, int index2)
		{
			btPairSet_push_pair_inv(_native, index1, index2);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPairSet_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPairSet_push_pair(IntPtr obj, int index1, int index2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPairSet_push_pair_inv(IntPtr obj, int index1, int index2);
	}

	public class GIM_BVH_DATA
	{
		internal IntPtr _native;

		internal GIM_BVH_DATA(IntPtr native)
		{
			_native = native;
		}

		public GIM_BVH_DATA()
		{
			_native = GIM_BVH_DATA_new();
		}
        /*
		public void Bound
		{
			get { return GIM_BVH_DATA_getBound(_native); }
			set { GIM_BVH_DATA_setBound(_native, value._native); }
		}
        */
		public int Data
		{
			get { return GIM_BVH_DATA_getData(_native); }
			set { GIM_BVH_DATA_setData(_native, value); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				GIM_BVH_DATA_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~GIM_BVH_DATA()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_BVH_DATA_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_DATA_getBound(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int GIM_BVH_DATA_getData(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_DATA_setBound(IntPtr obj, Aabb value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_DATA_setData(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_DATA_delete(IntPtr obj);
	}

	public class GIM_BVH_TREE_NODE
	{
		internal IntPtr _native;

		internal GIM_BVH_TREE_NODE(IntPtr native)
		{
			_native = native;
		}

		public GIM_BVH_TREE_NODE()
		{
			_native = GIM_BVH_TREE_NODE_new();
		}
        /*
		public void Bound
		{
			get { return GIM_BVH_TREE_NODE_getBound(_native); }
			set { GIM_BVH_TREE_NODE_setBound(_native, value._native); }
		}
        */
		public int DataIndex
		{
			get { return GIM_BVH_TREE_NODE_getDataIndex(_native); }
			set { GIM_BVH_TREE_NODE_setDataIndex(_native, value); }
		}

		public int EscapeIndex
		{
			get { return GIM_BVH_TREE_NODE_getEscapeIndex(_native); }
			set { GIM_BVH_TREE_NODE_setEscapeIndex(_native, value); }
		}

		public bool IsLeafNode
		{
			get { return GIM_BVH_TREE_NODE_isLeafNode(_native); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				GIM_BVH_TREE_NODE_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~GIM_BVH_TREE_NODE()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_BVH_TREE_NODE_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_TREE_NODE_getBound(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int GIM_BVH_TREE_NODE_getDataIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int GIM_BVH_TREE_NODE_getEscapeIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool GIM_BVH_TREE_NODE_isLeafNode(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_TREE_NODE_setBound(IntPtr obj, Aabb value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_TREE_NODE_setDataIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_TREE_NODE_setEscapeIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void GIM_BVH_TREE_NODE_delete(IntPtr obj);
	}

	public class GIM_BVH_DATA_ARRAY : AlignedObjectArray
	{
		internal GIM_BVH_DATA_ARRAY(IntPtr native)
			: base(native)
		{
		}

		public GIM_BVH_DATA_ARRAY()
			: base(GIM_BVH_DATA_ARRAY_new())
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_BVH_DATA_ARRAY_new();
	}

	public class GIM_BVH_TREE_NODE_ARRAY : AlignedObjectArray
	{
		internal GIM_BVH_TREE_NODE_ARRAY(IntPtr native)
			: base(native)
		{
		}

		public GIM_BVH_TREE_NODE_ARRAY()
			: base(GIM_BVH_TREE_NODE_ARRAY_new())
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr GIM_BVH_TREE_NODE_ARRAY_new();
	}

	public class BvhTree
	{
		internal IntPtr _native;

		internal BvhTree(IntPtr native)
		{
			_native = native;
		}

		public BvhTree()
		{
			_native = btBvhTree_new();
		}

		public void Build_tree(GIM_BVH_DATA_ARRAY primitive_boxes)
		{
			btBvhTree_build_tree(_native, primitive_boxes._native);
		}

		public void ClearNodes()
		{
			btBvhTree_clearNodes(_native);
		}

		public GIM_BVH_TREE_NODE Get_node_pointer(int index)
		{
            return new GIM_BVH_TREE_NODE(btBvhTree_get_node_pointer(_native, index));
		}

		public GIM_BVH_TREE_NODE Get_node_pointer()
		{
			return new GIM_BVH_TREE_NODE(btBvhTree_get_node_pointer2(_native));
		}

		public int GetEscapeNodeIndex(int nodeindex)
		{
			return btBvhTree_getEscapeNodeIndex(_native, nodeindex);
		}

		public int GetLeftNode(int nodeindex)
		{
			return btBvhTree_getLeftNode(_native, nodeindex);
		}

		public void GetNodeBound(int nodeindex, Aabb bound)
		{
			btBvhTree_getNodeBound(_native, nodeindex, bound._native);
		}

		public int GetNodeData(int nodeindex)
		{
			return btBvhTree_getNodeData(_native, nodeindex);
		}

		public int GetRightNode(int nodeindex)
		{
			return btBvhTree_getRightNode(_native, nodeindex);
		}

		public bool IsLeafNode(int nodeindex)
		{
			return btBvhTree_isLeafNode(_native, nodeindex);
		}

		public void SetNodeBound(int nodeindex, Aabb bound)
		{
			btBvhTree_setNodeBound(_native, nodeindex, bound._native);
		}

		public int NodeCount
		{
			get { return btBvhTree_getNodeCount(_native); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btBvhTree_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~BvhTree()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBvhTree_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBvhTree_build_tree(IntPtr obj, IntPtr primitive_boxes);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBvhTree_clearNodes(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBvhTree_get_node_pointer(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBvhTree_get_node_pointer2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBvhTree_getEscapeNodeIndex(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBvhTree_getLeftNode(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBvhTree_getNodeBound(IntPtr obj, int nodeindex, IntPtr bound);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBvhTree_getNodeCount(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBvhTree_getNodeData(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBvhTree_getRightNode(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btBvhTree_isLeafNode(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBvhTree_setNodeBound(IntPtr obj, int nodeindex, IntPtr bound);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBvhTree_delete(IntPtr obj);
	}

	public class PrimitiveManagerBase
	{
		internal IntPtr _native;

		internal PrimitiveManagerBase(IntPtr native)
		{
			_native = native;
		}

		public void GetPrimitiveBox(int prim_index, Aabb primbox)
		{
			btPrimitiveManagerBase_get_primitive_box(_native, prim_index, primbox._native);
		}
        /*
		public void Get_primitive_triangle(int prim_index, PrimitiveTriangle triangle)
		{
			btPrimitiveManagerBase_get_primitive_triangle(_native, prim_index, triangle._native);
		}
        */
		public int PrimitiveCount
		{
			get { return btPrimitiveManagerBase_get_primitive_count(_native); }
		}

		public bool IsTrimesh
		{
			get { return btPrimitiveManagerBase_is_trimesh(_native); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btPrimitiveManagerBase_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PrimitiveManagerBase()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPrimitiveManagerBase_get_primitive_box(IntPtr obj, int prim_index, IntPtr primbox);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btPrimitiveManagerBase_get_primitive_count(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPrimitiveManagerBase_get_primitive_triangle(IntPtr obj, int prim_index, IntPtr triangle);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btPrimitiveManagerBase_is_trimesh(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPrimitiveManagerBase_delete(IntPtr obj);
	}

	public class GImpactBvh
	{
		internal IntPtr _native;

		internal GImpactBvh(IntPtr native)
		{
			_native = native;
		}

		public GImpactBvh()
		{
			_native = btGImpactBvh_new();
		}

		public GImpactBvh(PrimitiveManagerBase primitive_manager)
		{
			_native = btGImpactBvh_new2(primitive_manager._native);
		}

		public bool BoxQuery(Aabb box, AlignedObjectArray collided_results)
		{
			return btGImpactBvh_boxQuery(_native, box._native, collided_results._native);
		}

		public bool BoxQueryTrans(Aabb box, Matrix transform, AlignedObjectArray collided_results)
		{
			return btGImpactBvh_boxQueryTrans(_native, box._native, ref transform, collided_results._native);
		}

		public void BuildSet()
		{
			btGImpactBvh_buildSet(_native);
		}

		public void Find_collision(GImpactBvh boxset1, Matrix trans1, GImpactBvh boxset2, Matrix trans2, PairSet collision_pairs)
		{
			btGImpactBvh_find_collision(boxset1._native, ref trans1, boxset2._native, ref trans2, collision_pairs._native);
		}

		public GIM_BVH_TREE_NODE Get_node_pointer(int index)
		{
			return new GIM_BVH_TREE_NODE(btGImpactBvh_get_node_pointer(_native, index));
		}

		public GIM_BVH_TREE_NODE Get_node_pointer()
		{
			return new GIM_BVH_TREE_NODE(btGImpactBvh_get_node_pointer2(_native));
		}

		public int GetEscapeNodeIndex(int nodeindex)
		{
			return btGImpactBvh_getEscapeNodeIndex(_native, nodeindex);
		}

		public int GetLeftNode(int nodeindex)
		{
			return btGImpactBvh_getLeftNode(_native, nodeindex);
		}

		public void GetNodeBound(int nodeindex, Aabb bound)
		{
			btGImpactBvh_getNodeBound(_native, nodeindex, bound._native);
		}

		public int GetNodeData(int nodeindex)
		{
			return btGImpactBvh_getNodeData(_native, nodeindex);
		}
        /*
		public void GetNodeTriangle(int nodeindex, PrimitiveTriangle triangle)
		{
			btGImpactBvh_getNodeTriangle(_native, nodeindex, triangle._native);
		}
        */
		public int GetRightNode(int nodeindex)
		{
			return btGImpactBvh_getRightNode(_native, nodeindex);
		}

		public bool IsLeafNode(int nodeindex)
		{
			return btGImpactBvh_isLeafNode(_native, nodeindex);
		}

		public bool RayQuery(Vector3 ray_dir, Vector3 ray_origin, AlignedObjectArray collided_results)
		{
			return btGImpactBvh_rayQuery(_native, ref ray_dir, ref ray_origin, collided_results._native);
		}

		public void SetNodeBound(int nodeindex, Aabb bound)
		{
			btGImpactBvh_setNodeBound(_native, nodeindex, bound._native);
		}

		public void Update()
		{
			btGImpactBvh_update(_native);
		}
        /*
		public void GlobalBox
		{
			get { return btGImpactBvh_getGlobalBox(_native); }
		}
        */
		public bool HasHierarchy
		{
			get { return btGImpactBvh_hasHierarchy(_native); }
		}

		public bool IsTrimesh
		{
			get { return btGImpactBvh_isTrimesh(_native); }
		}

		public int NodeCount
		{
			get { return btGImpactBvh_getNodeCount(_native); }
		}

		public PrimitiveManagerBase PrimitiveManager
		{
			get { return new PrimitiveManagerBase(btGImpactBvh_getPrimitiveManager(_native)); }
			set { btGImpactBvh_setPrimitiveManager(_native, value._native); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btGImpactBvh_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~GImpactBvh()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btGImpactBvh_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btGImpactBvh_new2(IntPtr primitive_manager);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btGImpactBvh_boxQuery(IntPtr obj, IntPtr box, IntPtr collided_results);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btGImpactBvh_boxQueryTrans(IntPtr obj, IntPtr box, [In] ref Matrix transform, IntPtr collided_results);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_buildSet(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_find_collision(IntPtr boxset1, [In] ref Matrix trans1, IntPtr boxset2, [In] ref Matrix trans2, IntPtr collision_pairs);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btGImpactBvh_get_node_pointer(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btGImpactBvh_get_node_pointer2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btGImpactBvh_getEscapeNodeIndex(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_getGlobalBox(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btGImpactBvh_getLeftNode(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_getNodeBound(IntPtr obj, int nodeindex, IntPtr bound);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btGImpactBvh_getNodeCount(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btGImpactBvh_getNodeData(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_getNodeTriangle(IntPtr obj, int nodeindex, IntPtr triangle);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btGImpactBvh_getPrimitiveManager(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btGImpactBvh_getRightNode(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btGImpactBvh_hasHierarchy(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btGImpactBvh_isLeafNode(IntPtr obj, int nodeindex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btGImpactBvh_isTrimesh(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btGImpactBvh_rayQuery(IntPtr obj, [In] ref Vector3 ray_dir, [In] ref Vector3 ray_origin, IntPtr collided_results);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_setNodeBound(IntPtr obj, int nodeindex, IntPtr bound);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_setPrimitiveManager(IntPtr obj, IntPtr primitive_manager);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_update(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btGImpactBvh_delete(IntPtr obj);
	}
}
