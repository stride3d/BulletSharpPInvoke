using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class DefaultMotionState : MotionState
	{
		internal DefaultMotionState(IntPtr native)
			: base(native)
		{
		}

		public DefaultMotionState(Matrix startTrans, Matrix centerOfMassOffset)
			: base(btDefaultMotionState_new(ref startTrans, ref centerOfMassOffset))
		{
		}

		public DefaultMotionState(Matrix startTrans)
			: base(btDefaultMotionState_new2(ref startTrans))
		{
		}

		public DefaultMotionState()
			: base(btDefaultMotionState_new3())
		{
		}

        public Matrix CenterOfMassOffset
		{
            get
            {
                Matrix transform;
                btDefaultMotionState_getCenterOfMassOffset(_native, out transform);
                return transform;
            }
			set { btDefaultMotionState_setCenterOfMassOffset(_native, ref value); }
		}

        public Matrix GraphicsWorldTrans
		{
            get
            {
                Matrix transform;
                btDefaultMotionState_getGraphicsWorldTrans(_native, out transform);
                return transform;
            }
			set { btDefaultMotionState_setGraphicsWorldTrans(_native, ref value); }
		}

		public Matrix StartWorldTrans
		{
            get
            {
                Matrix transform;
                btDefaultMotionState_getStartWorldTrans(_native, out transform);
                return transform;
            }
			set { btDefaultMotionState_setStartWorldTrans(_native, ref value); }
		}

		public IntPtr UserPointer
		{
			get { return btDefaultMotionState_getUserPointer(_native); }
			set { btDefaultMotionState_setUserPointer(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultMotionState_new([In] ref Matrix startTrans, [In] ref Matrix centerOfMassOffset);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultMotionState_new2([In] ref Matrix startTrans);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultMotionState_new3();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultMotionState_getCenterOfMassOffset(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btDefaultMotionState_getGraphicsWorldTrans(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btDefaultMotionState_getStartWorldTrans(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultMotionState_getUserPointer(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultMotionState_setCenterOfMassOffset(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btDefaultMotionState_setGraphicsWorldTrans(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btDefaultMotionState_setStartWorldTrans(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultMotionState_setUserPointer(IntPtr obj, IntPtr value);
	}
}
