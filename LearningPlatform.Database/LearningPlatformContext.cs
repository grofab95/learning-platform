using LearningPlatform.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearningPlatform.Database;

public class LearningPlatformContext : IdentityDbContext<UserDb>
{
    public DbSet<RefreshTokenDb> RefreshTokens { get; set; }

    public LearningPlatformContext()
    {
                
    }
        
    public LearningPlatformContext(DbContextOptions<LearningPlatformContext> options) : base(options)
    {
            
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        var appDirectory =
            Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory())?.Parent?.FullName ?? "", "LearningPlatform");
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(appDirectory)
            .AddJsonFile(path:"appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        var connectionString = configuration.GetConnectionString("Database");
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LearningPlatformContext).Assembly); 
    }
}