using System;

namespace BulletSharp
{
    public enum PhyScalarType
    {
        Float = 0,
        Double = 1,
        Integer = 2,
        Short = 3,
        FixedPoint88 = 4,
        UChar = 5
    }

	public class ConcaveShape : CollisionShape
	{
		internal ConcaveShape(IntPtr native)
			: base(native)
		{
		}

        /*
		public void ProcessAllTriangles(TriangleCallback callback, Vector3 aabbMin, Vector3 aabbMax)
		{
			btConcaveShape_processAllTriangles(_native, callback._native, ref aabbMin, ref aabbMax);
		}
        */
	}
}
