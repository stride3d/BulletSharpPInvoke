using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class ConstraintSetting
	{
		internal IntPtr _native;

		internal ConstraintSetting(IntPtr native)
		{
			_native = native;
		}
        /*
		public ConstraintSetting()
		{
			_native = btConstraintSetting_new();
		}
        */
		public float Damping
		{
			get { return btConstraintSetting_getDamping(_native); }
			set { btConstraintSetting_setDamping(_native, value); }
		}

		public float ImpulseClamp
		{
			get { return btConstraintSetting_getImpulseClamp(_native); }
			set { btConstraintSetting_setImpulseClamp(_native, value); }
		}

		public float Tau
		{
			get { return btConstraintSetting_getTau(_native); }
			set { btConstraintSetting_setTau(_native, value); }
		}
        /*
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btConstraintSetting_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ConstraintSetting()
		{
			Dispose(false);
		}
        */

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btConstraintSetting_getDamping(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btConstraintSetting_getImpulseClamp(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btConstraintSetting_getTau(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSetting_setDamping(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSetting_setImpulseClamp(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSetting_setTau(IntPtr obj, float value);
	}

	public class Point2PointConstraint : TypedConstraint
	{
		internal Point2PointConstraint(IntPtr native)
			: base(native)
		{
		}

		public Point2PointConstraint(RigidBody rbA, RigidBody rbB, Vector3 pivotInA, Vector3 pivotInB)
			: base(btPoint2PointConstraint_new(rbA._native, rbB._native, ref pivotInA, ref pivotInB))
		{
		}

		public Point2PointConstraint(RigidBody rbA, Vector3 pivotInA)
			: base(btPoint2PointConstraint_new2(rbA._native, ref pivotInA))
		{
		}
        /*
        public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix body0_trans, Matrix body1_trans)
		{
			btPoint2PointConstraint_getInfo2NonVirtual(_native, info._native, ref body0_trans, ref body1_trans);
		}
        */
		public void SetPivotA(Vector3 pivotA)
		{
			btPoint2PointConstraint_setPivotA(_native, ref pivotA);
		}

		public void SetPivotB(Vector3 pivotB)
		{
			btPoint2PointConstraint_setPivotB(_native, ref pivotB);
		}

		public void UpdateRHS(float timeStep)
		{
			btPoint2PointConstraint_updateRHS(_native, timeStep);
		}
        /*
		public void Info1NonVirtual
		{
			get { return btPoint2PointConstraint_getInfo1NonVirtual(_native); }
		}
        */
		public Vector3 PivotInA
		{
			get
			{
				Vector3 value;
				btPoint2PointConstraint_getPivotInA(_native, out value);
				return value;
			}
		}

		public Vector3 PivotInB
		{
			get
			{
				Vector3 value;
				btPoint2PointConstraint_getPivotInB(_native, out value);
				return value;
			}
		}

        public ConstraintSetting Setting
		{
			get { return new ConstraintSetting(btPoint2PointConstraint_getSetting(_native)); }
			set { btPoint2PointConstraint_setSetting(_native, value._native); }
		}

		public bool UseSolveConstraintObsolete
		{
			get { return btPoint2PointConstraint_getUseSolveConstraintObsolete(_native); }
			set { btPoint2PointConstraint_setUseSolveConstraintObsolete(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPoint2PointConstraint_new(IntPtr rbA, IntPtr rbB, [In] ref Vector3 pivotInA, [In] ref Vector3 pivotInB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPoint2PointConstraint_new2(IntPtr rbA, [In] ref Vector3 pivotInA);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPoint2PointConstraint_getPivotInA(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btPoint2PointConstraint_getPivotInB(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPoint2PointConstraint_getSetting(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btPoint2PointConstraint_getUseSolveConstraintObsolete(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPoint2PointConstraint_setPivotA(IntPtr obj, [In] ref Vector3 pivotA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPoint2PointConstraint_setPivotB(IntPtr obj, [In] ref Vector3 pivotB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPoint2PointConstraint_setSetting(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPoint2PointConstraint_setUseSolveConstraintObsolete(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPoint2PointConstraint_updateRHS(IntPtr obj, float timeStep);
	}
}
