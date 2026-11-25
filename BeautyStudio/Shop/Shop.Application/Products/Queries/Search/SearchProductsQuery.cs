namespace Shop.Application.Products.Queries.Search
{
    using MediatR;

    public class SearchProductsQuery : IRequest<SearchProductsOutputModel>
    {
        public string? Search { get; set; }
        public bool? OnlyActive { get; set; }
        public int Page { get; set; } = 1;
    }
}
