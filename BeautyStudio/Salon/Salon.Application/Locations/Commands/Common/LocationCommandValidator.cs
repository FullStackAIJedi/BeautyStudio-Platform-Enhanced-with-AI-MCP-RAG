namespace Salon.Application.Locations.Commands.Common
{
    using FluentValidation;

    using Salon.Application.Common;
    using Salon.Domain.Models;

    public class LocationCommandValidator<TCommand> : AbstractValidator<LocationCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public LocationCommandValidator()
        {
            this.RuleFor(c => c.Name)
                .MinimumLength(ModelConstants.Location.MinNameLength)
                .MaximumLength(ModelConstants.Location.MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Address).NotEmpty();
            this.RuleFor(c => c.City).NotEmpty();
            this.RuleFor(c => c.Country).NotEmpty();
            this.RuleFor(c => c.Phone).NotEmpty();
            this.RuleFor(c => c.TimeZone).NotEmpty();
            this.RuleFor(c => c.WorkingHours).NotEmpty();
        }
    }
}
