namespace Salon.Application.Portfolio.Commands.Create
{
    using FluentValidation;
    using Salon.Domain.Models;

    public class CreatePortfolioItemCommandValidator : AbstractValidator<CreatePortfolioItemCommand>
    {
        public CreatePortfolioItemCommandValidator()
        {
            this.RuleFor(p => p.Title)
                .MinimumLength(ModelConstants.Portfolio.MinTitleLength)
                .MaximumLength(ModelConstants.Portfolio.MaxTitleLength)
                .NotEmpty();
            this.RuleFor(p => p.LocationId).GreaterThan(0);
            this.RuleFor(p => p.Description)
                .MaximumLength(ModelConstants.Portfolio.MaxDescriptionLength);

            this.RuleFor(p => p.ImageUrl).NotEmpty().MaximumLength(500);
            this.RuleFor(p => p.ServiceDate).LessThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
