namespace Salon.Application.Locations.Queries.Details
{
    using MediatR;
    using Salon.Application.Common.Exceptions;

    public class LocationDetailsQueryHandler : IRequestHandler<LocationDetailsQuery, LocationDetailsOutputModel>
    {
        private readonly ILocationRepository locationRepository;

        public LocationDetailsQueryHandler(ILocationRepository locationRepository)
            => this.locationRepository = locationRepository;

        public async Task<LocationDetailsOutputModel> Handle(
            LocationDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var details = await this.locationRepository.GetDetails(request.Id, cancellationToken);
            if (details == null) throw new NotFoundException(nameof(LocationDetailsQuery), request.Id);
            return details;
        }
    }
}
