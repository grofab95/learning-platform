using LearningPlatform.Core.Abstract.Commands;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Application.Users.AddUser;

public class AddUserCommandResult : CommandResultBase
{
    public User User { get; }
    
    public AddUserCommandResult(Guid id, string error) : base(id, error)
    {
    }

    public AddUserCommandResult(Guid id, User user) : base(id)
    {
        User = user;
    }
}