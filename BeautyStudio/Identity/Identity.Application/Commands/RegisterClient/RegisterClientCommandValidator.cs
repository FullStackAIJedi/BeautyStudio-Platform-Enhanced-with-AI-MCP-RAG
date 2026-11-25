namespace Identity.Application.Commands.RegisterClient
{
    using FluentValidation;
    using Identity.Domain.Models;

    public class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand>
    {
        public RegisterClientCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .MinimumLength(ModelConstants.User.MinEmailLength)
                .MaximumLength(ModelConstants.User.MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MinimumLength(ModelConstants.User.MinPasswordLength)
                .MaximumLength(ModelConstants.User.MaxPasswordLength)
                .NotEmpty();

            this.RuleFor(u => u.UserName)
                .MinimumLength(ModelConstants.User.MinUserNameLength)
                .MaximumLength(ModelConstants.User.MaxUserNameLength)
                .NotEmpty();

            this.RuleFor(u => u.FirstName)
                .MinimumLength(ModelConstants.User.MinNameLength)
                .MaximumLength(ModelConstants.User.MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.LastName)
                .MinimumLength(ModelConstants.User.MinNameLength)
                .MaximumLength(ModelConstants.User.MaxNameLength)
                .NotEmpty();
        }
    }
}
