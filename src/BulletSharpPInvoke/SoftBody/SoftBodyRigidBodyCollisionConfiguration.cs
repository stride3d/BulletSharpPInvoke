using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class SoftBodyRigidBodyCollisionConfiguration : DefaultCollisionConfiguration
	{
		internal SoftBodyRigidBodyCollisionConfiguration(IntPtr native)
			: base(native)
		{
		}

		public SoftBodyRigidBodyCollisionConfiguration(DefaultCollisionConstructionInfo constructionInfo)
			: base(btSoftBodyRigidBodyCollisionConfiguration_new(constructionInfo._native))
		{
		}

		public SoftBodyRigidBodyCollisionConfiguration()
			: base(btSoftBodyRigidBodyCollisionConfiguration_new2())
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBodyRigidBodyCollisionConfiguration_new(IntPtr constructionInfo);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBodyRigidBodyCollisionConfiguration_new2();
	}
}
