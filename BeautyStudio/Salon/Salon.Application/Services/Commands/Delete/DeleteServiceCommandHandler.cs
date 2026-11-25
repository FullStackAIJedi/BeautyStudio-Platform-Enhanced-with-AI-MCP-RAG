namespace Salon.Application.Services.Commands.Delete
{
    using MediatR; 
    using SharedKernel.Results;

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Result>
    {
        private readonly IServiceRepository serviceRepository;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
            => this.serviceRepository = serviceRepository;

        public async Task<Result> Handle(
            DeleteServiceCommand request,
            CancellationToken cancellationToken)
        {
            var deleted = await this.serviceRepository.Delete(request.Id, cancellationToken);
            return deleted ? Result.Success : "Service not found.";
        }
    }
}
