namespace Salon.Application.Locations.Commands.Edit
{
    using FluentValidation;
    using Salon.Application.Locations.Commands.Common;

    public class EditLocationCommandValidator : AbstractValidator<EditLocationCommand>
    {
        public EditLocationCommandValidator()
            => this.Include(new LocationCommandValidator<EditLocationCommand>());
    }
}
