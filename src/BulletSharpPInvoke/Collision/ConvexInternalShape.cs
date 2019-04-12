using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class ConvexInternalShape : ConvexShape
	{
		internal ConvexInternalShape(IntPtr native)
			: base(native)
		{
		}

		public void SetSafeMargin(float minDimension, float defaultMarginMultiplier)
		{
			btConvexInternalShape_setSafeMargin(_native, minDimension, defaultMarginMultiplier);
		}

		public void SetSafeMargin(float minDimension)
		{
			btConvexInternalShape_setSafeMargin2(_native, minDimension);
		}

		public void SetSafeMargin(Vector3 halfExtents, float defaultMarginMultiplier)
		{
			btConvexInternalShape_setSafeMargin3(_native, ref halfExtents, defaultMarginMultiplier);
		}

		public void SetSafeMargin(Vector3 halfExtents)
		{
			btConvexInternalShape_setSafeMargin4(_native, ref halfExtents);
		}

        /*
		public Vector3 ImplicitShapeDimensions
		{
			get
			{
				Vector3 value;
				btConvexInternalShape_getImplicitShapeDimensions(_native, out value);
				return value;
			}
			set { btConvexInternalShape_setImplicitShapeDimensions(_native, ref value); }
		}
        */

        /*
		public Vector3 LocalScalingNV
		{
			get
			{
				Vector3 value;
				btConvexInternalShape_getLocalScalingNV(_native, out value);
				return value;
			}
		}
        */

		public float MarginNV
		{
			get { return btConvexInternalShape_getMarginNV(_native); }
		}

		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btConvexInternalShape_getImplicitShapeDimensions(IntPtr obj, [Out] out Vector3 value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        //static extern void btConvexInternalShape_getLocalScalingNV(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btConvexInternalShape_getMarginNV(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexInternalShape_setImplicitShapeDimensions(IntPtr obj, [In] ref Vector3 dimensions);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexInternalShape_setSafeMargin(IntPtr obj, float minDimension, float defaultMarginMultiplier);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexInternalShape_setSafeMargin2(IntPtr obj, float minDimension);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexInternalShape_setSafeMargin3(IntPtr obj, [In] ref Vector3 halfExtents, float defaultMarginMultiplier);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexInternalShape_setSafeMargin4(IntPtr obj, [In] ref Vector3 halfExtents);
	}

	public class ConvexInternalAabbCachingShape : ConvexInternalShape
	{
		internal ConvexInternalAabbCachingShape(IntPtr native)
			: base(native)
		{
		}

		public void RecalcLocalAabb()
		{
			btConvexInternalAabbCachingShape_recalcLocalAabb(_native);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexInternalAabbCachingShape_recalcLocalAabb(IntPtr obj);
	}
}
