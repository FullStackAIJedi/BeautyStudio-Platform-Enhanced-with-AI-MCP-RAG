namespace Salon.Application.Services.Commands.Create
{
    using MediatR;
    using Salon.Domain.Factories.Services;

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CreateServiceOutputModel>
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IServiceFactory serviceFactory;

        public CreateServiceCommandHandler(
            IServiceRepository serviceRepository,
            IServiceFactory serviceFactory)
        {
            this.serviceRepository = serviceRepository;
            this.serviceFactory = serviceFactory;
        }

        public async Task<CreateServiceOutputModel> Handle(
            CreateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = this.serviceFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithDuration(request.DurationMinutes)
                .WithPrice(request.Price)
                .WithCategory(request.CategoryId)
                .Build();

            await this.serviceRepository.Save(service, cancellationToken);

            return new CreateServiceOutputModel(service.Id);
        }
    }
}
