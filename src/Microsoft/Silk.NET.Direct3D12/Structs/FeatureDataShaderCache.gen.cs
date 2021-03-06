// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_FEATURE_DATA_SHADER_CACHE")]
    public unsafe partial struct FeatureDataShaderCache
    {
        public FeatureDataShaderCache
        (
            ShaderCacheSupportFlags? supportFlags = null
        ) : this()
        {
            if (supportFlags is not null)
            {
                SupportFlags = supportFlags.Value;
            }
        }


        [NativeName("Type", "D3D12_SHADER_CACHE_SUPPORT_FLAGS")]
        [NativeName("Type.Name", "D3D12_SHADER_CACHE_SUPPORT_FLAGS")]
        [NativeName("Name", "SupportFlags")]
        public ShaderCacheSupportFlags SupportFlags;
    }
}
