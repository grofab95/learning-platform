using LearningPlatform.Core.Abstract.Queries;

namespace LearningPlatform.Application.Users.GetUser;

public class GetUserQuery : QueryBase<GetUserQueryResult>
{
    public string UserId { get; }
    
    public GetUserQuery(string userId)
    {
        UserId = userId;
    }
}