namespace Shop.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Shop.Application.Payments;
    using Shop.Domain.Models.Payments;

    internal class PaymentRepository : IPaymentRepository
    {
        private readonly ShopDbContext db;

        public PaymentRepository(ShopDbContext db) => this.db = db;

        public async Task<Payment> Find(int id, CancellationToken cancellationToken = default)
            => await this.db.Payments.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<Payment> FindByIdempotencyKey(
            string idempotencyKey,
            CancellationToken cancellationToken = default)
            => await this.db.Payments
                .FirstOrDefaultAsync(p => p.IdempotencyKey == idempotencyKey, cancellationToken);

        public async Task Save(Payment payment, CancellationToken cancellationToken = default)
        {
            this.db.Payments.Update(payment);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Payment>> GetByUser(
            int userId,
            int skip,
            int take,
            CancellationToken cancellationToken = default)
        {
            return await this.db.Payments
                .Join(this.db.Carts,
                    p => p.CartId,
                    c => c.Id,
                    (p, c) => new { Payment = p, Cart = c })
                .Where(x => x.Cart.UserId == userId)
                .OrderByDescending(x => x.Payment.CreatedAt)
                .Skip(skip)
                .Take(take)
                .Select(x => x.Payment)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> TotalByUser(int userId, CancellationToken cancellationToken = default)
            => await this.db.Payments
                .Join(this.db.Carts,
                    p => p.CartId,
                    c => c.Id,
                    (p, c) => new { p, c })
                .CountAsync(x => x.c.UserId == userId, cancellationToken);
    }
}
