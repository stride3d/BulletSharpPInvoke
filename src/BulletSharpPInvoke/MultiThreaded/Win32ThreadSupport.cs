using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public struct Win32ThreadFunc
    {
        internal IntPtr _native;

        public Win32ThreadFunc(IntPtr native)
        {
            _native = native;
        }

        public static Win32ThreadFunc ProcessCollisionTask
        {
            get { return new Win32ThreadFunc(Win32ThreadFunc_getProcessCollisionTask()); }
        }

        public static Win32ThreadFunc SolverThreadFunc
        {
            get { return new Win32ThreadFunc(Win32ThreadFunc_getSolverThreadFunc()); }
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadFunc_getProcessCollisionTask();
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadFunc_getSolverThreadFunc();
    }

    public struct Win32LSMemorySetupFunc
    {
        internal IntPtr _native;

        public Win32LSMemorySetupFunc(IntPtr native)
        {
            _native = native;
        }

        public static Win32LSMemorySetupFunc CreateCollisionLocalStoreMemory
        {
            get { return new Win32LSMemorySetupFunc(Win32lsMemorySetupFunc_getCreateCollisionLocalStoreMemory()); }
        }

        public static Win32LSMemorySetupFunc SolverLSMemoryFunc
        {
            get { return new Win32LSMemorySetupFunc(Win32lsMemorySetupFunc_getSolverlsMemoryFunc()); }
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32lsMemorySetupFunc_getCreateCollisionLocalStoreMemory();
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32lsMemorySetupFunc_getSolverlsMemoryFunc();
    }

    public class Win32ThreadConstructionInfo
    {
        internal IntPtr _native;

        internal Win32ThreadConstructionInfo(IntPtr native)
        {
            _native = native;
        }

        public Win32ThreadConstructionInfo(string uniqueName, Win32ThreadFunc userThreadFunc, Win32LSMemorySetupFunc lsMemoryFunc, int numThreads, int threadStackSize)
        {
            _native = Win32ThreadSupport_Win32ThreadConstructionInfo_new(uniqueName, userThreadFunc._native, lsMemoryFunc._native, numThreads, threadStackSize);
        }

        public Win32ThreadConstructionInfo(string uniqueName, Win32ThreadFunc userThreadFunc, Win32LSMemorySetupFunc lsMemoryFunc, int numThreads)
        {
            _native = Win32ThreadSupport_Win32ThreadConstructionInfo_new2(uniqueName, userThreadFunc._native, lsMemoryFunc._native, numThreads);
        }

        public Win32ThreadConstructionInfo(string uniqueName, Win32ThreadFunc userThreadFunc, Win32LSMemorySetupFunc lsMemoryFunc)
        {
            _native = Win32ThreadSupport_Win32ThreadConstructionInfo_new3(uniqueName, userThreadFunc._native, lsMemoryFunc._native);
        }

        public Win32LSMemorySetupFunc LsMemoryFunc
        {
            get { return new Win32LSMemorySetupFunc(Win32ThreadSupport_Win32ThreadConstructionInfo_getLsMemoryFunc(_native)); }
            set { Win32ThreadSupport_Win32ThreadConstructionInfo_setLsMemoryFunc(_native, value._native); }
        }

        public int NumThreads
        {
            get { return Win32ThreadSupport_Win32ThreadConstructionInfo_getNumThreads(_native); }
            set { Win32ThreadSupport_Win32ThreadConstructionInfo_setNumThreads(_native, value); }
        }

        public int ThreadStackSize
        {
            get { return Win32ThreadSupport_Win32ThreadConstructionInfo_getThreadStackSize(_native); }
            set { Win32ThreadSupport_Win32ThreadConstructionInfo_setThreadStackSize(_native, value); }
        }

        public string UniqueName
        {
            get { return Win32ThreadSupport_Win32ThreadConstructionInfo_getUniqueName(_native); }
            set { Win32ThreadSupport_Win32ThreadConstructionInfo_setUniqueName(_native, value); }
        }

        public Win32ThreadFunc UserThreadFunc
        {
            get { return new Win32ThreadFunc(Win32ThreadSupport_Win32ThreadConstructionInfo_getUserThreadFunc(_native)); }
            set { Win32ThreadSupport_Win32ThreadConstructionInfo_setUserThreadFunc(_native, value._native); }
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
                Win32ThreadSupport_Win32ThreadConstructionInfo_delete(_native);
                _native = IntPtr.Zero;
            }
        }

        ~Win32ThreadConstructionInfo()
        {
            Dispose(false);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadSupport_Win32ThreadConstructionInfo_new(string uniqueName, IntPtr userThreadFunc, IntPtr lsMemoryFunc, int numThreads, int threadStackSize);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadSupport_Win32ThreadConstructionInfo_new2(string uniqueName, IntPtr userThreadFunc, IntPtr lsMemoryFunc, int numThreads);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadSupport_Win32ThreadConstructionInfo_new3(string uniqueName, IntPtr userThreadFunc, IntPtr lsMemoryFunc);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadSupport_Win32ThreadConstructionInfo_getLsMemoryFunc(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int Win32ThreadSupport_Win32ThreadConstructionInfo_getNumThreads(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int Win32ThreadSupport_Win32ThreadConstructionInfo_getThreadStackSize(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern string Win32ThreadSupport_Win32ThreadConstructionInfo_getUniqueName(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Win32ThreadSupport_Win32ThreadConstructionInfo_getUserThreadFunc(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Win32ThreadSupport_Win32ThreadConstructionInfo_setLsMemoryFunc(IntPtr obj, IntPtr value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Win32ThreadSupport_Win32ThreadConstructionInfo_setNumThreads(IntPtr obj, int value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Win32ThreadSupport_Win32ThreadConstructionInfo_setThreadStackSize(IntPtr obj, int value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Win32ThreadSupport_Win32ThreadConstructionInfo_setUniqueName(IntPtr obj, string value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Win32ThreadSupport_Win32ThreadConstructionInfo_setUserThreadFunc(IntPtr obj, IntPtr value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void Win32ThreadSupport_Win32ThreadConstructionInfo_delete(IntPtr obj);
    }

	public class Win32ThreadSupport : ThreadSupportInterface
	{
		internal Win32ThreadSupport(IntPtr native)
			: base(native)
		{
		}

		public Win32ThreadSupport(Win32ThreadConstructionInfo threadConstructionInfo)
			: base(Win32ThreadSupport_new(threadConstructionInfo._native))
		{
		}

        public bool IsTaskCompleted(IntPtr puiArgument0, IntPtr puiArgument1, int timeOutInMilliseconds)
		{
			return Win32ThreadSupport_isTaskCompleted(_native, puiArgument0, puiArgument1, timeOutInMilliseconds);
		}

		public void StartThreads(Win32ThreadConstructionInfo threadInfo)
		{
			Win32ThreadSupport_startThreads(_native, threadInfo._native);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr Win32ThreadSupport_new(IntPtr threadConstructionInfo);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool Win32ThreadSupport_isTaskCompleted(IntPtr obj, IntPtr puiArgument0, IntPtr puiArgument1, int timeOutInMilliseconds);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void Win32ThreadSupport_startThreads(IntPtr obj, IntPtr threadInfo);
	}
}
