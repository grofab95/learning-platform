using MediatR;

namespace LearningPlatform.Core.Abstract.Events;

public interface IEventHandler<in T> : INotificationHandler<T> where T : IEvent
{
    
}