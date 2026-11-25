namespace Shop.Application.Products.Commands.Delete
{
    using MediatR;
    using SharedKernel.Results;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<Result> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var deleted = await this.productRepository.Delete(request.Id, cancellationToken);
            return deleted ? Result.Success : "Product not found.";
        }
    }
}
