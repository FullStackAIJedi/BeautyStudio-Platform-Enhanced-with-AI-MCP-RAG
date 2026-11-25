namespace Salon.Application.Services.Commands.Commands.Activate
{ 
    using MediatR; 
    using SharedKernel.Results;

    public class ActivateServiceCommandHandler : IRequestHandler<ActivateServiceCommand, Result>
    {
        private readonly IServiceRepository serviceRepository;

        public ActivateServiceCommandHandler(IServiceRepository serviceRepository)
            => this.serviceRepository = serviceRepository;

        public async Task<Result> Handle(
            ActivateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = await this.serviceRepository.Find(request.Id, cancellationToken);

            if (service == null)
                return "Service not found.";

            service.Activate();

            await this.serviceRepository.Save(service, cancellationToken);

            return Result.Success;
        }
    }
}
