namespace Salon.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Salon.Application.Portfolio;
    using Salon.Application.Portfolio.Queries.Details;
    using Salon.Domain.Models.Portfolio;
    using Salon.Infrastructure.Persistence.Common;

    using SharedKernel.Models;

    internal class PortfolioRepository : DataRepository<SalonDbContext, PortfolioItem>, IPortfolioRepository
    {
        private readonly IMapper mapper;

        public PortfolioRepository(SalonDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<PortfolioItem> Find(int id, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<PortfolioItem> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.All().Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<PortfolioDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<PortfolioDetailsOutputModel>(this.All().Where(p => p.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(Specification<PortfolioItem> specification, CancellationToken cancellationToken = default)
            => await this.All().Where(specification).CountAsync(cancellationToken);
    }
}
