using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class CollisionAlgorithmConstructionInfo
	{
		internal IntPtr _native;

		internal CollisionAlgorithmConstructionInfo(IntPtr native)
		{
			_native = native;
		}

		public CollisionAlgorithmConstructionInfo()
		{
			_native = btCollisionAlgorithmConstructionInfo_new();
		}

		public CollisionAlgorithmConstructionInfo(Dispatcher dispatcher, int temp)
		{
			_native = btCollisionAlgorithmConstructionInfo_new2(dispatcher._native, temp);
		}

		public Dispatcher Dispatcher1
		{
            get { return new Dispatcher(btCollisionAlgorithmConstructionInfo_getDispatcher1(_native)); }
			set { btCollisionAlgorithmConstructionInfo_setDispatcher1(_native, value._native); }
		}
        /*
		public PersistentManifold Manifold
		{
			get { return btCollisionAlgorithmConstructionInfo_getManifold(_native); }
			set { btCollisionAlgorithmConstructionInfo_setManifold(_native, value._native); }
		}
        */
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btCollisionAlgorithmConstructionInfo_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~CollisionAlgorithmConstructionInfo()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionAlgorithmConstructionInfo_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionAlgorithmConstructionInfo_new2(IntPtr dispatcher, int temp);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCollisionAlgorithmConstructionInfo_getDispatcher1(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionAlgorithmConstructionInfo_setDispatcher1(IntPtr obj, IntPtr value);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionAlgorithmConstructionInfo_delete(IntPtr obj);
	}

	public class CollisionAlgorithm
	{
		internal IntPtr _native;
        bool _preventDelete;

		internal CollisionAlgorithm(IntPtr native, bool preventDelete = false)
		{
			_native = native;
            _preventDelete = preventDelete;
		}
        /*
		public float CalculateTimeOfImpact(CollisionObject body0, CollisionObject body1, DispatcherInfo dispatchInfo, ManifoldResult resultOut)
		{
			return btCollisionAlgorithm_calculateTimeOfImpact(_native, body0._native, body1._native, dispatchInfo._native, resultOut._native);
		}
        */
        public void GetAllContactManifolds(AlignedManifoldArray manifoldArray)
        {
            btCollisionAlgorithm_getAllContactManifolds(_native, manifoldArray._native);
        }
        /*
		public void ProcessCollision(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, DispatcherInfo dispatchInfo, ManifoldResult resultOut)
		{
			btCollisionAlgorithm_processCollision(_native, body0Wrap._native, body1Wrap._native, dispatchInfo._native, resultOut._native);
		}
        */
        
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
                    btCollisionAlgorithm_delete(_native);
                }
				_native = IntPtr.Zero;
			}
		}

		~CollisionAlgorithm()
		{
			Dispose(false);
		}

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionAlgorithm_getAllContactManifolds(IntPtr obj, IntPtr manifoldArray);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btCollisionAlgorithm_delete(IntPtr obj);
	}
}
