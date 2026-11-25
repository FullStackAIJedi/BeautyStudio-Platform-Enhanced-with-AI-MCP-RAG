namespace Salon.Application.Locations.Queries.Common
{
    using Salon.Domain.Models.Locations;
    using Salon.Domain.Specifications.Locations;

    using SharedKernel.Models;

    public abstract class LocationsQuery
    {
        protected const int LocationsPerPage = 20;

        public string? City { get; set; }
        public string? Country { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Search { get; set; }
        public int Page { get; set; } = 1;

        public abstract class LocationsQueryHandler
        {
            private readonly ILocationRepository locationRepository;

            protected LocationsQueryHandler(ILocationRepository locationRepository)
                => this.locationRepository = locationRepository;

            protected async Task<IEnumerable<TOutputModel>> GetLocationListings<TOutputModel>(
                LocationsQuery request,
                CancellationToken cancellationToken = default)
            {
                var specification = this.GetSpecification(request);
                var skip = (request.Page - 1) * LocationsPerPage;

                return await this.locationRepository.GetListings<TOutputModel>(
                    specification, skip, LocationsPerPage, cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                LocationsQuery request,
                CancellationToken cancellationToken = default)
            {
                var specification = this.GetSpecification(request);
                var total = await this.locationRepository.Total(specification, cancellationToken);
                return (int)Math.Ceiling((double)total / LocationsPerPage);
            }

            private Specification<Location> GetSpecification(LocationsQuery request)
                => new LocationByCitySpecification(request.City)
                    .And(new LocationByCountrySpecification(request.Country))
                    .And(new LocationByAvailabilitySpecification(request.IsAvailable))
                    .And(new LocationByNameSpecification(request.Search));
        }
    }
}
