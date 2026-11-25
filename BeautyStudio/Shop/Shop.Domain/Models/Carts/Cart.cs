namespace Shop.Domain.Models.Carts
{
    using SharedKernel.Models;
    using Shop.Domain.Exceptions;

    public class Cart : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CartItem> items;

        internal Cart(int userId)
        {
            this.UserId = userId;
            this.Status = CartStatus.Active;
            this.CreatedAt = DateTime.UtcNow;
            this.items = new HashSet<CartItem>();
        }

        private Cart()
        {
            this.items = new HashSet<CartItem>();
        }

        public int UserId { get; private set; }
        public int Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CheckedOutAt { get; private set; }

        public IReadOnlyCollection<CartItem> Items => this.items.ToList().AsReadOnly();

        public decimal Total => this.items.Sum(i => i.Price * i.Quantity);

        public void AddProduct(int productId, string productName, decimal price, int quantity)
        {
            if (this.Status != CartStatus.Active)
                throw new InvalidCartException("Cart is not active.");

            var existing = this.items.FirstOrDefault(i => i.ProductId == productId);
            if (existing != null)
            {
                existing.IncreaseQuantity(quantity);
                return;
            }

            this.items.Add(new CartItem(this.Id, productId, productName, price, quantity, CartItemType.Product));
        }

        public void AddSalonService(int appointmentId, string serviceName, decimal price)
        {
            if (this.Status != CartStatus.Active)
                throw new InvalidCartException("Cart is not active.");

            this.items.Add(new CartItem(this.Id, appointmentId, serviceName, price, 1, CartItemType.SalonService));
        }

        public void Checkout()
        {
            if (!this.items.Any()) throw new InvalidCartException("Cart is empty.");
            this.Status = CartStatus.CheckedOut;
            this.CheckedOutAt = DateTime.UtcNow;
        }

        public void Clear() => this.items.Clear();
    }

    public static class CartStatus
    {
        public const int Active = 1;
        public const int CheckedOut = 2;
        public const int Abandoned = 3;
    }

    public static class CartItemType
    {
        public const int Product = 1;
        public const int SalonService = 2;
    }
}
