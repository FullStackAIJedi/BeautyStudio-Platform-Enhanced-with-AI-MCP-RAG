namespace Salon.Application.Clients.Queries.Details
{
    using MediatR;
    using Salon.Application.Common.Exceptions;

    public class ClientDetailsQueryHandler : IRequestHandler<ClientDetailsQuery, ClientDetailsOutputModel>
    {
        private readonly IClientRepository clientRepository;

        public ClientDetailsQueryHandler(IClientRepository clientRepository)
            => this.clientRepository = clientRepository;

        public async Task<ClientDetailsOutputModel> Handle(
            ClientDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var details = await this.clientRepository.GetDetails(request.Id, cancellationToken);
            if (details == null) throw new NotFoundException(nameof(ClientDetailsQuery), request.Id);
            return details;
        }
    }
}
