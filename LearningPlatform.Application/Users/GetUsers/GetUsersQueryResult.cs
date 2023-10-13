using LearningPlatform.Core.Abstract.Queries;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Application.Users.GetUsers;

public class GetUsersQueryResult : QueryResultBase<User[]>
{
    public GetUsersQueryResult(Guid id, string error) : base(id, error)
    {
    }

    public GetUsersQueryResult(Guid id, User[] data) : base(id, data)
    {
    }
}