// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

namespace Silk.NET.OpenAL.Extensions.EXT
{
    /// <summary>
    /// Defines valid format specifiers for sound samples. This covers the additions from the multi-channel buffers
    /// extension.
    /// </summary>
    public enum ALAWBufferFormat
    {
        /// <summary>
        /// 1 Channel, A-law encoded data.
        /// </summary>
        Mono = 0x10016,

        /// <summary>
        /// 2 Channels, A-law encoded data.
        /// </summary>
        Stereo = 0x10017
    }
}