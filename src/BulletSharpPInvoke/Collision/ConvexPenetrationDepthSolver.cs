using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class ConvexPenetrationDepthSolver
	{
		internal IntPtr _native;

		internal ConvexPenetrationDepthSolver(IntPtr native)
		{
			_native = native;
		}
        /*
		public bool CalcPenDepth(VoronoiSimplexSolver simplexSolver, ConvexShape convexA, ConvexShape convexB, Matrix transA, Matrix transB, Vector3 v, Vector3 pa, Vector3 pb, IDebugDraw debugDraw)
		{
			return btConvexPenetrationDepthSolver_calcPenDepth(_native, simplexSolver._native, convexA._native, convexB._native, ref transA, ref transB, ref v, ref pa, ref pb, DebugDraw.GetUnmanaged(debugDraw));
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
				btConvexPenetrationDepthSolver_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ConvexPenetrationDepthSolver()
		{
			Dispose(false);
		}

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexPenetrationDepthSolver_delete(IntPtr obj);
	}
}
