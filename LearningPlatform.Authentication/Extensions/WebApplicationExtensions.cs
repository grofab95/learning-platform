using Microsoft.AspNetCore.Builder;

namespace LearningPlatform.Authentication.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureAuthorization(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}