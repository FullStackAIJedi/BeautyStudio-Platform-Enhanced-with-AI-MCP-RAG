namespace Salon.Domain.Specifications.Locations
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Locations;
    using SharedKernel.Models;

    public class LocationByCountrySpecification : Specification<Location>
    {
        private readonly string? country;
        public LocationByCountrySpecification(string? country) => this.country = country;
        protected override bool Include => !string.IsNullOrEmpty(this.country);
        public override Expression<Func<Location, bool>> ToExpression()
            => location => location.Country.ToLower() == this.country!.ToLower();
    }
}
