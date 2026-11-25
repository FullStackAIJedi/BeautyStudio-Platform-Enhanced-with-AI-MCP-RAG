namespace Salon.Application.Locations.Queries.Search
{
    using Salon.Application.Locations.Queries.Common;

    public class SearchLocationsOutputModel : LocationsOutputModel<LocationOutputModel>
    {
        public SearchLocationsOutputModel(
            IEnumerable<LocationOutputModel> locations,
            int page,
            int totalPages)
            : base(locations, page, totalPages)
        {
        }
    }
}
