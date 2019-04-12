using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class Barrier
	{
		internal IntPtr _native;

		internal Barrier(IntPtr native)
		{
			_native = native;
		}

		public void Sync()
		{
			btBarrier_sync(_native);
		}

		public int MaxCount
		{
			get { return btBarrier_getMaxCount(_native); }
			set { btBarrier_setMaxCount(_native, value); }
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
				btBarrier_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Barrier()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btBarrier_getMaxCount(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBarrier_setMaxCount(IntPtr obj, int n);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBarrier_sync(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBarrier_delete(IntPtr obj);
	}

	public class CriticalSection
	{
		internal IntPtr _native;

		internal CriticalSection(IntPtr native)
		{
			_native = native;
		}

		public uint GetSharedParam(int i)
		{
			return btCriticalSection_getSharedParam(_native, i);
		}

		public void Lock()
		{
			btCriticalSection_lock(_native);
		}

		public void SetSharedParam(int i, uint p)
		{
			btCriticalSection_setSharedParam(_native, i, p);
		}

		public void Unlock()
		{
			btCriticalSection_unlock(_native);
		}

		public IntPtr MCommonBuff
		{
			get { return btCriticalSection_getMCommonBuff(_native); }
			set { btCriticalSection_setMCommonBuff(_native, value); }
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
				btCriticalSection_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~CriticalSection()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCriticalSection_getMCommonBuff(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btCriticalSection_getSharedParam(IntPtr obj, int i);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCriticalSection_lock(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCriticalSection_setMCommonBuff(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCriticalSection_setSharedParam(IntPtr obj, int i, uint p);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCriticalSection_unlock(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCriticalSection_delete(IntPtr obj);
	}

	public class ThreadSupportInterface
	{
		internal IntPtr _native;

		internal ThreadSupportInterface(IntPtr native)
		{
			_native = native;
		}

		public Barrier CreateBarrier()
		{
			return new Barrier(btThreadSupportInterface_createBarrier(_native));
		}

		public CriticalSection CreateCriticalSection()
		{
            return new CriticalSection(btThreadSupportInterface_createCriticalSection(_native));
		}

		public void DeleteBarrier(Barrier barrier)
		{
			btThreadSupportInterface_deleteBarrier(_native, barrier._native);
		}

		public void DeleteCriticalSection(CriticalSection criticalSection)
		{
			btThreadSupportInterface_deleteCriticalSection(_native, criticalSection._native);
		}

		public IntPtr GetThreadLocalMemory(int taskId)
		{
			return btThreadSupportInterface_getThreadLocalMemory(_native, taskId);
		}

		public void SendRequest(uint uiCommand, uint uiArgument0, uint uiArgument1)
		{
			btThreadSupportInterface_sendRequest(_native, uiCommand, uiArgument0, uiArgument1);
		}

		public void StartSpu()
		{
			btThreadSupportInterface_startSPU(_native);
		}

		public void StopSpu()
		{
			btThreadSupportInterface_stopSPU(_native);
		}

        public void WaitForResponse(IntPtr puiArgument0, IntPtr puiArgument1)
		{
			btThreadSupportInterface_waitForResponse(_native, puiArgument0, puiArgument1);
		}

		public int NumTasks
		{
			get { return btThreadSupportInterface_getNumTasks(_native); }
			set { btThreadSupportInterface_setNumTasks(_native, value); }
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
				btThreadSupportInterface_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ThreadSupportInterface()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btThreadSupportInterface_createBarrier(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btThreadSupportInterface_createCriticalSection(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_deleteBarrier(IntPtr obj, IntPtr barrier);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_deleteCriticalSection(IntPtr obj, IntPtr criticalSection);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btThreadSupportInterface_getNumTasks(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btThreadSupportInterface_getThreadLocalMemory(IntPtr obj, int taskId);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_sendRequest(IntPtr obj, uint uiCommand, uint uiArgument0, uint uiArgument1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_setNumTasks(IntPtr obj, int numTasks);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_startSPU(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_stopSPU(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_waitForResponse(IntPtr obj, IntPtr puiArgument0, IntPtr puiArgument1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btThreadSupportInterface_delete(IntPtr obj);
	}
}
