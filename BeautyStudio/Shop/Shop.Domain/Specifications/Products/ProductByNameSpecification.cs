namespace Shop.Domain.Specifications.Products
{
    using System.Linq.Expressions;

    using SharedKernel.Models;
    using Shop.Domain.Models.Products;

    public class ProductByNameSpecification : Specification<Product>
    {
        private readonly string? search;

        public ProductByNameSpecification(string? search) => this.search = search;

        protected override bool Include => !string.IsNullOrEmpty(this.search);

        public override Expression<Func<Product, bool>> ToExpression()
            => product => product.Name.ToLower().Contains(this.search!.ToLower());
    }
}
