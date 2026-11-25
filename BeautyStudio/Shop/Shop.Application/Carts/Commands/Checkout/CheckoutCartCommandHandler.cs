namespace Shop.Application.Carts.Commands.Checkout
{
    using MediatR;

    using SharedKernel.Results;
    using SharedKernel.Security; 

    public class CheckoutCartCommandHandler : IRequestHandler<CheckoutCartCommand, Result>
    {
        private readonly ICartRepository cartRepository;
        private readonly ICurrentUser currentUser;

        public CheckoutCartCommandHandler(
            ICartRepository cartRepository,
            ICurrentUser currentUser)
        {
            this.cartRepository = cartRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            CheckoutCartCommand request,
            CancellationToken cancellationToken)
        {
            var cart = await this.cartRepository
                .FindActiveByUser(this.currentUser.UserId, cancellationToken);

            if (cart == null) return "Cart not found or not active.";
            if (!cart.Items.Any()) return "Cart is empty.";

            cart.Checkout();

            await this.cartRepository.Save(cart, cancellationToken);
            return Result.Success;
        }
    }
}
