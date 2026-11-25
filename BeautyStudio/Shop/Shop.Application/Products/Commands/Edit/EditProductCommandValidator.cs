namespace Shop.Application.Products.Commands.Edit
{
    using FluentValidation;
    using Shop.Domain.Models;

    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            this.RuleFor(p => p.Name)
                .MinimumLength(ModelConstants.Product.MinNameLength)
                .MaximumLength(ModelConstants.Product.MaxNameLength)
                .NotEmpty();

            this.RuleFor(p => p.Description)
                .MaximumLength(ModelConstants.Product.MaxDescriptionLength);

            this.RuleFor(p => p.Price).GreaterThan(0);
            this.RuleFor(p => p.Stock).GreaterThanOrEqualTo(0);
        }
    }
}
