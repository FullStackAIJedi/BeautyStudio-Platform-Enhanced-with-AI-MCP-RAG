namespace Salon.Application.Locations.Queries.Details
{
    using AutoMapper;
    using Salon.Application.Locations.Queries.Common;
    using Salon.Domain.Models.Locations;

    public class LocationDetailsOutputModel : LocationOutputModel
    {
        public string WorkingHours { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Location, LocationDetailsOutputModel>()
                .IncludeBase<Location, LocationOutputModel>();
    }
}
