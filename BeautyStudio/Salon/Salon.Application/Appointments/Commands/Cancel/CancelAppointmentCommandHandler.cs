namespace Salon.Application.Appointments.Commands.Cancel
{
    using MediatR;

    using SharedKernel.Results;
    using SharedKernel.Security;

    public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, Result>
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly ICurrentUser currentUser;

        public CancelAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository,
            ICurrentUser currentUser)
        {
            this.appointmentRepository = appointmentRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            CancelAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            var appointment = await this.appointmentRepository.Find(request.Id, cancellationToken);
            if (appointment == null) return "Appointment not found.";

            appointment.Cancel();

            await this.appointmentRepository.Save(appointment, cancellationToken);
            return Result.Success;
        }
    }
}
