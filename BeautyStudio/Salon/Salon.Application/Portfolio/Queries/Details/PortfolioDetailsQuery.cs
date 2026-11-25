namespace Salon.Application.Portfolio.Queries.Details
{
    using MediatR;
    using Salon.Application.Common;

    public class PortfolioDetailsQuery : EntityCommand<int>, IRequest<PortfolioDetailsOutputModel>
    {
    }
}
