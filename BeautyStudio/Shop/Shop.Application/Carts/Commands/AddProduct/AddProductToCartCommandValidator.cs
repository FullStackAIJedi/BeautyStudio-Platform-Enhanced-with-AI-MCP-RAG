namespace Shop.Application.Carts.Commands.AddProduct
{
    using FluentValidation;

    public class AddProductToCartCommandValidator : AbstractValidator<AddProductToCartCommand>
    {
        public AddProductToCartCommandValidator()
        {
            this.RuleFor(c => c.ProductId).GreaterThan(0);
            this.RuleFor(c => c.Quantity).GreaterThan(0);
        }
    }
}
