namespace Salon.Application.Portfolio.Queries.Search
{
    using Salon.Application.Portfolio.Queries.Common;

    public class SearchPortfolioOutputModel
    {
        public SearchPortfolioOutputModel(
            IEnumerable<PortfolioItemOutputModel> items,
            int page,
            int totalPages)
        {
            this.Items = items;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<PortfolioItemOutputModel> Items { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}
