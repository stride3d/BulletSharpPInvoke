using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class FixedConstraint : TypedConstraint
	{
		internal FixedConstraint(IntPtr native)
			: base(native)
		{
		}

		public FixedConstraint(RigidBody rbA, RigidBody rbB, Matrix frameInA, Matrix frameInB)
			: base(btFixedConstraint_new(rbA._native, rbB._native, ref frameInA, ref frameInB))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btFixedConstraint_new(IntPtr rbA, IntPtr rbB, [In] ref Matrix frameInA, [In] ref Matrix frameInB);
	}
}
