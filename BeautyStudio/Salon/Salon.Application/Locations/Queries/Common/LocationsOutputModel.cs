namespace Salon.Application.Locations.Queries.Common
{
    public abstract class LocationsOutputModel<TLocationOutputModel>
    {
        internal LocationsOutputModel(
            IEnumerable<TLocationOutputModel> locations,
            int page,
            int totalPages)
        {
            this.Locations = locations;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TLocationOutputModel> Locations { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}
