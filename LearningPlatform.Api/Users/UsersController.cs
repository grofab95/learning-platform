﻿using AutoMapper;
using LearningPlatform.Api.Models;
using LearningPlatform.Api.Users.AddUser;
using LearningPlatform.Api.Users.GetUsers;
using LearningPlatform.Application.Users.AddUser;
using LearningPlatform.Application.Users.GetUser;
using LearningPlatform.Application.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Api.Users;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(ILogger<UsersController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ApiResponse<UserGetDto[]>> GetUsers()
    {
        _logger.LogInformation("GetUsers");

        var queryResult = await _mediator.Send(new GetUsersQuery());
        if (queryResult.IsFailure)
        {
            return ApiResponse<UserGetDto[]>.Failure(queryResult.Error!);
        }

        var dto = _mapper.Map<UserGetDto[]>(queryResult.Data);
        return ApiResponse<UserGetDto[]>.Success(dto);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ApiResponse<UserGetDto>> AddUser(AddUserRequest request)
    {
        _logger.LogInformation("AddUser | Email={Email}", request.Email);

        var commandResult = await _mediator.Send(new AddUserCommand(request.Email, request.Password));
        if (commandResult.IsFailure)
        {
            return ApiResponse<UserGetDto>.Failure(commandResult.Error!);
        }

        var dto = _mapper.Map<UserGetDto>(commandResult.User);
        return ApiResponse<UserGetDto>.Success(dto);
    }
    
    [HttpGet("{userId}")]
    public async Task<ApiResponse<UserGetDto>> GetUser([FromRoute] string userId)
    {
        _logger.LogInformation("GetUser | GetUser={GetUser}", userId);
        
        var queryResult = await _mediator.Send(new GetUserQuery(userId));
        if (queryResult.IsFailure)
        {
            return ApiResponse<UserGetDto>.Failure(queryResult.Error!);
        }

        var dto = _mapper.Map<UserGetDto>(queryResult.Data);
        return ApiResponse<UserGetDto>.Success(dto);
    }
}