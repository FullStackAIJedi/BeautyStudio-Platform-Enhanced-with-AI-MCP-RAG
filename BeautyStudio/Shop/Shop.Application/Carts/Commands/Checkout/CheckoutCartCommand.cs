namespace Shop.Application.Carts.Commands.Checkout
{
    using MediatR;
    using SharedKernel.Results; 

    public class CheckoutCartCommand : IRequest<Result>
    { }
}
