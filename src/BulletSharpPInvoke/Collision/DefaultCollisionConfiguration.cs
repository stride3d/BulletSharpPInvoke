using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class DefaultCollisionConstructionInfo
	{
		internal IntPtr _native;

		internal DefaultCollisionConstructionInfo(IntPtr native)
		{
			_native = native;
		}

		public DefaultCollisionConstructionInfo()
		{
			_native = btDefaultCollisionConstructionInfo_new();
		}
        /*
		public PoolAllocator CollisionAlgorithmPool
		{
			get { return btDefaultCollisionConstructionInfo_getCollisionAlgorithmPool(_native); }
			set { btDefaultCollisionConstructionInfo_setCollisionAlgorithmPool(_native, value._native); }
		}
        */
		public int CustomCollisionAlgorithmMaxElementSize
		{
			get { return btDefaultCollisionConstructionInfo_getCustomCollisionAlgorithmMaxElementSize(_native); }
			set { btDefaultCollisionConstructionInfo_setCustomCollisionAlgorithmMaxElementSize(_native, value); }
		}

		public int DefaultMaxCollisionAlgorithmPoolSize
		{
			get { return btDefaultCollisionConstructionInfo_getDefaultMaxCollisionAlgorithmPoolSize(_native); }
			set { btDefaultCollisionConstructionInfo_setDefaultMaxCollisionAlgorithmPoolSize(_native, value); }
		}

		public int DefaultMaxPersistentManifoldPoolSize
		{
			get { return btDefaultCollisionConstructionInfo_getDefaultMaxPersistentManifoldPoolSize(_native); }
			set { btDefaultCollisionConstructionInfo_setDefaultMaxPersistentManifoldPoolSize(_native, value); }
		}
        /*
		public PoolAllocator PersistentManifoldPool
		{
			get { return btDefaultCollisionConstructionInfo_getPersistentManifoldPool(_native); }
			set { btDefaultCollisionConstructionInfo_setPersistentManifoldPool(_native, value._native); }
		}
        */
		public int UseEpaPenetrationAlgorithm
		{
			get { return btDefaultCollisionConstructionInfo_getUseEpaPenetrationAlgorithm(_native); }
			set { btDefaultCollisionConstructionInfo_setUseEpaPenetrationAlgorithm(_native, value); }
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
				btDefaultCollisionConstructionInfo_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~DefaultCollisionConstructionInfo()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultCollisionConstructionInfo_new();

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDefaultCollisionConstructionInfo_getCustomCollisionAlgorithmMaxElementSize(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDefaultCollisionConstructionInfo_getDefaultMaxCollisionAlgorithmPoolSize(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDefaultCollisionConstructionInfo_getDefaultMaxPersistentManifoldPoolSize(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btDefaultCollisionConstructionInfo_getUseEpaPenetrationAlgorithm(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConstructionInfo_setCustomCollisionAlgorithmMaxElementSize(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConstructionInfo_setDefaultMaxCollisionAlgorithmPoolSize(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConstructionInfo_setDefaultMaxPersistentManifoldPoolSize(IntPtr obj, int value);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConstructionInfo_setUseEpaPenetrationAlgorithm(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConstructionInfo_delete(IntPtr obj);
	}

	public class DefaultCollisionConfiguration : CollisionConfiguration
	{
		internal DefaultCollisionConfiguration(IntPtr native)
			: base(native)
		{
		}

		public DefaultCollisionConfiguration(DefaultCollisionConstructionInfo constructionInfo)
			: base(btDefaultCollisionConfiguration_new(constructionInfo._native))
		{
		}

		public DefaultCollisionConfiguration()
			: base(btDefaultCollisionConfiguration_new2())
		{
		}

		public void SetConvexConvexMultipointIterations(int numPerturbationIterations, int minimumPointsPerturbationThreshold)
		{
			btDefaultCollisionConfiguration_setConvexConvexMultipointIterations(_native, numPerturbationIterations, minimumPointsPerturbationThreshold);
		}

		public void SetConvexConvexMultipointIterations(int numPerturbationIterations)
		{
			btDefaultCollisionConfiguration_setConvexConvexMultipointIterations2(_native, numPerturbationIterations);
		}

		public void SetConvexConvexMultipointIterations()
		{
			btDefaultCollisionConfiguration_setConvexConvexMultipointIterations3(_native);
		}

		public void SetPlaneConvexMultipointIterations(int numPerturbationIterations, int minimumPointsPerturbationThreshold)
		{
			btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations(_native, numPerturbationIterations, minimumPointsPerturbationThreshold);
		}

		public void SetPlaneConvexMultipointIterations(int numPerturbationIterations)
		{
			btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations2(_native, numPerturbationIterations);
		}

		public void SetPlaneConvexMultipointIterations()
		{
			btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations3(_native);
		}

		public VoronoiSimplexSolver SimplexSolver
		{
			get { return new VoronoiSimplexSolver(btDefaultCollisionConfiguration_getSimplexSolver(_native)); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultCollisionConfiguration_new(IntPtr constructionInfo);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultCollisionConfiguration_new2();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btDefaultCollisionConfiguration_getSimplexSolver(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConfiguration_setConvexConvexMultipointIterations(IntPtr obj, int numPerturbationIterations, int minimumPointsPerturbationThreshold);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConfiguration_setConvexConvexMultipointIterations2(IntPtr obj, int numPerturbationIterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConfiguration_setConvexConvexMultipointIterations3(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations(IntPtr obj, int numPerturbationIterations, int minimumPointsPerturbationThreshold);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations2(IntPtr obj, int numPerturbationIterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations3(IntPtr obj);
	}
}
