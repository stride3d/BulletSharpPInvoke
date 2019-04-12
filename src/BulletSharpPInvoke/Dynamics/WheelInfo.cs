using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class WheelInfoConstructionInfo
	{
		internal IntPtr _native;

		internal WheelInfoConstructionInfo(IntPtr native)
		{
			_native = native;
		}

		public WheelInfoConstructionInfo()
		{
			_native = btWheelInfoConstructionInfo_new();
		}

		public bool IsFrontWheel
		{
			get { return btWheelInfoConstructionInfo_getBIsFrontWheel(_native); }
			set { btWheelInfoConstructionInfo_setBIsFrontWheel(_native, value); }
		}

		public Vector3 ChassisConnectionCS
		{
            get
			{
				Vector3 value;
				btWheelInfoConstructionInfo_getChassisConnectionCS(_native, out value);
				return value;
			}
			set { btWheelInfoConstructionInfo_setChassisConnectionCS(_native, ref value); }
		}

		public float FrictionSlip
		{
			get { return btWheelInfoConstructionInfo_getFrictionSlip(_native); }
			set { btWheelInfoConstructionInfo_setFrictionSlip(_native, value); }
		}

		public float MaxSuspensionForce
		{
			get { return btWheelInfoConstructionInfo_getMaxSuspensionForce(_native); }
			set { btWheelInfoConstructionInfo_setMaxSuspensionForce(_native, value); }
		}

		public float MaxSuspensionTravelCm
		{
			get { return btWheelInfoConstructionInfo_getMaxSuspensionTravelCm(_native); }
			set { btWheelInfoConstructionInfo_setMaxSuspensionTravelCm(_native, value); }
		}

		public float SuspensionRestLength
		{
			get { return btWheelInfoConstructionInfo_getSuspensionRestLength(_native); }
			set { btWheelInfoConstructionInfo_setSuspensionRestLength(_native, value); }
		}

		public float SuspensionStiffness
		{
			get { return btWheelInfoConstructionInfo_getSuspensionStiffness(_native); }
			set { btWheelInfoConstructionInfo_setSuspensionStiffness(_native, value); }
		}

        public Vector3 WheelAxleCS
		{
            get
			{
				Vector3 value;
				btWheelInfoConstructionInfo_getWheelAxleCS(_native, out value);
				return value;
			}
			set { btWheelInfoConstructionInfo_setWheelAxleCS(_native, ref value); }
		}

        public Vector3 WheelDirectionCS
		{
            get
			{
				Vector3 value;
				btWheelInfoConstructionInfo_getWheelDirectionCS(_native, out value);
				return value;
			}
			set { btWheelInfoConstructionInfo_setWheelDirectionCS(_native, ref value); }
		}

		public float WheelRadius
		{
			get { return btWheelInfoConstructionInfo_getWheelRadius(_native); }
			set { btWheelInfoConstructionInfo_setWheelRadius(_native, value); }
		}

		public float WheelsDampingCompression
		{
			get { return btWheelInfoConstructionInfo_getWheelsDampingCompression(_native); }
			set { btWheelInfoConstructionInfo_setWheelsDampingCompression(_native, value); }
		}

		public float WheelsDampingRelaxation
		{
			get { return btWheelInfoConstructionInfo_getWheelsDampingRelaxation(_native); }
			set { btWheelInfoConstructionInfo_setWheelsDampingRelaxation(_native, value); }
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
				btWheelInfoConstructionInfo_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~WheelInfoConstructionInfo()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWheelInfoConstructionInfo_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btWheelInfoConstructionInfo_getBIsFrontWheel(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_getChassisConnectionCS(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getFrictionSlip(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getMaxSuspensionForce(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getMaxSuspensionTravelCm(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getSuspensionRestLength(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getSuspensionStiffness(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfoConstructionInfo_getWheelAxleCS(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfoConstructionInfo_getWheelDirectionCS(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getWheelRadius(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getWheelsDampingCompression(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfoConstructionInfo_getWheelsDampingRelaxation(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setBIsFrontWheel(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setChassisConnectionCS(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setFrictionSlip(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setMaxSuspensionForce(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setMaxSuspensionTravelCm(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setSuspensionRestLength(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setSuspensionStiffness(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfoConstructionInfo_setWheelAxleCS(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfoConstructionInfo_setWheelDirectionCS(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setWheelRadius(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setWheelsDampingCompression(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_setWheelsDampingRelaxation(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfoConstructionInfo_delete(IntPtr obj);
	}

    public class RaycastInfo
    {
        internal IntPtr _native;

        internal RaycastInfo(IntPtr native)
        {
            _native = native;
        }

        public RaycastInfo()
        {
            _native = btWheelInfo_RaycastInfo_new();
        }

        public Vector3 ContactNormalWS
        {
            get
			{
				Vector3 value;
				btWheelInfo_RaycastInfo_getContactNormalWS(_native, out value);
				return value;
			}
            set { btWheelInfo_RaycastInfo_setContactNormalWS(_native, ref value); }
        }

        public Vector3 ContactPointWS
        {
            get
			{
				Vector3 value;
				btWheelInfo_RaycastInfo_getContactPointWS(_native, out value);
				return value;
			}
            set { btWheelInfo_RaycastInfo_setContactPointWS(_native, ref value); }
        }

        public Object GroundObject
        {
            get { return CollisionObject.GetManaged(btWheelInfo_RaycastInfo_getGroundObject(_native)); }
            set { btWheelInfo_RaycastInfo_setGroundObject(_native, (value as CollisionObject)._native); }
        }

        public Vector3 HardPointWS
        {
            get
			{
				Vector3 value;
				btWheelInfo_RaycastInfo_getHardPointWS(_native, out value);
				return value;
			}
            set { btWheelInfo_RaycastInfo_setHardPointWS(_native, ref value); }
        }

        public bool IsInContact
        {
            get { return btWheelInfo_RaycastInfo_getIsInContact(_native); }
            set { btWheelInfo_RaycastInfo_setIsInContact(_native, value); }
        }

        public float SuspensionLength
        {
            get { return btWheelInfo_RaycastInfo_getSuspensionLength(_native); }
            set { btWheelInfo_RaycastInfo_setSuspensionLength(_native, value); }
        }

        public Vector3 WheelAxleWS
        {
            get
			{
				Vector3 value;
				btWheelInfo_RaycastInfo_getWheelAxleWS(_native, out value);
				return value;
			}
            set { btWheelInfo_RaycastInfo_setWheelAxleWS(_native, ref value); }
        }

        public Vector3 WheelDirectionWS
        {
            get
			{
				Vector3 value;
				btWheelInfo_RaycastInfo_getWheelDirectionWS(_native, out value);
				return value;
			}
            set { btWheelInfo_RaycastInfo_setWheelDirectionWS(_native, ref value); }
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
                btWheelInfo_RaycastInfo_delete(_native);
                _native = IntPtr.Zero;
            }
        }

        ~RaycastInfo()
        {
            Dispose(false);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWheelInfo_RaycastInfo_new();
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_getContactNormalWS(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_getContactPointWS(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btWheelInfo_RaycastInfo_getGroundObject(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_getHardPointWS(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.I1)]
		static extern bool btWheelInfo_RaycastInfo_getIsInContact(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern float btWheelInfo_RaycastInfo_getSuspensionLength(IntPtr obj);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_getWheelAxleWS(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_getWheelDirectionWS(IntPtr obj, [Out] out Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setContactNormalWS(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setContactPointWS(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setGroundObject(IntPtr obj, IntPtr value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setHardPointWS(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setIsInContact(IntPtr obj, bool value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setSuspensionLength(IntPtr obj, float value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setWheelAxleWS(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_setWheelDirectionWS(IntPtr obj, [In] ref Vector3 value);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_RaycastInfo_delete(IntPtr obj);
    }

	public class WheelInfo
	{
		internal IntPtr _native;
        bool _preventDelete;

		internal WheelInfo(IntPtr native, bool preventDelete = true)
		{
			_native = native;
            _preventDelete = preventDelete;
		}

		public WheelInfo(WheelInfoConstructionInfo ci)
		{
			_native = btWheelInfo_new(ci._native);
		}

		public void UpdateWheel(RigidBody chassis, RaycastInfo raycastInfo)
		{
			btWheelInfo_updateWheel(_native, chassis._native, raycastInfo._native);
		}

		public bool IsFrontWheel
		{
			get { return btWheelInfo_getBIsFrontWheel(_native); }
			set { btWheelInfo_setBIsFrontWheel(_native, value); }
		}

		public float Brake
		{
			get { return btWheelInfo_getBrake(_native); }
			set { btWheelInfo_setBrake(_native, value); }
		}

        public Vector3 ChassisConnectionPointCS
		{
            get
			{
				Vector3 value;
				btWheelInfo_getChassisConnectionPointCS(_native, out value);
				return value;
			}
			set { btWheelInfo_setChassisConnectionPointCS(_native, ref value); }
		}

		public IntPtr ClientInfo
		{
			get { return btWheelInfo_getClientInfo(_native); }
			set { btWheelInfo_setClientInfo(_native, value); }
		}

		public float ClippedInvContactDotSuspension
		{
			get { return btWheelInfo_getClippedInvContactDotSuspension(_native); }
			set { btWheelInfo_setClippedInvContactDotSuspension(_native, value); }
		}

		public float DeltaRotation
		{
			get { return btWheelInfo_getDeltaRotation(_native); }
			set { btWheelInfo_setDeltaRotation(_native, value); }
		}

		public float EngineForce
		{
			get { return btWheelInfo_getEngineForce(_native); }
			set { btWheelInfo_setEngineForce(_native, value); }
		}

		public float FrictionSlip
		{
			get { return btWheelInfo_getFrictionSlip(_native); }
			set { btWheelInfo_setFrictionSlip(_native, value); }
		}

		public float MaxSuspensionForce
		{
			get { return btWheelInfo_getMaxSuspensionForce(_native); }
			set { btWheelInfo_setMaxSuspensionForce(_native, value); }
		}

		public float MaxSuspensionTravelCm
		{
			get { return btWheelInfo_getMaxSuspensionTravelCm(_native); }
			set { btWheelInfo_setMaxSuspensionTravelCm(_native, value); }
		}

		public RaycastInfo RaycastInfo
		{
            get { return new RaycastInfo(btWheelInfo_getRaycastInfo(_native)); }
			set { btWheelInfo_setRaycastInfo(_native, value._native); }
		}

		public float RollInfluence
		{
			get { return btWheelInfo_getRollInfluence(_native); }
			set { btWheelInfo_setRollInfluence(_native, value); }
		}

		public float Rotation
		{
			get { return btWheelInfo_getRotation(_native); }
			set { btWheelInfo_setRotation(_native, value); }
		}

		public float SkidInfo
		{
			get { return btWheelInfo_getSkidInfo(_native); }
			set { btWheelInfo_setSkidInfo(_native, value); }
		}

		public float Steering
		{
			get { return btWheelInfo_getSteering(_native); }
			set { btWheelInfo_setSteering(_native, value); }
		}

		public float SuspensionRelativeVelocity
		{
			get { return btWheelInfo_getSuspensionRelativeVelocity(_native); }
			set { btWheelInfo_setSuspensionRelativeVelocity(_native, value); }
		}

		public float SuspensionRestLength
		{
			get { return btWheelInfo_getSuspensionRestLength(_native); }
		}

		public float SuspensionRestLength1
		{
			get { return btWheelInfo_getSuspensionRestLength1(_native); }
			set { btWheelInfo_setSuspensionRestLength1(_native, value); }
		}

		public float SuspensionStiffness
		{
			get { return btWheelInfo_getSuspensionStiffness(_native); }
			set { btWheelInfo_setSuspensionStiffness(_native, value); }
		}

        public Vector3 WheelAxleCS
		{
            get
			{
				Vector3 value;
				btWheelInfo_getWheelAxleCS(_native, out value);
				return value;
			}
			set { btWheelInfo_setWheelAxleCS(_native, ref value); }
		}

        public Vector3 WheelDirectionCS
		{
            get
			{
				Vector3 value;
				btWheelInfo_getWheelDirectionCS(_native, out value);
				return value;
			}
			set { btWheelInfo_setWheelDirectionCS(_native, ref value); }
		}

		public float WheelsDampingCompression
		{
			get { return btWheelInfo_getWheelsDampingCompression(_native); }
			set { btWheelInfo_setWheelsDampingCompression(_native, value); }
		}

		public float WheelsDampingRelaxation
		{
			get { return btWheelInfo_getWheelsDampingRelaxation(_native); }
			set { btWheelInfo_setWheelsDampingRelaxation(_native, value); }
		}

		public float WheelsRadius
		{
			get { return btWheelInfo_getWheelsRadius(_native); }
			set { btWheelInfo_setWheelsRadius(_native, value); }
		}

		public float WheelsSuspensionForce
		{
			get { return btWheelInfo_getWheelsSuspensionForce(_native); }
			set { btWheelInfo_setWheelsSuspensionForce(_native, value); }
		}

		public Matrix WorldTransform
		{
            get
			{
				Matrix value;
				btWheelInfo_getWorldTransform(_native, out value);
				return value;
			}
			set { btWheelInfo_setWorldTransform(_native, ref value); }
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
                if (!_preventDelete)
                {
                    btWheelInfo_delete(_native);
                }
				_native = IntPtr.Zero;
			}
		}

		~WheelInfo()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWheelInfo_new(IntPtr ci);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btWheelInfo_getBIsFrontWheel(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getBrake(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_getChassisConnectionPointCS(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWheelInfo_getClientInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getClippedInvContactDotSuspension(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getDeltaRotation(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getEngineForce(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getFrictionSlip(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getMaxSuspensionForce(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getMaxSuspensionTravelCm(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btWheelInfo_getRaycastInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getRollInfluence(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getRotation(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getSkidInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getSteering(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getSuspensionRelativeVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getSuspensionRestLength(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getSuspensionRestLength1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getSuspensionStiffness(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_getWheelAxleCS(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_getWheelDirectionCS(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getWheelsDampingCompression(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getWheelsDampingRelaxation(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getWheelsRadius(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btWheelInfo_getWheelsSuspensionForce(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_getWorldTransform(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setBIsFrontWheel(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setBrake(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setChassisConnectionPointCS(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setClientInfo(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setClippedInvContactDotSuspension(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setDeltaRotation(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setEngineForce(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setFrictionSlip(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setMaxSuspensionForce(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setMaxSuspensionTravelCm(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setRaycastInfo(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setRollInfluence(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setRotation(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setSkidInfo(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setSteering(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setSuspensionRelativeVelocity(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setSuspensionRestLength1(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setSuspensionStiffness(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setWheelAxleCS(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setWheelDirectionCS(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setWheelsDampingCompression(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setWheelsDampingRelaxation(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setWheelsRadius(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_setWheelsSuspensionForce(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btWheelInfo_setWorldTransform(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_updateWheel(IntPtr obj, IntPtr chassis, IntPtr raycastInfo);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btWheelInfo_delete(IntPtr obj);
	}
}
