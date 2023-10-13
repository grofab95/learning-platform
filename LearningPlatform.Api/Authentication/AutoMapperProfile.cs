using AutoMapper;
using LearningPlatform.Api.Authentication.Dto;
using LearningPlatform.Core.Users;

namespace LearningPlatform.Api.Authentication;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserWithTokens, UserWithTokensDto>();
        CreateMap<UserWithTokensDto, UserWithTokens>();
    }
}