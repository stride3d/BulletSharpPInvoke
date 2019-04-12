using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class AxisSweep3 : BroadphaseInterface
	{
		internal AxisSweep3(IntPtr native)
			: base(native)
		{
		}

		public AxisSweep3(Vector3 worldAabbMin, Vector3 worldAabbMax, ushort maxHandles, OverlappingPairCache pairCache, bool disableRaycastAccelerator)
			: base(btAxisSweep3_new(ref worldAabbMin, ref worldAabbMax, maxHandles, pairCache._native, disableRaycastAccelerator))
		{
            _pairCache = pairCache;
		}

		public AxisSweep3(Vector3 worldAabbMin, Vector3 worldAabbMax, ushort maxHandles, OverlappingPairCache pairCache)
			: base(btAxisSweep3_new2(ref worldAabbMin, ref worldAabbMax, maxHandles, pairCache._native))
		{
            _pairCache = pairCache;
		}

		public AxisSweep3(Vector3 worldAabbMin, Vector3 worldAabbMax, ushort maxHandles)
			: base(btAxisSweep3_new3(ref worldAabbMin, ref worldAabbMax, maxHandles))
		{
		}

		public AxisSweep3(Vector3 worldAabbMin, Vector3 worldAabbMax)
			: base(btAxisSweep3_new4(ref worldAabbMin, ref worldAabbMax))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btAxisSweep3_new([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax, ushort maxHandles, IntPtr pairCache, bool disableRaycastAccelerator);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btAxisSweep3_new2([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax, ushort maxHandles, IntPtr pairCache);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btAxisSweep3_new3([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax, ushort maxHandles);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btAxisSweep3_new4([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax);
	}

	public class AxisSweep3_32Bit : BroadphaseInterface
	{
		internal AxisSweep3_32Bit(IntPtr native)
			: base(native)
		{
		}

		public AxisSweep3_32Bit(Vector3 worldAabbMin, Vector3 worldAabbMax, uint maxHandles, OverlappingPairCache pairCache, bool disableRaycastAccelerator)
			: base(bt32BitAxisSweep3_new(ref worldAabbMin, ref worldAabbMax, maxHandles, pairCache._native, disableRaycastAccelerator))
		{
		}

		public AxisSweep3_32Bit(Vector3 worldAabbMin, Vector3 worldAabbMax, uint maxHandles, OverlappingPairCache pairCache)
			: base(bt32BitAxisSweep3_new2(ref worldAabbMin, ref worldAabbMax, maxHandles, pairCache._native))
		{
		}

		public AxisSweep3_32Bit(Vector3 worldAabbMin, Vector3 worldAabbMax, uint maxHandles)
			: base(bt32BitAxisSweep3_new3(ref worldAabbMin, ref worldAabbMax, maxHandles))
		{
		}

        public AxisSweep3_32Bit(Vector3 worldAabbMin, Vector3 worldAabbMax)
			: base(bt32BitAxisSweep3_new4(ref worldAabbMin, ref worldAabbMax))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bt32BitAxisSweep3_new([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax, uint maxHandles, IntPtr pairCache, bool disableRaycastAccelerator);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bt32BitAxisSweep3_new2([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax, uint maxHandles, IntPtr pairCache);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bt32BitAxisSweep3_new3([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax, uint maxHandles);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bt32BitAxisSweep3_new4([In] ref Vector3 worldAabbMin, [In] ref Vector3 worldAabbMax);
	}
}
