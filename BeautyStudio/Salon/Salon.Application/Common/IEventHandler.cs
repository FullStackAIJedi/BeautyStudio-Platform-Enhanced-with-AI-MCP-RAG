namespace Salon.Application.Common
{
    using SharedKernel.Models;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
