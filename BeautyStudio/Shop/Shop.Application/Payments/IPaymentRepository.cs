namespace Shop.Application.Payments
{
    using Shop.Domain.Models.Payments;

    public interface IPaymentRepository
    {
        Task<Payment> Find(int id, CancellationToken cancellationToken = default);
        Task<Payment> FindByIdempotencyKey(string idempotencyKey, CancellationToken cancellationToken = default);
        Task Save(Payment payment, CancellationToken cancellationToken = default);
        Task<IEnumerable<Payment>> GetByUser(int userId, int skip, int take, CancellationToken cancellationToken = default);
        Task<int> TotalByUser(int userId, CancellationToken cancellationToken = default);
    }
}
