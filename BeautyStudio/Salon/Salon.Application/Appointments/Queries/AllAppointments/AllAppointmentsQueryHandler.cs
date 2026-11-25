namespace Salon.Application.Appointments.Queries.AllAppointments
{
    using MediatR;
    using Salon.Application.Appointments.Queries.Common;
    using Salon.Domain.Specifications.Appointments;

    public class AllAppointmentsQueryHandler : IRequestHandler<AllAppointmentsQuery, AllAppointmentsOutputModel>
    {
        private const int AppointmentsPerPage = 20;

        private readonly IAppointmentRepository appointmentRepository;

        public AllAppointmentsQueryHandler(IAppointmentRepository appointmentRepository)
            => this.appointmentRepository = appointmentRepository;

        public async Task<AllAppointmentsOutputModel> Handle(
            AllAppointmentsQuery request,
            CancellationToken cancellationToken)
        {
            var specification = new AppointmentByDateRangeSpecification(request.FromDate, request.ToDate)
                .And(new AppointmentByEmployeeSpecification(request.EmployeeId));

            var skip = (request.Page - 1) * AppointmentsPerPage;

            var listings = await this.appointmentRepository.GetListings<AppointmentOutputModel>(
                specification, skip, AppointmentsPerPage, cancellationToken);

            var total = await this.appointmentRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / AppointmentsPerPage);

            return new AllAppointmentsOutputModel(listings, request.Page, totalPages);
        }
    }
}
