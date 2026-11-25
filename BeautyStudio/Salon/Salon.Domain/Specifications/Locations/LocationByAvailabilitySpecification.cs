namespace Salon.Domain.Specifications.Locations
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Locations;
    using SharedKernel.Models;

    public class LocationByAvailabilitySpecification : Specification<Location>
    {
        private readonly bool? isAvailable;
        public LocationByAvailabilitySpecification(bool? isAvailable) => this.isAvailable = isAvailable;
        protected override bool Include => this.isAvailable != null;
        public override Expression<Func<Location, bool>> ToExpression()
            => location => location.IsAvailable == this.isAvailable;
    }
}
