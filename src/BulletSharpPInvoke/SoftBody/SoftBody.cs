using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp.SoftBody
{
	public class SoftBodyWorldInfo
	{
		internal IntPtr _native;

		internal SoftBodyWorldInfo(IntPtr native)
		{
			_native = native;
		}

		public SoftBodyWorldInfo()
		{
			_native = btSoftBodyWorldInfo_new();
		}

		public float Air_density
		{
			get { return btSoftBodyWorldInfo_getAir_density(_native); }
			set { btSoftBodyWorldInfo_setAir_density(_native, value); }
		}

		public BroadphaseInterface Broadphase
		{
            get { return new BroadphaseInterface(btSoftBodyWorldInfo_getBroadphase(_native)); }
			set { btSoftBodyWorldInfo_setBroadphase(_native, value._native); }
		}

		public Dispatcher Dispatcher
		{
            get { return new Dispatcher(btSoftBodyWorldInfo_getDispatcher(_native)); }
			set { btSoftBodyWorldInfo_setDispatcher(_native, value._native); }
		}

		public Vector3 Gravity
		{
            get
            {
                Vector3 value;
                btSoftBodyWorldInfo_getGravity(_native, out value);
                return value;
            }
			set { btSoftBodyWorldInfo_setGravity(_native, ref value); }
		}
        /*
		public void Sparsesdf
		{
			get { return btSoftBodyWorldInfo_getSparsesdf(_native); }
			set { btSoftBodyWorldInfo_setSparsesdf(_native, value._native); }
		}
        */
		public float WaterDensity
		{
			get { return btSoftBodyWorldInfo_getWater_density(_native); }
			set { btSoftBodyWorldInfo_setWater_density(_native, value); }
		}

		public Vector3 WaterNormal
		{
            get
            {
                Vector3 value;
                btSoftBodyWorldInfo_getWater_normal(_native, out value);
                return value;
            }
			set { btSoftBodyWorldInfo_setWater_normal(_native, ref value); }
		}

		public float WaterOffset
		{
			get { return btSoftBodyWorldInfo_getWater_offset(_native); }
			set { btSoftBodyWorldInfo_setWater_offset(_native, value); }
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
				btSoftBodyWorldInfo_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SoftBodyWorldInfo()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBodyWorldInfo_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBodyWorldInfo_getAir_density(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBodyWorldInfo_getBroadphase(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBodyWorldInfo_getDispatcher(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_getGravity(IntPtr obj, [Out] out Vector3 value);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBodyWorldInfo_getWater_density(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_getWater_normal(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBodyWorldInfo_getWater_offset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setAir_density(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setBroadphase(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setDispatcher(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setGravity(IntPtr obj, [In] ref Vector3 value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBodyWorldInfo_setSparsesdf(IntPtr obj, SparseSdf value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setWater_density(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setWater_normal(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_setWater_offset(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodyWorldInfo_delete(IntPtr obj);
	}

    public enum AeroModel
    {
        VPoint,
        VTwoSided,
        VTwoSidedLiftDrag,
        VOneSided,
        FTwoSided,
        FTwoSidedLiftDrag,
        FOneSided
    }

    public enum VSolver
    {
        Linear
    }

    public enum PSolver
    {
        Linear,
        Anchors,
        RContacts,
        SContacts
    }

    public enum SolverPresets
    {
        Positions,
        Velocities,
        Default = Positions
    }

    public enum EFeature
    {
        None,
        Node,
        Link,
        Face,
        Tetra
    }

    [Flags]
    public enum Collision
    {
        None = 0x00,
        RvsMask = 0x0f,
        SdfRS = 0x01,
        CLRS = 0x02,
        SvsMask = 0x30,
        VFSS = 0x10,
        CLSS = 0x20,
        CLSelf = 0x40,
        Default = SdfRS
    }

    [Flags]
    public enum FMaterial
    {
        None = 0x00,
        DebugDraw = 0x01,
        Default = DebugDraw
    }

	public class SRayCast
	{
		internal IntPtr _native;

		internal SRayCast(IntPtr native)
		{
			_native = native;
		}

		public SRayCast()
		{
			_native = btSoftBody_sRayCast_new();
		}

		public SoftBody Body
		{
			get { return SoftBody.GetManaged(btSoftBody_sRayCast_getBody(_native)) as SoftBody; }
			set { btSoftBody_sRayCast_setBody(_native, value._native); }
		}
        /*
		public void Feature
		{
			get { return btSoftBody_sRayCast_getFeature(_native); }
			set { btSoftBody_sRayCast_setFeature(_native, value._native); }
		}
        */
		public float Fraction
		{
			get { return btSoftBody_sRayCast_getFraction(_native); }
			set { btSoftBody_sRayCast_setFraction(_native, value); }
		}

		public int Index
		{
			get { return btSoftBody_sRayCast_getIndex(_native); }
			set { btSoftBody_sRayCast_setIndex(_native, value); }
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
				btSoftBody_sRayCast_delete(_native);
				_native = IntPtr.Zero;
			}
		}

        ~SRayCast()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_sRayCast_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_sRayCast_getBody(IntPtr obj);

	    [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_sRayCast_getFraction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_sRayCast_getIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sRayCast_setBody(IntPtr obj, IntPtr value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_sRayCast_setFeature(IntPtr obj, _ value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sRayCast_setFraction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sRayCast_setIndex(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sRayCast_delete(IntPtr obj);
	}

	public class ImplicitFn
	{
		internal IntPtr _native;

		internal ImplicitFn(IntPtr native)
		{
			_native = native;
		}

		public float Eval(Vector3 x)
		{
			return btSoftBody_ImplicitFn_Eval(_native, ref x);
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
				btSoftBody_ImplicitFn_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~ImplicitFn()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_ImplicitFn_Eval(IntPtr obj, [In] ref Vector3 x);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_ImplicitFn_delete(IntPtr obj);
	}

	public class sCti
	{
		internal IntPtr _native;

		internal sCti(IntPtr native)
		{
			_native = native;
		}

		public sCti()
		{
			_native = btSoftBody_sCti_new();
		}

		public CollisionObject ColObj
		{
            get { return CollisionObject.GetManaged(btSoftBody_sCti_getColObj(_native)); }
			set { btSoftBody_sCti_setColObj(_native, value._native); }
		}
        /*
		public void Normal
		{
			get { return btSoftBody_sCti_getNormal(_native); }
			set { btSoftBody_sCti_setNormal(_native, value._native); }
		}
        */
		public float Offset
		{
			get { return btSoftBody_sCti_getOffset(_native); }
			set { btSoftBody_sCti_setOffset(_native, value); }
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
				btSoftBody_sCti_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~sCti()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_sCti_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_sCti_getColObj(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sCti_getNormal(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_sCti_getOffset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sCti_setColObj(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sCti_setNormal(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sCti_setOffset(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sCti_delete(IntPtr obj);
	}

	public class sMedium
	{
		internal IntPtr _native;

		internal sMedium(IntPtr native)
		{
			_native = native;
		}

		public sMedium()
		{
			_native = btSoftBody_sMedium_new();
		}

		public float Density
		{
			get { return btSoftBody_sMedium_getDensity(_native); }
			set { btSoftBody_sMedium_setDensity(_native, value); }
		}

		public float Pressure
		{
			get { return btSoftBody_sMedium_getPressure(_native); }
			set { btSoftBody_sMedium_setPressure(_native, value); }
		}
        /*
		public void Velocity
		{
			get { return btSoftBody_sMedium_getVelocity(_native); }
			set { btSoftBody_sMedium_setVelocity(_native, value._native); }
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
				btSoftBody_sMedium_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~sMedium()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_sMedium_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_sMedium_getDensity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_sMedium_getPressure(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sMedium_getVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sMedium_setDensity(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sMedium_setPressure(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sMedium_setVelocity(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_sMedium_delete(IntPtr obj);
	}

	public class Element
	{
		internal IntPtr _native;

		internal Element(IntPtr native)
		{
			_native = native;
		}

		public Element()
		{
			_native = btSoftBody_Element_new();
		}

		public IntPtr Tag
		{
			get { return btSoftBody_Element_getTag(_native); }
			set { btSoftBody_Element_setTag(_native, value); }
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
				btSoftBody_Element_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Element()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Element_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Element_getTag(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Element_setTag(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Element_delete(IntPtr obj);
	}

	public class Material : Element
	{
		internal Material(IntPtr native)
			: base(native)
		{
		}

		public Material()
			: base(btSoftBody_Material_new())
		{
		}

		public int Flags
		{
			get { return btSoftBody_Material_getFlags(_native); }
			set { btSoftBody_Material_setFlags(_native, value); }
		}

		public float KAST
		{
			get { return btSoftBody_Material_getKAST(_native); }
			set { btSoftBody_Material_setKAST(_native, value); }
		}

		public float KLST
		{
			get { return btSoftBody_Material_getKLST(_native); }
			set { btSoftBody_Material_setKLST(_native, value); }
		}

		public float KVST
		{
			get { return btSoftBody_Material_getKVST(_native); }
			set { btSoftBody_Material_setKVST(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Material_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Material_getFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Material_getKAST(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Material_getKLST(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Material_getKVST(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Material_setFlags(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Material_setKAST(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Material_setKLST(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Material_setKVST(IntPtr obj, float value);
	}

	public class Feature : Element
	{
		internal Feature(IntPtr native)
			: base(native)
		{
		}

		public Feature()
			: base(btSoftBody_Feature_new())
		{
		}

		public Material Material
		{
			get { return new Material(btSoftBody_Feature_getMaterial(_native)); }
			set { btSoftBody_Feature_setMaterial(_native, value._native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Feature_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Feature_getMaterial(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Feature_setMaterial(IntPtr obj, IntPtr value);
	}

	public class Node : Feature
	{
		internal Node(IntPtr native)
			: base(native)
		{
		}

		public Node()
			: base(btSoftBody_Node_new())
		{
		}

		public float Area
		{
			get { return btSoftBody_Node_getArea(_native); }
			set { btSoftBody_Node_setArea(_native, value); }
		}

		public int Battach
		{
			get { return btSoftBody_Node_getBattach(_native); }
			set { btSoftBody_Node_setBattach(_native, value); }
		}
        /*
		public void F
		{
			get { return btSoftBody_Node_getF(_native); }
			set { btSoftBody_Node_setF(_native, value._native); }
		}
        */
		public float Im
		{
			get { return btSoftBody_Node_getIm(_native); }
			set { btSoftBody_Node_setIm(_native, value); }
		}
        /*
		public DbvtNode Leaf
		{
			get { return btSoftBody_Node_getLeaf(_native); }
			set { btSoftBody_Node_setLeaf(_native, value._native); }
		}

		public void N
		{
			get { return btSoftBody_Node_getN(_native); }
			set { btSoftBody_Node_setN(_native, value._native); }
		}

		public void Q
		{
			get { return btSoftBody_Node_getQ(_native); }
			set { btSoftBody_Node_setQ(_native, value._native); }
		}

		public void V
		{
			get { return btSoftBody_Node_getV(_native); }
			set { btSoftBody_Node_setV(_native, value._native); }
		}

		public void X
		{
			get { return btSoftBody_Node_getX(_native); }
			set { btSoftBody_Node_setX(_native, value._native); }
		}
        */
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Node_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Node_getArea(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Node_getBattach(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_getF(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Node_getIm(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Node_getLeaf(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_getN(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_getQ(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_getV(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_getX(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setArea(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setBattach(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setF(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setIm(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setLeaf(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setN(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setQ(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setV(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Node_setX(IntPtr obj, Vector3 value);
	}

	public class Link : Feature
	{
		internal Link(IntPtr native)
			: base(native)
		{
		}

		public Link()
			: base(btSoftBody_Link_new())
		{
		}

		public int Bbending
		{
			get { return btSoftBody_Link_getBbending(_native); }
			set { btSoftBody_Link_setBbending(_native, value); }
		}

		public float C0
		{
			get { return btSoftBody_Link_getC0(_native); }
			set { btSoftBody_Link_setC0(_native, value); }
		}

		public float C1
		{
			get { return btSoftBody_Link_getC1(_native); }
			set { btSoftBody_Link_setC1(_native, value); }
		}

		public float C2
		{
			get { return btSoftBody_Link_getC2(_native); }
			set { btSoftBody_Link_setC2(_native, value); }
		}
        /*
		public void C3
		{
			get { return btSoftBody_Link_getC3(_native); }
			set { btSoftBody_Link_setC3(_native, value._native); }
		}
        */
		public Node N
		{
			get { return new Node(btSoftBody_Link_getN(_native)); }
			set { btSoftBody_Link_setN(_native, value._native); }
		}

		public float Rl
		{
			get { return btSoftBody_Link_getRl(_native); }
			set { btSoftBody_Link_setRl(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Link_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Link_getBbending(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Link_getC0(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Link_getC1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Link_getC2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_getC3(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Link_getN(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Link_getRl(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setBbending(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setC0(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setC1(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setC2(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setC3(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setN(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Link_setRl(IntPtr obj, float value);
	}

	public class Face : Feature
	{
		internal Face(IntPtr native)
			: base(native)
		{
		}

		public Face()
			: base(btSoftBody_Face_new())
		{
		}
        /*
		public DbvtNode Leaf
		{
			get { return btSoftBody_Face_getLeaf(_native); }
			set { btSoftBody_Face_setLeaf(_native, value._native); }
		}
        */
		public Node N
		{
            get { return new Node(btSoftBody_Face_getN(_native)); }
			set { btSoftBody_Face_setN(_native, value._native); }
		}
        /*
		public void Normal
		{
			get { return btSoftBody_Face_getNormal(_native); }
			set { btSoftBody_Face_setNormal(_native, value._native); }
		}
        */
		public float Ra
		{
			get { return btSoftBody_Face_getRa(_native); }
			set { btSoftBody_Face_setRa(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Face_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Face_getLeaf(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Face_getN(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Face_getNormal(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Face_getRa(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Face_setLeaf(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Face_setN(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Face_setNormal(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Face_setRa(IntPtr obj, float value);
	}

	public class Tetra : Feature
	{
		internal Tetra(IntPtr native)
			: base(native)
		{
		}

		public Tetra()
			: base(btSoftBody_Tetra_new())
		{
		}

		public Vector3 C0
		{
			get
			{
				Vector3 value;
				btSoftBody_Tetra_getC0(_native, out value);
				return value;
			}
			set { btSoftBody_Tetra_setC0(_native, ref value); }
		}

		public float C1
		{
			get { return btSoftBody_Tetra_getC1(_native); }
			set { btSoftBody_Tetra_setC1(_native, value); }
		}

		public float C2
		{
			get { return btSoftBody_Tetra_getC2(_native); }
			set { btSoftBody_Tetra_setC2(_native, value); }
		}
        /*
		public DbvtNode Leaf
		{
			get { return btSoftBody_Tetra_getLeaf(_native); }
			set { btSoftBody_Tetra_setLeaf(_native, value._native); }
		}
        */
		public Node N
		{
			get { return new Node(btSoftBody_Tetra_getN(_native)); }
			set { btSoftBody_Tetra_setN(_native, value._native); }
		}

		public float Rv
		{
			get { return btSoftBody_Tetra_getRv(_native); }
			set { btSoftBody_Tetra_setRv(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Tetra_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_getC0(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Tetra_getC1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Tetra_getC2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Tetra_getLeaf(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Tetra_getN(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Tetra_getRv(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_setC0(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_setC1(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_setC2(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_setLeaf(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_setN(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Tetra_setRv(IntPtr obj, float value);
	}

	public class RContact
	{
		internal IntPtr _native;

		internal RContact(IntPtr native)
		{
			_native = native;
		}

		public RContact()
		{
			_native = btSoftBody_RContact_new();
		}
        /*
		public void C0
		{
			get { return btSoftBody_RContact_getC0(_native); }
			set { btSoftBody_RContact_setC0(_native, value._native); }
		}
            
		public void C1
		{
			get { return btSoftBody_RContact_getC1(_native); }
			set { btSoftBody_RContact_setC1(_native, value._native); }
		}
        */
		public float C2
		{
			get { return btSoftBody_RContact_getC2(_native); }
			set { btSoftBody_RContact_setC2(_native, value); }
		}

		public float C3
		{
			get { return btSoftBody_RContact_getC3(_native); }
			set { btSoftBody_RContact_setC3(_native, value); }
		}

		public float C4
		{
			get { return btSoftBody_RContact_getC4(_native); }
			set { btSoftBody_RContact_setC4(_native, value); }
		}
        /*
		public void Cti
		{
			get { return btSoftBody_RContact_getCti(_native); }
			set { btSoftBody_RContact_setCti(_native, value._native); }
		}
        */
		public Node Node
		{
			get { return new Node(btSoftBody_RContact_getNode(_native)); }
			set { btSoftBody_RContact_setNode(_native, value._native); }
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
				btSoftBody_RContact_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~RContact()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_RContact_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_getC0(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_getC1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_RContact_getC2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_RContact_getC3(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_RContact_getC4(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_getCti(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_RContact_getNode(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_setC0(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_RContact_setC1(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_setC2(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_setC3(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_setC4(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_setCti(IntPtr obj, sCti value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_setNode(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RContact_delete(IntPtr obj);
	}

	public class SContact
	{
		internal IntPtr _native;

		internal SContact(IntPtr native)
		{
			_native = native;
		}

		public SContact()
		{
			_native = btSoftBody_SContact_new();
		}
        /*
		public float Cfm
		{
			get { return btSoftBody_SContact_getCfm(_native); }
			set { btSoftBody_SContact_setCfm(_native, value._native); }
		}
        */
		public Face Face
		{
			get { return new Face(btSoftBody_SContact_getFace(_native)); }
			set { btSoftBody_SContact_setFace(_native, value._native); }
		}

		public float Friction
		{
			get { return btSoftBody_SContact_getFriction(_native); }
			set { btSoftBody_SContact_setFriction(_native, value); }
		}

		public float Margin
		{
			get { return btSoftBody_SContact_getMargin(_native); }
			set { btSoftBody_SContact_setMargin(_native, value); }
		}

		public Node Node
		{
			get { return new Node(btSoftBody_SContact_getNode(_native)); }
			set { btSoftBody_SContact_setNode(_native, value._native); }
		}
        /*
		public void Normal
		{
			get { return btSoftBody_SContact_getNormal(_native); }
			set { btSoftBody_SContact_setNormal(_native, value._native); }
		}

		public void Weights
		{
			get { return btSoftBody_SContact_getWeights(_native); }
			set { btSoftBody_SContact_setWeights(_native, value._native); }
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
				btSoftBody_SContact_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SContact()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_SContact_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_SContact_getCfm(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_SContact_getFace(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SContact_getFriction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SContact_getMargin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_SContact_getNode(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_getNormal(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_getWeights(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setCfm(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setFace(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setFriction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setMargin(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setNode(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setNormal(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_setWeights(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SContact_delete(IntPtr obj);
	}

	public class Anchor
	{
		internal IntPtr _native;

		internal Anchor(IntPtr native)
		{
			_native = native;
		}

		public Anchor()
		{
			_native = btSoftBody_Anchor_new();
		}

		public RigidBody Body
		{
			get { return CollisionObject.GetManaged(btSoftBody_Anchor_getBody(_native)) as RigidBody; }
			set { btSoftBody_Anchor_setBody(_native, value._native); }
		}
        /*
		public void C0
		{
			get { return btSoftBody_Anchor_getC0(_native); }
			set { btSoftBody_Anchor_setC0(_native, value._native); }
		}

		public void C1
		{
			get { return btSoftBody_Anchor_getC1(_native); }
			set { btSoftBody_Anchor_setC1(_native, value._native); }
		}
        */
		public float C2
		{
			get { return btSoftBody_Anchor_getC2(_native); }
			set { btSoftBody_Anchor_setC2(_native, value); }
		}

		public float Influence
		{
			get { return btSoftBody_Anchor_getInfluence(_native); }
			set { btSoftBody_Anchor_setInfluence(_native, value); }
		}
        /*
		public void Local
		{
			get { return btSoftBody_Anchor_getLocal(_native); }
			set { btSoftBody_Anchor_setLocal(_native, value._native); }
		}
        */
		public Node Node
		{
			get { return new Node(btSoftBody_Anchor_getNode(_native)); }
			set { btSoftBody_Anchor_setNode(_native, value._native); }
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
				btSoftBody_Anchor_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Anchor()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Anchor_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Anchor_getBody(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_getC0(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_getC1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Anchor_getC2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Anchor_getInfluence(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_getLocal(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Anchor_getNode(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_setBody(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_setC0(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Anchor_setC1(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_setC2(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_setInfluence(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_setLocal(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_setNode(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Anchor_delete(IntPtr obj);
	}

	public class Note : Element
	{
		internal Note(IntPtr native)
			: base(native)
		{
		}

		public Note()
			: base(btSoftBody_Note_new())
		{
		}
        /*
		public float Coords
		{
			get { return btSoftBody_Note_getCoords(_native); }
			set { btSoftBody_Note_setCoords(_native, value._native); }
		}
        */
		public Node Nodes
		{
			get { return new Node(btSoftBody_Note_getNodes(_native)); }
			set { btSoftBody_Note_setNodes(_native, value._native); }
		}
        /*
		public void Offset
		{
			get { return btSoftBody_Note_getOffset(_native); }
			set { btSoftBody_Note_setOffset(_native, value._native); }
		}
        */
		public int Rank
		{
			get { return btSoftBody_Note_getRank(_native); }
			set { btSoftBody_Note_setRank(_native, value); }
		}

		public string Text
		{
			get { return btSoftBody_Note_getText(_native); }
			set { btSoftBody_Note_setText(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Note_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Note_getCoords(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Note_getNodes(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Note_getOffset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Note_getRank(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern string btSoftBody_Note_getText(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Note_setCoords(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Note_setNodes(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Note_setOffset(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Note_setRank(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Note_setText(IntPtr obj, string value);
	}

	public class Pose
	{
		internal IntPtr _native;

		internal Pose(IntPtr native)
		{
			_native = native;
		}

		public Pose()
		{
			_native = btSoftBody_Pose_new();
		}
        /*
		public void Aqq
		{
			get { return btSoftBody_Pose_getAqq(_native); }
			set { btSoftBody_Pose_setAqq(_native, value._native); }
		}
        */
		public bool Bframe
		{
			get { return btSoftBody_Pose_getBframe(_native); }
			set { btSoftBody_Pose_setBframe(_native, value); }
		}

		public bool Bvolume
		{
			get { return btSoftBody_Pose_getBvolume(_native); }
			set { btSoftBody_Pose_setBvolume(_native, value); }
		}
        /*
		public void Com
		{
			get { return btSoftBody_Pose_getCom(_native); }
			set { btSoftBody_Pose_setCom(_native, value._native); }
		}

		public tVector3Array Pos
		{
			get { return btSoftBody_Pose_getPos(_native); }
			set { btSoftBody_Pose_setPos(_native, value._native); }
		}

		public void Rot
		{
			get { return btSoftBody_Pose_getRot(_native); }
			set { btSoftBody_Pose_setRot(_native, value._native); }
		}

		public void Scl
		{
			get { return btSoftBody_Pose_getScl(_native); }
			set { btSoftBody_Pose_setScl(_native, value._native); }
		}

		public tScalarArray Wgh
		{
			get { return btSoftBody_Pose_getWgh(_native); }
			set { btSoftBody_Pose_setWgh(_native, value._native); }
		}
        */
		public float Volume
		{
			get { return btSoftBody_Pose_getVolume(_native); }
			set { btSoftBody_Pose_setVolume(_native, value); }
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
				btSoftBody_Pose_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Pose()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Pose_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_getAqq(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_Pose_getBframe(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_Pose_getBvolume(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_getCom(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Pose_getPos(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_getRot(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_getScl(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Pose_getWgh(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Pose_getVolume(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setAqq(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setBframe(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setBvolume(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setCom(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setPos(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Pose_setRot(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Pose_setScl(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setWgh(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_setVolume(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Pose_delete(IntPtr obj);
	}

	public class Cluster
	{
		internal IntPtr _native;

		internal Cluster(IntPtr native)
		{
			_native = native;
		}

		public Cluster()
		{
			_native = btSoftBody_Cluster_new();
		}

		public float Adamping
		{
			get { return btSoftBody_Cluster_getAdamping(_native); }
			set { btSoftBody_Cluster_setAdamping(_native, value); }
		}
        /*
		public void Av
		{
			get { return btSoftBody_Cluster_getAv(_native); }
			set { btSoftBody_Cluster_setAv(_native, value._native); }
		}
        */
		public int ClusterIndex
		{
			get { return btSoftBody_Cluster_getClusterIndex(_native); }
			set { btSoftBody_Cluster_setClusterIndex(_native, value); }
		}

		public bool Collide
		{
			get { return btSoftBody_Cluster_getCollide(_native); }
			set { btSoftBody_Cluster_setCollide(_native, value); }
		}
        /*
		public void Com
		{
			get { return btSoftBody_Cluster_getCom(_native); }
			set { btSoftBody_Cluster_setCom(_native, value._native); }
		}
        */
		public bool ContainsAnchor
		{
			get { return btSoftBody_Cluster_getContainsAnchor(_native); }
			set { btSoftBody_Cluster_setContainsAnchor(_native, value); }
		}
        /*
		public Vector3 Dimpulses
		{
			get
			{
				Vector3 value;
				btSoftBody_Cluster_getDimpulses(_native, out value);
				return value;
			}
			set { btSoftBody_Cluster_setDimpulses(_native, ref value); }
		}

		public tVector3Array Framerefs
		{
			get { return btSoftBody_Cluster_getFramerefs(_native); }
			set { btSoftBody_Cluster_setFramerefs(_native, value._native); }
		}

		public void Framexform
		{
			get { return btSoftBody_Cluster_getFramexform(_native); }
			set { btSoftBody_Cluster_setFramexform(_native, value._native); }
		}
        */
		public float Idmass
		{
			get { return btSoftBody_Cluster_getIdmass(_native); }
			set { btSoftBody_Cluster_setIdmass(_native, value); }
		}

		public float Imass
		{
			get { return btSoftBody_Cluster_getImass(_native); }
			set { btSoftBody_Cluster_setImass(_native, value); }
		}
        /*
		public void Invwi
		{
			get { return btSoftBody_Cluster_getInvwi(_native); }
			set { btSoftBody_Cluster_setInvwi(_native, value._native); }
		}
        */
		public float Ldamping
		{
			get { return btSoftBody_Cluster_getLdamping(_native); }
			set { btSoftBody_Cluster_setLdamping(_native, value); }
		}
        /*
		public DbvtNode Leaf
		{
			get { return btSoftBody_Cluster_getLeaf(_native); }
			set { btSoftBody_Cluster_setLeaf(_native, value._native); }
		}

		public void Locii
		{
			get { return btSoftBody_Cluster_getLocii(_native); }
			set { btSoftBody_Cluster_setLocii(_native, value._native); }
		}

		public void Lv
		{
			get { return btSoftBody_Cluster_getLv(_native); }
			set { btSoftBody_Cluster_setLv(_native, value._native); }
		}

		public tScalarArray Masses
		{
			get { return btSoftBody_Cluster_getMasses(_native); }
			set { btSoftBody_Cluster_setMasses(_native, value._native); }
		}
        */
		public float Matching
		{
			get { return btSoftBody_Cluster_getMatching(_native); }
			set { btSoftBody_Cluster_setMatching(_native, value); }
		}

		public float MaxSelfCollisionImpulse
		{
			get { return btSoftBody_Cluster_getMaxSelfCollisionImpulse(_native); }
			set { btSoftBody_Cluster_setMaxSelfCollisionImpulse(_native, value); }
		}

		public float Ndamping
		{
			get { return btSoftBody_Cluster_getNdamping(_native); }
			set { btSoftBody_Cluster_setNdamping(_native, value); }
		}

		public int Ndimpulses
		{
			get { return btSoftBody_Cluster_getNdimpulses(_native); }
			set { btSoftBody_Cluster_setNdimpulses(_native, value); }
		}
        /*
		public void Nodes
		{
			get { return btSoftBody_Cluster_getNodes(_native); }
			set { btSoftBody_Cluster_setNodes(_native, value._native); }
		}
        */
		public int Nvimpulses
		{
			get { return btSoftBody_Cluster_getNvimpulses(_native); }
			set { btSoftBody_Cluster_setNvimpulses(_native, value); }
		}

		public float SelfCollisionImpulseFactor
		{
			get { return btSoftBody_Cluster_getSelfCollisionImpulseFactor(_native); }
			set { btSoftBody_Cluster_setSelfCollisionImpulseFactor(_native, value); }
		}
        /*
		public Vector3 Vimpulses
		{
			get
			{
				Vector3 value;
				btSoftBody_Cluster_getVimpulses(_native, out value);
				return value;
			}
			set { btSoftBody_Cluster_setVimpulses(_native, ref value); }
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
				btSoftBody_Cluster_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Cluster()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Cluster_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getAdamping(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getAv(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Cluster_getClusterIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_Cluster_getCollide(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getCom(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_Cluster_getContainsAnchor(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Cluster_getDimpulses(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Cluster_getFramerefs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getFramexform(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getIdmass(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getImass(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getInvwi(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getLdamping(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Cluster_getLeaf(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getLocii(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getLv(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Cluster_getMasses(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getMatching(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getMaxSelfCollisionImpulse(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getNdamping(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Cluster_getNdimpulses(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_getNodes(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Cluster_getNvimpulses(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Cluster_getSelfCollisionImpulseFactor(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Cluster_getVimpulses(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setAdamping(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setAv(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setClusterIndex(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setCollide(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setCom(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setContainsAnchor(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setDimpulses(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setFramerefs(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setFramexform(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setIdmass(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setImass(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Cluster_setInvwi(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setLdamping(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setLeaf(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Cluster_setLocii(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setLv(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setMasses(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setMatching(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setMaxSelfCollisionImpulse(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setNdamping(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setNdimpulses(IntPtr obj, int value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_Cluster_setNodes(IntPtr obj, AlignedObjectArray<Node> value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setNvimpulses(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setSelfCollisionImpulseFactor(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_setVimpulses(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Cluster_delete(IntPtr obj);
	}

	public class Impulse
	{
		internal IntPtr _native;

		internal Impulse(IntPtr native)
		{
			_native = native;
		}

		public Impulse()
		{
			_native = btSoftBody_Impulse_new();
		}
        /*
		public void operator-(Impulse impulse)
		{
			btSoftBody_Impulse_operator_n(_native);
		}

		public void operator*(Impulse impulse, float x)
		{
			btSoftBody_Impulse_operator_m(_native, x);
		}
        */
		public int AsDrift
		{
			get { return btSoftBody_Impulse_getAsDrift(_native); }
			set { btSoftBody_Impulse_setAsDrift(_native, value); }
		}

		public int AsVelocity
		{
			get { return btSoftBody_Impulse_getAsVelocity(_native); }
			set { btSoftBody_Impulse_setAsVelocity(_native, value); }
		}
        /*
		public void Drift
		{
			get { return btSoftBody_Impulse_getDrift(_native); }
			set { btSoftBody_Impulse_setDrift(_native, value._native); }
		}

		public void Velocity
		{
			get { return btSoftBody_Impulse_getVelocity(_native); }
			set { btSoftBody_Impulse_setVelocity(_native, value._native); }
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
				btSoftBody_Impulse_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Impulse()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Impulse_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Impulse_getAsDrift(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Impulse_getAsVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_getDrift(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_getVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_operator_n(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_operator_m(IntPtr obj, float x);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_setAsDrift(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_setAsVelocity(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_setDrift(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_setVelocity(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Impulse_delete(IntPtr obj);
	}

	public class Body
	{
		internal IntPtr _native;

		internal Body(IntPtr native)
		{
			_native = native;
		}

		public Body()
		{
			_native = btSoftBody_Body_new();
		}

		public Body(CollisionObject colObj)
		{
			_native = btSoftBody_Body_new2(colObj._native);
		}

		public Body(Cluster p)
		{
			_native = btSoftBody_Body_new3(p._native);
		}

		public void Activate()
		{
			btSoftBody_Body_activate(_native);
		}

		public void AngularVelocity(Vector3 rpos)
		{
			btSoftBody_Body_angularVelocity(_native, ref rpos);
		}

		public void AngularVelocity()
		{
			btSoftBody_Body_angularVelocity2(_native);
		}

		public void ApplyAImpulse(Impulse impulse)
		{
			btSoftBody_Body_applyAImpulse(_native, impulse._native);
		}

		public void ApplyDAImpulse(Vector3 impulse)
		{
			btSoftBody_Body_applyDAImpulse(_native, ref impulse);
		}

		public void ApplyDCImpulse(Vector3 impulse)
		{
			btSoftBody_Body_applyDCImpulse(_native, ref impulse);
		}

		public void ApplyDImpulse(Vector3 impulse, Vector3 rpos)
		{
			btSoftBody_Body_applyDImpulse(_native, ref impulse, ref rpos);
		}

		public void ApplyImpulse(Impulse impulse, Vector3 rpos)
		{
			btSoftBody_Body_applyImpulse(_native, impulse._native, ref rpos);
		}

		public void ApplyVAImpulse(Vector3 impulse)
		{
			btSoftBody_Body_applyVAImpulse(_native, ref impulse);
		}

		public void ApplyVImpulse(Vector3 impulse, Vector3 rpos)
		{
			btSoftBody_Body_applyVImpulse(_native, ref impulse, ref rpos);
		}

		public float InvMass()
		{
			return btSoftBody_Body_invMass(_native);
		}
        /*
		public Matrix InvWorldInertia()
		{
			return btSoftBody_Body_invWorldInertia(_native);
		}
        */
		public void LinearVelocity()
		{
			btSoftBody_Body_linearVelocity(_native);
		}

		public void Velocity(Vector3 rpos)
		{
			btSoftBody_Body_velocity(_native, ref rpos);
		}
        /*
		public Matrix Xform()
		{
			return btSoftBody_Body_xform(_native);
		}
        */
		public CollisionObject CollisionObject
		{
            get { return CollisionObject.GetManaged(btSoftBody_Body_getCollisionObject(_native)); }
			set { btSoftBody_Body_setCollisionObject(_native, value._native); }
		}

		public RigidBody Rigid
		{
			get { return CollisionObject.GetManaged(btSoftBody_Body_getRigid(_native)) as RigidBody; }
			set { btSoftBody_Body_setRigid(_native, value._native); }
		}

		public Cluster Soft
		{
			get { return new Cluster(btSoftBody_Body_getSoft(_native)); }
			set { btSoftBody_Body_setSoft(_native, value._native); }
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
				btSoftBody_Body_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Body()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_new2(IntPtr colObj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_new3(IntPtr p);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_activate(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_angularVelocity(IntPtr obj, [In] ref Vector3 rpos);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_angularVelocity2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyAImpulse(IntPtr obj, IntPtr impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyDAImpulse(IntPtr obj, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyDCImpulse(IntPtr obj, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyDImpulse(IntPtr obj, [In] ref Vector3 impulse, [In] ref Vector3 rpos);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyImpulse(IntPtr obj, IntPtr impulse, [In] ref Vector3 rpos);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyVAImpulse(IntPtr obj, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_applyVImpulse(IntPtr obj, [In] ref Vector3 impulse, [In] ref Vector3 rpos);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_getCollisionObject(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_getRigid(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_getSoft(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Body_invMass(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_invWorldInertia(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_linearVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_setCollisionObject(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_setRigid(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_setSoft(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_velocity(IntPtr obj, [In] ref Vector3 rpos);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Body_xform(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Body_delete(IntPtr obj);
	}

	public class Joint
	{
		public class eType
		{
			internal IntPtr _native;

			internal eType(IntPtr native)
			{
				_native = native;
			}

			public eType()
			{
				_native = btSoftBody_Joint_eType_new();
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
					btSoftBody_Joint_eType_delete(_native);
					_native = IntPtr.Zero;
				}
			}

			~eType()
			{
				Dispose(false);
			}

			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern IntPtr btSoftBody_Joint_eType_new();
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_Joint_eType_delete(IntPtr obj);
		}

		public class Specs
		{
			internal IntPtr _native;

			internal Specs(IntPtr native)
			{
				_native = native;
			}

			public Specs()
			{
				_native = btSoftBody_Joint_Specs_new();
			}

			public float Cfm
			{
				get { return btSoftBody_Joint_Specs_getCfm(_native); }
				set { btSoftBody_Joint_Specs_setCfm(_native, value); }
			}

			public float Erp
			{
				get { return btSoftBody_Joint_Specs_getErp(_native); }
				set { btSoftBody_Joint_Specs_setErp(_native, value); }
			}

			public float Split
			{
				get { return btSoftBody_Joint_Specs_getSplit(_native); }
				set { btSoftBody_Joint_Specs_setSplit(_native, value); }
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
					btSoftBody_Joint_Specs_delete(_native);
					_native = IntPtr.Zero;
				}
			}

			~Specs()
			{
				Dispose(false);
			}

			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern IntPtr btSoftBody_Joint_Specs_new();
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern float btSoftBody_Joint_Specs_getCfm(IntPtr obj);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern float btSoftBody_Joint_Specs_getErp(IntPtr obj);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern float btSoftBody_Joint_Specs_getSplit(IntPtr obj);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_Joint_Specs_setCfm(IntPtr obj, float value);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_Joint_Specs_setErp(IntPtr obj, float value);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_Joint_Specs_setSplit(IntPtr obj, float value);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_Joint_Specs_delete(IntPtr obj);
		}

		internal IntPtr _native;

		internal Joint(IntPtr native)
		{
			_native = native;
		}

		public void Prepare(float dt, int iterations)
		{
			btSoftBody_Joint_Prepare(_native, dt, iterations);
		}

		public void Solve(float dt, float sor)
		{
			btSoftBody_Joint_Solve(_native, dt, sor);
		}

		public void Terminate(float dt)
		{
			btSoftBody_Joint_Terminate(_native, dt);
		}

		public void Type()
		{
			btSoftBody_Joint_Type(_native);
		}
        /*
		public Body Bodies
		{
			get { return btSoftBody_Joint_getBodies(_native); }
			set { btSoftBody_Joint_setBodies(_native, value._native); }
		}
        */
		public float Cfm
		{
			get { return btSoftBody_Joint_getCfm(_native); }
			set { btSoftBody_Joint_setCfm(_native, value); }
		}

		public bool Delete
		{
			get { return btSoftBody_Joint_getDelete(_native); }
			set { btSoftBody_Joint_setDelete(_native, value); }
		}
        /*
		public void Drift
		{
			get { return btSoftBody_Joint_getDrift(_native); }
			set { btSoftBody_Joint_setDrift(_native, value._native); }
		}
        */
		public float Erp
		{
			get { return btSoftBody_Joint_getErp(_native); }
			set { btSoftBody_Joint_setErp(_native, value); }
		}
        /*
		public void Massmatrix
		{
			get { return btSoftBody_Joint_getMassmatrix(_native); }
			set { btSoftBody_Joint_setMassmatrix(_native, value._native); }
		}

		public Vector3 Refs
		{
			get
			{
				Vector3 value;
				btSoftBody_Joint_getRefs(_native, out value);
				return value;
			}
			set { btSoftBody_Joint_setRefs(_native, ref value); }
		}

		public void Sdrift
		{
			get { return btSoftBody_Joint_getSdrift(_native); }
			set { btSoftBody_Joint_setSdrift(_native, value._native); }
		}
        */
		public float Split
		{
			get { return btSoftBody_Joint_getSplit(_native); }
			set { btSoftBody_Joint_setSplit(_native, value); }
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
				btSoftBody_Joint_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Joint()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Joint_getBodies(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Joint_getCfm(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_Joint_getDelete(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_getDrift(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Joint_getErp(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_getMassmatrix(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Joint_getRefs(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_getSdrift(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Joint_getSplit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_Prepare(IntPtr obj, float dt, int iterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setBodies(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setCfm(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setDelete(IntPtr obj, bool value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setDrift(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setErp(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Joint_setMassmatrix(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setRefs(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setSdrift(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_setSplit(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_Solve(IntPtr obj, float dt, float sor);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_Terminate(IntPtr obj, float dt);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_Type(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Joint_delete(IntPtr obj);
	}

	public class LJoint : Joint
	{
		internal LJoint(IntPtr native)
			: base(native)
		{
		}

		public LJoint()
			: base(btSoftBody_LJoint_new())
		{
		}

		public Vector3 Rpos
		{
			get
			{
				Vector3 value;
				btSoftBody_LJoint_getRpos(_native, out value);
				return value;
			}
			set { btSoftBody_LJoint_setRpos(_native, ref value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_LJoint_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_LJoint_getRpos(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_LJoint_setRpos(IntPtr obj, [In] ref Vector3 value);
	}

	public class AJoint : Joint
	{
		public class IControl
		{
			internal IntPtr _native;

			internal IControl(IntPtr native)
			{
				_native = native;
			}

			public IControl()
			{
				_native = btSoftBody_AJoint_IControl_new();
			}

			public IControl Default()
			{
                return new IControl(btSoftBody_AJoint_IControl_Default());
			}

			public void Prepare(AJoint __unnamed0)
			{
				btSoftBody_AJoint_IControl_Prepare(_native, __unnamed0._native);
			}

			public float Speed(AJoint __unnamed0, float current)
			{
				return btSoftBody_AJoint_IControl_Speed(_native, __unnamed0._native, current);
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
					btSoftBody_AJoint_IControl_delete(_native);
					_native = IntPtr.Zero;
				}
			}

			~IControl()
			{
				Dispose(false);
			}

			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern IntPtr btSoftBody_AJoint_IControl_new();
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern IntPtr btSoftBody_AJoint_IControl_Default();
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_AJoint_IControl_Prepare(IntPtr obj, IntPtr __unnamed0);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern float btSoftBody_AJoint_IControl_Speed(IntPtr obj, IntPtr __unnamed0, float current);
			[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
			static extern void btSoftBody_AJoint_IControl_delete(IntPtr obj);
		}

		internal AJoint(IntPtr native)
			: base(native)
		{
		}

		public AJoint()
			: base(btSoftBody_AJoint_new())
		{
		}

		public Vector3 Axis
		{
			get
			{
				Vector3 value;
				btSoftBody_AJoint_getAxis(_native, out value);
				return value;
			}
			set { btSoftBody_AJoint_setAxis(_native, ref value); }
		}

		public IControl Icontrol
		{
			get { return new IControl(btSoftBody_AJoint_getIcontrol(_native)); }
			set { btSoftBody_AJoint_setIcontrol(_native, value._native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_AJoint_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_AJoint_getAxis(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_AJoint_getIcontrol(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_AJoint_setAxis(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_AJoint_setIcontrol(IntPtr obj, IntPtr value);
	}

	public class CJoint : Joint
	{
		internal CJoint(IntPtr native)
			: base(native)
		{
		}

		public CJoint()
			: base(btSoftBody_CJoint_new())
		{
		}

		public float Friction
		{
			get { return btSoftBody_CJoint_getFriction(_native); }
			set { btSoftBody_CJoint_setFriction(_native, value); }
		}

		public int Life
		{
			get { return btSoftBody_CJoint_getLife(_native); }
			set { btSoftBody_CJoint_setLife(_native, value); }
		}

		public int Maxlife
		{
			get { return btSoftBody_CJoint_getMaxlife(_native); }
			set { btSoftBody_CJoint_setMaxlife(_native, value); }
		}
        /*
		public void Normal
		{
			get { return btSoftBody_CJoint_getNormal(_native); }
			set { btSoftBody_CJoint_setNormal(_native, value._native); }
		}
        */
		public Vector3 Rpos
		{
			get
			{
				Vector3 value;
				btSoftBody_CJoint_getRpos(_native, out value);
				return value;
			}
			set { btSoftBody_CJoint_setRpos(_native, ref value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_CJoint_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_CJoint_getFriction(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_CJoint_getLife(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_CJoint_getMaxlife(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_CJoint_getNormal(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_CJoint_getRpos(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_CJoint_setFriction(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_CJoint_setLife(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_CJoint_setMaxlife(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_CJoint_setNormal(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_CJoint_setRpos(IntPtr obj, [In] ref Vector3 value);
	}

	public class Config
	{
		internal IntPtr _native;

		internal Config(IntPtr native)
		{
			_native = native;
		}

		public Config()
		{
			_native = btSoftBody_Config_new();
		}

        public AeroModel Aeromodel
		{
			get { return btSoftBody_Config_getAeromodel(_native); }
			set { btSoftBody_Config_setAeromodel(_native, value); }
		}

		public int CIterations
		{
			get { return btSoftBody_Config_getCiterations(_native); }
			set { btSoftBody_Config_setCiterations(_native, value); }
		}

		public int Collisions
		{
			get { return btSoftBody_Config_getCollisions(_native); }
			set { btSoftBody_Config_setCollisions(_native, value); }
		}

		public int Diterations
		{
			get { return btSoftBody_Config_getDiterations(_native); }
			set { btSoftBody_Config_setDiterations(_native, value); }
		}
        /*
		public tPSolverArray Dsequence
		{
			get { return btSoftBody_Config_getDsequence(_native); }
			set { btSoftBody_Config_setDsequence(_native, value._native); }
		}
        */
		public float KAHR
		{
			get { return btSoftBody_Config_getKAHR(_native); }
			set { btSoftBody_Config_setKAHR(_native, value); }
		}

		public float KCHR
		{
			get { return btSoftBody_Config_getKCHR(_native); }
			set { btSoftBody_Config_setKCHR(_native, value); }
		}

		public float KDF
		{
			get { return btSoftBody_Config_getKDF(_native); }
			set { btSoftBody_Config_setKDF(_native, value); }
		}

		public float KDG
		{
			get { return btSoftBody_Config_getKDG(_native); }
			set { btSoftBody_Config_setKDG(_native, value); }
		}

		public float KDP
		{
			get { return btSoftBody_Config_getKDP(_native); }
			set { btSoftBody_Config_setKDP(_native, value); }
		}

		public float KKHR
		{
			get { return btSoftBody_Config_getKKHR(_native); }
			set { btSoftBody_Config_setKKHR(_native, value); }
		}

		public float KLF
		{
			get { return btSoftBody_Config_getKLF(_native); }
			set { btSoftBody_Config_setKLF(_native, value); }
		}

		public float KMT
		{
			get { return btSoftBody_Config_getKMT(_native); }
			set { btSoftBody_Config_setKMT(_native, value); }
		}

		public float KPR
		{
			get { return btSoftBody_Config_getKPR(_native); }
			set { btSoftBody_Config_setKPR(_native, value); }
		}

		public float KSHR
		{
			get { return btSoftBody_Config_getKSHR(_native); }
			set { btSoftBody_Config_setKSHR(_native, value); }
		}

		public float KSK_SPLT_CL
		{
			get { return btSoftBody_Config_getKSK_SPLT_CL(_native); }
			set { btSoftBody_Config_setKSK_SPLT_CL(_native, value); }
		}

		public float KSKHR_CL
		{
			get { return btSoftBody_Config_getKSKHR_CL(_native); }
			set { btSoftBody_Config_setKSKHR_CL(_native, value); }
		}

		public float KSR_SPLT_CL
		{
			get { return btSoftBody_Config_getKSR_SPLT_CL(_native); }
			set { btSoftBody_Config_setKSR_SPLT_CL(_native, value); }
		}

		public float KSRHR_CL
		{
			get { return btSoftBody_Config_getKSRHR_CL(_native); }
			set { btSoftBody_Config_setKSRHR_CL(_native, value); }
		}

		public float KSS_SPLT_CL
		{
			get { return btSoftBody_Config_getKSS_SPLT_CL(_native); }
			set { btSoftBody_Config_setKSS_SPLT_CL(_native, value); }
		}

		public float KSSHR_CL
		{
			get { return btSoftBody_Config_getKSSHR_CL(_native); }
			set { btSoftBody_Config_setKSSHR_CL(_native, value); }
		}

		public float KVC
		{
			get { return btSoftBody_Config_getKVC(_native); }
			set { btSoftBody_Config_setKVC(_native, value); }
		}

		public float KVCF
		{
			get { return btSoftBody_Config_getKVCF(_native); }
			set { btSoftBody_Config_setKVCF(_native, value); }
		}

		public float Maxvolume
		{
			get { return btSoftBody_Config_getMaxvolume(_native); }
			set { btSoftBody_Config_setMaxvolume(_native, value); }
		}

		public int Piterations
		{
			get { return btSoftBody_Config_getPiterations(_native); }
			set { btSoftBody_Config_setPiterations(_native, value); }
		}
        /*
		public tPSolverArray Psequence
		{
			get { return btSoftBody_Config_getPsequence(_native); }
			set { btSoftBody_Config_setPsequence(_native, value._native); }
		}
        */
		public float Timescale
		{
			get { return btSoftBody_Config_getTimescale(_native); }
			set { btSoftBody_Config_setTimescale(_native, value); }
		}

		public int Viterations
		{
			get { return btSoftBody_Config_getViterations(_native); }
			set { btSoftBody_Config_setViterations(_native, value); }
		}
        /*
		public tVSolverArray Vsequence
		{
			get { return btSoftBody_Config_getVsequence(_native); }
			set { btSoftBody_Config_setVsequence(_native, value._native); }
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
				btSoftBody_Config_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~Config()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Config_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern AeroModel btSoftBody_Config_getAeromodel(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Config_getCiterations(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Config_getCollisions(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Config_getDiterations(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Config_getDsequence(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKAHR(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKCHR(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKDF(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKDG(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKDP(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKKHR(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKLF(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKMT(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKPR(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSHR(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSK_SPLT_CL(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSKHR_CL(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSR_SPLT_CL(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSRHR_CL(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSS_SPLT_CL(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKSSHR_CL(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKVC(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getKVCF(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getMaxvolume(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Config_getPiterations(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Config_getPsequence(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_Config_getTimescale(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_Config_getViterations(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_Config_getVsequence(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_Config_setAeromodel(IntPtr obj, AeroModel value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setCiterations(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setCollisions(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setDiterations(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setDsequence(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKAHR(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKCHR(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKDF(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKDG(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKDP(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKKHR(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKLF(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKMT(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKPR(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSHR(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSK_SPLT_CL(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSKHR_CL(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSR_SPLT_CL(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSRHR_CL(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSS_SPLT_CL(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKSSHR_CL(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKVC(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setKVCF(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setMaxvolume(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setPiterations(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setPsequence(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setTimescale(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setViterations(IntPtr obj, int value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_setVsequence(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_Config_delete(IntPtr obj);
	}

	public class SolverState
	{
		internal IntPtr _native;

		internal SolverState(IntPtr native)
		{
			_native = native;
		}

		public SolverState()
		{
			_native = btSoftBody_SolverState_new();
		}

		public float Isdt
		{
			get { return btSoftBody_SolverState_getIsdt(_native); }
			set { btSoftBody_SolverState_setIsdt(_native, value); }
		}

		public float Radmrg
		{
			get { return btSoftBody_SolverState_getRadmrg(_native); }
			set { btSoftBody_SolverState_setRadmrg(_native, value); }
		}

		public float Sdt
		{
			get { return btSoftBody_SolverState_getSdt(_native); }
			set { btSoftBody_SolverState_setSdt(_native, value); }
		}

		public float Updmrg
		{
			get { return btSoftBody_SolverState_getUpdmrg(_native); }
			set { btSoftBody_SolverState_setUpdmrg(_native, value); }
		}

		public float Velmrg
		{
			get { return btSoftBody_SolverState_getVelmrg(_native); }
			set { btSoftBody_SolverState_setVelmrg(_native, value); }
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
				btSoftBody_SolverState_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~SolverState()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_SolverState_new();
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SolverState_getIsdt(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SolverState_getRadmrg(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SolverState_getSdt(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SolverState_getUpdmrg(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_SolverState_getVelmrg(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SolverState_setIsdt(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SolverState_setRadmrg(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SolverState_setSdt(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SolverState_setUpdmrg(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SolverState_setVelmrg(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_SolverState_delete(IntPtr obj);
	}
    /*
	public class RayFromToCaster : ICollide
	{
		internal RayFromToCaster(IntPtr native)
			: base(native)
		{
		}

		public RayFromToCaster(Vector3 rayFrom, Vector3 rayTo, float mxt)
			: base(btSoftBody_RayFromToCaster_new(ref rayFrom, ref rayTo, mxt))
		{
		}

		public float RayFromToTriangle(Vector3 rayFrom, Vector3 rayTo, Vector3 rayNormalizedDirection, Vector3 a, Vector3 b, Vector3 c, float maxt)
		{
			return btSoftBody_RayFromToCaster_rayFromToTriangle(ref rayFrom, ref rayTo, ref rayNormalizedDirection, ref a, ref b, ref c, maxt);
		}

		public float RayFromToTriangle(Vector3 rayFrom, Vector3 rayTo, Vector3 rayNormalizedDirection, Vector3 a, Vector3 b, Vector3 c)
		{
			return btSoftBody_RayFromToCaster_rayFromToTriangle2(ref rayFrom, ref rayTo, ref rayNormalizedDirection, ref a, ref b, ref c);
		}

		public Face Face
		{
			get { return btSoftBody_RayFromToCaster_getFace(_native); }
			set { btSoftBody_RayFromToCaster_setFace(_native, value._native); }
		}

		public float Mint
		{
			get { return btSoftBody_RayFromToCaster_getMint(_native); }
			set { btSoftBody_RayFromToCaster_setMint(_native, value); }
		}

		public void RayFrom
		{
			get { return btSoftBody_RayFromToCaster_getRayFrom(_native); }
			set { btSoftBody_RayFromToCaster_setRayFrom(_native, value._native); }
		}

		public void RayNormalizedDirection
		{
			get { return btSoftBody_RayFromToCaster_getRayNormalizedDirection(_native); }
			set { btSoftBody_RayFromToCaster_setRayNormalizedDirection(_native, value._native); }
		}

		public void RayTo
		{
			get { return btSoftBody_RayFromToCaster_getRayTo(_native); }
			set { btSoftBody_RayFromToCaster_setRayTo(_native, value._native); }
		}

		public int Tests
		{
			get { return btSoftBody_RayFromToCaster_getTests(_native); }
			set { btSoftBody_RayFromToCaster_setTests(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_RayFromToCaster_new([In] ref Vector3 rayFrom, [In] ref Vector3 rayTo, float mxt);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_RayFromToCaster_getFace(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_RayFromToCaster_getMint(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_getRayFrom(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_getRayNormalizedDirection(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_getRayTo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_RayFromToCaster_getTests(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_RayFromToCaster_rayFromToTriangle([In] ref Vector3 rayFrom, [In] ref Vector3 rayTo, [In] ref Vector3 rayNormalizedDirection, [In] ref Vector3 a, [In] ref Vector3 b, [In] ref Vector3 c, float maxt);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_RayFromToCaster_rayFromToTriangle2([In] ref Vector3 rayFrom, [In] ref Vector3 rayTo, [In] ref Vector3 rayNormalizedDirection, [In] ref Vector3 a, [In] ref Vector3 b, [In] ref Vector3 c);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_setFace(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_setMint(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_setRayFrom(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_setRayNormalizedDirection(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_setRayTo(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_RayFromToCaster_setTests(IntPtr obj, int value);
	}
    */

    public class SoftBody : CollisionObject
    {
		internal SoftBody(IntPtr native)
			: base(native)
		{
		}
        /*
		public SoftBody(SoftBodyWorldInfo worldInfo, int node_count, Vector3 x, float m)
			: base(btSoftBody_new(worldInfo._native, node_count, ref x, m._native))
		{
		}
        */
		public SoftBody(SoftBodyWorldInfo worldInfo)
			: base(btSoftBody_new2(worldInfo._native))
		{
		}

		public void AddAeroForceToFace(Vector3 windVelocity, int faceIndex)
		{
			btSoftBody_addAeroForceToFace(_native, ref windVelocity, faceIndex);
		}

		public void AddAeroForceToNode(Vector3 windVelocity, int nodeIndex)
		{
			btSoftBody_addAeroForceToNode(_native, ref windVelocity, nodeIndex);
		}

		public void AddForce(Vector3 force)
		{
			btSoftBody_addForce(_native, ref force);
		}

		public void AddForce(Vector3 force, int node)
		{
			btSoftBody_addForce2(_native, ref force, node);
		}

		public void AddVelocity(Vector3 velocity, int node)
		{
			btSoftBody_addVelocity(_native, ref velocity, node);
		}

		public void AddVelocity(Vector3 velocity)
		{
			btSoftBody_addVelocity2(_native, ref velocity);
		}

		public void AppendAnchor(int node, RigidBody body, Vector3 localPivot, bool disableCollisionBetweenLinkedBodies, float influence)
		{
			btSoftBody_appendAnchor(_native, node, body._native, ref localPivot, disableCollisionBetweenLinkedBodies, influence);
		}

		public void AppendAnchor(int node, RigidBody body, Vector3 localPivot, bool disableCollisionBetweenLinkedBodies)
		{
			btSoftBody_appendAnchor2(_native, node, body._native, ref localPivot, disableCollisionBetweenLinkedBodies);
		}

		public void AppendAnchor(int node, RigidBody body, Vector3 localPivot)
		{
			btSoftBody_appendAnchor3(_native, node, body._native, ref localPivot);
		}

		public void AppendAnchor(int node, RigidBody body, bool disableCollisionBetweenLinkedBodies, float influence)
		{
			btSoftBody_appendAnchor4(_native, node, body._native, disableCollisionBetweenLinkedBodies, influence);
		}

		public void AppendAnchor(int node, RigidBody body, bool disableCollisionBetweenLinkedBodies)
		{
			btSoftBody_appendAnchor5(_native, node, body._native, disableCollisionBetweenLinkedBodies);
		}

		public void AppendAnchor(int node, RigidBody body)
		{
			btSoftBody_appendAnchor6(_native, node, body._native);
		}
        
		public void AppendAngularJoint(AJoint.Specs specs, Body body)
		{
			btSoftBody_appendAngularJoint(_native, specs._native, body._native);
		}

        public void AppendAngularJoint(AJoint.Specs specs)
		{
			btSoftBody_appendAngularJoint2(_native, specs._native);
		}

        public void AppendAngularJoint(AJoint.Specs specs, Cluster body0, Body body1)
		{
			btSoftBody_appendAngularJoint3(_native, specs._native, body0._native, body1._native);
		}

        public void AppendAngularJoint(AJoint.Specs specs, SoftBody body)
		{
			btSoftBody_appendAngularJoint4(_native, specs._native, body._native);
		}

		public void AppendFace(int model, Material mat)
		{
			btSoftBody_appendFace(_native, model, mat._native);
		}

		public void AppendFace(int model)
		{
			btSoftBody_appendFace2(_native, model);
		}

		public void AppendFace()
		{
			btSoftBody_appendFace3(_native);
		}

		public void AppendFace(int node0, int node1, int node2, Material mat)
		{
			btSoftBody_appendFace4(_native, node0, node1, node2, mat._native);
		}

		public void AppendFace(int node0, int node1, int node2)
		{
			btSoftBody_appendFace5(_native, node0, node1, node2);
		}

        public void AppendLinearJoint(LJoint.Specs specs, SoftBody body)
		{
			btSoftBody_appendLinearJoint(_native, specs._native, body._native);
		}

        public void AppendLinearJoint(LJoint.Specs specs, Body body)
		{
			btSoftBody_appendLinearJoint2(_native, specs._native, body._native);
		}

        public void AppendLinearJoint(LJoint.Specs specs)
		{
			btSoftBody_appendLinearJoint3(_native, specs._native);
		}

		public void AppendLinearJoint(LJoint.Specs specs, Cluster body0, Body body1)
		{
			btSoftBody_appendLinearJoint4(_native, specs._native, body0._native, body1._native);
		}

        public void AppendLink(int node0, int node1, Material mat, bool bcheckexist)
		{
			btSoftBody_appendLink(_native, node0, node1, mat._native, bcheckexist);
		}

		public void AppendLink(int node0, int node1, Material mat)
		{
			btSoftBody_appendLink2(_native, node0, node1, mat._native);
		}

		public void AppendLink(int node0, int node1)
		{
			btSoftBody_appendLink3(_native, node0, node1);
		}

		public void AppendLink(int model, Material mat)
		{
			btSoftBody_appendLink4(_native, model, mat._native);
		}

		public void AppendLink(int model)
		{
			btSoftBody_appendLink5(_native, model);
		}

		public void AppendLink()
		{
			btSoftBody_appendLink6(_native);
		}

		public void AppendLink(Node node0, Node node1, Material mat, bool bcheckexist)
		{
			btSoftBody_appendLink7(_native, node0._native, node1._native, mat._native, bcheckexist);
		}

		public void AppendLink(Node node0, Node node1, Material mat)
		{
			btSoftBody_appendLink8(_native, node0._native, node1._native, mat._native);
		}

		public void AppendLink(Node node0, Node node1)
		{
			btSoftBody_appendLink9(_native, node0._native, node1._native);
		}

		public Material AppendMaterial()
		{
			return new Material(btSoftBody_appendMaterial(_native));
		}

		public void AppendNode(Vector3 x, float m)
		{
			btSoftBody_appendNode(_native, ref x, m);
		}

		public void AppendNote(string text, Vector3 o, Face feature)
		{
			btSoftBody_appendNote(_native, text, ref o, feature._native);
		}

        public void AppendNote(string text, Vector3 o, Link feature)
		{
			btSoftBody_appendNote2(_native, text, ref o, feature._native);
		}

        public void AppendNote(string text, Vector3 o, Node feature)
		{
			btSoftBody_appendNote3(_native, text, ref o, feature._native);
		}

        public void AppendNote(string text, Vector3 o, Vector4 c, Node n0, Node n1, Node n2, Node n3)
		{
			btSoftBody_appendNote4(_native, text, ref o, ref c, n0._native, n1._native, n2._native, n3._native);
		}

        public void AppendNote(string text, Vector3 o, Vector4 c, Node n0, Node n1, Node n2)
		{
			btSoftBody_appendNote5(_native, text, ref o, ref c, n0._native, n1._native, n2._native);
		}

        public void AppendNote(string text, Vector3 o, Vector4 c, Node n0, Node n1)
		{
			btSoftBody_appendNote6(_native, text, ref o, ref c, n0._native, n1._native);
		}

        public void AppendNote(string text, Vector3 o, Vector4 c, Node n0)
		{
			btSoftBody_appendNote7(_native, text, ref o, ref c, n0._native);
		}

        public void AppendNote(string text, Vector3 o, Vector4 c)
		{
			btSoftBody_appendNote8(_native, text, ref o, ref c);
		}

        public void AppendNote(string text, Vector3 o)
		{
			btSoftBody_appendNote9(_native, text, ref o);
		}

		public void AppendTetra(int model, Material mat)
		{
			btSoftBody_appendTetra(_native, model, mat._native);
		}

		public void AppendTetra(int node0, int node1, int node2, int node3, Material mat)
		{
			btSoftBody_appendTetra2(_native, node0, node1, node2, node3, mat._native);
		}

		public void AppendTetra(int node0, int node1, int node2, int node3)
		{
			btSoftBody_appendTetra3(_native, node0, node1, node2, node3);
		}

		public void ApplyClusters(bool drift)
		{
			btSoftBody_applyClusters(_native, drift);
		}

		public void ApplyForces()
		{
			btSoftBody_applyForces(_native);
		}

		public bool CheckContact(CollisionObjectWrapper colObjWrap, Vector3 x, float margin, sCti cti)
		{
			return btSoftBody_checkContact(_native, colObjWrap._native, ref x, margin, cti._native);
		}

		public bool CheckFace(int node0, int node1, int node2)
		{
			return btSoftBody_checkFace(_native, node0, node1, node2);
		}

		public bool CheckLink(Node node0, Node node1)
		{
			return btSoftBody_checkLink(_native, node0._native, node1._native);
		}

		public bool CheckLink(int node0, int node1)
		{
			return btSoftBody_checkLink2(_native, node0, node1);
		}

		public void CleanupClusters()
		{
			btSoftBody_cleanupClusters(_native);
		}

		public void ClusterAImpulse(Cluster cluster, Impulse impulse)
		{
			btSoftBody_clusterAImpulse(cluster._native, impulse._native);
		}

		public void ClusterCom(Cluster cluster)
		{
			btSoftBody_clusterCom(cluster._native);
		}

		public void ClusterCom(int cluster)
		{
			btSoftBody_clusterCom2(_native, cluster);
		}

		public int ClusterCount()
		{
			return btSoftBody_clusterCount(_native);
		}

		public void ClusterDAImpulse(Cluster cluster, Vector3 impulse)
		{
			btSoftBody_clusterDAImpulse(cluster._native, ref impulse);
		}

		public void ClusterDCImpulse(Cluster cluster, Vector3 impulse)
		{
			btSoftBody_clusterDCImpulse(cluster._native, ref impulse);
		}

		public void ClusterDImpulse(Cluster cluster, Vector3 rpos, Vector3 impulse)
		{
			btSoftBody_clusterDImpulse(cluster._native, ref rpos, ref impulse);
		}

		public void ClusterImpulse(Cluster cluster, Vector3 rpos, Impulse impulse)
		{
			btSoftBody_clusterImpulse(cluster._native, ref rpos, impulse._native);
		}

		public void ClusterVAImpulse(Cluster cluster, Vector3 impulse)
		{
			btSoftBody_clusterVAImpulse(cluster._native, ref impulse);
		}

		public void ClusterVelocity(Cluster cluster, Vector3 rpos)
		{
			btSoftBody_clusterVelocity(cluster._native, ref rpos);
		}

		public void ClusterVImpulse(Cluster cluster, Vector3 rpos, Vector3 impulse)
		{
			btSoftBody_clusterVImpulse(cluster._native, ref rpos, ref impulse);
		}

		public bool CutLink(int node0, int node1, float position)
		{
			return btSoftBody_cutLink(_native, node0, node1, position);
		}

		public bool CutLink(Node node0, Node node1, float position)
		{
			return btSoftBody_cutLink2(_native, node0._native, node1._native, position);
		}

		public void DampClusters()
		{
			btSoftBody_dampClusters(_native);
		}

		public void DefaultCollisionHandler(CollisionObjectWrapper pcoWrap)
		{
			btSoftBody_defaultCollisionHandler(_native, pcoWrap._native);
		}

		public void DefaultCollisionHandler(SoftBody psb)
		{
			btSoftBody_defaultCollisionHandler2(_native, psb._native);
		}

		public void EvaluateCom()
		{
			btSoftBody_evaluateCom(_native);
		}

		public int GenerateBendingConstraints(int distance, Material mat)
		{
			return btSoftBody_generateBendingConstraints(_native, distance, mat._native);
		}

		public int GenerateBendingConstraints(int distance)
		{
			return btSoftBody_generateBendingConstraints2(_native, distance);
		}

		public int GenerateClusters(int k, int maxiterations)
		{
			return btSoftBody_generateClusters(_native, k, maxiterations);
		}

		public int GenerateClusters(int k)
		{
			return btSoftBody_generateClusters2(_native, k);
		}

		public void GetAabb(Vector3 aabbMin, Vector3 aabbMax)
		{
			btSoftBody_getAabb(_native, ref aabbMin, ref aabbMax);
		}

		public float GetMass(int node)
		{
			return btSoftBody_getMass(_native, node);
		}
        /*
		public psolver_t GetSolver(void solver)
		{
			return btSoftBody_getSolver(solver._native);
		}

		public vsolver_t GetSolver(void solver)
		{
			return btSoftBody_getSolver2(solver._native);
		}

		public void IndicesToPointers(int map)
		{
			btSoftBody_indicesToPointers(_native, map._native);
		}
        */
		public void IndicesToPointers()
		{
			btSoftBody_indicesToPointers2(_native);
		}

		public void InitDefaults()
		{
			btSoftBody_initDefaults(_native);
		}

		public void InitializeClusters()
		{
			btSoftBody_initializeClusters(_native);
		}

		public void InitializeFaceTree()
		{
			btSoftBody_initializeFaceTree(_native);
		}

		public void IntegrateMotion()
		{
			btSoftBody_integrateMotion(_native);
		}

		public void PointersToIndices()
		{
			btSoftBody_pointersToIndices(_native);
		}

		public void PredictMotion(float dt)
		{
			btSoftBody_predictMotion(_native, dt);
		}

		public void PrepareClusters(int iterations)
		{
			btSoftBody_prepareClusters(_native, iterations);
		}

		public void PSolve_Anchors(SoftBody psb, float kst, float ti)
		{
			btSoftBody_PSolve_Anchors(psb._native, kst, ti);
		}

		public void PSolve_Links(SoftBody psb, float kst, float ti)
		{
			btSoftBody_PSolve_Links(psb._native, kst, ti);
		}

		public void PSolve_RContacts(SoftBody psb, float kst, float ti)
		{
			btSoftBody_PSolve_RContacts(psb._native, kst, ti);
		}

		public void PSolve_SContacts(SoftBody psb, float __unnamed1, float ti)
		{
			btSoftBody_PSolve_SContacts(psb._native, __unnamed1, ti);
		}

		public void RandomizeConstraints()
		{
			btSoftBody_randomizeConstraints(_native);
		}
        /*
		public int RayTest(Vector3 rayFrom, Vector3 rayTo, float mint, _ feature, int index, bool bcountonly)
		{
			return btSoftBody_rayTest(_native, ref rayFrom, ref rayTo, mint._native, feature._native, index._native, bcountonly);
		}
        */
        public bool RayTest(Vector3 rayFrom, Vector3 rayTo, SRayCast results)
		{
			return btSoftBody_rayTest2(_native, ref rayFrom, ref rayTo, results._native);
		}

		public void Refine(ImplicitFn ifn, float accurary, bool cut)
		{
			btSoftBody_refine(_native, ifn._native, accurary, cut);
		}

		public void ReleaseCluster(int index)
		{
			btSoftBody_releaseCluster(_native, index);
		}

		public void ReleaseClusters()
		{
			btSoftBody_releaseClusters(_native);
		}

		public void ResetLinkRestLengths()
		{
			btSoftBody_resetLinkRestLengths(_native);
		}

		public void Rotate(Quaternion rot)
		{
			btSoftBody_rotate(_native, ref rot);
		}

		public void Scale(Vector3 scl)
		{
			btSoftBody_scale(_native, ref scl);
		}

		public void SetMass(int node, float mass)
		{
			btSoftBody_setMass(_native, node, mass);
		}

		public void SetPose(bool bvolume, bool bframe)
		{
			btSoftBody_setPose2(_native, bvolume, bframe);
		}
        /*
		public void SetSolver(void preset)
		{
			btSoftBody_setSolver(_native, preset._native);
		}
        */
		public void SetTotalDensity(float density)
		{
			btSoftBody_setTotalDensity(_native, density);
		}

		public void SetTotalMass(float mass, bool fromfaces)
		{
			btSoftBody_setTotalMass(_native, mass, fromfaces);
		}

		public void SetVelocity(Vector3 velocity)
		{
			btSoftBody_setVelocity(_native, ref velocity);
		}

		public void SetVolumeDensity(float density)
		{
			btSoftBody_setVolumeDensity(_native, density);
		}

		public void SetVolumeMass(float mass)
		{
			btSoftBody_setVolumeMass(_native, mass);
		}

		public void SolveClusters(AlignedObjectArray bodies)
		{
			btSoftBody_solveClusters(bodies._native);
		}

		public void SolveClusters(float sor)
		{
			btSoftBody_solveClusters2(_native, sor);
		}

		public void SolveCommonConstraints(SoftBody bodies, int count, int iterations)
		{
			btSoftBody_solveCommonConstraints(bodies._native, count, iterations);
		}

		public void SolveConstraints()
		{
			btSoftBody_solveConstraints(_native);
		}

		public void StaticSolve(int iterations)
		{
			btSoftBody_staticSolve(_native, iterations);
		}

		public void Transform(Matrix trs)
		{
			btSoftBody_transform(_native, ref trs);
		}

		public void Translate(Vector3 trs)
		{
			btSoftBody_translate(_native, ref trs);
		}
        /*
		public SoftBody Upcast(CollisionObject colObj)
		{
			return btSoftBody_upcast(colObj._native);
		}
        */
		public void UpdateArea(bool averageArea)
		{
			btSoftBody_updateArea(_native, averageArea);
		}

		public void UpdateArea()
		{
			btSoftBody_updateArea2(_native);
		}

		public void UpdateBounds()
		{
			btSoftBody_updateBounds(_native);
		}

		public void UpdateClusters()
		{
			btSoftBody_updateClusters(_native);
		}

		public void UpdateConstants()
		{
			btSoftBody_updateConstants(_native);
		}

		public void UpdateLinkConstants()
		{
			btSoftBody_updateLinkConstants(_native);
		}

		public void UpdateNormals()
		{
			btSoftBody_updateNormals(_native);
		}

		public void UpdatePose()
		{
			btSoftBody_updatePose(_native);
		}

		public void VSolve_Links(SoftBody psb, float kst)
		{
			btSoftBody_VSolve_Links(psb._native, kst);
		}
        /*
		public tAnchorArray Anchors
		{
			get { return btSoftBody_getAnchors(_native); }
			set { btSoftBody_setAnchors(_native, value._native); }
		}

		public Vector3 Bounds
		{
			get
			{
				Vector3 value;
				btSoftBody_getBounds(_native, out value);
				return value;
			}
			set { btSoftBody_setBounds(_native, ref value); }
		}
        */
		public bool BUpdateRtCst
		{
			get { return btSoftBody_getBUpdateRtCst(_native); }
			set { btSoftBody_setBUpdateRtCst(_native, value); }
		}
        /*
		public void Cdbvt
		{
			get { return btSoftBody_getCdbvt(_native); }
			set { btSoftBody_setCdbvt(_native, value._native); }
		}

		public void Cfg
		{
			get { return btSoftBody_getCfg(_native); }
			set { btSoftBody_setCfg(_native, value._native); }
		}

		public void ClusterConnectivity
		{
			get { return btSoftBody_getClusterConnectivity(_native); }
			set { btSoftBody_setClusterConnectivity(_native, value._native); }
		}

		public tClusterArray Clusters
		{
			get { return btSoftBody_getClusters(_native); }
			set { btSoftBody_setClusters(_native, value._native); }
		}

		public void CollisionDisabledObjects
		{
			get { return btSoftBody_getCollisionDisabledObjects(_native); }
			set { btSoftBody_setCollisionDisabledObjects(_native, value._native); }
		}

		public tFaceArray Faces
		{
			get { return btSoftBody_getFaces(_native); }
			set { btSoftBody_setFaces(_native, value._native); }
		}

		public void Fdbvt
		{
			get { return btSoftBody_getFdbvt(_native); }
			set { btSoftBody_setFdbvt(_native, value._native); }
		}

		public void InitialWorldTransform
		{
			get { return btSoftBody_getInitialWorldTransform(_native); }
			set { btSoftBody_setInitialWorldTransform(_native, value._native); }
		}

		public tJointArray Joints
		{
			get { return btSoftBody_getJoints(_native); }
			set { btSoftBody_setJoints(_native, value._native); }
		}

		public tLinkArray Links
		{
			get { return btSoftBody_getLinks(_native); }
			set { btSoftBody_setLinks(_native, value._native); }
		}

		public tMaterialArray Materials
		{
			get { return btSoftBody_getMaterials(_native); }
			set { btSoftBody_setMaterials(_native, value._native); }
		}

		public void Ndbvt
		{
			get { return btSoftBody_getNdbvt(_native); }
			set { btSoftBody_setNdbvt(_native, value._native); }
		}

		public tNodeArray Nodes
		{
			get { return btSoftBody_getNodes(_native); }
			set { btSoftBody_setNodes(_native, value._native); }
		}

		public tNoteArray Notes
		{
			get { return btSoftBody_getNotes(_native); }
			set { btSoftBody_setNotes(_native, value._native); }
		}

		public void Pose
		{
			get { return btSoftBody_getPose(_native); }
			set { btSoftBody_setPose(_native, value._native); }
		}
        
		public tRContactArray Rcontacts
		{
			get { return btSoftBody_getRcontacts(_native); }
			set { btSoftBody_setRcontacts(_native, value._native); }
		}
        */
		public float RestLengthScale
		{
			get { return btSoftBody_getRestLengthScale(_native); }
			set { btSoftBody_setRestLengthScale(_native, value); }
		}
        /*
		public tSContactArray Scontacts
		{
			get { return btSoftBody_getScontacts(_native); }
			set { btSoftBody_setScontacts(_native, value._native); }
		}

		public SoftBodySolver SoftBodySolver
		{
			get { return btSoftBody_getSoftBodySolver(_native); }
			set { btSoftBody_setSoftBodySolver(_native, value._native); }
		}

		public void Sst
		{
			get { return btSoftBody_getSst(_native); }
			set { btSoftBody_setSst(_native, value._native); }
		}
        */
		public IntPtr Tag
		{
			get { return btSoftBody_getTag(_native); }
			set { btSoftBody_setTag(_native, value); }
		}
        /*
		public tTetraArray Tetras
		{
			get { return btSoftBody_getTetras(_native); }
			set { btSoftBody_setTetras(_native, value._native); }
		}
        */
		public float Timeacc
		{
			get { return btSoftBody_getTimeacc(_native); }
			set { btSoftBody_setTimeacc(_native, value); }
		}

		public float TotalMass
		{
			get { return btSoftBody_getTotalMass(_native); }
            set { btSoftBody_setTotalMass2(_native, value); }
		}
        /*
		public void UserIndexMapping
		{
			get { return btSoftBody_getUserIndexMapping(_native); }
			set { btSoftBody_setUserIndexMapping(_native, value._native); }
		}
        */
		public Vector3 WindVelocity
		{
			get
			{
				Vector3 value;
				btSoftBody_getWindVelocity(_native, out value);
				return value;
			}
			set { btSoftBody_setWindVelocity(_native, ref value); }
		}

		public float Volume
		{
			get { return btSoftBody_getVolume(_native); }
		}

		public SoftBodyWorldInfo WorldInfo
		{
            get { return new SoftBodyWorldInfo(btSoftBody_getWorldInfo(_native)); }
			set { btSoftBody_setWorldInfo(_native, value._native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_new(IntPtr worldInfo, int node_count, [In] ref Vector3 x, IntPtr m);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_new2(IntPtr worldInfo);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_addAeroForceToFace(IntPtr obj, [In] ref Vector3 windVelocity, int faceIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_addAeroForceToNode(IntPtr obj, [In] ref Vector3 windVelocity, int nodeIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_addForce(IntPtr obj, [In] ref Vector3 force);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_addForce2(IntPtr obj, [In] ref Vector3 force, int node);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_addVelocity(IntPtr obj, [In] ref Vector3 velocity, int node);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_addVelocity2(IntPtr obj, [In] ref Vector3 velocity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAnchor(IntPtr obj, int node, IntPtr body, [In] ref Vector3 localPivot, bool disableCollisionBetweenLinkedBodies, float influence);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAnchor2(IntPtr obj, int node, IntPtr body, [In] ref Vector3 localPivot, bool disableCollisionBetweenLinkedBodies);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAnchor3(IntPtr obj, int node, IntPtr body, [In] ref Vector3 localPivot);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAnchor4(IntPtr obj, int node, IntPtr body, bool disableCollisionBetweenLinkedBodies, float influence);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAnchor5(IntPtr obj, int node, IntPtr body, bool disableCollisionBetweenLinkedBodies);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAnchor6(IntPtr obj, int node, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAngularJoint(IntPtr obj, IntPtr specs, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAngularJoint2(IntPtr obj, IntPtr specs);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAngularJoint3(IntPtr obj, IntPtr specs, IntPtr body0, IntPtr body1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendAngularJoint4(IntPtr obj, IntPtr specs, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendFace(IntPtr obj, int model, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendFace2(IntPtr obj, int model);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendFace3(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendFace4(IntPtr obj, int node0, int node1, int node2, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendFace5(IntPtr obj, int node0, int node1, int node2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLinearJoint(IntPtr obj, IntPtr specs, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLinearJoint2(IntPtr obj, IntPtr specs, IntPtr body);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLinearJoint3(IntPtr obj, IntPtr specs);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLinearJoint4(IntPtr obj, IntPtr specs, IntPtr body0, IntPtr body1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink(IntPtr obj, int node0, int node1, IntPtr mat, bool bcheckexist);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink2(IntPtr obj, int node0, int node1, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink3(IntPtr obj, int node0, int node1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink4(IntPtr obj, int model, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink5(IntPtr obj, int model);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink6(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink7(IntPtr obj, IntPtr node0, IntPtr node1, IntPtr mat, bool bcheckexist);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink8(IntPtr obj, IntPtr node0, IntPtr node1, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendLink9(IntPtr obj, IntPtr node0, IntPtr node1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_appendMaterial(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendNode(IntPtr obj, [In] ref Vector3 x, float m);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote(IntPtr obj, string text, [In] ref Vector3 o, IntPtr feature);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote2(IntPtr obj, string text, [In] ref Vector3 o, IntPtr feature);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote3(IntPtr obj, string text, [In] ref Vector3 o, IntPtr feature);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote4(IntPtr obj, string text, [In] ref Vector3 o, [In] ref Vector4 c, IntPtr n0, IntPtr n1, IntPtr n2, IntPtr n3);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote5(IntPtr obj, string text, [In] ref Vector3 o, [In] ref Vector4 c, IntPtr n0, IntPtr n1, IntPtr n2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote6(IntPtr obj, string text, [In] ref Vector3 o, [In] ref Vector4 c, IntPtr n0, IntPtr n1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote7(IntPtr obj, string text, [In] ref Vector3 o, [In] ref Vector4 c, IntPtr n0);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote8(IntPtr obj, string text, [In] ref Vector3 o, [In] ref Vector4 c);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_appendNote9(IntPtr obj, string text, [In] ref Vector3 o);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendTetra(IntPtr obj, int model, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendTetra2(IntPtr obj, int node0, int node1, int node2, int node3, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_appendTetra3(IntPtr obj, int node0, int node1, int node2, int node3);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_applyClusters(IntPtr obj, bool drift);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_applyForces(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_checkContact(IntPtr obj, IntPtr colObjWrap, [In] ref Vector3 x, float margin, IntPtr cti);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_checkFace(IntPtr obj, int node0, int node1, int node2);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_checkLink(IntPtr obj, IntPtr node0, IntPtr node1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_checkLink2(IntPtr obj, int node0, int node1);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_cleanupClusters(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterAImpulse(IntPtr cluster, IntPtr impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterCom(IntPtr cluster);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterCom2(IntPtr obj, int cluster);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_clusterCount(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterDAImpulse(IntPtr cluster, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterDCImpulse(IntPtr cluster, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterDImpulse(IntPtr cluster, [In] ref Vector3 rpos, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterImpulse(IntPtr cluster, [In] ref Vector3 rpos, IntPtr impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterVAImpulse(IntPtr cluster, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterVelocity(IntPtr cluster, [In] ref Vector3 rpos);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_clusterVImpulse(IntPtr cluster, [In] ref Vector3 rpos, [In] ref Vector3 impulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_cutLink(IntPtr obj, int node0, int node1, float position);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_cutLink2(IntPtr obj, IntPtr node0, IntPtr node1, float position);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_dampClusters(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_defaultCollisionHandler(IntPtr obj, IntPtr pcoWrap);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_defaultCollisionHandler2(IntPtr obj, IntPtr psb);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_evaluateCom(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_generateBendingConstraints(IntPtr obj, int distance, IntPtr mat);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_generateBendingConstraints2(IntPtr obj, int distance);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_generateClusters(IntPtr obj, int k, int maxiterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_generateClusters2(IntPtr obj, int k);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getAabb(IntPtr obj, [In] ref Vector3 aabbMin, [In] ref Vector3 aabbMax);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getAnchors(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getBounds(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_getBUpdateRtCst(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getCdbvt(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getCfg(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getClusterConnectivity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getClusters(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getCollisionDisabledObjects(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getFaces(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getFdbvt(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getInitialWorldTransform(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getJoints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getLinks(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_getMass(IntPtr obj, int node);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getMaterials(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getNdbvt(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getNodes(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getNotes(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getPose(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getRcontacts(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_getRestLengthScale(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_getRestLengthScale2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getScontacts(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getSoftBodySolver(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getSoftBodySolver2(IntPtr obj);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern IntPtr btSoftBody_getSolver(_ solver);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern IntPtr btSoftBody_getSolver2(_ solver);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getSst(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getTag(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getTetras(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_getTimeacc(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_getTotalMass(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_getUserIndexMapping(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btSoftBody_getWindVelocity(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getWindVelocity2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btSoftBody_getVolume(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getWorldInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_getWorldInfo2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_indicesToPointers(IntPtr obj, IntPtr map);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_indicesToPointers2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_initDefaults(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_initializeClusters(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_initializeFaceTree(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_integrateMotion(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_pointersToIndices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_predictMotion(IntPtr obj, float dt);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_prepareClusters(IntPtr obj, int iterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_PSolve_Anchors(IntPtr psb, float kst, float ti);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_PSolve_Links(IntPtr psb, float kst, float ti);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_PSolve_RContacts(IntPtr psb, float kst, float ti);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_PSolve_SContacts(IntPtr psb, float __unnamed1, float ti);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_randomizeConstraints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btSoftBody_rayTest(IntPtr obj, [In] ref Vector3 rayFrom, [In] ref Vector3 rayTo, IntPtr mint, IntPtr feature, IntPtr index, bool bcountonly);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool btSoftBody_rayTest2(IntPtr obj, [In] ref Vector3 rayFrom, [In] ref Vector3 rayTo, IntPtr results);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_refine(IntPtr obj, IntPtr ifn, float accurary, bool cut);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_releaseCluster(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_releaseClusters(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_resetLinkRestLengths(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_rotate(IntPtr obj, [In] ref Quaternion rot);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_scale(IntPtr obj, [In] ref Vector3 scl);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setAnchors(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setBounds(IntPtr obj, [In] ref Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setBUpdateRtCst(IntPtr obj, bool value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_setCdbvt(IntPtr obj, Dbvt value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setCfg(IntPtr obj, Config value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setClusterConnectivity(IntPtr obj, AlignedObjectArray value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setClusters(IntPtr obj, IntPtr value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_setCollisionDisabledObjects(IntPtr obj, AlignedObjectArray<btCollisionObject> value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setFaces(IntPtr obj, IntPtr value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_setFdbvt(IntPtr obj, Dbvt value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setInitialWorldTransform(IntPtr obj, [In] ref Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setJoints(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setLinks(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setMass(IntPtr obj, int node, float mass);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setMaterials(IntPtr obj, IntPtr value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_setNdbvt(IntPtr obj, Dbvt value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setNodes(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setNotes(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setPose(IntPtr obj, Pose value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setPose2(IntPtr obj, bool bvolume, bool bframe);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setRcontacts(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setRestLengthScale(IntPtr obj, float restLength);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setRestLengthScale2(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setScontacts(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setSoftBodySolver(IntPtr obj, IntPtr softBodySolver);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setSoftBodySolver2(IntPtr obj, IntPtr value);
		//[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		//static extern void btSoftBody_setSolver(IntPtr obj, _ preset);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setSst(IntPtr obj, SolverState value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setTag(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setTetras(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setTimeacc(IntPtr obj, float value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setTotalDensity(IntPtr obj, float density);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setTotalMass(IntPtr obj, float mass, bool fromfaces);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setTotalMass2(IntPtr obj, float mass);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setUserIndexMapping(IntPtr obj, AlignedObjectArray value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setVelocity(IntPtr obj, [In] ref Vector3 velocity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setWindVelocity(IntPtr obj, [In] ref Vector3 velocity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setWindVelocity2(IntPtr obj, Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setVolumeDensity(IntPtr obj, float density);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setVolumeMass(IntPtr obj, float mass);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_setWorldInfo(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_solveClusters(IntPtr bodies);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_solveClusters2(IntPtr obj, float sor);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_solveCommonConstraints(IntPtr bodies, int count, int iterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_solveConstraints(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_staticSolve(IntPtr obj, int iterations);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_transform(IntPtr obj, [In] ref Matrix trs);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_translate(IntPtr obj, [In] ref Vector3 trs);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSoftBody_upcast(IntPtr colObj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateArea(IntPtr obj, bool averageArea);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateArea2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateBounds(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateClusters(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateConstants(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateLinkConstants(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updateNormals(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_updatePose(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBody_VSolve_Links(IntPtr psb, float kst);
	}
}
