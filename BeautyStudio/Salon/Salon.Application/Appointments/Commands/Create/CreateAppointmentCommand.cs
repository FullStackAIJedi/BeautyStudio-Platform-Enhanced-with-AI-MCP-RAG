namespace Salon.Application.Appointments.Commands.Create
{ 
    using MediatR;

    public class CreateAppointmentCommand : IRequest<CreateAppointmentOutputModel>
    {
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartAt { get; set; }
        public string? Notes { get; set; }
    }
}
