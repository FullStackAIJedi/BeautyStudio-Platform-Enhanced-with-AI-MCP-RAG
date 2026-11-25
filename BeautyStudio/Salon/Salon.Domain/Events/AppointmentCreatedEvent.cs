namespace Salon.Domain.Events
{ 
    using SharedKernel.Models;

    public class AppointmentCreatedEvent : IDomainEvent
    {
        public AppointmentCreatedEvent(int appointmentId) => this.AppointmentId = appointmentId;
        public int AppointmentId { get; }
    }
}
