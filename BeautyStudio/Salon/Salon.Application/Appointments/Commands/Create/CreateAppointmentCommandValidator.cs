namespace Salon.Application.Appointments.Commands.Create
{
    using FluentValidation;

    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            this.RuleFor(a => a.ClientId).GreaterThan(0);
            this.RuleFor(a => a.EmployeeId).GreaterThan(0);
            this.RuleFor(a => a.ServiceId).GreaterThan(0);
            this.RuleFor(a => a.StartAt).GreaterThan(DateTime.UtcNow);
            this.RuleFor(a => a.Notes).MaximumLength(1000);
        }
    }
}
