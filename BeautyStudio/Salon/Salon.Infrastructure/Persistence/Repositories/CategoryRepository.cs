namespace Salon.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Salon.Application.Categories;
    using Salon.Domain.Models.Categories;
    using SharedKernel.Models;

    internal class CategoryRepository : ICategoryRepository
    {
        private readonly SalonDbContext db;
        private readonly IMapper mapper;

        public CategoryRepository(SalonDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Category> Find(int id, CancellationToken cancellationToken = default)
            => await this.db.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task Save(Category category, CancellationToken cancellationToken = default)
        {
            this.db.Categories.Update(category);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var category = await this.db.Categories.FindAsync(new object[] { id }, cancellationToken);
            if (category == null) return false;

            this.db.Categories.Remove(category);
            await this.db.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Category> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.db.Categories.Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<int> Total(Specification<Category> specification, CancellationToken cancellationToken = default)
            => await this.db.Categories.Where(specification).CountAsync(cancellationToken);
    }
}
