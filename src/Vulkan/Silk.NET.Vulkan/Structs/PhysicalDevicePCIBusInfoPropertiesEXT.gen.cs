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

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkPhysicalDevicePCIBusInfoPropertiesEXT")]
    public unsafe partial struct PhysicalDevicePCIBusInfoPropertiesEXT
    {
        public PhysicalDevicePCIBusInfoPropertiesEXT
        (
            StructureType? sType = StructureType.PhysicalDevicePciBusInfoPropertiesExt,
            void* pNext = null,
            uint? pciDomain = null,
            uint? pciBus = null,
            uint? pciDevice = null,
            uint? pciFunction = null
        ) : this()
        {
            if (sType is not null)
            {
                SType = sType.Value;
            }

            if (pNext is not null)
            {
                PNext = pNext;
            }

            if (pciDomain is not null)
            {
                PciDomain = pciDomain.Value;
            }

            if (pciBus is not null)
            {
                PciBus = pciBus.Value;
            }

            if (pciDevice is not null)
            {
                PciDevice = pciDevice.Value;
            }

            if (pciFunction is not null)
            {
                PciFunction = pciFunction.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "pciDomain")]
        public uint PciDomain;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "pciBus")]
        public uint PciBus;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "pciDevice")]
        public uint PciDevice;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "pciFunction")]
        public uint PciFunction;
    }
}
