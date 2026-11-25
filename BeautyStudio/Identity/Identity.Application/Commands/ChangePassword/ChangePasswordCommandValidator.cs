namespace Identity.Application.Commands.ChangePassword
{ 
    using FluentValidation; 
    using Identity.Domain.Models;

    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            this.RuleFor(u => u.CurrentPassword).NotEmpty();
            this.RuleFor(u => u.NewPassword)
                .MinimumLength(ModelConstants.User.MinPasswordLength)
                .MaximumLength(ModelConstants.User.MaxPasswordLength)
                .NotEmpty();
        }
    }
}
