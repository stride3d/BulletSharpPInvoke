using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp.SoftBody
{
	public class SoftRigidDynamicsWorld : DiscreteDynamicsWorld
	{
		internal SoftRigidDynamicsWorld(IntPtr native)
			: base(native)
		{
		}
        /*
		public SoftRigidDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache, ConstraintSolver constraintSolver, CollisionConfiguration collisionConfiguration, SoftBodySolver softBodySolver)
			: base(btSoftRigidDynamicsWorld_new(dispatcher._native, pairCache._native, constraintSolver._native, collisionConfiguration._native, softBodySolver._native))
		{
		}
        */
		public SoftRigidDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache, ConstraintSolver constraintSolver, CollisionConfiguration collisionConfiguration)
			: base(btSoftRigidDynamicsWorld_new2(dispatcher._native, pairCache._native, constraintSolver._native, collisionConfiguration._native))
		{
		}

		public void AddSoftBody(SoftBody body, short collisionFilterGroup, short collisionFilterMask)
		{
			btSoftRigidDynamicsWorld_addSoftBody(_native, body._native, collisionFilterGroup, collisionFilterMask);
		}

		public void AddSoftBody(SoftBody body, short collisionFilterGroup)
		{
			btSoftRigidDynamicsWorld_addSoftBody2(_native, body._native, collisionFilterGroup);
		}

		public void AddSoftBody(SoftBody body)
		{
			btSoftRigidDynamicsWorld_addSoftBody3(_native, body._native);
		}

		public void RemoveSoftBody(SoftBody body)
		{
			btSoftRigidDynamicsWorld_removeSoftBody(_native, body._native);
		}

		public int DrawFlags
		{
			get { return btSoftRigidDynamicsWorld_getDrawFlags(_native); }
			set { btSoftRigidDynamicsWorld_setDrawFlags(_native, value); }
		}
        /*
		public SoftBodyArray SoftBodyArray
		{
			get { return btSoftRigidDynamicsWorld_getSoftBodyArray(_native); }
		}
        */
		public SoftBodyWorldInfo WorldInfo
		{
            get { return new SoftBodyWorldInfo(btSoftRigidDynamicsWorld_getWorldInfo(_native)); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftRigidDynamicsWorld_new(IntPtr dispatcher, IntPtr pairCache, IntPtr constraintSolver, IntPtr collisionConfiguration, IntPtr softBodySolver);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftRigidDynamicsWorld_new2(IntPtr dispatcher, IntPtr pairCache, IntPtr constraintSolver, IntPtr collisionConfiguration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftRigidDynamicsWorld_addSoftBody(IntPtr obj, IntPtr body, short collisionFilterGroup, short collisionFilterMask);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftRigidDynamicsWorld_addSoftBody2(IntPtr obj, IntPtr body, short collisionFilterGroup);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftRigidDynamicsWorld_addSoftBody3(IntPtr obj, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftRigidDynamicsWorld_getDrawFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftRigidDynamicsWorld_getSoftBodyArray(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftRigidDynamicsWorld_getWorldInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftRigidDynamicsWorld_removeSoftBody(IntPtr obj, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftRigidDynamicsWorld_setDrawFlags(IntPtr obj, int f);
	}
}
