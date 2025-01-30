namespace OmegaFY.Blog.WebAPI.BackgroundServices;

internal sealed class ThreadsPerformanceMonitoringService : BackgroundService
{
    private readonly ILogger<ThreadsPerformanceMonitoringService> _logger;

    public ThreadsPerformanceMonitoringService(ILogger<ThreadsPerformanceMonitoringService> logger)
    {
        _logger = logger;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("GC and Thread Monitoring Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("=== ThreadPool Metrics ===");

                ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableCompletionPortThreads);

                ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);

                ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);

                _logger.LogInformation("Available Worker Threads: {availableWorkerThreads}/{maxWorkerThreads} (Min: {minWorkerThreads})", availableWorkerThreads, maxWorkerThreads, minWorkerThreads);
                
                _logger.LogInformation("Available Completion Port Threads: {availableCompletionPortThreads}/{maxCompletionPortThreads} (Min: {minCompletionPortThreads})", availableCompletionPortThreads, maxCompletionPortThreads, minCompletionPortThreads);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no serviço de monitoramento de ThreadPool.");
            }
        }

        _logger.LogInformation("Thread Monitoring Service is stopping.");
    }
}