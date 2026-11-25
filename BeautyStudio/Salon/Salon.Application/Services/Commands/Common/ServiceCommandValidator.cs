namespace Salon.Application.Services.Commands.Common
{
    using FluentValidation;
    using Salon.Application.Common;
    using Salon.Domain.Models;

    public class ServiceCommandValidator<TCommand> : AbstractValidator<ServiceCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ServiceCommandValidator(IServiceRepository serviceRepository)
        {
            this.RuleFor(c => c.Name)
                .MinimumLength(ModelConstants.Service.MinNameLength)
                .MaximumLength(ModelConstants.Service.MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Description)
                .MinimumLength(ModelConstants.Service.MinDescriptionLength)
                .MaximumLength(ModelConstants.Service.MaxDescriptionLength)
                .NotEmpty();

            this.RuleFor(c => c.DurationMinutes)
                .InclusiveBetween(ModelConstants.Service.MinDuration, ModelConstants.Service.MaxDuration);

            this.RuleFor(c => c.Price)
                .GreaterThan(0);
        }
    }
}
