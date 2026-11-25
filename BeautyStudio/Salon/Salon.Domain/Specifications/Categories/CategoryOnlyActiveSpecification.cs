namespace Salon.Domain.Specifications.Categories
{
    using System;
    using System.Linq.Expressions;

    using Salon.Domain.Models.Categories;
    using SharedKernel.Models;

    public class CategoryOnlyActiveSpecification : Specification<Category>
    {
        private readonly bool? onlyActive;

        public CategoryOnlyActiveSpecification(bool? onlyActive) => this.onlyActive = onlyActive;

        protected override bool Include => this.onlyActive == true;

        public override Expression<Func<Category, bool>> ToExpression()
            => category => category.IsActive;
    }
}
