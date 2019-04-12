using System;
using System.Runtime.InteropServices;
using System.Security;

namespace VHACDSharp
{
    public class ConvexHullMesh : IDisposable
    {
        private IntPtr _internalCompound;

        public struct DecompositionDesc
        {
            public uint VertexCount;
            public uint IndicesCount;
            public float[] Vertexes;
            public uint[] Indices;

            public bool SimpleHull;

            public int Depth;
            public int PosSampling;
            public int AngleSampling;
            public int PosRefine;
            public int AngleRefine;
            public float Alpha;
            public float Threshold;
        }

        private static int _sTokens = 0;
        private readonly int _token;

        public ConvexHullMesh()
        {
            _token = _sTokens++;
        }

        public void Generate(DecompositionDesc desc)
        {
            _internalCompound = GenerateCompoundShape(desc.VertexCount, desc.IndicesCount, desc.Vertexes, desc.Indices, desc.SimpleHull,
                desc.Depth, desc.PosSampling, desc.AngleSampling, desc.PosRefine, desc.AngleRefine, desc.Alpha, desc.Threshold, _token);
        }

        public void Cancel()
        {
            CancelGenerate(_token);   
        }

        public uint Count
        {
            get { return GetNumHulls(_internalCompound); }
        }

        public void CopyPoints(uint index, out float[] points)
        {
            points = new float[GetHullNumPoints(_internalCompound, index)];
            CopyHullPoints(_internalCompound, index, points);
        }

        public void CopyIndices(uint index, out uint[] indices)
        {
            indices = new uint[GetHullNumIndices(_internalCompound, index)];
            CopyHullIndices(_internalCompound, index, indices);
        }

        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr GenerateCompoundShape(uint vertexCount, uint indicesCount, [In] float[] vertexes, [In] uint[] indices, bool simpleHull,
            int depth, int posSampling, int angleSampling, int posRefine, int angleRefine, float alpha, float threshold, int token);
        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void DeleteHulls(IntPtr hulls);

        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void CancelGenerate(int token);

        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint GetNumHulls(IntPtr hulls);

        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint GetHullNumPoints(IntPtr hulls, uint index);
        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void CopyHullPoints(IntPtr hulls, uint index, [Out] float[] outPoints);

        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint GetHullNumIndices(IntPtr hulls, uint index);
        [DllImport("VHACD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void CopyHullIndices(IntPtr hulls, uint index, [Out] uint[] outPoints);

        public void Dispose()
        {
            if (_internalCompound != IntPtr.Zero)
            {
                DeleteHulls(_internalCompound);
            }
        }
    }
}
