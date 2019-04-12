using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class UsageBitfield
	{
		internal IntPtr _native;

		internal UsageBitfield(IntPtr native)
		{
			_native = native;
		}

		public UsageBitfield()
		{
			_native = btUsageBitfield_new();
		}

		public void Reset()
		{
			btUsageBitfield_reset(_native);
		}

		public ushort Unused1
		{
			get { return btUsageBitfield_getUnused1(_native); }
			set { btUsageBitfield_setUnused1(_native, value); }
		}

		public ushort Unused2
		{
			get { return btUsageBitfield_getUnused2(_native); }
			set { btUsageBitfield_setUnused2(_native, value); }
		}

		public ushort Unused3
		{
			get { return btUsageBitfield_getUnused3(_native); }
			set { btUsageBitfield_setUnused3(_native, value); }
		}

		public ushort Unused4
		{
			get { return btUsageBitfield_getUnused4(_native); }
			set { btUsageBitfield_setUnused4(_native, value); }
		}

		public ushort UsedVertexA
		{
			get { return btUsageBitfield_getUsedVertexA(_native); }
			set { btUsageBitfield_setUsedVertexA(_native, value); }
		}

		public ushort UsedVertexB
		{
			get { return btUsageBitfield_getUsedVertexB(_native); }
			set { btUsageBitfield_setUsedVertexB(_native, value); }
		}

		public ushort UsedVertexC
		{
			get { return btUsageBitfield_getUsedVertexC(_native); }
			set { btUsageBitfield_setUsedVertexC(_native, value); }
		}

		public ushort UsedVertexD
		{
			get { return btUsageBitfield_getUsedVertexD(_native); }
			set { btUsageBitfield_setUsedVertexD(_native, value); }
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
				btUsageBitfield_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~UsageBitfield()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btUsageBitfield_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUnused1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUnused2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUnused3(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUnused4(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUsedVertexA(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUsedVertexB(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUsedVertexC(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort btUsageBitfield_getUsedVertexD(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_reset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUnused1(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUnused2(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUnused3(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUnused4(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUsedVertexA(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUsedVertexB(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUsedVertexC(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_setUsedVertexD(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btUsageBitfield_delete(IntPtr obj);
	}

	public class SubSimplexClosestResult
	{
		internal IntPtr _native;

		internal SubSimplexClosestResult(IntPtr native)
		{
			_native = native;
		}

		public SubSimplexClosestResult()
		{
			_native = btSubSimplexClosestResult_new();
		}

		public void Reset()
		{
			btSubSimplexClosestResult_reset(_native);
		}

		public void SetBarycentricCoordinates(float a, float b, float c, float d)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates(_native, a, b, c, d);
		}

		public void SetBarycentricCoordinates(float a, float b, float c)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates2(_native, a, b, c);
		}

		public void SetBarycentricCoordinates(float a, float b)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates3(_native, a, b);
		}

		public void SetBarycentricCoordinates(float a)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates4(_native, a);
		}

		public void SetBarycentricCoordinates()
		{
			btSubSimplexClosestResult_setBarycentricCoordinates5(_native);
		}
        /*
		public float BarycentricCoords
		{
			get { return btSubSimplexClosestResult_getBarycentricCoords(_native); }
			set { btSubSimplexClosestResult_setBarycentricCoords(_native, value._native); }
		}
        */
		public Vector3 ClosestPointOnSimplex
		{
            get
            {
                Vector3 value;
                btSubSimplexClosestResult_getClosestPointOnSimplex(_native, out value);
                return value;

            }
			set { btSubSimplexClosestResult_setClosestPointOnSimplex(_native, ref value); }
		}

		public bool Degenerate
		{
			get { return btSubSimplexClosestResult_getDegenerate(_native); }
			set { btSubSimplexClosestResult_setDegenerate(_native, value); }
		}

		public bool IsValid
		{
			get { return btSubSimplexClosestResult_isValid(_native); }
		}
        /*
		public void UsedVertices
		{
			get { return btSubSimplexClosestResult_getUsedVertices(_native); }
			set { btSubSimplexClosestResult_setUsedVertices(_native, value._native); }
		}
        */
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btSubSimplexClosestResult_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SubSimplexClosestResult()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSubSimplexClosestResult_new();

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_getClosestPointOnSimplex(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSubSimplexClosestResult_getDegenerate(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSubSimplexClosestResult_isValid(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_reset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setBarycentricCoordinates(IntPtr obj, float a, float b, float c, float d);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setBarycentricCoordinates2(IntPtr obj, float a, float b, float c);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setBarycentricCoordinates3(IntPtr obj, float a, float b);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setBarycentricCoordinates4(IntPtr obj, float a);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setBarycentricCoordinates5(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setClosestPointOnSimplex(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_setDegenerate(IntPtr obj, bool value);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSubSimplexClosestResult_delete(IntPtr obj);
	}

	public class VoronoiSimplexSolver
	{
		internal IntPtr _native;

		internal VoronoiSimplexSolver(IntPtr native)
		{
			_native = native;
		}

		public VoronoiSimplexSolver()
		{
			_native = btVoronoiSimplexSolver_new();
		}

		public void AddVertex(Vector3 w, Vector3 p, Vector3 q)
		{
			btVoronoiSimplexSolver_addVertex(_native, ref w, ref p, ref q);
		}

		public void Backup_closest(out Vector3 v)
		{
			btVoronoiSimplexSolver_backup_closest(_native, out v);
		}

		public bool Closest(out Vector3 v)
		{
            return btVoronoiSimplexSolver_closest(_native, out v);
		}

		public bool ClosestPtPointTetrahedron(Vector3 p, Vector3 a, Vector3 b, Vector3 c, Vector3 d, SubSimplexClosestResult finalResult)
		{
			return btVoronoiSimplexSolver_closestPtPointTetrahedron(_native, ref p, ref a, ref b, ref c, ref d, finalResult._native);
		}

		public bool ClosestPtPointTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c, SubSimplexClosestResult result)
		{
			return btVoronoiSimplexSolver_closestPtPointTriangle(_native, ref p, ref a, ref b, ref c, result._native);
		}

		public void Compute_points(out Vector3 p1, out Vector3 p2)
		{
			btVoronoiSimplexSolver_compute_points(_native, out p1, out p2);
		}

		public bool EmptySimplex()
		{
			return btVoronoiSimplexSolver_emptySimplex(_native);
		}

		public bool FullSimplex()
		{
			return btVoronoiSimplexSolver_fullSimplex(_native);
		}
        /*
		public int GetSimplex(Vector3 pBuf, Vector3 qBuf, Vector3 yBuf)
		{
			return btVoronoiSimplexSolver_getSimplex(_native, ref pBuf, ref qBuf, ref yBuf);
		}
        */
		public bool InSimplex(Vector3 w)
		{
			return btVoronoiSimplexSolver_inSimplex(_native, ref w);
		}

		public float MaxVertex()
		{
			return btVoronoiSimplexSolver_maxVertex(_native);
		}

		public int PointOutsideOfPlane(Vector3 p, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			return btVoronoiSimplexSolver_pointOutsideOfPlane(_native, ref p, ref a, ref b, ref c, ref d);
		}

		public void ReduceVertices(UsageBitfield usedVerts)
		{
			btVoronoiSimplexSolver_reduceVertices(_native, usedVerts._native);
		}

		public void RemoveVertex(int index)
		{
			btVoronoiSimplexSolver_removeVertex(_native, index);
		}

		public void Reset()
		{
			btVoronoiSimplexSolver_reset(_native);
		}

		public bool UpdateClosestVectorAndPoints()
		{
			return btVoronoiSimplexSolver_updateClosestVectorAndPoints(_native);
		}

        public SubSimplexClosestResult CachedBC
		{
            get { return new SubSimplexClosestResult(btVoronoiSimplexSolver_getCachedBC(_native)); }
			set { btVoronoiSimplexSolver_setCachedBC(_native, value._native); }
		}

        public Vector3 CachedP1
		{
            get
            {
                Vector3 value;
                btVoronoiSimplexSolver_getCachedP1(_native, out value);
                return value;
            }
			set { btVoronoiSimplexSolver_setCachedP1(_native, ref value); }
		}

        public Vector3 CachedP2
		{
            get
            {
                Vector3 value;
                btVoronoiSimplexSolver_getCachedP2(_native, out value);
                return value;
            }
			set { btVoronoiSimplexSolver_setCachedP2(_native, ref value); }
		}

        public Vector3 CachedV
		{
            get
            {
                Vector3 value;
                btVoronoiSimplexSolver_getCachedV(_native, out value);
                return value;
            }
			set { btVoronoiSimplexSolver_setCachedV(_native, ref value); }
		}

		public bool CachedValidClosest
		{
			get { return btVoronoiSimplexSolver_getCachedValidClosest(_native); }
			set { btVoronoiSimplexSolver_setCachedValidClosest(_native, value); }
		}

		public float EqualVertexThreshold
		{
			get { return btVoronoiSimplexSolver_getEqualVertexThreshold(_native); }
			set { btVoronoiSimplexSolver_setEqualVertexThreshold(_native, value); }
		}

		public Vector3 LastW
		{
            get
            {
                Vector3 value;
                btVoronoiSimplexSolver_getLastW(_native, out value);
                return value;
            }
			set { btVoronoiSimplexSolver_setLastW(_native, ref value); }
		}

		public bool NeedsUpdate
		{
			get { return btVoronoiSimplexSolver_getNeedsUpdate(_native); }
			set { btVoronoiSimplexSolver_setNeedsUpdate(_native, value); }
		}

		public int NumVertices
		{
			get { return btVoronoiSimplexSolver_getNumVertices(_native); }
			set { btVoronoiSimplexSolver_setNumVertices(_native, value); }
		}
        /*
		public Vector3 SimplexPointsP
		{
			get { return btVoronoiSimplexSolver_getSimplexPointsP(_native); }
			set { btVoronoiSimplexSolver_setSimplexPointsP(_native, value._native); }
		}

		public Vector3 SimplexPointsQ
		{
			get { return btVoronoiSimplexSolver_getSimplexPointsQ(_native); }
			set { btVoronoiSimplexSolver_setSimplexPointsQ(_native, value._native); }
		}

		public Vector3 SimplexVectorW
		{
			get { return btVoronoiSimplexSolver_getSimplexVectorW(_native); }
			set { btVoronoiSimplexSolver_setSimplexVectorW(_native, value._native); }
		}
        */
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btVoronoiSimplexSolver_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~VoronoiSimplexSolver()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btVoronoiSimplexSolver_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_addVertex(IntPtr obj, [In] ref Vector3 w, [In] ref Vector3 p, [In] ref Vector3 q);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_backup_closest(IntPtr obj, [Out] out Vector3 v);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_closest(IntPtr obj, [Out] out Vector3 v);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_closestPtPointTetrahedron(IntPtr obj, [In] ref Vector3 p, [In] ref Vector3 a, [In] ref Vector3 b, [In] ref Vector3 c, [In] ref Vector3 d, IntPtr finalResult);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_closestPtPointTriangle(IntPtr obj, [In] ref Vector3 p, [In] ref Vector3 a, [In] ref Vector3 b, [In] ref Vector3 c, IntPtr result);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_compute_points(IntPtr obj, [Out] out Vector3 p1, [Out] out Vector3 p2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_emptySimplex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_fullSimplex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btVoronoiSimplexSolver_getCachedBC(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_getCachedP1(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_getCachedP2(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_getCachedV(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_getCachedValidClosest(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btVoronoiSimplexSolver_getEqualVertexThreshold(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_getLastW(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_getNeedsUpdate(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btVoronoiSimplexSolver_getNumVertices(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_inSimplex(IntPtr obj, [In] ref Vector3 w);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btVoronoiSimplexSolver_maxVertex(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btVoronoiSimplexSolver_pointOutsideOfPlane(IntPtr obj, [In] ref Vector3 p, [In] ref Vector3 a, [In] ref Vector3 b, [In] ref Vector3 c, [In] ref Vector3 d);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_reduceVertices(IntPtr obj, IntPtr usedVerts);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_removeVertex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_reset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_setCachedBC(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_setCachedP1(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_setCachedP2(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_setCachedV(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_setCachedValidClosest(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_setEqualVertexThreshold(IntPtr obj, float threshold);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVoronoiSimplexSolver_setLastW(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_setNeedsUpdate(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_setNumVertices(IntPtr obj, int value);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btVoronoiSimplexSolver_updateClosestVectorAndPoints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVoronoiSimplexSolver_delete(IntPtr obj);
	}
}
