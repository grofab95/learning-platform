using LearningPlatform.Core.Users;

namespace LearningPlatform.Api.Users.Events;

public interface IUserHubClient
{
    Task UserAdded(User user);
}