using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class DiscreteDynamicsWorld : DynamicsWorld
	{
		private SimulationIslandManager _simulationIslandManager;

		internal DiscreteDynamicsWorld(IntPtr native)
			: base(native)
		{
		}

        public DiscreteDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache, ConstraintSolver solver, CollisionConfiguration collisionConfiguration)
            : base(btDiscreteDynamicsWorld_new(
            dispatcher != null ? dispatcher._native : IntPtr.Zero,
            pairCache != null ? pairCache._native : IntPtr.Zero,
            solver != null ? solver._native : IntPtr.Zero,
            collisionConfiguration != null ? collisionConfiguration._native : IntPtr.Zero))
        {
            _collisionConfiguration = collisionConfiguration;
            _dispatcher = dispatcher;
            _broadphase = pairCache;
            _solver = solver;
        }

		public void ApplyGravity()
		{
			btDiscreteDynamicsWorld_applyGravity(_native);
		}

		public void DebugDrawConstraint(TypedConstraint constraint)
		{
			btDiscreteDynamicsWorld_debugDrawConstraint(_native, constraint._native);
		}

		public void SetNumTasks(int numTasks)
		{
			btDiscreteDynamicsWorld_setNumTasks(_native, numTasks);
		}

		public void SynchronizeSingleMotionState(RigidBody body)
		{
			btDiscreteDynamicsWorld_synchronizeSingleMotionState(_native, body._native);
		}

		public void UpdateVehicles(float timeStep)
		{
			btDiscreteDynamicsWorld_updateVehicles(_native, timeStep);
		}

		public bool ApplySpeculativeContactRestitution
		{
			get { return btDiscreteDynamicsWorld_getApplySpeculativeContactRestitution(_native); }
			set { btDiscreteDynamicsWorld_setApplySpeculativeContactRestitution(_native, value); }
		}
        /*
		public CollisionWorld CollisionWorld
		{
			get { return btDiscreteDynamicsWorld_getCollisionWorld(_native); }
		}
        */
		public bool LatencyMotionStateInterpolation
		{
			get { return btDiscreteDynamicsWorld_getLatencyMotionStateInterpolation(_native); }
			set { btDiscreteDynamicsWorld_setLatencyMotionStateInterpolation(_native, value); }
		}

		public SimulationIslandManager SimulationIslandManager
		{
			get
			{
				if (_simulationIslandManager == null)
				{
					_simulationIslandManager = new SimulationIslandManager(btDiscreteDynamicsWorld_getSimulationIslandManager(_native));
				}
				return _simulationIslandManager;
			}
		}

		public bool SynchronizeAllMotionStates
		{
			get { return btDiscreteDynamicsWorld_getSynchronizeAllMotionStates(_native); }
			set { btDiscreteDynamicsWorld_setSynchronizeAllMotionStates(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDiscreteDynamicsWorld_new(IntPtr dispatcher, IntPtr pairCache, IntPtr constraintSolver, IntPtr collisionConfiguration);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_applyGravity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_debugDrawConstraint(IntPtr obj, IntPtr constraint);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btDiscreteDynamicsWorld_getApplySpeculativeContactRestitution(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.I1)]
		static extern bool btDiscreteDynamicsWorld_getLatencyMotionStateInterpolation(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDiscreteDynamicsWorld_getSimulationIslandManager(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btDiscreteDynamicsWorld_getSynchronizeAllMotionStates(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_setApplySpeculativeContactRestitution(IntPtr obj, bool enable);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btDiscreteDynamicsWorld_setLatencyMotionStateInterpolation(IntPtr obj, bool latencyInterpolation);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_setNumTasks(IntPtr obj, int numTasks);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_setSynchronizeAllMotionStates(IntPtr obj, bool synchronizeAll);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_synchronizeSingleMotionState(IntPtr obj, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDiscreteDynamicsWorld_updateVehicles(IntPtr obj, float timeStep);
	}
}
