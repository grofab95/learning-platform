using System.Reflection;
using LearningPlatform.Core.Users;
using LearningPlatform.Database.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        var connectionString = configuration.GetConnectionString("Database")!;
        services.AddDbContext<LearningPlatformContext>(o => o.UseSqlServer(connectionString));
        //services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddHostedService<DatabaseManager>();

        services.AddTransient<IUserStore, UserStore>();
    }
}