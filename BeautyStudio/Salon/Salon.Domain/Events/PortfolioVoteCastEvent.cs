namespace Salon.Domain.Events
{ 
    using SharedKernel.Models;

    public class PortfolioVoteCastEvent : IDomainEvent
    {
        public PortfolioVoteCastEvent(int portfolioItemId, int userId, int vote)
        {
            this.PortfolioItemId = portfolioItemId;
            this.UserId = userId;
            this.Vote = vote;
        }

        public int PortfolioItemId { get; }
        public int UserId { get; }
        public int Vote { get; }
    }
}
