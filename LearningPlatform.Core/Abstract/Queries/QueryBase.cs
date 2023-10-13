using LearningPlatform.Core.Abstract.Commands;

namespace LearningPlatform.Core.Abstract.Queries;

public abstract class QueryBase<T> : ICommand<T>
    where T : IQueryResultBase
{
    public Guid Id { get; } = Guid.NewGuid();
}