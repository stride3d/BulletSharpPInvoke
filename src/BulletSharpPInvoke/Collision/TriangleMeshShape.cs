using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class TriangleMeshShape : ConcaveShape
	{
        protected StridingMeshInterface _meshInterface;

		internal TriangleMeshShape(IntPtr native)
			: base(native)
		{
		}

		public void LocalGetSupportingVertex(Vector3 vec)
		{
			btTriangleMeshShape_localGetSupportingVertex(_native, ref vec);
		}

		public void LocalGetSupportingVertexWithoutMargin(Vector3 vec)
		{
			btTriangleMeshShape_localGetSupportingVertexWithoutMargin(_native, ref vec);
		}

		public void RecalcLocalAabb()
		{
			btTriangleMeshShape_recalcLocalAabb(_native);
		}

		public Vector3 LocalAabbMax
		{
			get
			{
				Vector3 value;
				btTriangleMeshShape_getLocalAabbMax(_native, out value);
				return value;
			}
		}

		public Vector3 LocalAabbMin
		{
			get
			{
				Vector3 value;
				btTriangleMeshShape_getLocalAabbMin(_native, out value);
				return value;
			}
		}

		public StridingMeshInterface MeshInterface
		{
            get
            {
                if (_meshInterface == null)
                {
                    _meshInterface = new StridingMeshInterface(btTriangleMeshShape_getMeshInterface(_native));
                }
                return _meshInterface;
            }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btTriangleMeshShape_getLocalAabbMax(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMeshShape_getLocalAabbMin(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleMeshShape_getMeshInterface(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMeshShape_localGetSupportingVertex(IntPtr obj, [In] ref Vector3 vec);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMeshShape_localGetSupportingVertexWithoutMargin(IntPtr obj, [In] ref Vector3 vec);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMeshShape_recalcLocalAabb(IntPtr obj);
	}
}
