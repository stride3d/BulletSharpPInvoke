using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class Convex2DShape : ConvexShape
	{
		internal Convex2DShape(IntPtr native)
			: base(native)
		{
		}

		public Convex2DShape(ConvexShape convexChildShape)
			: base(btConvex2dShape_new(convexChildShape._native))
		{
		}

		public ConvexShape ChildShape
		{
            get { return CollisionShape.GetManaged(btConvex2dShape_getChildShape(_native)) as ConvexShape; }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConvex2dShape_new(IntPtr convexChildShape);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConvex2dShape_getChildShape(IntPtr obj);
	}
}
