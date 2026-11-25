namespace Salon.Application.Services.Queries.Details
{
    using MediatR;
    using Salon.Application.Common.Exceptions;

    public class ServiceDetailsQueryHandler : IRequestHandler<ServiceDetailsQuery, ServiceDetailsOutputModel>
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceDetailsQueryHandler(IServiceRepository serviceRepository)
            => this.serviceRepository = serviceRepository;

        public async Task<ServiceDetailsOutputModel> Handle(
            ServiceDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var details = await this.serviceRepository.GetDetails(request.Id, cancellationToken);
            if (details == null) throw new NotFoundException(nameof(ServiceDetailsQuery), request.Id);
            return details;
        }
    }
}
