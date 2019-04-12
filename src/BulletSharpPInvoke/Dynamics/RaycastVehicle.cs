using Xenko.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public class VehicleTuning
    {
        internal IntPtr _native;

        internal VehicleTuning(IntPtr native)
        {
            _native = native;
        }

        public VehicleTuning()
        {
            _native = btRaycastVehicle_btVehicleTuning_new();
        }

        public float FrictionSlip
        {
            get { return btRaycastVehicle_btVehicleTuning_getFrictionSlip(_native); }
            set { btRaycastVehicle_btVehicleTuning_setFrictionSlip(_native, value); }
        }

        public float MaxSuspensionForce
        {
            get { return btRaycastVehicle_btVehicleTuning_getMaxSuspensionForce(_native); }
            set { btRaycastVehicle_btVehicleTuning_setMaxSuspensionForce(_native, value); }
        }

        public float MaxSuspensionTravelCm
        {
            get { return btRaycastVehicle_btVehicleTuning_getMaxSuspensionTravelCm(_native); }
            set { btRaycastVehicle_btVehicleTuning_setMaxSuspensionTravelCm(_native, value); }
        }

        public float SuspensionCompression
        {
            get { return btRaycastVehicle_btVehicleTuning_getSuspensionCompression(_native); }
            set { btRaycastVehicle_btVehicleTuning_setSuspensionCompression(_native, value); }
        }

        public float SuspensionDamping
        {
            get { return btRaycastVehicle_btVehicleTuning_getSuspensionDamping(_native); }
            set { btRaycastVehicle_btVehicleTuning_setSuspensionDamping(_native, value); }
        }

        public float SuspensionStiffness
        {
            get { return btRaycastVehicle_btVehicleTuning_getSuspensionStiffness(_native); }
            set { btRaycastVehicle_btVehicleTuning_setSuspensionStiffness(_native, value); }
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
                btRaycastVehicle_btVehicleTuning_delete(_native);
                _native = IntPtr.Zero;
            }
        }

        ~VehicleTuning()
        {
            Dispose(false);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btRaycastVehicle_btVehicleTuning_new();
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btRaycastVehicle_btVehicleTuning_getFrictionSlip(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btRaycastVehicle_btVehicleTuning_getMaxSuspensionForce(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btRaycastVehicle_btVehicleTuning_getMaxSuspensionTravelCm(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btRaycastVehicle_btVehicleTuning_getSuspensionCompression(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btRaycastVehicle_btVehicleTuning_getSuspensionDamping(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btRaycastVehicle_btVehicleTuning_getSuspensionStiffness(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_setFrictionSlip(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_setMaxSuspensionForce(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_setMaxSuspensionTravelCm(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_setSuspensionCompression(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_setSuspensionDamping(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_setSuspensionStiffness(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btRaycastVehicle_btVehicleTuning_delete(IntPtr obj);
    }
    
    public class RaycastVehicle : ActionInterface
	{
        List<WheelInfo> _wheelInfo = new List<WheelInfo>();
        VehicleRaycaster _rayCaster;

		public RaycastVehicle(VehicleTuning tuning, RigidBody chassis, VehicleRaycaster raycaster)
			: base(btRaycastVehicle_new(tuning._native, chassis._native, raycaster._native))
		{
            _rayCaster = raycaster;
		}

		public WheelInfo AddWheel(Vector3 connectionPointCS0, Vector3 wheelDirectionCS0, Vector3 wheelAxleCS, float suspensionRestLength, float wheelRadius, VehicleTuning tuning, bool isFrontWheel)
		{
            WheelInfo wheelInfo = new WheelInfo(btRaycastVehicle_addWheel(_native, ref connectionPointCS0, ref wheelDirectionCS0, ref wheelAxleCS, suspensionRestLength, wheelRadius, tuning._native, isFrontWheel));
            _wheelInfo.Add(wheelInfo);
            return wheelInfo;
		}

		public void ApplyEngineForce(float force, int wheel)
		{
			btRaycastVehicle_applyEngineForce(_native, force, wheel);
		}

		public float GetSteeringValue(int wheel)
		{
			return btRaycastVehicle_getSteeringValue(_native, wheel);
		}

		public WheelInfo GetWheelInfo(int index)
		{
            return _wheelInfo[index];
		}

		public Matrix GetWheelTransformWS(int wheelIndex)
		{
            Matrix value;
			btRaycastVehicle_getWheelTransformWS(_native, wheelIndex, out value);
            return value;
		}

		public float RayCast(WheelInfo wheel)
		{
			return btRaycastVehicle_rayCast(_native, wheel._native);
		}

		public void ResetSuspension()
		{
			btRaycastVehicle_resetSuspension(_native);
		}

		public void SetBrake(float brake, int wheelIndex)
		{
			btRaycastVehicle_setBrake(_native, brake, wheelIndex);
		}

		public void SetCoordinateSystem(int rightIndex, int upIndex, int forwardIndex)
		{
			btRaycastVehicle_setCoordinateSystem(_native, rightIndex, upIndex, forwardIndex);
		}

		public void SetPitchControl(float pitch)
		{
			btRaycastVehicle_setPitchControl(_native, pitch);
		}

		public void SetSteeringValue(float steering, int wheel)
		{
			btRaycastVehicle_setSteeringValue(_native, steering, wheel);
		}

		public void UpdateFriction(float timeStep)
		{
			btRaycastVehicle_updateFriction(_native, timeStep);
		}

		public void UpdateSuspension(float deltaTime)
		{
			btRaycastVehicle_updateSuspension(_native, deltaTime);
		}

		public void UpdateVehicle(float step)
		{
			btRaycastVehicle_updateVehicle(_native, step);
		}

		public void UpdateWheelTransform(int wheelIndex, bool interpolatedTransform)
		{
			btRaycastVehicle_updateWheelTransform(_native, wheelIndex, interpolatedTransform);
		}

		public void UpdateWheelTransform(int wheelIndex)
		{
			btRaycastVehicle_updateWheelTransform2(_native, wheelIndex);
		}

		public void UpdateWheelTransformsWS(WheelInfo wheel, bool interpolatedTransform)
		{
			btRaycastVehicle_updateWheelTransformsWS(_native, wheel._native, interpolatedTransform);
		}

		public void UpdateWheelTransformsWS(WheelInfo wheel)
		{
			btRaycastVehicle_updateWheelTransformsWS2(_native, wheel._native);
		}

		public Matrix ChassisWorldTransform
		{
			get
			{
				Matrix value;
				btRaycastVehicle_getChassisWorldTransform(_native, out value);
				return value;
			}
		}

		public float CurrentSpeedKmHour
		{
			get { return btRaycastVehicle_getCurrentSpeedKmHour(_native); }
		}

		public int ForwardAxis
		{
			get { return btRaycastVehicle_getForwardAxis(_native); }
		}

        public Vector3 ForwardVector
		{
            get
			{
				Vector3 value;
				btRaycastVehicle_getForwardVector(_native, out value);
				return value;
			}
		}

		public int NumWheels
		{
            get { return _wheelInfo.Count; }
		}

		public int RightAxis
		{
            get { return btRaycastVehicle_getRightAxis(_native); }
		}

		public RigidBody RigidBody
		{
            get { return CollisionObject.GetManaged(btRaycastVehicle_getRigidBody(_native)) as RigidBody; }
		}

		public int UpAxis
		{
			get { return btRaycastVehicle_getUpAxis(_native); }
		}

		public int UserConstraintId
		{
			get { return btRaycastVehicle_getUserConstraintId(_native); }
			set { btRaycastVehicle_setUserConstraintId(_native, value); }
		}

		public int UserConstraintType
		{
			get { return btRaycastVehicle_getUserConstraintType(_native); }
			set { btRaycastVehicle_setUserConstraintType(_native, value); }
		}
        /*
        public AlignedWheelInfoArray WheelInfo
		{
            get { return new AlignedWheelInfoArray(btRaycastVehicle_getWheelInfo2(_native)); }
			//set { btRaycastVehicle_setWheelInfo(_native, value._native); }
		}
        */
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btRaycastVehicle_new(IntPtr tuning, IntPtr chassis, IntPtr raycaster);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btRaycastVehicle_addWheel(IntPtr obj, [In] ref Vector3 connectionPointCS0, [In] ref Vector3 wheelDirectionCS0, [In] ref Vector3 wheelAxleCS, float suspensionRestLength, float wheelRadius, IntPtr tuning, bool isFrontWheel);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_applyEngineForce(IntPtr obj, float force, int wheel);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_getChassisWorldTransform(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btRaycastVehicle_getCurrentSpeedKmHour(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btRaycastVehicle_getForwardAxis(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_getForwardVector(IntPtr obj, [Out] out Vector3 value);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btRaycastVehicle_getRightAxis(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btRaycastVehicle_getRigidBody(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btRaycastVehicle_getSteeringValue(IntPtr obj, int wheel);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btRaycastVehicle_getUpAxis(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btRaycastVehicle_getUserConstraintId(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btRaycastVehicle_getUserConstraintType(IntPtr obj);

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_getWheelTransformWS(IntPtr obj, int wheelIndex, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btRaycastVehicle_rayCast(IntPtr obj, IntPtr wheel);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_resetSuspension(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_setBrake(IntPtr obj, float brake, int wheelIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_setCoordinateSystem(IntPtr obj, int rightIndex, int upIndex, int forwardIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_setPitchControl(IntPtr obj, float pitch);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_setSteeringValue(IntPtr obj, float steering, int wheel);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_setUserConstraintId(IntPtr obj, int uid);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_setUserConstraintType(IntPtr obj, int userConstraintType);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btRaycastVehicle_setWheelInfo(IntPtr obj, AlignedObjectArray<btWheelInfo> value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateFriction(IntPtr obj, float timeStep);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateSuspension(IntPtr obj, float deltaTime);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateVehicle(IntPtr obj, float step);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateWheelTransform(IntPtr obj, int wheelIndex, bool interpolatedTransform);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateWheelTransform2(IntPtr obj, int wheelIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateWheelTransformsWS(IntPtr obj, IntPtr wheel, bool interpolatedTransform);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btRaycastVehicle_updateWheelTransformsWS2(IntPtr obj, IntPtr wheel);
	}

	public class DefaultVehicleRaycaster : VehicleRaycaster
	{
		internal DefaultVehicleRaycaster(IntPtr native)
			: base(native)
		{
		}

		public DefaultVehicleRaycaster(DynamicsWorld world)
			: base(btDefaultVehicleRaycaster_new(world._native))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultVehicleRaycaster_new(IntPtr world);
	}
}
