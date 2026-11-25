namespace Salon.Application.Appointments.Queries.MyAppointments
{
    using MediatR;

    public class MyAppointmentsQuery : IRequest<MyAppointmentsOutputModel>
    {
        public int Page { get; set; } = 1;
    }
}
