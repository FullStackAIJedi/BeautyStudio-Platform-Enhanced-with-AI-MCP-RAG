namespace Salon.Application.Portfolio.Commands.Vote
{
    using FluentValidation;

    public class VotePortfolioCommandValidator : AbstractValidator<VotePortfolioCommand>
    {
        public VotePortfolioCommandValidator()
        {
            this.RuleFor(v => v.Vote).Must(v => v == 1 || v == -1)
                .WithMessage("Vote must be 1 or -1.");
        }
    }
}
