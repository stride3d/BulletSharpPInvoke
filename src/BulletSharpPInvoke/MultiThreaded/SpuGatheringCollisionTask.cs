using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class SpuGatherAndProcessPairsTaskDesc
	{
		internal IntPtr _native;

		internal SpuGatherAndProcessPairsTaskDesc(IntPtr native)
		{
			_native = native;
		}

		public SpuGatherAndProcessPairsTaskDesc()
		{
			_native = SpuGatherAndProcessPairsTaskDesc_new();
		}

		public uint Dispatcher
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getDispatcher(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setDispatcher(_native, value); }
		}

		public uint InPairPtr
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getInPairPtr(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setInPairPtr(_native, value); }
		}

		public IntPtr LsMemory
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getLsMemory(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setLsMemory(_native, value); }
		}

		public uint NumOnLastPage
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getNumOnLastPage(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setNumOnLastPage(_native, value); }
		}

		public ushort NumPages
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getNumPages(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setNumPages(_native, value); }
		}

		public uint SomeMutexVariableInMainMemory
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getSomeMutexVariableInMainMemory(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setSomeMutexVariableInMainMemory(_native, value); }
		}

		public ushort TaskId
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getTaskId(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setTaskId(_native, value); }
		}

		public bool UseEpa
		{
			get { return SpuGatherAndProcessPairsTaskDesc_getUseEpa(_native); }
			set { SpuGatherAndProcessPairsTaskDesc_setUseEpa(_native, value); }
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
				SpuGatherAndProcessPairsTaskDesc_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SpuGatherAndProcessPairsTaskDesc()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SpuGatherAndProcessPairsTaskDesc_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint SpuGatherAndProcessPairsTaskDesc_getDispatcher(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint SpuGatherAndProcessPairsTaskDesc_getInPairPtr(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SpuGatherAndProcessPairsTaskDesc_getLsMemory(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint SpuGatherAndProcessPairsTaskDesc_getNumOnLastPage(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort SpuGatherAndProcessPairsTaskDesc_getNumPages(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint SpuGatherAndProcessPairsTaskDesc_getSomeMutexVariableInMainMemory(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort SpuGatherAndProcessPairsTaskDesc_getTaskId(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool SpuGatherAndProcessPairsTaskDesc_getUseEpa(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setDispatcher(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setInPairPtr(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setLsMemory(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setNumOnLastPage(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setNumPages(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setSomeMutexVariableInMainMemory(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setTaskId(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_setUseEpa(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void SpuGatherAndProcessPairsTaskDesc_delete(IntPtr obj);
	}
}
