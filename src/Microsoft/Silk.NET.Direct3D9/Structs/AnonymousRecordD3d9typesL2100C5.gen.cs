// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Direct3D9
{
    [StructLayout(LayoutKind.Explicit)]
    [NativeName("Name", "__AnonymousRecord_d3d9types_L2100_C5")]
    public unsafe partial struct AnonymousRecordD3d9typesL2100C5
    {
        public AnonymousRecordD3d9typesL2100C5
        (
            uint? value = null
        ) : this()
        {
            if (value is not null)
            {
                Value = value.Value;
            }
        }


        [FieldOffset(0)]
        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "Value")]
        public uint Value;
    }
}