namespace Salon.Application.Portfolio.Commands.Vote
{ 
    using MediatR;
    using SharedKernel.Results;

    public class VotePortfolioCommand : IRequest<Result>
    {
        public int PortfolioItemId { get; set; }
        public int Vote { get; set; } // 1 или -1
    }
}
