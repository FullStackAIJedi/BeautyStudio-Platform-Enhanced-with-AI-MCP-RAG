namespace Salon.Application.Portfolio
{ 
    using Salon.Application.Portfolio.Queries.Details; 
    using Salon.Domain.Models.Portfolio;

    using SharedKernel.Models;

    public interface IPortfolioRepository
    {
        Task<PortfolioItem> Find(int id, CancellationToken cancellationToken = default);
        Task Save(PortfolioItem item, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<PortfolioItem> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<PortfolioDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<int> Total(Specification<PortfolioItem> specification, CancellationToken cancellationToken = default);
    }
}
