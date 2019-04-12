using Xenko.Core.Mathematics;
﻿using System;
using System.Runtime.InteropServices;
using System.Security;


namespace BulletSharp
{
    public class Box2DShape : PolyhedralConvexShape
    {
        internal Box2DShape(IntPtr native)
			: base(native)
		{
		}

        public Box2DShape(Vector2 boxHalfExtents)
            : base(btBox2dShape_new(boxHalfExtents.X, boxHalfExtents.Y))
        {
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btBox2dShape_new(float halfExtentX, float halfExtentY);
    }
}
