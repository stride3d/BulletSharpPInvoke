using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class TriangleMesh : TriangleIndexVertexArray
	{
		internal TriangleMesh(IntPtr native)
			: base(native)
		{
		}

		public TriangleMesh(bool use32bitIndices, bool use4componentVertices)
			: base(btTriangleMesh_new(use32bitIndices, use4componentVertices))
		{
		}

		public TriangleMesh(bool use32bitIndices)
			: base(btTriangleMesh_new2(use32bitIndices))
		{
		}

		public TriangleMesh()
			: base(btTriangleMesh_new3())
		{
		}

		public void AddIndex(int index)
		{
			btTriangleMesh_addIndex(_native, index);
		}

		public void AddTriangle(Vector3 vertex0, Vector3 vertex1, Vector3 vertex2, bool removeDuplicateVertices)
		{
			btTriangleMesh_addTriangle(_native, ref vertex0, ref vertex1, ref vertex2, removeDuplicateVertices);
		}

		public void AddTriangle(Vector3 vertex0, Vector3 vertex1, Vector3 vertex2)
		{
			btTriangleMesh_addTriangle2(_native, ref vertex0, ref vertex1, ref vertex2);
		}

		public int FindOrAddVertex(Vector3 vertex, bool removeDuplicateVertices)
		{
			return btTriangleMesh_findOrAddVertex(_native, ref vertex, removeDuplicateVertices);
		}

		public int NumTriangles
		{
			get { return btTriangleMesh_getNumTriangles(_native); }
		}

		public bool Use32bitIndices
		{
			get { return btTriangleMesh_getUse32bitIndices(_native); }
		}

		public bool Use4componentVertices
		{
			get { return btTriangleMesh_getUse4componentVertices(_native); }
		}

		public float WeldingThreshold
		{
			get { return btTriangleMesh_getWeldingThreshold(_native); }
			set { btTriangleMesh_setWeldingThreshold(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleMesh_new(bool use32bitIndices, bool use4componentVertices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleMesh_new2(bool use32bitIndices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleMesh_new3();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_addIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_addTriangle(IntPtr obj, [In] ref Vector3 vertex0, [In] ref Vector3 vertex1, [In] ref Vector3 vertex2, bool removeDuplicateVertices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_addTriangle2(IntPtr obj, [In] ref Vector3 vertex0, [In] ref Vector3 vertex1, [In] ref Vector3 vertex2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btTriangleMesh_findOrAddVertex(IntPtr obj, [In] ref Vector3 vertex, bool removeDuplicateVertices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btTriangleMesh_getNumTriangles(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btTriangleMesh_getUse32bitIndices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btTriangleMesh_getUse4componentVertices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btTriangleMesh_getWeldingThreshold(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_setWeldingThreshold(IntPtr obj, float value);
	}
}
