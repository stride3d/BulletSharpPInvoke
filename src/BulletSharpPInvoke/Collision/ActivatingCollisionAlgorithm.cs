using Xenko.Core.Mathematics;
using System;

namespace BulletSharp
{
	public class ActivatingCollisionAlgorithm : CollisionAlgorithm
	{
		internal ActivatingCollisionAlgorithm(IntPtr native, bool preventDelete = false)
			: base(native, preventDelete)
		{
		}
	}
}
