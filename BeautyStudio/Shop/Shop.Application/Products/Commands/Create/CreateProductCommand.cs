namespace Shop.Application.Products.Commands.Create
{
    using MediatR;

    public class CreateProductCommand : IRequest<CreateProductOutputModel>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
