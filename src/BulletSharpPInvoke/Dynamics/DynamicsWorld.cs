using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public enum DynamicsWorldType
    {
        Simple = 1,
        Discrete = 2,
        Continuous = 3,
        SoftRigid = 4,
        Gpu = 5
    }

	public class DynamicsWorld : CollisionWorld
	{
        public delegate void InternalTickCallback(DynamicsWorld world, float timeStep);
        
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        public delegate void InternalTickCallbackUnmanaged(IntPtr world, float timeStep);

        internal InternalTickCallback _callback;
        internal InternalTickCallbackUnmanaged _callbackUnmanaged;
        protected ConstraintSolver _solver;

		internal DynamicsWorld(IntPtr native)
			: base(native)
		{
		}

		public void AddAction(IActionInterface action)
		{
            if (action is ActionInterface)
            {
                btDynamicsWorld_addAction(_native, (action as ActionInterface)._native);
            }
            else
            {
                throw new NotImplementedException();
            }
		}

		public void AddCharacter(ActionInterface character)
		{
			btDynamicsWorld_addCharacter(_native, character._native);
		}

		public void AddConstraint(TypedConstraint constraint, bool disableCollisionsBetweenLinkedBodies)
		{
			btDynamicsWorld_addConstraint(_native, constraint._native, disableCollisionsBetweenLinkedBodies);
		}

		public void AddConstraint(TypedConstraint constraint)
		{
			btDynamicsWorld_addConstraint2(_native, constraint._native);
		}

		public void AddRigidBody(RigidBody body)
		{
			btDynamicsWorld_addRigidBody(_native, body._native);
		}

		public void AddRigidBody(RigidBody body, short group, short mask)
		{
			btDynamicsWorld_addRigidBody2(_native, body._native, group, mask);
		}

		public void AddVehicle(ActionInterface vehicle)
		{
			btDynamicsWorld_addVehicle(_native, vehicle._native);
		}

		public void ClearForces()
		{
			btDynamicsWorld_clearForces(_native);
		}

		public TypedConstraint GetConstraint(int index)
		{
            return TypedConstraint.GetManaged(btDynamicsWorld_getConstraint(_native, index));
		}

		public void RemoveAction(ActionInterface action)
		{
			btDynamicsWorld_removeAction(_native, action._native);
		}

		public void RemoveCharacter(ActionInterface character)
		{
			btDynamicsWorld_removeCharacter(_native, character._native);
		}

		public void RemoveConstraint(TypedConstraint constraint)
		{
			btDynamicsWorld_removeConstraint(_native, constraint._native);
		}

		public void RemoveRigidBody(RigidBody body)
		{
			btDynamicsWorld_removeRigidBody(_native, body._native);
		}

		public void RemoveVehicle(ActionInterface vehicle)
		{
			btDynamicsWorld_removeVehicle(_native, vehicle._native);
		}

        private void InternalTickCallbackNative(IntPtr world, float timeStep)
        {
            IntPtr nativeUserInfo = btDynamicsWorld_getWorldUserInfo(_native);
            DynamicsWorld worldManaged = GCHandle.FromIntPtr(nativeUserInfo).Target as DynamicsWorld;
            worldManaged._callback(worldManaged, timeStep);
        }

		public void SetInternalTickCallback(InternalTickCallback cb, Object worldUserInfo, bool isPreTick)
		{
            if (_callback != cb)
            {
                if (cb != null)
                {
                    _callback = cb;
                    _callbackUnmanaged = new InternalTickCallbackUnmanaged(InternalTickCallbackNative);
                }
                else
                {
                    _callback = null;
                    _callbackUnmanaged = null;
                }
            }

	        WorldUserInfo = worldUserInfo;

            IntPtr nativeUserInfo = btDynamicsWorld_getWorldUserInfo(_native);
	        if (cb != null) {
		        if (nativeUserInfo == IntPtr.Zero) {
			        GCHandle handle = GCHandle.Alloc(this, GCHandleType.Weak);
			        nativeUserInfo = GCHandle.ToIntPtr(handle);
		        }
                btDynamicsWorld_setInternalTickCallback(_native,
                    Marshal.GetFunctionPointerForDelegate(_callbackUnmanaged),
                    nativeUserInfo, isPreTick);
	        } else {
		        if (nativeUserInfo != IntPtr.Zero) {
                    GCHandle.FromIntPtr(nativeUserInfo).Free();
		        }
                btDynamicsWorld_setInternalTickCallback(_native, IntPtr.Zero, IntPtr.Zero, isPreTick);
	        }
		}

		public void SetInternalTickCallback(InternalTickCallback cb, Object worldUserInfo)
		{
            SetInternalTickCallback(cb, worldUserInfo, false);
		}

		public void SetInternalTickCallback(InternalTickCallback cb)
		{
            SetInternalTickCallback(cb, WorldUserInfo, false);
		}

		public int StepSimulation(float timeStep, int maxSubSteps, float fixedTimeStep)
		{
			return btDynamicsWorld_stepSimulation(_native, timeStep, maxSubSteps, fixedTimeStep);
		}

		public int StepSimulation(float timeStep, int maxSubSteps)
		{
			return btDynamicsWorld_stepSimulation2(_native, timeStep, maxSubSteps);
		}

		public int StepSimulation(float timeStep)
		{
			return btDynamicsWorld_stepSimulation3(_native, timeStep);
		}

		public void SynchronizeMotionStates()
		{
			btDynamicsWorld_synchronizeMotionStates(_native);
		}

		public ConstraintSolver ConstraintSolver
		{
            get
            {
                if (_solver == null)
                {
                    _solver = new ConstraintSolver(btDynamicsWorld_getConstraintSolver(_native), true);
                }
                return _solver;
            }
            set
            {
                _solver = value;
                btDynamicsWorld_setConstraintSolver(_native, value._native);
            }
		}

        public Vector3 Gravity
        {
            get
            {
                Vector3 gravity;
                btDynamicsWorld_getGravity(_native, out gravity);
                return gravity;
            }
            set { btDynamicsWorld_setGravity(_native, ref value); }
        }

		public int NumConstraints
		{
			get { return btDynamicsWorld_getNumConstraints(_native); }
		}

		public ContactSolverInfo SolverInfo
		{
            get { return new ContactSolverInfo(btDynamicsWorld_getSolverInfo(_native)); }
		}

		public DynamicsWorldType WorldType
		{
			get { return btDynamicsWorld_getWorldType(_native); }
		}

        public Object WorldUserInfo { get; set; }

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addAction(IntPtr obj, IntPtr action);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addCharacter(IntPtr obj, IntPtr character);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addConstraint(IntPtr obj, IntPtr constraint, bool disableCollisionsBetweenLinkedBodies);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addConstraint2(IntPtr obj, IntPtr constraint);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addRigidBody(IntPtr obj, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addRigidBody2(IntPtr obj, IntPtr body, short group, short mask);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_addVehicle(IntPtr obj, IntPtr vehicle);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_clearForces(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDynamicsWorld_getConstraint(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDynamicsWorld_getConstraintSolver(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_getGravity(IntPtr obj, [Out] out Vector3 gravity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDynamicsWorld_getNumConstraints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDynamicsWorld_getSolverInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern DynamicsWorldType btDynamicsWorld_getWorldType(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDynamicsWorld_getWorldUserInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_removeAction(IntPtr obj, IntPtr action);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_removeCharacter(IntPtr obj, IntPtr character);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_removeConstraint(IntPtr obj, IntPtr constraint);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_removeRigidBody(IntPtr obj, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_removeVehicle(IntPtr obj, IntPtr vehicle);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_setConstraintSolver(IntPtr obj, IntPtr solver);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_setGravity(IntPtr obj, [In] ref Vector3 gravity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_setInternalTickCallback(IntPtr obj, IntPtr cb, IntPtr worldUserInfo, bool isPreTick);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDynamicsWorld_stepSimulation(IntPtr obj, float timeStep, int maxSubSteps, float fixedTimeStep);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDynamicsWorld_stepSimulation2(IntPtr obj, float timeStep, int maxSubSteps);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDynamicsWorld_stepSimulation3(IntPtr obj, float timeStep);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDynamicsWorld_synchronizeMotionStates(IntPtr obj);
	}
}
