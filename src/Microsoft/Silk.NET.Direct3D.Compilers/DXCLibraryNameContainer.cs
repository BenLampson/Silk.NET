// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Core.Loader;

namespace Silk.NET.Direct3D.Compilers
{
    /// <summary>
    /// Contains the library name of DXC.
    /// </summary>
    internal class DXCLibraryNameContainer : SearchPathContainer
    {
        /// <inheritdoc />
        public override string Linux => "libdxcompiler.so";

        /// <inheritdoc />
        public override string MacOS => "libdxcompiler.dylib";

        /// <inheritdoc />
        public override string Android => "libdxcompiler.so";

        /// <inheritdoc />
        public override string IOS => "__Internal";

        /// <inheritdoc />
        public override string Windows64 => "dxcompiler.dll";

        /// <inheritdoc />
        public override string Windows86 => "dxcompiler.dll";
    }
}
