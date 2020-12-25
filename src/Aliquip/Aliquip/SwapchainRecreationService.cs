﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class SwapchainRecreationService : IHostedService, ISwapchainRecreationService, IObserver<WindowResized>
    {
        private readonly IWindowProvider _windowProvider;
        private readonly ILogger _logger;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IImageViewProvider _imageViewProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IGraphicsPipelineProvider _graphicsPipelineProvider;
        private readonly IFramebufferProvider _framebufferProvider;
        private readonly IPipelineLayoutProvider _pipelineLayoutProvider;
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private IDisposable? _subscription;

        public SwapchainRecreationService
        (
            IWindowProvider windowProvider,
            ILogger<SwapchainRecreationService> logger,
            ISwapchainProvider swapchainProvider,
            IImageViewProvider imageViewProvider,
            IRenderPassProvider renderPassProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider,
            IFramebufferProvider framebufferProvider,
            IPipelineLayoutProvider pipelineLayoutProvider,
            Vk vk,
            ILogicalDeviceProvider logicalDeviceProvider
        )
        {
            _windowProvider = windowProvider;
            _logger = logger;
            _swapchainProvider = swapchainProvider;
            _imageViewProvider = imageViewProvider;
            _renderPassProvider = renderPassProvider;
            _graphicsPipelineProvider = graphicsPipelineProvider;
            _framebufferProvider = framebufferProvider;
            _pipelineLayoutProvider = pipelineLayoutProvider;
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscription = _windowProvider.Subscribe(this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscription?.Dispose();
            return Task.CompletedTask;
        }

        public void RecreateSwapchain(Vector2D<int>? newSize)
        {
            if (_windowProvider.Window.IsClosing)
                return;
            
            _logger.LogDebug("Recreating swapchain");
            _vk.DeviceWaitIdle(_logicalDeviceProvider.LogicalDevice);

            _framebufferProvider.Dispose();
            _graphicsPipelineProvider.Dispose();
            _pipelineLayoutProvider.Dispose();
            _renderPassProvider.Dispose();
            _imageViewProvider.Dispose();
            _swapchainProvider.Dispose();
            
            _swapchainProvider.RecreateSwapchain(newSize);
            _imageViewProvider.RecreateImageViews();
            _renderPassProvider.RecreateRenderPass();
            _pipelineLayoutProvider.RecreatePipelineLayout();
            _graphicsPipelineProvider.RecreateGraphicsPipeline();
            _framebufferProvider.RecreateFramebuffers();
        }

        public void OnCompleted()
        { }

        public void OnError(Exception error)
        { }

        public void OnNext(WindowResized value)
        {
            RecreateSwapchain(value.EventArgs);
        }
    }
}