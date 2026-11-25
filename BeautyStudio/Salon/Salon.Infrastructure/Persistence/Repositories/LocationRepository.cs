namespace Salon.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Salon.Application.Locations;
    using Salon.Application.Locations.Queries.Details; 
    using Salon.Domain.Models.Locations;
    using Salon.Infrastructure.Persistence.Common;

    using SharedKernel.Models;

    internal class LocationRepository : DataRepository<SalonDbContext, Location>, ILocationRepository
    {
        private readonly IMapper mapper;

        public LocationRepository(SalonDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<Location> Find(int id, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var location = await this.Data.Locations.FindAsync(id);
            if (location == null) return false;

            this.Data.Locations.Remove(location);
            await this.Data.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Location> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.All().Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<LocationDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<LocationDetailsOutputModel>(this.All().Where(l => l.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(Specification<Location> specification, CancellationToken cancellationToken = default)
            => await this.All().Where(specification).CountAsync(cancellationToken);
    }
}
