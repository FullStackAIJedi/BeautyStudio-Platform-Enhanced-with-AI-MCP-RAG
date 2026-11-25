namespace Salon.Infrastructure.Persistence.Repositories
{ 
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Salon.Application.Clients;
    using Salon.Application.Clients.Queries.Details; 
    using Salon.Domain.Models.Clients;
    using Salon.Infrastructure.Persistence.Common;
    using SharedKernel.Models;

    internal class ClientRepository : DataRepository<SalonDbContext, Client>, IClientRepository
    {
        private readonly IMapper mapper;

        public ClientRepository(SalonDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<Client> Find(int id, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<Client> FindByUserId(int userId, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Client> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.All().Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<ClientDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ClientDetailsOutputModel>(this.All().Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(Specification<Client> specification, CancellationToken cancellationToken = default)
            => await this.All().Where(specification).CountAsync(cancellationToken);
    }
}
