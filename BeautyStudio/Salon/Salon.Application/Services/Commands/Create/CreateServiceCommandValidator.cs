namespace Salon.Application.Services.Commands.Create
{
    using FluentValidation;
    using Salon.Application.Services.Commands.Common;

    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator(IServiceRepository serviceRepository)
            => this.Include(new ServiceCommandValidator<CreateServiceCommand>(serviceRepository));
    }
}
