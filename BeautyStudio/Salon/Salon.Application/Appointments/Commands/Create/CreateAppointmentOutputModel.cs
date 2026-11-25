namespace Salon.Application.Appointments.Commands.Create
{
    public class CreateAppointmentOutputModel
    {
        public CreateAppointmentOutputModel(int appointmentId) => this.AppointmentId = appointmentId;
        public int AppointmentId { get; }
    }
}
