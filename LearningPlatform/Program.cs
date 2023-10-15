using LearningPlatform.Api.Extensions;
using LearningPlatform.Authentication.Extensions;
using LearningPlatform.Core.Extensions;
using LearningPlatform.Database.Extensions;
using LearningPlatform.Logging;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
    
    builder.Services.AddCors(x => x.AddDefaultPolicy(new CorsPolicyBuilder()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(h => true)
        .Build()));

    var app = builder.Build();
    
    if (!app.Environment.IsDevelopment())
    {
        app.UseHsts();
    }
    
    app.UseCors();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseHttpsRedirection();
    
    app.ConfigureApi();
    app.ConfigureAuthorization();
    
    app.MapFallbackToFile("index.html"); 
    
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