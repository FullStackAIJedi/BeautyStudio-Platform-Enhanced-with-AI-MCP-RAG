namespace Salon.Application.Appointments.Queries.AllAppointments
{
    using Salon.Application.Appointments.Queries.Common;

    public class AllAppointmentsOutputModel
    {
        public AllAppointmentsOutputModel(
            IEnumerable<AppointmentOutputModel> appointments,
            int page,
            int totalPages)
        {
            this.Appointments = appointments;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<AppointmentOutputModel> Appointments { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}
