using MediatR;

namespace LearningPlatform.Core.Abstract.Commands;

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{

}