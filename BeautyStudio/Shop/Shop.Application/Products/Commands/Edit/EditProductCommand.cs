namespace Shop.Application.Products.Commands.Edit
{
    using MediatR;
    using SharedKernel.Results; 

    public class EditProductCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
