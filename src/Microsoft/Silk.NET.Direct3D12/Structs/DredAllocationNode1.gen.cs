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
    [NativeName("Name", "D3D12_DRED_ALLOCATION_NODE1")]
    public unsafe partial struct DredAllocationNode1
    {
        public DredAllocationNode1
        (
            byte* objectNameA = null,
            char* objectNameW = null,
            DredAllocationType? allocationType = null,
            DredAllocationNode1* pNext = null,
            Silk.NET.Core.Native.IUnknown* pObject = null
        ) : this()
        {
            if (objectNameA is not null)
            {
                ObjectNameA = objectNameA;
            }

            if (objectNameW is not null)
            {
                ObjectNameW = objectNameW;
            }

            if (allocationType is not null)
            {
                AllocationType = allocationType.Value;
            }

            if (pNext is not null)
            {
                PNext = pNext;
            }

            if (pObject is not null)
            {
                PObject = pObject;
            }
        }


        [NativeName("Type", "const char *")]
        [NativeName("Type.Name", "const char *")]
        [NativeName("Name", "ObjectNameA")]
        public byte* ObjectNameA;

        [NativeName("Type", "const wchar_t *")]
        [NativeName("Type.Name", "const wchar_t *")]
        [NativeName("Name", "ObjectNameW")]
        public char* ObjectNameW;

        [NativeName("Type", "D3D12_DRED_ALLOCATION_TYPE")]
        [NativeName("Type.Name", "D3D12_DRED_ALLOCATION_TYPE")]
        [NativeName("Name", "AllocationType")]
        public DredAllocationType AllocationType;

        [NativeName("Type", "const struct D3D12_DRED_ALLOCATION_NODE1 *")]
        [NativeName("Type.Name", "const struct D3D12_DRED_ALLOCATION_NODE1 *")]
        [NativeName("Name", "pNext")]
        public DredAllocationNode1* PNext;

        [NativeName("Type", "const IUnknown *")]
        [NativeName("Type.Name", "const IUnknown *")]
        [NativeName("Name", "pObject")]
        public Silk.NET.Core.Native.IUnknown* PObject;
    }
}
