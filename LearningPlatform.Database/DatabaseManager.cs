using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LearningPlatform.Database;

public class DatabaseManager : IHostedService
{
    private readonly ILogger<DatabaseManager> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DatabaseManager(ILogger<DatabaseManager> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await MigrateDatabase(cancellationToken);
    }

    private async Task MigrateDatabase(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("MigrateDatabase");

            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            await using var learningPlatformContext = scope.ServiceProvider.GetRequiredService<LearningPlatformContext>();
            
            await learningPlatformContext.Database.MigrateAsync(cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "MigrateDatabase error");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}