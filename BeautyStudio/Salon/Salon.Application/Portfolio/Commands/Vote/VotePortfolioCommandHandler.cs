namespace Salon.Application.Portfolio.Commands.Vote
{
    using MediatR;

    using SharedKernel.Results;
    using SharedKernel.Security;

    public class VotePortfolioCommandHandler : IRequestHandler<VotePortfolioCommand, Result>
    {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly ICurrentUser currentUser;

        public VotePortfolioCommandHandler(
            IPortfolioRepository portfolioRepository,
            ICurrentUser currentUser)
        {
            this.portfolioRepository = portfolioRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            VotePortfolioCommand request,
            CancellationToken cancellationToken)
        {
            var item = await this.portfolioRepository.Find(request.PortfolioItemId, cancellationToken);
            if (item == null) return "Portfolio item not found.";

            item.ApplyVote(this.currentUser.UserId, request.Vote);

            await this.portfolioRepository.Save(item, cancellationToken);
            return Result.Success;
        }
    }
}
