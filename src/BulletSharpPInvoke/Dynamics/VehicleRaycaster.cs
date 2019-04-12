using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public class VehicleRaycasterResult
    {
        internal IntPtr _native;

        internal VehicleRaycasterResult(IntPtr native)
        {
            _native = native;
        }

        public VehicleRaycasterResult()
        {
            _native = btVehicleRaycaster_btVehicleRaycasterResult_new();
        }

        public float DistFraction
        {
            get { return btVehicleRaycaster_btVehicleRaycasterResult_getDistFraction(_native); }
            set { btVehicleRaycaster_btVehicleRaycasterResult_setDistFraction(_native, value); }
        }

        public Vector3 HitNormalInWorld
        {
            get
			{
				Vector3 value;
				btVehicleRaycaster_btVehicleRaycasterResult_getHitNormalInWorld(_native, out value);
				return value;
			}
            set { btVehicleRaycaster_btVehicleRaycasterResult_setHitNormalInWorld(_native, ref value); }
        }

        public Vector3 HitPointInWorld
        {
            get
			{
				Vector3 value;
				btVehicleRaycaster_btVehicleRaycasterResult_getHitPointInWorld(_native, out value);
				return value;
			}
            set { btVehicleRaycaster_btVehicleRaycasterResult_setHitPointInWorld(_native, ref value); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_native != IntPtr.Zero)
            {
                btVehicleRaycaster_btVehicleRaycasterResult_delete(_native);
                _native = IntPtr.Zero;
            }
        }

        ~VehicleRaycasterResult()
        {
            Dispose(false);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btVehicleRaycaster_btVehicleRaycasterResult_new();
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btVehicleRaycaster_btVehicleRaycasterResult_getDistFraction(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVehicleRaycaster_btVehicleRaycasterResult_getHitNormalInWorld(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVehicleRaycaster_btVehicleRaycasterResult_getHitPointInWorld(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVehicleRaycaster_btVehicleRaycasterResult_setDistFraction(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVehicleRaycaster_btVehicleRaycasterResult_setHitNormalInWorld(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVehicleRaycaster_btVehicleRaycasterResult_setHitPointInWorld(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btVehicleRaycaster_btVehicleRaycasterResult_delete(IntPtr obj);
    }
    
    public class VehicleRaycaster
	{
		internal IntPtr _native;

		internal VehicleRaycaster(IntPtr native)
		{
			_native = native;
		}

		public IntPtr CastRay(Vector3 from, Vector3 to, VehicleRaycasterResult result)
		{
			return btVehicleRaycaster_castRay(_native, ref from, ref to, result._native);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btVehicleRaycaster_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~VehicleRaycaster()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btVehicleRaycaster_castRay(IntPtr obj, [In] ref Vector3 from, [In] ref Vector3 to, IntPtr result);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btVehicleRaycaster_delete(IntPtr obj);
	}
}
