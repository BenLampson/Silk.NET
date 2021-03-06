// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.OpenGL
{
    [NativeName("Name", "TextureEnvMode")]
    public enum TextureEnvMode : int
    {
        [NativeName("Name", "GL_BLEND")]
        Blend = 0xBE2,
        [NativeName("Name", "GL_REPLACE_EXT")]
        ReplaceExt = 0x8062,
        [NativeName("Name", "GL_TEXTURE_ENV_BIAS_SGIX")]
        TextureEnvBiasSgix = 0x80BE,
    }
}
