namespace Shop.Application.Products.Queries.Details
{
    using MediatR;

    public class ProductDetailsQuery : IRequest<ProductDetailsOutputModel>
    {
        public int Id { get; set; }
    }
}
