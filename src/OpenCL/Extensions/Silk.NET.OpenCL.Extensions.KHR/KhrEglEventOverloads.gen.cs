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

namespace Silk.NET.OpenCL.Extensions.KHR
{
    public static class KhrEglEventOverloads
    {
        public static unsafe nint CreateEventFromEglsync(this KhrEglEvent thisApi, [Flow(FlowDirection.In)] nint context, [Flow(FlowDirection.In)] nint sync, [Flow(FlowDirection.In)] nint display, [Flow(FlowDirection.Out)] Span<int> errcode_ret)
        {
            // SpanOverloader
            return thisApi.CreateEventFromEglsync(context, sync, display, out errcode_ret.GetPinnableReference());
        }

    }
}

