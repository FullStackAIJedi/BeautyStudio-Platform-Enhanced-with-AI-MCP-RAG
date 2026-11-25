namespace Salon.Application.Employees.Commands.UpdateProfile
{
    using FluentValidation;

    public class UpdateEmployeeProfileCommandValidator : AbstractValidator<UpdateEmployeeProfileCommand>
    {
        public UpdateEmployeeProfileCommandValidator()
        {
            this.RuleFor(u => u.FirstName).NotEmpty().MaximumLength(50);
            this.RuleFor(u => u.LastName).NotEmpty().MaximumLength(50);
            this.RuleFor(u => u.Bio).MaximumLength(1000);
            this.RuleFor(u => u.ProfilePhotoUrl).MaximumLength(500);
        }
    }
}
