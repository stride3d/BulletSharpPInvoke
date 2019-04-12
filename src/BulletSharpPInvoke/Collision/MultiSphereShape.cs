using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class MultiSphereShape : ConvexInternalAabbCachingShape
	{
		internal MultiSphereShape(IntPtr native)
			: base(native)
		{
		}

        public MultiSphereShape(Vector3[] positions, float[] radi)
            : base(btMultiSphereShape_new(positions, radi, (radi.Length < positions.Length) ? radi.Length : positions.Length))
        {
        }

		public MultiSphereShape(Vector3Array positions, float[] radi)
			: base(btMultiSphereShape_new2(positions._native, radi, (radi.Length < positions.Count) ? radi.Length : positions.Count))
		{
		}

		public Vector3 GetSpherePosition(int index)
		{
            Vector3 value;
			btMultiSphereShape_getSpherePosition(_native, index, out value);
            return value;
		}

		public float GetSphereRadius(int index)
		{
			return btMultiSphereShape_getSphereRadius(_native, index);
		}

		public int SphereCount
		{
			get { return btMultiSphereShape_getSphereCount(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btMultiSphereShape_new(Vector3[] positions, float[] radi, int numSpheres);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btMultiSphereShape_new2(IntPtr positions, float[] radi, int numSpheres);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btMultiSphereShape_getSphereCount(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btMultiSphereShape_getSpherePosition(IntPtr obj, int index, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btMultiSphereShape_getSphereRadius(IntPtr obj, int index);
	}

	public class PositionAndRadius
	{
		internal IntPtr _native;

		internal PositionAndRadius(IntPtr native)
		{
			_native = native;
		}

		public PositionAndRadius()
		{
			_native = btPositionAndRadius_new();
		}
        /*
		public Vector3 Pos
		{
            get
            {
                Vector3 value;
                btPositionAndRadius_getPos(_native, out value);
                return value;
            }
			set { btPositionAndRadius_setPos(_native, ref value); }
		}
        */
		public float Radius
		{
			get { return btPositionAndRadius_getRadius(_native); }
			set { btPositionAndRadius_setRadius(_native, value); }
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
				btPositionAndRadius_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PositionAndRadius()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPositionAndRadius_new();

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btPositionAndRadius_getRadius(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPositionAndRadius_setRadius(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPositionAndRadius_delete(IntPtr obj);
	}
}
