using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class ConvexShape : CollisionShape
	{
		internal ConvexShape(IntPtr native)
			: base(native)
		{
		}
        /*
		public void BatchedUnitVectorGetSupportingVertexWithoutMargin(Vector3 vectors, Vector3 supportVerticesOut, int numVectors)
		{
			btConvexShape_batchedUnitVectorGetSupportingVertexWithoutMargin(_native, vectors._native, supportVerticesOut._native, numVectors);
		}
        */
        public void GetAabbNonVirtual(Matrix t, out Vector3 aabbMin, out Vector3 aabbMax)
		{
			btConvexShape_getAabbNonVirtual(_native, ref t, out aabbMin, out aabbMax);
		}

        public void GetAabbSlow(Matrix t, out Vector3 aabbMin, out Vector3 aabbMax)
		{
			btConvexShape_getAabbSlow(_native, ref t, out aabbMin, out aabbMax);
		}

		public void GetPreferredPenetrationDirection(int index, out Vector3 penetrationVector)
		{
			btConvexShape_getPreferredPenetrationDirection(_native, index, out penetrationVector);
		}

		public void LocalGetSupportingVertex(out Vector3 vec)
		{
			btConvexShape_localGetSupportingVertex(_native, out vec);
		}

		public void LocalGetSupportingVertexWithoutMargin(out Vector3 vec)
		{
			btConvexShape_localGetSupportingVertexWithoutMargin(_native, out vec);
		}

		public void LocalGetSupportVertexNonVirtual(out Vector3 vec)
		{
			btConvexShape_localGetSupportVertexNonVirtual(_native, out vec);
		}

		public void LocalGetSupportVertexWithoutMarginNonVirtual(out Vector3 vec)
		{
			btConvexShape_localGetSupportVertexWithoutMarginNonVirtual(_native, out vec);
		}
        /*
		public void Project(Matrix trans, Vector3 dir, float min, float max)
		{
			btConvexShape_project(_native, trans._native, dir._native, min._native, max._native);
		}
        */
		public float MarginNonVirtual
		{
			get { return btConvexShape_getMarginNonVirtual(_native); }
		}

		public int NumPreferredPenetrationDirections
		{
			get { return btConvexShape_getNumPreferredPenetrationDirections(_native); }
		}

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btConvexShape_getAabbNonVirtual(IntPtr obj, [In] ref Matrix t, [Out] out Vector3 aabbMin, [Out] out Vector3 aabbMax);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btConvexShape_getAabbSlow(IntPtr obj, [In] ref Matrix t, [Out] out Vector3 aabbMin, [Out] out Vector3 aabbMax);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btConvexShape_getMarginNonVirtual(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btConvexShape_getNumPreferredPenetrationDirections(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexShape_getPreferredPenetrationDirection(IntPtr obj, int index, [Out] out Vector3 penetrationVector);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btConvexShape_localGetSupportingVertex(IntPtr obj, [Out] out Vector3 vec);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btConvexShape_localGetSupportingVertexWithoutMargin(IntPtr obj, [Out] out Vector3 vec);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btConvexShape_localGetSupportVertexNonVirtual(IntPtr obj, [Out] out Vector3 vec);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btConvexShape_localGetSupportVertexWithoutMarginNonVirtual(IntPtr obj, [Out] out Vector3 vec);
	}
}
