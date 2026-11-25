namespace Salon.Domain.Specifications.Services
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Services;
    using SharedKernel.Models;

    public class ServiceByNameSpecification : Specification<Service>
    {
        private readonly string? name;

        public ServiceByNameSpecification(string? name) => this.name = name;

        protected override bool Include => !string.IsNullOrEmpty(this.name);

        public override Expression<Func<Service, bool>> ToExpression()
            => service => service.Name.ToLower().Contains(this.name!.ToLower());
    }
}
