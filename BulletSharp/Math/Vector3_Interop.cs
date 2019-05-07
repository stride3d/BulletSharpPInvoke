using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BulletSharp.Math
{
	/// <summary>
	/// Bullet implements its Vector3 as 4 floats where the w ends up unused, see btVector3.h.
	/// This struct should be used when reading data from the c++ side to keep the same packing across languages
	/// </summary>
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public readonly struct Vector3_Interop
	{
		[FieldOffset(0)] public readonly Vector3 value;
		[FieldOffset(12)] public readonly float unusedW;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Xenko.Core.Mathematics.Vector3(Vector3_Interop value)
		{
			unsafe { return *(Xenko.Core.Mathematics.Vector3*)&value; }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Vector3(Vector3_Interop value) => value.value;
	}
}