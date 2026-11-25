namespace Salon.Domain.Specifications.Categories
{ 
    using System;
    using System.Linq.Expressions;

    using Salon.Domain.Models.Categories;
    using SharedKernel.Models;
 
    public class CategoryByNameSpecification : Specification<Category>
    {
        private readonly string? search;

        public CategoryByNameSpecification(string? search) => this.search = search;

        protected override bool Include => !string.IsNullOrEmpty(this.search);

        public override Expression<Func<Category, bool>> ToExpression()
            => category => category.Name.ToLower().Contains(this.search!.ToLower());
    }
}
