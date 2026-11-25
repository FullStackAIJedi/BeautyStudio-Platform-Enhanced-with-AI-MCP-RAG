namespace Shop.Application.Carts
{
    using Shop.Domain.Models.Carts;
    using SharedKernel.Models;

    public interface ICartRepository
    {
        Task<Cart> Find(int id, CancellationToken cancellationToken = default);
        Task<Cart> FindActiveByUser(int userId, CancellationToken cancellationToken = default);
        Task<Cart> CreateForUser(int userId, CancellationToken cancellationToken = default);
        Task Save(Cart cart, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Cart> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Cart> specification, CancellationToken cancellationToken = default);
    }
}
