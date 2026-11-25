namespace Salon.Application.Locations.Queries.Common
{
    using AutoMapper;
    using Salon.Application.Common.Mapping;
    using Salon.Domain.Models.Locations;

    public class LocationOutputModel : IMapFrom<Location>
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Address { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public string Phone { get; private set; } = default!;
        public string TimeZone { get; private set; } = default!;
        public bool IsAvailable { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Location, LocationOutputModel>();
    }
}
