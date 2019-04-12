using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class KinematicCharacterController : CharacterControllerInterface
	{
		internal KinematicCharacterController(IntPtr native)
			: base(native)
		{
		}

		public KinematicCharacterController(PairCachingGhostObject ghostObject, ConvexShape convexShape, float stepHeight, Vector3 upAxis)
			: base(btKinematicCharacterController_new(ghostObject._native, convexShape._native, stepHeight, ref upAxis))
		{
		}

		public KinematicCharacterController(PairCachingGhostObject ghostObject, ConvexShape convexShape, float stepHeight)
			: base(btKinematicCharacterController_new2(ghostObject._native, convexShape._native, stepHeight))
		{
		}

		public void SetFallSpeed(float fallSpeed)
		{
			btKinematicCharacterController_setFallSpeed(_native, fallSpeed);
		}

		public void SetJumpSpeed(float jumpSpeed)
		{
			btKinematicCharacterController_setJumpSpeed(_native, jumpSpeed);
		}

		public void SetMaxJumpHeight(float maxJumpHeight)
		{
			btKinematicCharacterController_setMaxJumpHeight(_native, maxJumpHeight);
		}

//		public void SetUpAxis(int axis)
//		{
//			btKinematicCharacterController_setUpAxis(_native, axis);
//		}

		public void SetUseGhostSweepTest(bool useGhostObjectSweepTest)
		{
			btKinematicCharacterController_setUseGhostSweepTest(_native, useGhostObjectSweepTest);
		}

		public PairCachingGhostObject GhostObject => CollisionObject.GetManaged(btKinematicCharacterController_getGhostObject(_native)) as PairCachingGhostObject;

	    public Vector3 Gravity
		{
			//get { return btKinematicCharacterController_getGravity(_native); }
			set { btKinematicCharacterController_setGravity(_native, ref value); }
		}

		public float MaxSlope
		{
			get { return btKinematicCharacterController_getMaxSlope(_native); }
			set { btKinematicCharacterController_setMaxSlope(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btKinematicCharacterController_new(IntPtr ghostObject, IntPtr convexShape, float stepHeight, [In] ref Vector3 upAxis);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btKinematicCharacterController_new2(IntPtr ghostObject, IntPtr convexShape, float stepHeight);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btKinematicCharacterController_getGhostObject(IntPtr obj);
//		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
//		static extern float btKinematicCharacterController_getGravity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btKinematicCharacterController_getMaxSlope(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btKinematicCharacterController_setFallSpeed(IntPtr obj, float fallSpeed);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btKinematicCharacterController_setGravity(IntPtr obj, [In] ref Vector3 gravity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btKinematicCharacterController_setJumpSpeed(IntPtr obj, float jumpSpeed);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btKinematicCharacterController_setMaxJumpHeight(IntPtr obj, float maxJumpHeight);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btKinematicCharacterController_setMaxSlope(IntPtr obj, float slopeRadians);
//		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
//		static extern void btKinematicCharacterController_setUpAxis(IntPtr obj, int axis);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btKinematicCharacterController_setUseGhostSweepTest(IntPtr obj, bool useGhostObjectSweepTest);
	}
}
