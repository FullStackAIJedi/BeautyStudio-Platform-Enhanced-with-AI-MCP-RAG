namespace Salon.Domain.Factories.Appointments
{
    using Salon.Domain.Models.Appointments;

    public class AppointmentFactory : IAppointmentFactory
    {
        private int clientId;
        private int employeeId;
        private int serviceId;
        private int locationId;
        private DateTime startAt;
        private string? notes;

        public IAppointmentFactory WithClient(int clientId) { this.clientId = clientId; return this; }
        public IAppointmentFactory WithEmployee(int employeeId) { this.employeeId = employeeId; return this; }
        public IAppointmentFactory WithService(int serviceId) { this.serviceId = serviceId; return this; }
        public IAppointmentFactory WithLocation(int locationId) { this.locationId = locationId; return this; }
        public IAppointmentFactory WithStartAt(DateTime startAt) { this.startAt = startAt; return this; }
        public IAppointmentFactory WithNotes(string? notes) { this.notes = notes; return this; } 

        public Appointment Build()
            => new Appointment(this.clientId, this.employeeId, this.serviceId, this.locationId, this.startAt, this.notes);
    }
}
