namespace Salon.Application.Appointments.Commands.Create
{ 
    using MediatR; 
    using Salon.Domain.Factories.Appointments;

    using SharedKernel.Security;

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentOutputModel>
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IAppointmentFactory appointmentFactory;

        public CreateAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository,
            IAppointmentFactory appointmentFactory)
        {
            this.appointmentRepository = appointmentRepository;
            this.appointmentFactory = appointmentFactory;
        }

        public async Task<CreateAppointmentOutputModel> Handle(
            CreateAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            var appointment = this.appointmentFactory
                .WithClient(request.ClientId)
                .WithEmployee(request.EmployeeId)
                .WithService(request.ServiceId)
                .WithStartAt(request.StartAt)
                .WithNotes(request.Notes)
                .Build();

            await this.appointmentRepository.Save(appointment, cancellationToken);

            return new CreateAppointmentOutputModel(appointment.Id);
        }
    }
}
