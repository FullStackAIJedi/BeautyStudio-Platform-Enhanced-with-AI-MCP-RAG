namespace Shop.Domain.Specifications.Products
{
    using System.Linq.Expressions;

    using SharedKernel.Models; 
    using Shop.Domain.Models.Products;

    public class ProductOnlyActiveSpecification : Specification<Product>
    {
        private readonly bool? onlyActive;

        public ProductOnlyActiveSpecification(bool? onlyActive) => this.onlyActive = onlyActive;

        protected override bool Include => this.onlyActive == true;

        public override Expression<Func<Product, bool>> ToExpression()
            => product => product.IsActive;
    }
}
