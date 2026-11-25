namespace Salon.Application.Categories.Queries.Search
{ 
    using MediatR;
    using Salon.Domain.Specifications.Categories;

    public class SearchCategoriesQueryHandler : IRequestHandler<SearchCategoriesQuery, SearchCategoriesOutputModel>
    {
        private const int CategoriesPerPage = 20;
        private readonly ICategoryRepository categoryRepository;

        public SearchCategoriesQueryHandler(ICategoryRepository categoryRepository)
            => this.categoryRepository = categoryRepository;

        public async Task<SearchCategoriesOutputModel> Handle(
            SearchCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            // Combines the filters. If Search is null or empty, Include returns false and is ignored.
            var specification = new CategoryByNameSpecification(request.Search)
                .And(new CategoryOnlyActiveSpecification(request.OnlyActive));

            var skip = (request.Page - 1) * CategoriesPerPage;

            var listings = await this.categoryRepository.GetListings<CategoryOutputModel>(
                specification, skip, CategoriesPerPage, cancellationToken);

            var total = await this.categoryRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / CategoriesPerPage);

            return new SearchCategoriesOutputModel(listings, request.Page, totalPages);
        }
    }
}
