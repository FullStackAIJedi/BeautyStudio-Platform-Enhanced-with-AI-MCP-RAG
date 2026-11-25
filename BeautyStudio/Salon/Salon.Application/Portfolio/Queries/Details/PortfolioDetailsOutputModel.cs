namespace Salon.Application.Portfolio.Queries.Details
{ 
    using AutoMapper; 
    using Salon.Application.Portfolio.Queries.Common;
    using Salon.Domain.Models.Portfolio;

    public class PortfolioDetailsOutputModel : PortfolioItemOutputModel
    {
        public List<string> Tags { get; private set; } = new();

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<PortfolioItem, PortfolioDetailsOutputModel>()
                .IncludeBase<PortfolioItem, PortfolioItemOutputModel>();
    }
}
