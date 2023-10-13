using LearningPlatform.Core;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Authentication.Services;

public interface IAuthenticationService
{
    Task<Result<UserWithTokens>> Authenticate(string email, string password, string ipAddress);
    Task<Result<UserWithTokens>> RefreshToken(string token);
    // Task RevokeToken(string token);
    // Task<string> GetAccessToken(UserDb user);
    // RefreshTokenDb GetRefreshToken();
    Task<Result> RevokeToken(string requestRefreshToken);
}