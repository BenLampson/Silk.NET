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

namespace Silk.NET.Assimp
{
    [NativeName("Name", "aiMetadata")]
    public unsafe partial struct Metadata
    {
        public Metadata
        (
            uint? mNumProperties = null,
            AssimpString* mKeys = null,
            MetadataEntry* mValues = null
        ) : this()
        {
            if (mNumProperties is not null)
            {
                MNumProperties = mNumProperties.Value;
            }

            if (mKeys is not null)
            {
                MKeys = mKeys;
            }

            if (mValues is not null)
            {
                MValues = mValues;
            }
        }


        [NativeName("Type", "unsigned int")]
        [NativeName("Type.Name", "unsigned int")]
        [NativeName("Name", "mNumProperties")]
        public uint MNumProperties;

        [NativeName("Type", "aiString *")]
        [NativeName("Type.Name", "aiString *")]
        [NativeName("Name", "mKeys")]
        public AssimpString* MKeys;

        [NativeName("Type", "aiMetadataEntry *")]
        [NativeName("Type.Name", "aiMetadataEntry *")]
        [NativeName("Name", "mValues")]
        public MetadataEntry* MValues;
    }
}
