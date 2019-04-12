using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class BulletWorldImporter : WorldImporter
	{
		internal BulletWorldImporter(IntPtr native)
			: base(native)
		{
		}

		public BulletWorldImporter(DynamicsWorld world)
			: base(btBulletWorldImporter_new(world._native))
		{
		}

		public BulletWorldImporter()
			: base(btBulletWorldImporter_new2())
		{
		}
        /*
		public bool ConvertAllObjects(btBulletFile file)
		{
			return btBulletWorldImporter_convertAllObjects(_native, file._native);
		}
        */
        public bool LoadFile(string fileName, string preSwapFilenameOut)
		{
			return btBulletWorldImporter_loadFile(_native, fileName, preSwapFilenameOut);
		}

        public bool LoadFile(string fileName)
		{
			return btBulletWorldImporter_loadFile2(_native, fileName);
		}
        /*
		public bool LoadFileFromMemory(char memoryBuffer, int len)
		{
			return btBulletWorldImporter_loadFileFromMemory(_native, memoryBuffer._native, len);
		}

		public bool LoadFileFromMemory(btBulletFile file)
		{
			return btBulletWorldImporter_loadFileFromMemory2(_native, file._native);
		}
        */
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBulletWorldImporter_new(IntPtr world);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBulletWorldImporter_new2();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btBulletWorldImporter_convertAllObjects(IntPtr obj, IntPtr file);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern bool btBulletWorldImporter_loadFile(IntPtr obj, string fileName, string preSwapFilenameOut);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern bool btBulletWorldImporter_loadFile2(IntPtr obj, string fileName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btBulletWorldImporter_loadFileFromMemory(IntPtr obj, IntPtr memoryBuffer, int len);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btBulletWorldImporter_loadFileFromMemory2(IntPtr obj, IntPtr file);
	}
}
