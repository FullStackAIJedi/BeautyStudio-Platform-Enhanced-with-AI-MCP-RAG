namespace Shop.Infrastructure.Persistence.Repositories
{ 
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

     using Shop.Application.Carts;
    using Shop.Domain.Factories.Carts;
    using Shop.Domain.Models.Carts;

    using SharedKernel.Models;

    internal class CartRepository : ICartRepository
    {
        private readonly ShopDbContext db;
        private readonly IMapper mapper;
        private readonly ICartFactory cartFactory;

        public CartRepository(ShopDbContext db, IMapper mapper, ICartFactory cartFactory)
        {
            this.db = db;
            this.mapper = mapper;
            this.cartFactory = cartFactory;
        }

        public async Task<Cart> Find(int id, CancellationToken cancellationToken = default)
            => await this.db.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<Cart> FindActiveByUser(int userId, CancellationToken cancellationToken = default)
            => await this.db.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.Status == CartStatus.Active,
                    cancellationToken);

        public async Task<Cart> CreateForUser(int userId, CancellationToken cancellationToken = default)
        {
            var cart = this.cartFactory.WithUser(userId).Build();
            this.db.Carts.Add(cart);
            await this.db.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task Save(Cart cart, CancellationToken cancellationToken = default)
        {
            this.db.Carts.Update(cart);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Cart> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.db.Carts.Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<int> Total(Specification<Cart> specification, CancellationToken cancellationToken = default)
            => await this.db.Carts.Where(specification).CountAsync(cancellationToken);
    }
}
