namespace Salon.Domain.Events
{ 
    using SharedKernel.Models;

    public class ServiceCreatedEvent : IDomainEvent
    {
        public ServiceCreatedEvent(int serviceId) => this.ServiceId = serviceId;
        public int ServiceId { get; }
    }
}
