namespace Shop.Application.Carts.Commands.AddProduct
{
    using MediatR;
    using SharedKernel.Results; 

    public class AddProductToCartCommand : IRequest<Result> 
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
