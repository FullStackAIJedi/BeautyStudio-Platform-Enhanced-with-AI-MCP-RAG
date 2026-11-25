namespace Shop.Application.Carts.Commands.AddProduct
{
    using MediatR;

    using Shop.Application.Products;
    using SharedKernel.Results;
    using SharedKernel.Security;
 
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, Result>
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly ICurrentUser currentUser;

        public AddProductToCartCommandHandler(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            ICurrentUser currentUser)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            AddProductToCartCommand request,
            CancellationToken cancellationToken)
        {
            var product = await this.productRepository.Find(request.ProductId, cancellationToken);
            if (product == null) return "Product not found.";
            if (product.Stock < request.Quantity) return "Not enough stock.";

            var cart = await this.cartRepository
                .FindActiveByUser(this.currentUser.UserId, cancellationToken);

            if (cart == null)
                cart = await this.cartRepository.CreateForUser(this.currentUser.UserId, cancellationToken);

            cart.AddProduct(product.Id, product.Name, product.Price, request.Quantity);

            await this.cartRepository.Save(cart, cancellationToken);
            return Result.Success;
        }
    }
}
