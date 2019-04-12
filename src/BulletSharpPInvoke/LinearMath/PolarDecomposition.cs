using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class PolarDecomposition
	{
		internal IntPtr _native;

		internal PolarDecomposition(IntPtr native)
		{
			_native = native;
		}

		public PolarDecomposition(float tolerance, uint maxIterations)
		{
			_native = btPolarDecomposition_new(tolerance, maxIterations);
		}

		public PolarDecomposition(float tolerance)
		{
			_native = btPolarDecomposition_new2(tolerance);
		}

		public PolarDecomposition()
		{
			_native = btPolarDecomposition_new3();
		}

		public uint Decompose(Matrix a, Matrix u, Matrix h)
		{
			return btPolarDecomposition_decompose(_native, ref a, ref u, ref h);
		}

		public uint MaxIterations()
		{
			return btPolarDecomposition_maxIterations(_native);
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
				btPolarDecomposition_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PolarDecomposition()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPolarDecomposition_new(float tolerance, uint maxIterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPolarDecomposition_new2(float tolerance);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btPolarDecomposition_new3();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btPolarDecomposition_decompose(IntPtr obj, [In] ref Matrix a, [In] ref Matrix u, [In] ref Matrix h);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btPolarDecomposition_maxIterations(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btPolarDecomposition_delete(IntPtr obj);
	}
}
