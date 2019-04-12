using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class BulletFile : bFile
	{
		internal BulletFile(IntPtr native)
			: base(native)
		{
		}

		public BulletFile()
			: base(btBulletFile_new())
		{
		}
        /*
		public BulletFile(char fileName)
			: base(btBulletFile_new2(fileName._native))
		{
		}

		public BulletFile(char memoryBuffer, int len)
			: base(btBulletFile_new3(memoryBuffer._native, len))
		{
		}

		public void AddStruct(char structType, IntPtr data, int len, IntPtr oldPtr, int code)
		{
			btBulletFile_addStruct(_native, structType._native, data, len, oldPtr, code);
		}
        */
		public void ParseData()
		{
			btBulletFile_parseData(_native);
		}
        /*
		public void Bvhs
		{
			get { return btBulletFile_getBvhs(_native); }
		}

		public void CollisionObjects
		{
			get { return btBulletFile_getCollisionObjects(_native); }
		}

		public void CollisionShapes
		{
			get { return btBulletFile_getCollisionShapes(_native); }
		}

		public void Constraints
		{
			get { return btBulletFile_getConstraints(_native); }
		}

		public void DataBlocks
		{
			get { return btBulletFile_getDataBlocks(_native); }
		}

		public void DynamicsWorldInfo
		{
			get { return btBulletFile_getDynamicsWorldInfo(_native); }
		}

		public void RigidBodies
		{
			get { return btBulletFile_getRigidBodies(_native); }
		}

		public void SoftBodies
		{
			get { return btBulletFile_getSoftBodies(_native); }
		}

		public void TriangleInfoMaps
		{
			get { return btBulletFile_getTriangleInfoMaps(_native); }
		}
        */
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBulletFile_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBulletFile_new2(IntPtr fileName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btBulletFile_new3(IntPtr memoryBuffer, int len);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_addStruct(IntPtr obj, IntPtr structType, IntPtr data, int len, IntPtr oldPtr, int code);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getBvhs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getCollisionObjects(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getCollisionShapes(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getConstraints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getDataBlocks(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getDynamicsWorldInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getRigidBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getSoftBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_getTriangleInfoMaps(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btBulletFile_parseData(IntPtr obj);
	}
}
