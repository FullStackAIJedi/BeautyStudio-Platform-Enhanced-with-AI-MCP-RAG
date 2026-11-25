namespace Salon.Application.Locations
{
    using Salon.Application.Locations.Queries.Details;
    using Salon.Domain.Models.Locations;

    using SharedKernel.Models;

    public interface ILocationRepository
    {
        Task<Location> Find(int id, CancellationToken cancellationToken = default);
        Task Save(Location location, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Location> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<LocationDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Location> specification, CancellationToken cancellationToken = default);
    }
}
