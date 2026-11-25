namespace Salon.Application.Services.Commands.Edit
{
    using FluentValidation;
    using Salon.Application.Services.Commands.Common;

    public class EditServiceCommandValidator : AbstractValidator<EditServiceCommand>
    {
        public EditServiceCommandValidator(IServiceRepository serviceRepository)
            => this.Include(new ServiceCommandValidator<EditServiceCommand>(serviceRepository));
    }
}
