namespace Shop.Domain.Factories.Products
{  
    using Shop.Domain.Models.Products;
    using SharedKernel.Models;

    public interface IProductFactory : IFactory<Product>
    {
        IProductFactory WithName(string name);
        IProductFactory WithDescription(string description);
        IProductFactory WithPrice(decimal price);
        IProductFactory WithStock(int stock);
    }
}
