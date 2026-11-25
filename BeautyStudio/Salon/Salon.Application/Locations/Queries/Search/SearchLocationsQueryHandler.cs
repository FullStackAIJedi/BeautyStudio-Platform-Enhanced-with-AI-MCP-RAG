using MediatR;

using Salon.Application.Locations.Queries.Common;
using static Salon.Application.Locations.Queries.Common.LocationsQuery;

namespace Salon.Application.Locations.Queries.Search
{
    public class SearchLocationsQueryHandler
        : LocationsQueryHandler,
          IRequestHandler<SearchLocationsQuery, SearchLocationsOutputModel>
    {
        public SearchLocationsQueryHandler(ILocationRepository locationRepository)
            : base(locationRepository)
        {
        }

        public async Task<SearchLocationsOutputModel> Handle(
            SearchLocationsQuery request,
            CancellationToken cancellationToken)
        {
            var listings = await base.GetLocationListings<LocationOutputModel>(request, cancellationToken);
            var totalPages = await base.GetTotalPages(request, cancellationToken);

            return new SearchLocationsOutputModel(listings, request.Page, totalPages);
        }
    }
}
