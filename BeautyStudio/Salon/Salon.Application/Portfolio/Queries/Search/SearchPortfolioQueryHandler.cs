namespace Salon.Application.Portfolio.Queries.Search
{
    using MediatR;
    using Salon.Application.Portfolio.Queries.Common;
    using Salon.Domain.Specifications.Portfolio;

    public class SearchPortfolioQueryHandler : IRequestHandler<SearchPortfolioQuery, SearchPortfolioOutputModel>
    {
        private const int PortfolioPerPage = 12;

        private readonly IPortfolioRepository portfolioRepository;

        public SearchPortfolioQueryHandler(IPortfolioRepository portfolioRepository)
            => this.portfolioRepository = portfolioRepository;

        public async Task<SearchPortfolioOutputModel> Handle(
            SearchPortfolioQuery request,
            CancellationToken cancellationToken)
        {
            var specification = new PortfolioByEmployeeSpecification(request.EmployeeId)
                .And(new PortfolioByServiceSpecification(request.ServiceId))
                .And(new PortfolioByTitleSpecification(request.Search));

            var skip = (request.Page - 1) * PortfolioPerPage;

            var listings = await this.portfolioRepository.GetListings<PortfolioItemOutputModel>(
                specification, skip, PortfolioPerPage, cancellationToken);

            var total = await this.portfolioRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / PortfolioPerPage);

            return new SearchPortfolioOutputModel(listings, request.Page, totalPages);
        }
    }
}
