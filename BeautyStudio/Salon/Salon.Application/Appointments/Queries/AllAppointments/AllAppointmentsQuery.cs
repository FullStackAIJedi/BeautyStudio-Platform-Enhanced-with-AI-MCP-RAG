namespace Salon.Application.Appointments.Queries.AllAppointments
{ 
    using MediatR;

    public class AllAppointmentsQuery : IRequest<AllAppointmentsOutputModel>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? EmployeeId { get; set; }
        public int Page { get; set; } = 1;
    }
}
