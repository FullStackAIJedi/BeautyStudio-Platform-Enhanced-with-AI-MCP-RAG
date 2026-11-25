namespace Shop.Application.Products.Queries.Search
{
    public class SearchProductsOutputModel
    {
        public SearchProductsOutputModel(
            IEnumerable<ProductOutputModel> products,
            int page,
            int totalPages)
        {
            this.Products = products;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<ProductOutputModel> Products { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }

    public class ProductOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
