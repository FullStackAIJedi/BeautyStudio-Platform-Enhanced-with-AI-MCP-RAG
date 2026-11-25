namespace Salon.Domain.Models.Appointments
{ 
    using Salon.Domain.Exceptions;

    using SharedKernel.Models;

    public class Appointment : Entity<int>, IAggregateRoot
    {
        internal Appointment(
            int clientId,
            int employeeId,
            int serviceId,
            int locationId,
            DateTime startAt,
            string? notes = null)
        {
            this.Validate(startAt);

            this.ClientId = clientId;
            this.EmployeeId = employeeId;
            this.ServiceId = serviceId;
            this.LocationId = locationId;
            this.StartAt = startAt;
            this.EndAt = startAt.AddMinutes(60);  
            this.Status = AppointmentStatus.Pending;
            this.Notes = notes;
        }

        private Appointment() { }

        public int LocationId { get; private set; }
        public int ClientId { get; private set; }
        public int EmployeeId { get; private set; }
        public int ServiceId { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
        public int Status { get; private set; }
        public string? Notes { get; private set; }

        public void Cancel()
        {
            if (this.Status == AppointmentStatus.Cancelled)
                throw new InvalidAppointmentException("Appointment is already cancelled.");

            this.Status = AppointmentStatus.Cancelled;
        }

        public void Reschedule(DateTime newStartAt)
        {
            this.Validate(newStartAt);
            this.StartAt = newStartAt;
            this.EndAt = newStartAt.AddMinutes((this.EndAt - this.StartAt).TotalMinutes);
        }

        public void Complete()
        {
            this.Status = AppointmentStatus.Completed;
        }

        private void Validate(DateTime startAt)
        {
            if (startAt <= DateTime.UtcNow)
                throw new InvalidAppointmentException("Appointment must be in the future.");
        }
    }

    public static class AppointmentStatus
    {
        public const int Pending = 1;
        public const int Confirmed = 2;
        public const int InProgress = 3;
        public const int Completed = 4;
        public const int Cancelled = 5;
    }
}
