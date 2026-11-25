namespace Salon.Application.Portfolio.Commands.Create
{
    public class CreatePortfolioItemOutputModel
    {
        public CreatePortfolioItemOutputModel(int portfolioItemId) => this.PortfolioItemId = portfolioItemId;
        public int PortfolioItemId { get; }
    }
}
