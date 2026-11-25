namespace Salon.Application.Categories
{
    using Salon.Domain.Models.Categories;
    using SharedKernel.Models;

    public interface ICategoryRepository
    {
        Task<Category> Find(int id, CancellationToken cancellationToken = default);
        Task Save(Category category, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Category> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Category> specification, CancellationToken cancellationToken = default);
    }
}
