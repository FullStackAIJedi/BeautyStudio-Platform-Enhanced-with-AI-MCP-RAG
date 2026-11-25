namespace Salon.Application.Clients.Queries.Search
{
    using MediatR;
    using Salon.Application.Clients.Queries.Common;
    using Salon.Domain.Specifications.Clients;

    public class SearchClientsQueryHandler : IRequestHandler<SearchClientsQuery, SearchClientsOutputModel>
    {
        private const int ClientsPerPage = 20;

        private readonly IClientRepository clientRepository;

        public SearchClientsQueryHandler(IClientRepository clientRepository)
            => this.clientRepository = clientRepository;

        public async Task<SearchClientsOutputModel> Handle(
            SearchClientsQuery request,
            CancellationToken cancellationToken)
        {
            var specification = new ClientByNameSpecification(request.Search);
            var skip = (request.Page - 1) * ClientsPerPage;

            var listings = await this.clientRepository.GetListings<ClientOutputModel>(
                specification, skip, ClientsPerPage, cancellationToken);

            var total = await this.clientRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / ClientsPerPage);

            return new SearchClientsOutputModel(listings, request.Page, totalPages);
        }
    }
}
