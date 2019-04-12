// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
#if !__iOS__
using System;
using System.Runtime.InteropServices;
namespace System.Security
{
    [AttributeUsageAttribute(
        AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate,
        AllowMultiple = true,
        Inherited = false)]
    [ComVisible(true)]
    public sealed class SuppressUnmanagedCodeSecurityAttribute : Attribute
    {
    }
}
#endif