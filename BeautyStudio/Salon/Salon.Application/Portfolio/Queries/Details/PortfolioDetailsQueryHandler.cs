namespace Salon.Application.Portfolio.Queries.Details
{
    using MediatR;
    using Salon.Application.Common.Exceptions;

    public class PortfolioDetailsQueryHandler : IRequestHandler<PortfolioDetailsQuery, PortfolioDetailsOutputModel>
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioDetailsQueryHandler(IPortfolioRepository portfolioRepository)
            => this.portfolioRepository = portfolioRepository;

        public async Task<PortfolioDetailsOutputModel> Handle(
            PortfolioDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var details = await this.portfolioRepository.GetDetails(request.Id, cancellationToken);
            if (details == null) throw new NotFoundException(nameof(PortfolioDetailsQuery), request.Id);
            return details;
        }
    }
}
