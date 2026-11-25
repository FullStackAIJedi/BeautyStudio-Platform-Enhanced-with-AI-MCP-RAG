namespace Salon.Domain.Specifications.Portfolio
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Portfolio;
    using SharedKernel.Models;

    public class PortfolioByEmployeeSpecification : Specification<PortfolioItem>
    {
        private readonly int? employeeId;

        public PortfolioByEmployeeSpecification(int? employeeId) => this.employeeId = employeeId;

        protected override bool Include => this.employeeId != null;

        public override Expression<Func<PortfolioItem, bool>> ToExpression()
            => item => item.EmployeeId == this.employeeId;
    }
}
