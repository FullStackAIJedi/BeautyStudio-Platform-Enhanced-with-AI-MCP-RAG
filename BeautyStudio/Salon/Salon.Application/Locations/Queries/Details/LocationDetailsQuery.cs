namespace Salon.Application.Locations.Queries.Details
{
    using MediatR;
    using Salon.Application.Common;

    public class LocationDetailsQuery : EntityCommand<int>, IRequest<LocationDetailsOutputModel>
    {
    }
}
