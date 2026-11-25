namespace Salon.Application.Appointments.Queries.MyAppointments
{
    using Salon.Application.Appointments.Queries.Common;

    public class MyAppointmentsOutputModel
    {
        public MyAppointmentsOutputModel(
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
