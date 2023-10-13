using LearningPlatform.Api.Extensions;
using LearningPlatform.Authentication.Extensions;
using LearningPlatform.Core.Extensions;
using LearningPlatform.Database.Extensions;
using LearningPlatform.Logging;
using Serilog;

SerilogHelpers.AddLoggerConfiguration();

try
{
    Log.Information("Program start");

    var builder = WebApplication.CreateBuilder(args);
    
    builder.Logging.AddSerilog();
    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddAppAuthentication(builder.Configuration);
    builder.Services.AddApi();
    builder.Services.AddCore();

    var app = builder.Build();
    app.ConfigureApi();
    app.ConfigureAuthorization();
    
    app.UseCors(builder =>
    {
        builder
            .WithOrigins("http://localhost:3000", "https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Program error");
}
finally
{
    Log.CloseAndFlush();
}