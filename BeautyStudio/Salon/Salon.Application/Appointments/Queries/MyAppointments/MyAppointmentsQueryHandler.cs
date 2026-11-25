namespace Salon.Application.Appointments.Queries.MyAppointments
{
    using MediatR;

    using Salon.Application.Appointments.Queries.Common; 
    using Salon.Domain.Specifications.Appointments;

    using SharedKernel.Security;

    public class MyAppointmentsQueryHandler : IRequestHandler<MyAppointmentsQuery, MyAppointmentsOutputModel>
    {
        private const int AppointmentsPerPage = 10;

        private readonly IAppointmentRepository appointmentRepository;
        private readonly ICurrentUser currentUser;

        public MyAppointmentsQueryHandler(
            IAppointmentRepository appointmentRepository,
            ICurrentUser currentUser)
        {
            this.appointmentRepository = appointmentRepository;
            this.currentUser = currentUser;
        }

        public async Task<MyAppointmentsOutputModel> Handle(
            MyAppointmentsQuery request,
            CancellationToken cancellationToken)
        {
            var specification = new AppointmentByUserSpecification(this.currentUser.UserId);
            var skip = (request.Page - 1) * AppointmentsPerPage;

            var listings = await this.appointmentRepository.GetListings<AppointmentOutputModel>(
                specification, skip, AppointmentsPerPage, cancellationToken);

            var total = await this.appointmentRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / AppointmentsPerPage);

            return new MyAppointmentsOutputModel(listings, request.Page, totalPages);
        }
    }
}
