using LearningPlatform.Core.Abstract.Events;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Application.Users.AddUser;

public record UserAddedEvent(User User) : IEvent;