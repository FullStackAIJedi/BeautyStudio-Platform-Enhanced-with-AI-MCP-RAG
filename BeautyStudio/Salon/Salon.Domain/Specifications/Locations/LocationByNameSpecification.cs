namespace Salon.Domain.Specifications.Locations
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Locations;
    using SharedKernel.Models;

    public class LocationByNameSpecification : Specification<Location>
    {
        private readonly string? search;
        public LocationByNameSpecification(string? search) => this.search = search;
        protected override bool Include => !string.IsNullOrEmpty(this.search);
        public override Expression<Func<Location, bool>> ToExpression()
            => location => location.Name.ToLower().Contains(this.search!.ToLower());
    }
}
