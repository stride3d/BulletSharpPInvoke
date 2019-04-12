using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public class ActionInterface : IActionInterface
	{
		internal IntPtr _native;

		internal ActionInterface(IntPtr native)
		{
			_native = native;
		}

		public void DebugDraw(IDebugDraw debugDrawer)
		{
			btActionInterface_debugDraw(_native, BulletSharp.DebugDraw.GetUnmanaged(debugDrawer));
		}

		public void UpdateAction(CollisionWorld collisionWorld, float deltaTimeStep)
		{
			btActionInterface_updateAction(_native, collisionWorld._native, deltaTimeStep);
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
				btActionInterface_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ActionInterface()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btActionInterface_debugDraw(IntPtr obj, IntPtr debugDrawer);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btActionInterface_updateAction(IntPtr obj, IntPtr collisionWorld, float deltaTimeStep);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btActionInterface_delete(IntPtr obj);
	}
}
