namespace Salon.Domain.Specifications.Services
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Services;
    using SharedKernel.Models;

    public class ServiceByCategorySpecification : Specification<Service>
    {
        private readonly int? categoryId;

        public ServiceByCategorySpecification(int? categoryId) => this.categoryId = categoryId;

        protected override bool Include => this.categoryId != null;

        public override Expression<Func<Service, bool>> ToExpression()
            => service => service.CategoryId == this.categoryId;
    }
}
