namespace Salon.Application.Services.Queries.Search
{ 
    using MediatR;

    using Salon.Application.Services.Queries.Common;
    using static Salon.Application.Services.Queries.Common.ServicesQuery;

    public class SearchServicesQueryHandler : ServicesQueryHandler, IRequestHandler<SearchServicesQuery, SearchServicesOutputModel>
    {
        public SearchServicesQueryHandler(IServiceRepository serviceRepository)
            : base(serviceRepository) { }

        public async Task<SearchServicesOutputModel> Handle(
            SearchServicesQuery request,
            CancellationToken cancellationToken)
        {
            var listings = await base.GetServiceListings<ServiceOutputModel>(request, cancellationToken);
            var totalPages = await base.GetTotalPages(request, cancellationToken);

            return new SearchServicesOutputModel(listings, request.Page, totalPages);
        }
    }
}
