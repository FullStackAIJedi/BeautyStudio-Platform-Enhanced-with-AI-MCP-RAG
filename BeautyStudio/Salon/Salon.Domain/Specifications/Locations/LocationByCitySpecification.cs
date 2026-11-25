namespace Salon.Domain.Specifications.Locations
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Locations;
    using SharedKernel.Models;

    public class LocationByCitySpecification : Specification<Location>
    {
        private readonly string? city;
        public LocationByCitySpecification(string? city) => this.city = city;
        protected override bool Include => !string.IsNullOrEmpty(this.city);
        public override Expression<Func<Location, bool>> ToExpression()
            => location => location.City.ToLower() == this.city!.ToLower();
    }
}
