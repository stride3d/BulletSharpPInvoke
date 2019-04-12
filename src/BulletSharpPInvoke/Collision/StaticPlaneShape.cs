using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class StaticPlaneShape : ConcaveShape
	{
		internal StaticPlaneShape(IntPtr native)
			: base(native)
		{
		}

		public StaticPlaneShape(Vector3 planeNormal, float planeConstant)
			: base(btStaticPlaneShape_new(ref planeNormal, planeConstant))
		{
		}

		public float PlaneConstant
		{
			get { return btStaticPlaneShape_getPlaneConstant(_native); }
		}

		public Vector3 PlaneNormal
		{
            get
            {
                Vector3 value;
                btStaticPlaneShape_getPlaneNormal(_native, out value);
                return value;
            }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btStaticPlaneShape_new([In] ref Vector3 planeNormal, float planeConstant);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btStaticPlaneShape_getPlaneConstant(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btStaticPlaneShape_getPlaneNormal(IntPtr obj, [Out] out Vector3 value);
	}
}
