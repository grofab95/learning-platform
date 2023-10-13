using LearningPlatform.Core.Abstract.Queries;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Application.Users.GetUser;

public class GetUserQueryResult : QueryResultBase<User>
{
    public GetUserQueryResult(Guid id, string error) : base(id, error)
    {
    }

    public GetUserQueryResult(Guid id, User data) : base(id, data)
    {
    }
}