namespace Salon.Application.Locations.Queries.Search
{
    using MediatR;
    using Salon.Application.Locations.Queries.Common;

    public class SearchLocationsQuery : LocationsQuery, IRequest<SearchLocationsOutputModel>
    {
    }
}
