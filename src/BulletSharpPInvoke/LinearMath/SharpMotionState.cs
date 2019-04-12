
#if __iOS__
using ObjCRuntime;
#endif
using System;
using System.Runtime.InteropServices;
using System.Security;
using Xenko.Core.Mathematics;

namespace BulletSharp
{
    public class SharpMotionState : IDisposable
    {
        internal IntPtr Native;
        private GCHandle _handle;

        public SharpMotionState()
        {
            _handle = GCHandle.Alloc(this);
            Native = SharpMotionState_new(GCHandle.ToIntPtr(_handle));
        }

        public virtual void Dispose()
        {
            SharpMotionState_delete(Native);
            _handle.Free();
            Native = IntPtr.Zero;
        }

        [UnmanagedFunctionPointer(BulletSharp.Native.Conv)]
        private delegate void GetWorldTransformUnmanagedDelegate(IntPtr sharpReference, [Out] out Matrix transform);

        [UnmanagedFunctionPointer(BulletSharp.Native.Conv)]
        private delegate void SetWorldTransformUnmanagedDelegate(IntPtr sharpReference, [In] ref Matrix transform);

#if __iOS__
        [MonoPInvokeCallback(typeof(GetWorldTransformUnmanagedDelegate))]
#endif
        static void InternalGetWorldTransform(IntPtr sharpReference, [Out] out Matrix transform)
        {
            transform = Matrix.Identity;
            try
            {
                var obj = (SharpMotionState)GCHandle.FromIntPtr(sharpReference).Target;
                obj.GetWorldTransform(out transform);
            }
            catch (Exception)
            {
                // ignored
            }
        }

#if __iOS__
        [MonoPInvokeCallback(typeof(SetWorldTransformUnmanagedDelegate))]
#endif
        static void InternalSetWorldTransform(IntPtr sharpReference, [In] ref Matrix transform)
        {
            try
            {
                var obj = (SharpMotionState)GCHandle.FromIntPtr(sharpReference).Target;
                obj.SetWorldTransform(transform);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private static readonly GetWorldTransformUnmanagedDelegate GetWorldTransformUnmanaged = InternalGetWorldTransform;
        private static readonly SetWorldTransformUnmanagedDelegate SetWorldTransformUnmanaged = InternalSetWorldTransform;

        static SharpMotionState()
        {
#if !__iOS__
            SharpMotionState_Setup(Marshal.GetFunctionPointerForDelegate(GetWorldTransformUnmanaged), Marshal.GetFunctionPointerForDelegate(SetWorldTransformUnmanaged));
#else
            SharpMotionState_Setup(GetWorldTransformUnmanaged, SetWorldTransformUnmanaged);
#endif
        }

        public virtual void GetWorldTransform(out Matrix transform)
        {
            transform = Matrix.Identity;
        }

        public virtual void SetWorldTransform(Matrix transform)
        {
            
        }

#if !__iOS__
        [DllImport(BulletSharp.Native.Dll, CallingConvention = BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr SharpMotionState_Setup(IntPtr getWorldTransformCallback, IntPtr setWorldTransformCallback);
#else
        [DllImport(BulletSharp.Native.Dll, CallingConvention = BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr SharpMotionState_Setup(GetWorldTransformUnmanagedDelegate getWorldTransformCallback, SetWorldTransformUnmanagedDelegate setWorldTransformCallback); 
#endif

        [DllImport(BulletSharp.Native.Dll, CallingConvention = BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr SharpMotionState_new(IntPtr sharpReference);
        [DllImport(BulletSharp.Native.Dll, CallingConvention = BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
        private static extern void SharpMotionState_delete(IntPtr obj);
    }
}
