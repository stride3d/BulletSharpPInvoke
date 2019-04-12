using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    /*
	public class PfxParallelBatch
	{
		internal IntPtr _native;

		internal PfxParallelBatch(IntPtr native)
		{
			_native = native;
		}

		public PfxParallelBatch()
		{
			_native = PfxParallelBatch_new();
		}

		public ushort PairIndices
		{
			get { return PfxParallelBatch_getPairIndices(_native); }
			set { PfxParallelBatch_setPairIndices(_native, value._native); }
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
				PfxParallelBatch_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxParallelBatch()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxParallelBatch_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxParallelBatch_getPairIndices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxParallelBatch_setPairIndices(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxParallelBatch_delete(IntPtr obj);
	}

	public class PfxParallelGroup
	{
		internal IntPtr _native;

		internal PfxParallelGroup(IntPtr native)
		{
			_native = native;
		}

		public PfxParallelGroup()
		{
			_native = PfxParallelGroup_new();
		}

		public ushort NumBatches
		{
			get { return PfxParallelGroup_getNumBatches(_native); }
			set { PfxParallelGroup_setNumBatches(_native, value._native); }
		}

		public ushort NumPairs
		{
			get { return PfxParallelGroup_getNumPairs(_native); }
			set { PfxParallelGroup_setNumPairs(_native, value._native); }
		}

		public ushort NumPhases
		{
			get { return PfxParallelGroup_getNumPhases(_native); }
			set { PfxParallelGroup_setNumPhases(_native, value); }
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
				PfxParallelGroup_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxParallelGroup()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxParallelGroup_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxParallelGroup_getNumBatches(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxParallelGroup_getNumPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort PfxParallelGroup_getNumPhases(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxParallelGroup_setNumBatches(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxParallelGroup_setNumPairs(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxParallelGroup_setNumPhases(IntPtr obj, ushort value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxParallelGroup_delete(IntPtr obj);
	}

	public class PfxSortData16
	{
		internal IntPtr _native;

		internal PfxSortData16(IntPtr native)
		{
			_native = native;
		}

		public PfxSortData16()
		{
			_native = PfxSortData16_new();
		}

		public ushort Get16(int elem)
		{
			return PfxSortData16_get16(_native, elem);
		}

		public uint Get32(int elem)
		{
			return PfxSortData16_get32(_native, elem);
		}

		public byte Get8(int elem)
		{
			return PfxSortData16_get8(_native, elem);
		}

		public void Set16(int elem, ushort data)
		{
			PfxSortData16_set16(_native, elem, data);
		}

		public void Set32(int elem, uint data)
		{
			PfxSortData16_set32(_native, elem, data);
		}

		public void Set8(int elem, byte data)
		{
			PfxSortData16_set8(_native, elem, data);
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
				PfxSortData16_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxSortData16()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSortData16_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ushort PfxSortData16_get16(IntPtr obj, int elem);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSortData16_get32(IntPtr obj, int elem);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern byte PfxSortData16_get8(IntPtr obj, int elem);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSortData16_set16(IntPtr obj, int elem, ushort data);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSortData16_set32(IntPtr obj, int elem, uint data);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSortData16_set8(IntPtr obj, int elem, byte data);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSortData16_delete(IntPtr obj);
	}

	public class PfxSolverBody
	{
		internal IntPtr _native;

		internal PfxSolverBody(IntPtr native)
		{
			_native = native;
		}

		public PfxSolverBody()
		{
			_native = PfxSolverBody_new();
		}

		public float Friction
		{
			get { return PfxSolverBody_getFriction(_native); }
			set { PfxSolverBody_setFriction(_native, value); }
		}

		public vmVector3 MDeltaAngularVelocity
		{
			get { return PfxSolverBody_getMDeltaAngularVelocity(_native); }
			set { PfxSolverBody_setMDeltaAngularVelocity(_native, value._native); }
		}

		public vmVector3 MDeltaLinearVelocity
		{
			get { return PfxSolverBody_getMDeltaLinearVelocity(_native); }
			set { PfxSolverBody_setMDeltaLinearVelocity(_native, value._native); }
		}

		public vmMatrix3 MInertiaInv
		{
			get { return PfxSolverBody_getMInertiaInv(_native); }
			set { PfxSolverBody_setMInertiaInv(_native, value._native); }
		}

		public float MMassInv
		{
			get { return PfxSolverBody_getMMassInv(_native); }
			set { PfxSolverBody_setMMassInv(_native, value); }
		}

		public vmQuat MOrientation
		{
			get { return PfxSolverBody_getMOrientation(_native); }
			set { PfxSolverBody_setMOrientation(_native, value._native); }
		}

		public float Restitution
		{
			get { return PfxSolverBody_getRestitution(_native); }
			set { PfxSolverBody_setRestitution(_native, value); }
		}

		public float Unused
		{
			get { return PfxSolverBody_getUnused(_native); }
			set { PfxSolverBody_setUnused(_native, value); }
		}

		public float Unused2
		{
			get { return PfxSolverBody_getUnused2(_native); }
			set { PfxSolverBody_setUnused2(_native, value); }
		}

		public float Unused3
		{
			get { return PfxSolverBody_getUnused3(_native); }
			set { PfxSolverBody_setUnused3(_native, value); }
		}

		public float Unused4
		{
			get { return PfxSolverBody_getUnused4(_native); }
			set { PfxSolverBody_setUnused4(_native, value); }
		}

		public float Unused5
		{
			get { return PfxSolverBody_getUnused5(_native); }
			set { PfxSolverBody_setUnused5(_native, value); }
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
				PfxSolverBody_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxSolverBody()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolverBody_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getFriction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolverBody_getMDeltaAngularVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolverBody_getMDeltaLinearVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolverBody_getMInertiaInv(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getMMassInv(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolverBody_getMOrientation(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getRestitution(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getUnused(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getUnused2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getUnused3(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getUnused4(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSolverBody_getUnused5(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setFriction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setMDeltaAngularVelocity(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setMDeltaLinearVelocity(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setMInertiaInv(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setMMassInv(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setMOrientation(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setRestitution(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setUnused(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setUnused2(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setUnused3(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setUnused4(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_setUnused5(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolverBody_delete(IntPtr obj);
	}

	public class PfxSetupContactConstraintsIO
	{
		internal IntPtr _native;

		internal PfxSetupContactConstraintsIO(IntPtr native)
		{
			_native = native;
		}

		public PfxSetupContactConstraintsIO()
		{
			_native = PfxSetupContactConstraintsIO_new();
		}

		public CriticalSection CriticalSection
		{
			get { return PfxSetupContactConstraintsIO_getCriticalSection(_native); }
			set { PfxSetupContactConstraintsIO_setCriticalSection(_native, value._native); }
		}

		public uint NumContactPairs1
		{
			get { return PfxSetupContactConstraintsIO_getNumContactPairs1(_native); }
			set { PfxSetupContactConstraintsIO_setNumContactPairs1(_native, value); }
		}

		public uint NumRigidBodies
		{
			get { return PfxSetupContactConstraintsIO_getNumRigidBodies(_native); }
			set { PfxSetupContactConstraintsIO_setNumRigidBodies(_native, value); }
		}

		public ConstraintRow OffsetContactConstraintRows
		{
			get { return PfxSetupContactConstraintsIO_getOffsetContactConstraintRows(_native); }
			set { PfxSetupContactConstraintsIO_setOffsetContactConstraintRows(_native, value._native); }
		}

		public PersistentManifold OffsetContactManifolds
		{
			get { return PfxSetupContactConstraintsIO_getOffsetContactManifolds(_native); }
			set { PfxSetupContactConstraintsIO_setOffsetContactManifolds(_native, value._native); }
		}

		public PfxConstraintPair OffsetContactPairs
		{
			get { return PfxSetupContactConstraintsIO_getOffsetContactPairs(_native); }
			set { PfxSetupContactConstraintsIO_setOffsetContactPairs(_native, value._native); }
		}

		public TrbState OffsetRigStates
		{
			get { return PfxSetupContactConstraintsIO_getOffsetRigStates(_native); }
			set { PfxSetupContactConstraintsIO_setOffsetRigStates(_native, value._native); }
		}

		public PfxSolverBody OffsetSolverBodies
		{
			get { return PfxSetupContactConstraintsIO_getOffsetSolverBodies(_native); }
			set { PfxSetupContactConstraintsIO_setOffsetSolverBodies(_native, value._native); }
		}

		public float SeparateBias
		{
			get { return PfxSetupContactConstraintsIO_getSeparateBias(_native); }
			set { PfxSetupContactConstraintsIO_setSeparateBias(_native, value); }
		}

		public float TimeStep
		{
			get { return PfxSetupContactConstraintsIO_getTimeStep(_native); }
			set { PfxSetupContactConstraintsIO_setTimeStep(_native, value); }
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
				PfxSetupContactConstraintsIO_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxSetupContactConstraintsIO()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_getCriticalSection(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSetupContactConstraintsIO_getNumContactPairs1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSetupContactConstraintsIO_getNumRigidBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_getOffsetContactConstraintRows(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_getOffsetContactManifolds(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_getOffsetContactPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_getOffsetRigStates(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSetupContactConstraintsIO_getOffsetSolverBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSetupContactConstraintsIO_getSeparateBias(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float PfxSetupContactConstraintsIO_getTimeStep(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setCriticalSection(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setNumContactPairs1(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setNumRigidBodies(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setOffsetContactConstraintRows(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setOffsetContactManifolds(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setOffsetContactPairs(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setOffsetRigStates(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setOffsetSolverBodies(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setSeparateBias(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_setTimeStep(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSetupContactConstraintsIO_delete(IntPtr obj);
	}

	public class PfxSolveConstraintsIO
	{
		internal IntPtr _native;

		internal PfxSolveConstraintsIO(IntPtr native)
		{
			_native = native;
		}

		public PfxSolveConstraintsIO()
		{
			_native = PfxSolveConstraintsIO_new();
		}

		public Barrier Barrier
		{
			get { return PfxSolveConstraintsIO_getBarrier(_native); }
			set { PfxSolveConstraintsIO_setBarrier(_native, value._native); }
		}

		public PfxConstraintPair ContactPairs
		{
			get { return PfxSolveConstraintsIO_getContactPairs(_native); }
			set { PfxSolveConstraintsIO_setContactPairs(_native, value._native); }
		}

		public PfxParallelBatch ContactParallelBatches
		{
			get { return PfxSolveConstraintsIO_getContactParallelBatches(_native); }
			set { PfxSolveConstraintsIO_setContactParallelBatches(_native, value._native); }
		}

		public PfxParallelGroup ContactParallelGroup
		{
			get { return PfxSolveConstraintsIO_getContactParallelGroup(_native); }
			set { PfxSolveConstraintsIO_setContactParallelGroup(_native, value._native); }
		}

		public uint Iteration
		{
			get { return PfxSolveConstraintsIO_getIteration(_native); }
			set { PfxSolveConstraintsIO_setIteration(_native, value); }
		}

		public PfxConstraintPair JointPairs
		{
			get { return PfxSolveConstraintsIO_getJointPairs(_native); }
			set { PfxSolveConstraintsIO_setJointPairs(_native, value._native); }
		}

		public PfxParallelBatch JointParallelBatches
		{
			get { return PfxSolveConstraintsIO_getJointParallelBatches(_native); }
			set { PfxSolveConstraintsIO_setJointParallelBatches(_native, value._native); }
		}

		public PfxParallelGroup JointParallelGroup
		{
			get { return PfxSolveConstraintsIO_getJointParallelGroup(_native); }
			set { PfxSolveConstraintsIO_setJointParallelGroup(_native, value._native); }
		}

		public uint NumContactPairs
		{
			get { return PfxSolveConstraintsIO_getNumContactPairs(_native); }
			set { PfxSolveConstraintsIO_setNumContactPairs(_native, value); }
		}

		public uint NumJointPairs
		{
			get { return PfxSolveConstraintsIO_getNumJointPairs(_native); }
			set { PfxSolveConstraintsIO_setNumJointPairs(_native, value); }
		}

		public uint NumRigidBodies
		{
			get { return PfxSolveConstraintsIO_getNumRigidBodies(_native); }
			set { PfxSolveConstraintsIO_setNumRigidBodies(_native, value); }
		}

		public ConstraintRow OffsetContactConstraintRows
		{
			get { return PfxSolveConstraintsIO_getOffsetContactConstraintRows(_native); }
			set { PfxSolveConstraintsIO_setOffsetContactConstraintRows(_native, value._native); }
		}

		public PersistentManifold OffsetContactManifolds
		{
			get { return PfxSolveConstraintsIO_getOffsetContactManifolds(_native); }
			set { PfxSolveConstraintsIO_setOffsetContactManifolds(_native, value._native); }
		}

		public TrbState OffsetRigStates1
		{
			get { return PfxSolveConstraintsIO_getOffsetRigStates1(_native); }
			set { PfxSolveConstraintsIO_setOffsetRigStates1(_native, value._native); }
		}

		public PfxSolverBody OffsetSolverBodies
		{
			get { return PfxSolveConstraintsIO_getOffsetSolverBodies(_native); }
			set { PfxSolveConstraintsIO_setOffsetSolverBodies(_native, value._native); }
		}

		public SolverConstraint OffsetSolverConstraints
		{
			get { return PfxSolveConstraintsIO_getOffsetSolverConstraints(_native); }
			set { PfxSolveConstraintsIO_setOffsetSolverConstraints(_native, value._native); }
		}

		public uint TaskId
		{
			get { return PfxSolveConstraintsIO_getTaskId(_native); }
			set { PfxSolveConstraintsIO_setTaskId(_native, value); }
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
				PfxSolveConstraintsIO_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxSolveConstraintsIO()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getBarrier(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getContactPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getContactParallelBatches(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getContactParallelGroup(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSolveConstraintsIO_getIteration(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getJointPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getJointParallelBatches(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getJointParallelGroup(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSolveConstraintsIO_getNumContactPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSolveConstraintsIO_getNumJointPairs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSolveConstraintsIO_getNumRigidBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getOffsetContactConstraintRows(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getOffsetContactManifolds(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getOffsetRigStates1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getOffsetSolverBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxSolveConstraintsIO_getOffsetSolverConstraints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxSolveConstraintsIO_getTaskId(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setBarrier(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setContactPairs(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setContactParallelBatches(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setContactParallelGroup(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setIteration(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setJointPairs(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setJointParallelBatches(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setJointParallelGroup(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setNumContactPairs(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setNumJointPairs(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setNumRigidBodies(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setOffsetContactConstraintRows(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setOffsetContactManifolds(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setOffsetRigStates1(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setOffsetSolverBodies(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setOffsetSolverConstraints(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_setTaskId(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxSolveConstraintsIO_delete(IntPtr obj);
	}

	public class PfxPostSolverIO
	{
		internal IntPtr _native;

		internal PfxPostSolverIO(IntPtr native)
		{
			_native = native;
		}

		public PfxPostSolverIO()
		{
			_native = PfxPostSolverIO_new();
		}

		public uint NumRigidBodies
		{
			get { return PfxPostSolverIO_getNumRigidBodies(_native); }
			set { PfxPostSolverIO_setNumRigidBodies(_native, value); }
		}

		public PfxSolverBody SolverBodies
		{
			get { return PfxPostSolverIO_getSolverBodies(_native); }
			set { PfxPostSolverIO_setSolverBodies(_native, value._native); }
		}

		public TrbState States
		{
			get { return PfxPostSolverIO_getStates(_native); }
			set { PfxPostSolverIO_setStates(_native, value._native); }
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
				PfxPostSolverIO_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~PfxPostSolverIO()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxPostSolverIO_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint PfxPostSolverIO_getNumRigidBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxPostSolverIO_getSolverBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr PfxPostSolverIO_getStates(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxPostSolverIO_setNumRigidBodies(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxPostSolverIO_setSolverBodies(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxPostSolverIO_setStates(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void PfxPostSolverIO_delete(IntPtr obj);
	}

	public class ConstraintSolverIO
	{
		internal IntPtr _native;

		internal ConstraintSolverIO(IntPtr native)
		{
			_native = native;
		}

		public ConstraintSolverIO()
		{
			_native = btConstraintSolverIO_new();
		}

		public uint BarrierAddr2
		{
			get { return btConstraintSolverIO_getBarrierAddr2(_native); }
			set { btConstraintSolverIO_setBarrierAddr2(_native, value); }
		}

		public byte Cmd
		{
			get { return btConstraintSolverIO_getCmd(_native); }
			set { btConstraintSolverIO_setCmd(_native, value); }
		}

		public uint CriticalsectionAddr2
		{
			get { return btConstraintSolverIO_getCriticalsectionAddr2(_native); }
			set { btConstraintSolverIO_setCriticalsectionAddr2(_native, value); }
		}

		public uint MaxTasks1
		{
			get { return btConstraintSolverIO_getMaxTasks1(_native); }
			set { btConstraintSolverIO_setMaxTasks1(_native, value); }
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
				btConstraintSolverIO_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ConstraintSolverIO()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConstraintSolverIO_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btConstraintSolverIO_getBarrierAddr2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern byte btConstraintSolverIO_getCmd(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btConstraintSolverIO_getCriticalsectionAddr2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern uint btConstraintSolverIO_getMaxTasks1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSolverIO_setBarrierAddr2(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSolverIO_setCmd(IntPtr obj, byte value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSolverIO_setCriticalsectionAddr2(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSolverIO_setMaxTasks1(IntPtr obj, uint value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConstraintSolverIO_delete(IntPtr obj);
	}
*/
	public class ParallelConstraintSolver : SequentialImpulseConstraintSolver
	{
        private ThreadSupportInterface _solverThreadSupport;

		internal ParallelConstraintSolver(IntPtr native)
			: base(native)
		{
		}

		public ParallelConstraintSolver(ThreadSupportInterface solverThreadSupport)
			: base(btParallelConstraintSolver_new(solverThreadSupport._native))
		{
            _solverThreadSupport = solverThreadSupport;
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btParallelConstraintSolver_new(IntPtr solverThreadSupport);
	}
}
