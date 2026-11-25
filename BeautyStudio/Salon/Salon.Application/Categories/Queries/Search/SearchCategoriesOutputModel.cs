namespace Salon.Application.Categories.Queries.Search
{
    public class SearchCategoriesOutputModel
    {
        public SearchCategoriesOutputModel(IEnumerable<CategoryOutputModel> categories, int page, int totalPages)
        {
            this.Categories = categories;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<CategoryOutputModel> Categories { get; }
        public int Page { get; }
        public int TotalPages { get; }
    } 
}
