namespace Salon.Application.Appointments.Commands.Reschedule
{
    using FluentValidation;

    public class RescheduleAppointmentCommandValidator : AbstractValidator<RescheduleAppointmentCommand>
    {
        public RescheduleAppointmentCommandValidator()
        {
            this.RuleFor(a => a.NewStartAt).GreaterThan(DateTime.UtcNow);
        }
    }
}
