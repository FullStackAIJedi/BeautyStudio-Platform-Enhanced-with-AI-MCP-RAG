namespace Salon.Application.Services.Commands.Commands.Deactivate
{
    using MediatR;
    using SharedKernel.Results;

    public class DeactivateServiceCommandHandler : IRequestHandler<DeactivateServiceCommand, Result>
    {
        private readonly IServiceRepository serviceRepository; 
        public DeactivateServiceCommandHandler(IServiceRepository serviceRepository)
            => this.serviceRepository = serviceRepository;

        public async Task<Result> Handle(
            DeactivateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = await this.serviceRepository.Find(request.Id, cancellationToken);

            if (service == null)
                return "Service not found.";

            service.Deactivate();

            await this.serviceRepository.Save(service, cancellationToken);

            return Result.Success;
        }
    }
}
