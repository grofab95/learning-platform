using Microsoft.AspNet.SignalR;

namespace LearningPlatform.Api.Users.Events;

[Authorize]
public class UserEventsHub : Microsoft.AspNetCore.SignalR.Hub<IUserHubClient>
{
    
}