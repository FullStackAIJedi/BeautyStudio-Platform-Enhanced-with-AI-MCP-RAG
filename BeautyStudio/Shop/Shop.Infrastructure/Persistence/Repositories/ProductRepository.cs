namespace Shop.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Shop.Application.Products;
    using Shop.Application.Products.Queries.Details;
    using Shop.Domain.Models.Products;

    using SharedKernel.Models;

    internal class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext db;
        private readonly IMapper mapper;

        public ProductRepository(ShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Product> Find(int id, CancellationToken cancellationToken = default)
            => await this.db.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task Save(Product product, CancellationToken cancellationToken = default)
        {
            this.db.Products.Update(product);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var product = await this.db.Products.FindAsync(new object[] { id }, cancellationToken);
            if (product == null) return false;

            this.db.Products.Remove(product);
            await this.db.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Product> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.db.Products.Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<ProductDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ProductDetailsOutputModel>(this.db.Products.Where(p => p.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(Specification<Product> specification, CancellationToken cancellationToken = default)
            => await this.db.Products.Where(specification).CountAsync(cancellationToken);
    }
}
