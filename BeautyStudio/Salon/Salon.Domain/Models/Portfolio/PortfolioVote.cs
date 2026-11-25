namespace Salon.Domain.Models.Portfolio
{ 
    using SharedKernel.Models;

    public class PortfolioVote : Entity<int>
    {
        internal PortfolioVote(int portfolioItemId, int userId, int vote)
        {
            this.PortfolioItemId = portfolioItemId;
            this.UserId = userId;
            this.Vote = vote;
            this.CreatedAt = DateTime.UtcNow;
        }

        private PortfolioVote() { }

        public int PortfolioItemId { get; private set; }
        public int UserId { get; private set; }
        public int Vote { get; private set; } // 1 or -1
        public DateTime CreatedAt { get; private set; }
    }
}
