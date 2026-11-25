namespace Salon.Application.Locations.Commands.Create
{
    using FluentValidation;
    using Salon.Application.Locations.Commands.Common;

    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
            => this.Include(new LocationCommandValidator<CreateLocationCommand>());
    }
}
