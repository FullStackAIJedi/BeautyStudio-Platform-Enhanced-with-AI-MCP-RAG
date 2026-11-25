namespace Shop.Application.Products.Queries.Search
{
    using MediatR;
    using Shop.Domain.Specifications.Products;

    public class SearchProductsQueryHandler
        : IRequestHandler<SearchProductsQuery, SearchProductsOutputModel>
    {
        private const int ProductsPerPage = 20;

        private readonly IProductRepository productRepository;

        public SearchProductsQueryHandler(IProductRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<SearchProductsOutputModel> Handle(
            SearchProductsQuery request,
            CancellationToken cancellationToken)
        {
            var specification = new ProductByNameSpecification(request.Search)
                .And(new ProductOnlyActiveSpecification(request.OnlyActive));

            var skip = (request.Page - 1) * ProductsPerPage;

            var listings = await this.productRepository.GetListings<ProductOutputModel>(
                specification, skip, ProductsPerPage, cancellationToken);

            var total = await this.productRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / ProductsPerPage);

            return new SearchProductsOutputModel(listings, request.Page, totalPages);
        }
    }
}
