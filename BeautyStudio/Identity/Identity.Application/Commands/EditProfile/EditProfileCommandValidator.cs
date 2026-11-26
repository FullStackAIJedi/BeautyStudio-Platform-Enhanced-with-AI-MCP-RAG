namespace Identity.Application.Commands.EditProfile
{
    using FluentValidation;
    using Identity.Domain.Models;

    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator()
        {
            this.RuleFor(u => u.FirstName)
                .MinimumLength(ModelConstants.User.MinNameLength)
                .MaximumLength(ModelConstants.User.MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.LastName)
                .MinimumLength(ModelConstants.User.MinNameLength)
                .MaximumLength(ModelConstants.User.MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MaximumLength(20);
        }
    }
}
