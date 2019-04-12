using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class SpuGatherAndProcessWorkUnitInput
	{
		internal IntPtr _native;

		internal SpuGatherAndProcessWorkUnitInput(IntPtr native)
		{
			_native = native;
		}

		public SpuGatherAndProcessWorkUnitInput()
		{
			_native = SpuGatherAndProcessWorkUnitInput_new();
		}

		public int EndIndex
		{
			get { return SpuGatherAndProcessWorkUnitInput_getEndIndex(_native); }
			set { SpuGatherAndProcessWorkUnitInput_setEndIndex(_native, value); }
		}

		public ulong PairArrayPtr
		{
			get { return SpuGatherAndProcessWorkUnitInput_getPairArrayPtr(_native); }
			set { SpuGatherAndProcessWorkUnitInput_setPairArrayPtr(_native, value); }
		}

		public int StartIndex
		{
			get { return SpuGatherAndProcessWorkUnitInput_getStartIndex(_native); }
			set { SpuGatherAndProcessWorkUnitInput_setStartIndex(_native, value); }
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
				SpuGatherAndProcessWorkUnitInput_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SpuGatherAndProcessWorkUnitInput()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SpuGatherAndProcessWorkUnitInput_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int SpuGatherAndProcessWorkUnitInput_getEndIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ulong SpuGatherAndProcessWorkUnitInput_getPairArrayPtr(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int SpuGatherAndProcessWorkUnitInput_getStartIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessWorkUnitInput_setEndIndex(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessWorkUnitInput_setPairArrayPtr(IntPtr obj, ulong value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessWorkUnitInput_setStartIndex(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessWorkUnitInput_delete(IntPtr obj);
	}

	public class SpuCollisionTaskProcess
	{
		internal IntPtr _native;

		internal SpuCollisionTaskProcess(IntPtr native)
		{
			_native = native;
		}

		public SpuCollisionTaskProcess(ThreadSupportInterface threadInterface, uint maxNumOutstandingTasks)
		{
			_native = SpuCollisionTaskProcess_new(threadInterface._native, maxNumOutstandingTasks);
		}

		public void AddWorkToTask(IntPtr pairArrayPtr, int startIndex, int endIndex)
		{
			SpuCollisionTaskProcess_addWorkToTask(_native, pairArrayPtr, startIndex, endIndex);
		}

		public void Flush2()
		{
			SpuCollisionTaskProcess_flush2(_native);
		}

		public void Initialize2(bool useEpa)
		{
			SpuCollisionTaskProcess_initialize2(_native, useEpa);
		}

		public void Initialize2()
		{
			SpuCollisionTaskProcess_initialize22(_native);
		}

		public int NumTasks
		{
			get { return SpuCollisionTaskProcess_getNumTasks(_native); }
			set { SpuCollisionTaskProcess_setNumTasks(_native, value); }
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
				SpuCollisionTaskProcess_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SpuCollisionTaskProcess()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SpuCollisionTaskProcess_new(IntPtr threadInterface, uint maxNumOutstandingTasks);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuCollisionTaskProcess_addWorkToTask(IntPtr obj, IntPtr pairArrayPtr, int startIndex, int endIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuCollisionTaskProcess_flush2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int SpuCollisionTaskProcess_getNumTasks(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuCollisionTaskProcess_initialize2(IntPtr obj, bool useEpa);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuCollisionTaskProcess_initialize22(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuCollisionTaskProcess_setNumTasks(IntPtr obj, int maxNumTasks);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuCollisionTaskProcess_delete(IntPtr obj);
	}
}
