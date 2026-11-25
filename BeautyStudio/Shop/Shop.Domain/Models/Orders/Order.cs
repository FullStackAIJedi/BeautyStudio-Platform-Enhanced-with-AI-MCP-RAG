namespace Shop.Domain.Models.Orders
{
    using Shop.Domain.Exceptions;
    using SharedKernel.Models;

    public class Order : Entity<int>, IAggregateRoot
    {
        internal Order(int userId, int cartId, decimal total, string orderNumber)
        {
            if (total <= 0) throw new InvalidCartException("Order total must be positive.");
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new InvalidCartException("Order number is required.");

            this.UserId = userId;
            this.CartId = cartId;
            this.Total = total;
            this.OrderNumber = orderNumber;
            this.Status = OrderStatus.Pending;
            this.CreatedAt = DateTime.UtcNow;
        }

        private Order()
        {
            this.OrderNumber = default!;
        }

        public int UserId { get; private set; }
        public int CartId { get; private set; }
        public string OrderNumber { get; private set; }
        public decimal Total { get; private set; }
        public int Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? PaidAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? CancelledAt { get; private set; }

        public void MarkAsPaid()
        {
            if (this.Status != OrderStatus.Pending)
                throw new InvalidCartException("Order is not pending.");
            this.Status = OrderStatus.Paid;
            this.PaidAt = DateTime.UtcNow;
        }

        public void Complete()
        {
            if (this.Status != OrderStatus.Paid)
                throw new InvalidCartException("Order is not paid.");
            this.Status = OrderStatus.Completed;
            this.CompletedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (this.Status == OrderStatus.Completed)
                throw new InvalidCartException("Cannot cancel completed order.");
            this.Status = OrderStatus.Cancelled;
            this.CancelledAt = DateTime.UtcNow;
        }
    }

    public static class OrderStatus
    {
        public const int Pending = 1;
        public const int Paid = 2;
        public const int Completed = 3;
        public const int Cancelled = 4;
    }
}
