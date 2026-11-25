namespace Salon.Application.Clients.Commands.UpdateMyProfile
{
    using FluentValidation;

    public class UpdateMyClientProfileCommandValidator : AbstractValidator<UpdateMyClientProfileCommand>
    {
        public UpdateMyClientProfileCommandValidator()
        {
            this.RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .When(x => x.FirstName != null);

            this.RuleFor(x => x.LastName)
                .MaximumLength(50)
                .When(x => x.LastName != null);

            this.RuleFor(x => x.Phone)
                .MaximumLength(20)
                .When(x => x.Phone != null);
        }
    }
}
