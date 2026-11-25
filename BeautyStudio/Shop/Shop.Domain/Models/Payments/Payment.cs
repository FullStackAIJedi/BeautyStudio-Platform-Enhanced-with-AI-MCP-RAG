namespace Shop.Domain.Models.Payments
{
    using SharedKernel.Models; 
    using Shop.Domain.Exceptions;

    public class Payment : Entity<int>, IAggregateRoot
    {
        public Payment(int cartId, decimal amount, string idempotencyKey)
        {
            if (amount <= 0) throw new InvalidPaymentException("Amount must be positive.");
            this.CartId = cartId;
            this.Amount = amount;
            this.Status = PaymentStatus.Pending;
            this.IdempotencyKey = idempotencyKey;
            this.CreatedAt = DateTime.UtcNow;
        }

        private Payment() { }

        public int CartId { get; private set; }
        public decimal Amount { get; private set; }
        public int Status { get; private set; }
        public string IdempotencyKey { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        public void SimulateSuccess()
        {
            if (this.Status != PaymentStatus.Pending)
                throw new InvalidPaymentException("Payment is not pending.");

            this.Status = PaymentStatus.Completed;
            this.CompletedAt = DateTime.UtcNow;
        }

        public void Fail()
        {
            this.Status = PaymentStatus.Failed;
        }
    }

    public static class PaymentStatus
    {
        public const int Pending = 1;
        public const int Completed = 2;
        public const int Failed = 3;
    }
}
