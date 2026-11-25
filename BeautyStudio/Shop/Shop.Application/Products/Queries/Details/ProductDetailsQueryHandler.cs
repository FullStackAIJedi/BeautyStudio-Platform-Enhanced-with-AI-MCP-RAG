namespace Shop.Application.Products.Queries.Details
{
    using MediatR;
    using SharedKernel.Exceptions;

    public class ProductDetailsQueryHandler
        : IRequestHandler<ProductDetailsQuery, ProductDetailsOutputModel>
    {
        private readonly IProductRepository productRepository;

        public ProductDetailsQueryHandler(IProductRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<ProductDetailsOutputModel> Handle(
            ProductDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var details = await this.productRepository.GetDetails(request.Id, cancellationToken);
            if (details == null) throw new NotFoundException(nameof(ProductDetailsQuery), request.Id);
            return details;
        }
    }
}
