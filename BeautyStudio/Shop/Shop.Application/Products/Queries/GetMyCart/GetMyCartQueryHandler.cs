namespace Shop.Application.Products.Queries.GetMyCart
{
    using MediatR;

    using Shop.Application.Carts;
    using SharedKernel.Security;

    public class GetMyCartQueryHandler
        : IRequestHandler<GetMyCartQuery, GetMyCartOutputModel>
    {
        private readonly ICartRepository cartRepository;
        private readonly ICurrentUser currentUser;

        public GetMyCartQueryHandler(
            ICartRepository cartRepository,
            ICurrentUser currentUser)
        {
            this.cartRepository = cartRepository;
            this.currentUser = currentUser;
        }

        public async Task<GetMyCartOutputModel> Handle(
            GetMyCartQuery request,
            CancellationToken cancellationToken)
        {
            var cart = await this.cartRepository
                .FindActiveByUser(this.currentUser.UserId, cancellationToken);

            if (cart == null)
                return new GetMyCartOutputModel(0, new List<CartItemOutputModel>(), 0);

            return new GetMyCartOutputModel(
                cart.Id,
                cart.Items.Select(i => new CartItemOutputModel
                {
                    Id = i.Id,
                    ReferenceId = i.ReferenceId,
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    Type = i.Type
                }).ToList(),
                cart.Total);
        }
    }
}
