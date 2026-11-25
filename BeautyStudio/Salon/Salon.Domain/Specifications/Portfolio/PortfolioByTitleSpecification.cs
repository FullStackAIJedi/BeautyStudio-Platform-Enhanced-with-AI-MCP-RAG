namespace Salon.Domain.Specifications.Portfolio
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Portfolio;
    using SharedKernel.Models;

    public class PortfolioByTitleSpecification : Specification<PortfolioItem>
    {
        private readonly string? search;

        public PortfolioByTitleSpecification(string? search) => this.search = search;

        protected override bool Include => !string.IsNullOrEmpty(this.search);

        public override Expression<Func<PortfolioItem, bool>> ToExpression()
            => item => item.Title.ToLower().Contains(this.search!.ToLower());
    }
}
