using AutoMapper;
using LearningPlatform.Core.Users;
using LearningPlatform.Database.Entities;

namespace LearningPlatform.Database.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDb>();
        CreateMap<UserDb, User>();
    }
}