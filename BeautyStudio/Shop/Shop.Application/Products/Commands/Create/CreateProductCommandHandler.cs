namespace Shop.Application.Products.Commands.Create
{
    using MediatR;
    using Shop.Domain.Factories.Products;

    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, CreateProductOutputModel>
    {
        private readonly IProductRepository productRepository;
        private readonly IProductFactory productFactory;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IProductFactory productFactory)
        {
            this.productRepository = productRepository;
            this.productFactory = productFactory;
        }

        public async Task<CreateProductOutputModel> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = this.productFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithPrice(request.Price)
                .WithStock(request.Stock)
                .Build();

            await this.productRepository.Save(product, cancellationToken);

            return new CreateProductOutputModel(product.Id);
        }
    }
}
