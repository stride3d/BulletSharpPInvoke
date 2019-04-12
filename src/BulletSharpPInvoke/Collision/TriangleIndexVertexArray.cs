using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;
using System.Collections.Generic;

namespace BulletSharp
{
	public class IndexedMesh : IDisposable
	{
		internal IntPtr _native;

		internal IndexedMesh(IntPtr native)
		{
			_native = native;
		}

		public IndexedMesh()
		{
			_native = btIndexedMesh_new();
		}

        public unsafe UnmanagedMemoryStream GetTriangleStream()
        {
            int length = btIndexedMesh_getNumTriangles(_native) * btIndexedMesh_getTriangleIndexStride(_native);
            return new UnmanagedMemoryStream((byte*)btIndexedMesh_getTriangleIndexBase(_native).ToPointer(), length, length);
        }

        public unsafe UnmanagedMemoryStream GetVertexStream()
        {
            int length = btIndexedMesh_getNumVertices(_native) * btIndexedMesh_getVertexStride(_native);
            return new UnmanagedMemoryStream((byte*)btIndexedMesh_getVertexBase(_native).ToPointer(), length, length);
        }

        public PhyScalarType IndexType
		{
			get { return btIndexedMesh_getIndexType(_native); }
			set { btIndexedMesh_setIndexType(_native, value); }
		}

		public int NumTriangles
		{
			get { return btIndexedMesh_getNumTriangles(_native); }
			set { btIndexedMesh_setNumTriangles(_native, value); }
		}

		public int NumVertices
		{
			get { return btIndexedMesh_getNumVertices(_native); }
			set { btIndexedMesh_setNumVertices(_native, value); }
		}

		public IntPtr TriangleIndexBase
		{
			get { return btIndexedMesh_getTriangleIndexBase(_native); }
			set { btIndexedMesh_setTriangleIndexBase(_native, value); }
		}

		public int TriangleIndexStride
		{
			get { return btIndexedMesh_getTriangleIndexStride(_native); }
			set { btIndexedMesh_setTriangleIndexStride(_native, value); }
		}

        public IntPtr VertexBase
		{
			get { return btIndexedMesh_getVertexBase(_native); }
			set { btIndexedMesh_setVertexBase(_native, value); }
		}

		public int VertexStride
		{
			get { return btIndexedMesh_getVertexStride(_native); }
			set { btIndexedMesh_setVertexStride(_native, value); }
		}

        public PhyScalarType VertexType
		{
			get { return btIndexedMesh_getVertexType(_native); }
			set { btIndexedMesh_setVertexType(_native, value); }
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
				btIndexedMesh_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~IndexedMesh()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btIndexedMesh_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern PhyScalarType btIndexedMesh_getIndexType(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btIndexedMesh_getNumTriangles(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btIndexedMesh_getNumVertices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btIndexedMesh_getTriangleIndexBase(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btIndexedMesh_getTriangleIndexStride(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btIndexedMesh_getVertexBase(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btIndexedMesh_getVertexStride(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern PhyScalarType btIndexedMesh_getVertexType(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btIndexedMesh_setIndexType(IntPtr obj, PhyScalarType value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_setNumTriangles(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_setNumVertices(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_setTriangleIndexBase(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_setTriangleIndexStride(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_setVertexBase(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_setVertexStride(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btIndexedMesh_setVertexType(IntPtr obj, PhyScalarType value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btIndexedMesh_delete(IntPtr obj);
	}

	public class TriangleIndexVertexArray : StridingMeshInterface
	{
        List<IndexedMesh> _meshes = new List<IndexedMesh>();
        IndexedMesh _initialMesh;

		internal TriangleIndexVertexArray(IntPtr native)
			: base(native)
		{
		}

		public TriangleIndexVertexArray()
			: base(btTriangleIndexVertexArray_new2())
		{
		}

        public TriangleIndexVertexArray(int[] triangles, float[] vertices)
            : base(btTriangleIndexVertexArray_new2())
        {
            _initialMesh = new IndexedMesh
            {
                NumTriangles = triangles.Length / 3,
                TriangleIndexBase = Marshal.AllocHGlobal(triangles.Length * sizeof(int)),
                TriangleIndexStride = 3 * sizeof(int),
                NumVertices = vertices.Length / 3,
                VertexBase = Marshal.AllocHGlobal(vertices.Length * sizeof(float)),
                VertexStride = sizeof(float) * 3
            };
            Marshal.Copy(triangles, 0, _initialMesh.TriangleIndexBase, triangles.Length);
            Marshal.Copy(vertices, 0, _initialMesh.VertexBase, vertices.Length);
            AddIndexedMesh(_initialMesh);
        }

        public TriangleIndexVertexArray(ICollection<int> triangles, ICollection<float> vertices)
            : base(btTriangleIndexVertexArray_new2())
        {
            _initialMesh = new IndexedMesh
            {
                NumTriangles = triangles.Count / 3,
                TriangleIndexBase = Marshal.AllocHGlobal(triangles.Count * sizeof(int)),
                TriangleIndexStride = 3 * sizeof(int),
                NumVertices = vertices.Count / 3,
                VertexBase = Marshal.AllocHGlobal(vertices.Count * sizeof(float)),
                VertexStride = sizeof(float) * 3
            };
            int[] triangleArray = new int[triangles.Count];
            triangles.CopyTo(triangleArray, 0);
            Marshal.Copy(triangleArray, 0, _initialMesh.TriangleIndexBase, triangles.Count);
            float[] vertexArray = new float[vertices.Count];
            vertices.CopyTo(vertexArray, 0);
            Marshal.Copy(vertexArray, 0, _initialMesh.VertexBase, vertices.Count);
            AddIndexedMesh(_initialMesh);
        }

        public TriangleIndexVertexArray(ICollection<int> triangles, ICollection<Vector3> vertices)
            : base(btTriangleIndexVertexArray_new2())
        {
            _initialMesh = new IndexedMesh
            {
                NumTriangles = triangles.Count / 3,
                TriangleIndexBase = Marshal.AllocHGlobal(triangles.Count * sizeof(int)),
                TriangleIndexStride = 3 * sizeof(int),
                NumVertices = vertices.Count,
                VertexBase = Marshal.AllocHGlobal(vertices.Count * Vector3.SizeInBytes),
                VertexStride = Vector3.SizeInBytes
            };
            int[] triangleArray = new int[triangles.Count];
            triangles.CopyTo(triangleArray, 0);
            Marshal.Copy(triangleArray, 0, _initialMesh.TriangleIndexBase, triangles.Count);
            float[] vertexArray = new float[vertices.Count];
            int i = 0;
            foreach (Vector3 v in vertices)
            {
                vertexArray[i] = v.X;
                vertexArray[i + 1] = v.Y;
                vertexArray[i + 2] = v.Z;
                i += 3;
            }
            Marshal.Copy(vertexArray, 0, _initialMesh.VertexBase, vertices.Count);
            AddIndexedMesh(_initialMesh);
        }

        public TriangleIndexVertexArray(int numTriangles, IntPtr triangleIndexBase, int triangleIndexStride, int numVertices, IntPtr vertexBase, int vertexStride)
			: base(btTriangleIndexVertexArray_new(numTriangles, triangleIndexBase, triangleIndexStride, numVertices, vertexBase, vertexStride))
		{
		}

        public void AddIndexedMesh(IndexedMesh mesh, PhyScalarType indexType)
		{
            _meshes.Add(mesh);
			btTriangleIndexVertexArray_addIndexedMesh(_native, mesh._native, indexType);
		}

		public void AddIndexedMesh(IndexedMesh mesh)
		{
            _meshes.Add(mesh);
			btTriangleIndexVertexArray_addIndexedMesh2(_native, mesh._native);
		}
        /*
		public IndexedMeshArray IndexedMeshArray
		{
			get { return btTriangleIndexVertexArray_getIndexedMeshArray(_native); }
		}
        */

        protected override void Dispose(bool disposing)
        {
            if (_initialMesh != null && _initialMesh._native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_initialMesh.TriangleIndexBase);
                Marshal.FreeHGlobal(_initialMesh.VertexBase);
                _initialMesh = null;
            }
            base.Dispose(disposing);
        }

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleIndexVertexArray_new(int numTriangles, IntPtr triangleIndexBase, int triangleIndexStride, int numVertices, IntPtr vertexBase, int vertexStride);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleIndexVertexArray_new2();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btTriangleIndexVertexArray_addIndexedMesh(IntPtr obj, IntPtr mesh, PhyScalarType indexType);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleIndexVertexArray_addIndexedMesh2(IntPtr obj, IntPtr mesh);
	}
}
