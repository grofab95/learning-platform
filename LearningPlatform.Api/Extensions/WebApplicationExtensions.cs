using LearningPlatform.Api.Users.Events;

namespace LearningPlatform.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapControllers();
        app.MapHub<UserEventsHub>("/user-events");
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}