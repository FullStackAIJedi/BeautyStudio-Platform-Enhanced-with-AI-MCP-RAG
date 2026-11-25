namespace Shop.Application.Carts.Commands.AddSalonService
{
    using MediatR;
    using SharedKernel.Results; 

    public class AddSalonServiceToCartCommandHandler
        : IRequestHandler<AddSalonServiceToCartCommand, Result>
    {
        private readonly ICartRepository cartRepository;

        public AddSalonServiceToCartCommandHandler(ICartRepository cartRepository)
            => this.cartRepository = cartRepository;

        public async Task<Result> Handle(
            AddSalonServiceToCartCommand request,
            CancellationToken cancellationToken)
        {
            var cart = await this.cartRepository.FindActiveByUser(request.UserId, cancellationToken);

            if (cart == null)
            {
                cart = await this.cartRepository.CreateForUser(request.UserId, cancellationToken);
            }

            cart.AddSalonService(request.AppointmentId, request.ServiceName, request.Price);

            await this.cartRepository.Save(cart, cancellationToken);

            return Result.Success;
        }
    }
}
