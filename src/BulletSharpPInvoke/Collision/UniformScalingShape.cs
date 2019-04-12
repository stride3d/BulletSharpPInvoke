using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class UniformScalingShape : ConvexShape
	{
		internal UniformScalingShape(IntPtr native)
			: base(native)
		{
		}

		public UniformScalingShape(ConvexShape convexChildShape, float uniformScalingFactor)
			: base(btUniformScalingShape_new(convexChildShape._native, uniformScalingFactor))
		{
		}

		public ConvexShape ChildShape
		{
			get { return CollisionShape.GetManaged(btUniformScalingShape_getChildShape(_native)) as ConvexShape; }
		}

		public float UniformScalingFactor
		{
			get { return btUniformScalingShape_getUniformScalingFactor(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btUniformScalingShape_new(IntPtr convexChildShape, float uniformScalingFactor);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btUniformScalingShape_getChildShape(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btUniformScalingShape_getUniformScalingFactor(IntPtr obj);
	}
}
