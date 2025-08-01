using ISKI.OpcUa.Client.Interfaces;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace ISKI.SARS.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConnectionService _connectionService;
    private readonly INodeReadWriteService _readWriteService;
    private readonly ConcurrentQueue<InstantValue> _instantValueQueue = new();

    public Worker(
        ILogger<Worker> logger,
        IServiceProvider serviceProvider,
        IConnectionService connectionService,
        INodeReadWriteService readWriteService)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _connectionService = connectionService;
        _readWriteService = readWriteService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await EnsureConnectedAsync(stoppingToken);

        using var scope = _serviceProvider.CreateScope();
        var templateRepo = scope.ServiceProvider.GetRequiredService<IReportTemplateRepository>();

        var templates = await templateRepo.GetAllAsync(t => t.IsActive);

        var queueTask = ProcessQueueAsync(stoppingToken);
        var tasks = templates.Select(t => ProcessTemplateAsync(t, stoppingToken)).ToList();
        tasks.Add(queueTask);

        await Task.WhenAll(tasks);
    }

    private async Task ProcessTemplateAsync(ReportTemplate template, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await EnsureConnectedAsync(token);

            using var scope = _serviceProvider.CreateScope();
            var mappingRepo = scope.ServiceProvider.GetRequiredService<IReportTemplateArchiveTagRepository>();
            var tagRepo = scope.ServiceProvider.GetRequiredService<IArchiveTagRepository>();

            var mappings = await mappingRepo.GetAllAsync(m => m.ReportTemplateId == template.Id);
            var tags = new List<ArchiveTag>();
            foreach (var map in mappings)
            {
                var tag = await tagRepo.GetByIdAsync(map.ArchiveTagId);
                if (tag is not null && tag.IsActive)
                    tags.Add(tag);
            }

            foreach (var tag in tags)
            {
                var result = await _readWriteService.ReadNodeAsync(tag.TagNodeId);
                if (!result.Success)
                {
                    _logger.LogWarning("Failed to read {node}", tag.TagNodeId);
                    continue;
                }

                var instantValue = new InstantValue
                {
                    Id = result.Timestamp,
                    ArchiveTagId = tag.Id,
                    Value = result.Data?.Value?.ToString() ?? string.Empty,
                    Status = true
                };

                _instantValueQueue.Enqueue(instantValue);
            }

            await Task.Delay(template.PullInterval*1000, token);
        }
    }

    private async Task ProcessQueueAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (_instantValueQueue.IsEmpty)
            {
                await Task.Delay(100, token);
                continue;
            }

            using var scope = _serviceProvider.CreateScope();
            var valueRepo = scope.ServiceProvider.GetRequiredService<IInstantValueRepository>();

            while (_instantValueQueue.TryDequeue(out var instantValue))
            {
                await valueRepo.AddAsync(instantValue);
            }
        }
    }

    private async Task EnsureConnectedAsync(CancellationToken token)
    {
        if (_connectionService.Session is { Connected: true })
            return;

        while (!token.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var settingRepo = scope.ServiceProvider.GetRequiredService<ISystemSettingRepository>();
            var setting = await settingRepo.GetAsync(x => true);
            var endpoint = setting?.OpcServerUrl;

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                _logger.LogWarning("OPC UA endpoint not configured.");
                await Task.Delay(5000, token);
                continue;
            }

            try
            {
                await _connectionService.ConnectAsync(endpoint);
                if (_connectionService.Session is { Connected: true })
                {
                    _logger.LogInformation("Connected to OPC UA {endpoint}", endpoint);
                    break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Connection failed");
            }

            await Task.Delay(5000, token);
        }
    }
}
