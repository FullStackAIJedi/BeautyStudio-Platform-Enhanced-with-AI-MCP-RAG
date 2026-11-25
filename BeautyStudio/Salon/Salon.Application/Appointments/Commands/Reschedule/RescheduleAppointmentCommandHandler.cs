namespace Salon.Application.Appointments.Commands.Reschedule
{
    using MediatR; 
    using SharedKernel.Results;

    public class RescheduleAppointmentCommandHandler : IRequestHandler<RescheduleAppointmentCommand, Result>
    {
        private readonly IAppointmentRepository appointmentRepository;

        public RescheduleAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
            => this.appointmentRepository = appointmentRepository;

        public async Task<Result> Handle(
            RescheduleAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            var appointment = await this.appointmentRepository.Find(request.Id, cancellationToken);
            if (appointment == null) return "Appointment not found.";

            appointment.Reschedule(request.NewStartAt);

            await this.appointmentRepository.Save(appointment, cancellationToken);
            return Result.Success;
        }
    }
}
