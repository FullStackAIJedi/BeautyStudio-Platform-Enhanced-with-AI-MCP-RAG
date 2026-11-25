namespace Shop.Domain.Models.Products
{
    using SharedKernel.Models;
    using Shop.Domain.Exceptions;

    public class Product : Entity<int>, IAggregateRoot
    {
        internal Product(string name, string description, decimal price, int stock)
        {
            this.Validate(name, description, price, stock);
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.IsActive = true;
            this.CreatedAt = DateTime.UtcNow;
        }

        private Product()
        {
            this.Name = default!;
            this.Description = default!;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Product UpdateStock(int newStock)
        {
            if (newStock < 0) throw new InvalidProductException("Stock cannot be negative.");
            this.Stock = newStock;
            return this;
        }

        public Product DecreaseStock(int quantity)
        {
            if (quantity > this.Stock)
                throw new InvalidProductException($"Not enough stock. Available: {this.Stock}");
            this.Stock -= quantity;
            return this;
        }

        public Product UpdateName(string name)
        {
            Guard.ForStringLength<InvalidProductException>(name, 2, 200, nameof(this.Name));
            this.Name = name;
            return this;
        }

        public Product UpdateDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public Product UpdatePrice(decimal price)
        {
            if (price <= 0) throw new InvalidProductException("Price must be positive.");
            this.Price = price;
            return this;
        }

        private void Validate(string name, string description, decimal price, int stock)
        {
            Guard.ForStringLength<InvalidProductException>(name, 2, 200, nameof(this.Name));
            Guard.ForStringLength<InvalidProductException>(description, 0, 2000, nameof(this.Description));
            if (price <= 0) throw new InvalidProductException("Price must be positive.");
            if (stock < 0) throw new InvalidProductException("Stock cannot be negative.");
        }
    }
}
