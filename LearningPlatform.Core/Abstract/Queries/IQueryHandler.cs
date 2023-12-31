﻿using MediatR;

namespace LearningPlatform.Core.Abstract.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> 
    where TQuery : QueryBase<TResult>
    where TResult : IQueryResultBase
{

}