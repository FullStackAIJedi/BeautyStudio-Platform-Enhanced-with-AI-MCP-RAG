namespace Shop.Application.Products.Commands.Edit
{
    using MediatR;
    using SharedKernel.Results; 

    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Result>
    {
        private readonly IProductRepository productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<Result> Handle(
            EditProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await this.productRepository.Find(request.Id, cancellationToken);
            if (product == null) return "Product not found.";

            product
                .UpdateName(request.Name)
                .UpdateDescription(request.Description)
                .UpdatePrice(request.Price)
                .UpdateStock(request.Stock);

            await this.productRepository.Save(product, cancellationToken);
            return Result.Success;
        }
    }
}
