using MediatR;

namespace LearningPlatform.Core.Abstract.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{

}