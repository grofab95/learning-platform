using MediatR;

namespace LearningPlatform.Core.Abstract.Commands;

public interface ICommand<out TResult> : IMessage, IRequest<TResult>
{
}