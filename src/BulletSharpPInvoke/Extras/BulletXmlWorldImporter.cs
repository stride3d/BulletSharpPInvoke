using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class BulletXmlWorldImporter
	{
		internal IntPtr _native;

		internal BulletXmlWorldImporter(IntPtr native)
		{
			_native = native;
		}

		public BulletXmlWorldImporter(DynamicsWorld world)
		{
			_native = btBulletXmlWorldImporter_new(world._native);
		}

		public bool LoadFile(string fileName)
		{
			return btBulletXmlWorldImporter_loadFile(_native, fileName);
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
				btBulletXmlWorldImporter_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~BulletXmlWorldImporter()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBulletXmlWorldImporter_new(IntPtr world);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btBulletXmlWorldImporter_loadFile(IntPtr obj, string fileName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletXmlWorldImporter_delete(IntPtr obj);
	}
}
