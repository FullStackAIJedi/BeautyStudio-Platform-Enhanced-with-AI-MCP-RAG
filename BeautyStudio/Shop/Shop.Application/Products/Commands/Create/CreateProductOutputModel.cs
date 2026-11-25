namespace Shop.Application.Products.Commands.Create
{
    public class CreateProductOutputModel
    {
        public CreateProductOutputModel(int productId) => this.ProductId = productId;
        public int ProductId { get; }
    }
}
