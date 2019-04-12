using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
    public class HeightfieldShape : ConcaveShape
    {
        internal HeightfieldShape(IntPtr native)
            : base(native)
        {
        }

        public HeightfieldShape(int heightStickWidth, int heightStickLength, IntPtr heightfieldData, float heightScale, float minHeight, float maxHeight, int upAxis, int heightDataType, bool flipQuadEdges)
            : base(btHeightfieldTerrainShape_new(heightStickWidth, heightStickLength, heightfieldData, heightScale, minHeight, maxHeight, upAxis, heightDataType, flipQuadEdges))
        {
        }

        public void SetUseDiamondSubdivision(bool use = true)
        {
            btHeightfieldTerrainShape_setUseDiamondSubdivision(_native, use);
        }

        public void SetUseZigzagSubdivision(bool use = true)
        {
            btHeightfieldTerrainShape_setUseZigzagSubdivision(_native, use);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btHeightfieldTerrainShape_new(int heightStickWidth, int heightStickLength, IntPtr heightfieldData, float heightScale, float minHeight, float maxHeight, int upAxis, int heightDataType, bool flipQuadEdges);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btHeightfieldTerrainShape_setUseDiamondSubdivision(IntPtr h, bool use);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btHeightfieldTerrainShape_setUseZigzagSubdivision(IntPtr h, bool use);
    }
}
