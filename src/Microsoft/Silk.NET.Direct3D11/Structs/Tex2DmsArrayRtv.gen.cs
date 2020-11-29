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

namespace Silk.NET.Direct3D11
{
    [NativeName("Name", "D3D11_TEX2DMS_ARRAY_RTV")]
    public unsafe partial struct Tex2DmsArrayRtv
    {
        public Tex2DmsArrayRtv
        (
            uint? firstArraySlice = null,
            uint? arraySize = null
        ) : this()
        {
            if (firstArraySlice is not null)
            {
                FirstArraySlice = firstArraySlice.Value;
            }

            if (arraySize is not null)
            {
                ArraySize = arraySize.Value;
            }
        }


        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "FirstArraySlice")]
        public uint FirstArraySlice;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "ArraySize")]
        public uint ArraySize;
    }
}