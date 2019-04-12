using Xenko.Core.Mathematics;
﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public class MotionState : IDisposable
    {
        internal IntPtr _native;

        internal MotionState(IntPtr native)
        {
            _native = native;
        }

        public void GetWorldTransform(out Matrix transform)
        {
            btMotionState_getWorldTransform(_native, out transform);
        }

        public void SetWorldTransform(Matrix transform)
        {
            btMotionState_setWorldTransform(_native, ref transform);
        }

        public Matrix WorldTransform
        {
            get
            {
                Matrix transform;
                btMotionState_getWorldTransform(_native, out transform);
                return transform;
            }
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btMotionState_getWorldTransform(IntPtr obj, [Out] out Matrix centerOfMassWorldTrans);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btMotionState_setWorldTransform(IntPtr obj, ref Matrix t);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btMotionState_delete(IntPtr obj);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_native != IntPtr.Zero)
            {
                btMotionState_delete(_native);
                _native = IntPtr.Zero;
            }
        }

        ~MotionState()
        {
            Dispose(false);
        }
    }
}
