namespace Salon.Domain.Specifications.Portfolio
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Portfolio;
    using SharedKernel.Models;

    public class PortfolioByServiceSpecification : Specification<PortfolioItem>
    {
        private readonly int? serviceId;

        public PortfolioByServiceSpecification(int? serviceId) => this.serviceId = serviceId;

        protected override bool Include => this.serviceId != null;

        public override Expression<Func<PortfolioItem, bool>> ToExpression()
            => item => item.ServiceId == this.serviceId;
    }
}
