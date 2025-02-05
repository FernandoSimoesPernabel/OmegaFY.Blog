using System.Runtime;

namespace OmegaFY.Blog.WebAPI.BackgroundServices;

internal sealed class GarbageCollectorPerformanceMonitoringService : BackgroundService
{
    private readonly ILogger<GarbageCollectorPerformanceMonitoringService> _logger;

    public GarbageCollectorPerformanceMonitoringService(ILogger<GarbageCollectorPerformanceMonitoringService> logger)
    {
        _logger = logger;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("GC Monitoring Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("=== Garbage Collector Metrics ===");
                
                _logger.LogInformation("Total Memory (bytes): {totalMemory}", GC.GetTotalMemory(false));
                
                _logger.LogInformation("Gen 0 Collections: {gen0}", GC.CollectionCount(0));

                _logger.LogInformation("Gen 1 Collections: {gen1}", GC.CollectionCount(1));

                _logger.LogInformation("Gen 2 Collections: {gen2}", GC.CollectionCount(2));

                _logger.LogInformation("GC Latency Mode: {gatencyMode}", GCSettings.LatencyMode);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no serviço de monitoramento de GarbageCollector.");
            }
        }

        _logger.LogInformation("GarbageCollector Monitoring Service is stopping.");
    }
}