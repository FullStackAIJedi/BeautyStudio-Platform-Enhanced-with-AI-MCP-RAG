namespace Shop.Application.Products
{
    using Shop.Application.Products.Queries.Details;
    using Shop.Domain.Models.Products;

    using SharedKernel.Models;

    public interface IProductRepository
    {
        Task<Product> Find(int id, CancellationToken cancellationToken = default);
        Task Save(Product product, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Product> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<ProductDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Product> specification, CancellationToken cancellationToken = default);
    }
}
