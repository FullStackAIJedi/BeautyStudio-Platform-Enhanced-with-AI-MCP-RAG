namespace Shop.Domain.Factories.Products
{
    using Shop.Domain.Models.Products;

    public class ProductFactory : IProductFactory
    {
        private string name = default!;
        private string description = default!;
        private decimal price;
        private int stock;

        public IProductFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IProductFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IProductFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IProductFactory WithStock(int stock)
        {
            this.stock = stock;
            return this;
        }

        public Product Build()
            => new Product(this.name, this.description, this.price, this.stock);
    }
}
