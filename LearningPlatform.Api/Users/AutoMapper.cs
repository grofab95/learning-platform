using AutoMapper;
using LearningPlatform.Api.Users.GetUsers;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Api.Users;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<UserGetDto, User>();
        CreateMap<User, UserGetDto>();
    }
}