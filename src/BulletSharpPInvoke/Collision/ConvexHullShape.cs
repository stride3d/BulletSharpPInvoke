using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.Generic;

namespace BulletSharp
{
	public class ConvexHullShape : PolyhedralConvexAabbCachingShape
	{
		internal ConvexHullShape(IntPtr native)
			: base(native)
		{
		}

		public ConvexHullShape(float[] points, int numPoints, int stride)
			: base(btConvexHullShape_new(points, numPoints, stride))
		{
		}

        public ConvexHullShape(IEnumerable<Vector3> points, int numPoints)
            : base(btConvexHullShape_new4())
		{
            int i = 0;
            foreach (Vector3 v in points)
            {
                Vector3 viter = v;
                btConvexHullShape_addPoint2(_native, ref viter);
                i++;
                if (i == numPoints)
                {
                    break;
                }
            }
            RecalcLocalAabb();
		}

		public ConvexHullShape(IEnumerable<Vector3> points)
            : base(btConvexHullShape_new4())
		{
            Vector3 viter;
            foreach (Vector3 v in points)
            {
                viter = v;
                btConvexHullShape_addPoint2(_native, ref viter);
            }
            RecalcLocalAabb();
		}

		public ConvexHullShape()
			: base(btConvexHullShape_new4())
		{
		}

		public void AddPoint(Vector3 point, bool recalculateLocalAabb)
		{
			btConvexHullShape_addPoint(_native, ref point, recalculateLocalAabb);
		}

		public void AddPoint(Vector3 point)
		{
			btConvexHullShape_addPoint2(_native, ref point);
		}

		public void GetScaledPoint(int i)
		{
			btConvexHullShape_getScaledPoint(_native, i);
		}
        /*
		public void Project(Matrix trans, Vector3 dir, float minProj, float maxProj, Vector3 witnesPtMin, Vector3 witnesPtMax)
		{
			btConvexHullShape_project(_native, ref trans, ref dir, minProj._native, maxProj._native, ref witnesPtMin, ref witnesPtMax);
		}
        */
		public int NumPoints
		{
			get { return btConvexHullShape_getNumPoints(_native); }
		}
        /*
		public Vector3 Points
		{
			get { return btConvexHullShape_getPoints(_native); }
		}

		public Vector3 UnscaledPoints
		{
			get { return btConvexHullShape_getUnscaledPoints(_native); }
		}
        */
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btConvexHullShape_new(float[] points, int numPoints, int stride);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConvexHullShape_new4();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexHullShape_addPoint(IntPtr obj, [In] ref Vector3 point, bool recalculateLocalAabb);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexHullShape_addPoint2(IntPtr obj, [In] ref Vector3 point);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btConvexHullShape_getNumPoints(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexHullShape_getScaledPoint(IntPtr obj, int i);
	}
}
