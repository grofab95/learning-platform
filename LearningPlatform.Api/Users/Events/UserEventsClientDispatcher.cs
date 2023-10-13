using LearningPlatform.Application.Users.AddUser;
using LearningPlatform.Core.Abstract.Events;
using Microsoft.AspNetCore.SignalR;

namespace LearningPlatform.Api.Users.Events;

public class UserEventsClientDispatcher : IEventHandler<UserAddedEvent>
{
    private readonly IHubContext<UserEventsHub, IUserHubClient> _userEventsHub;

    public UserEventsClientDispatcher(IHubContext<UserEventsHub, IUserHubClient> userEventsHub)
    {
        _userEventsHub = userEventsHub;
    }
    
    public async Task Handle(UserAddedEvent notification, CancellationToken cancellationToken)
    {
        await _userEventsHub.Clients.All.UserAdded(notification.User);
    }
}