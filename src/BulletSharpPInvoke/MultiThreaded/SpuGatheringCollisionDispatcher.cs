using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class SpuGatheringCollisionDispatcher : CollisionDispatcher
	{
        private ThreadSupportInterface _threadInterface;

		internal SpuGatheringCollisionDispatcher(IntPtr native)
			: base(native)
		{
		}

		public SpuGatheringCollisionDispatcher(ThreadSupportInterface threadInterface, uint maxNumOutstandingTasks, CollisionConfiguration collisionConfiguration)
			: base(SpuGatheringCollisionDispatcher_new(threadInterface._native, maxNumOutstandingTasks, collisionConfiguration._native))
		{
            _threadInterface = threadInterface;
		}

		public bool SupportsDispatchPairOnSpu(int proxyType0, int proxyType1)
		{
			return SpuGatheringCollisionDispatcher_supportsDispatchPairOnSpu(_native, proxyType0, proxyType1);
		}

		public SpuCollisionTaskProcess SpuCollisionTaskProcess
		{
            get
            {
                IntPtr spuCollisionTaskProcess = SpuGatheringCollisionDispatcher_getSpuCollisionTaskProcess(_native);
                if (spuCollisionTaskProcess == IntPtr.Zero)
                {
                    return null;
                }
                return new SpuCollisionTaskProcess(spuCollisionTaskProcess);
            }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SpuGatheringCollisionDispatcher_new(IntPtr threadInterface, uint maxNumOutstandingTasks, IntPtr collisionConfiguration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SpuGatheringCollisionDispatcher_getSpuCollisionTaskProcess(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool SpuGatheringCollisionDispatcher_supportsDispatchPairOnSpu(IntPtr obj, int proxyType0, int proxyType1);
	}
}
