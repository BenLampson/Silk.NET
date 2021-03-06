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
using Silk.NET.OpenGL.Legacy;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy.Extensions.ARB
{
    [Extension("ARB_cl_event")]
    public unsafe partial class ArbClEvent : NativeExtension<GL>
    {
        public const string ExtensionName = "ARB_cl_event";
        [NativeApi(EntryPoint = "glCreateSyncFromCLeventARB")]
        public unsafe partial nint CreateSyncFromCLevent([Flow(FlowDirection.Out)] nint* context, [Flow(FlowDirection.Out)] nint* @event, [Flow(FlowDirection.In)] uint flags);

        [NativeApi(EntryPoint = "glCreateSyncFromCLeventARB")]
        public unsafe partial nint CreateSyncFromCLevent([Flow(FlowDirection.Out)] nint* context, [Flow(FlowDirection.Out)] out nint @event, [Flow(FlowDirection.In)] uint flags);

        [NativeApi(EntryPoint = "glCreateSyncFromCLeventARB")]
        public unsafe partial nint CreateSyncFromCLevent([Flow(FlowDirection.Out)] out nint context, [Flow(FlowDirection.Out)] nint* @event, [Flow(FlowDirection.In)] uint flags);

        [NativeApi(EntryPoint = "glCreateSyncFromCLeventARB")]
        public partial nint CreateSyncFromCLevent([Flow(FlowDirection.Out)] out nint context, [Flow(FlowDirection.Out)] out nint @event, [Flow(FlowDirection.In)] uint flags);

        public ArbClEvent(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

