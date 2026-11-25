namespace Salon.Application.Services.Commands.Edit
{
    using MediatR; 
    using SharedKernel.Results;

    public class EditServiceCommandHandler : IRequestHandler<EditServiceCommand, Result>
    {
        private readonly IServiceRepository serviceRepository;

        public EditServiceCommandHandler(IServiceRepository serviceRepository)
            => this.serviceRepository = serviceRepository;

        public async Task<Result> Handle(
            EditServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = await this.serviceRepository.Find(request.Id, cancellationToken);
            if (service == null) return "Service not found.";

            service
                .UpdateName(request.Name)
                .UpdateDescription(request.Description)
                .UpdateDuration(request.DurationMinutes)
                .UpdatePrice(request.Price)
                .UpdateCategory(request.CategoryId);

            await this.serviceRepository.Save(service, cancellationToken);
            return Result.Success;
        }
    }
}
