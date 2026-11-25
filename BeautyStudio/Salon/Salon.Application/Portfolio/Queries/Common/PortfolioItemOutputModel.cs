namespace Salon.Application.Portfolio.Queries.Common
{
    using AutoMapper;
    using Salon.Application.Common.Mapping;
    using Salon.Domain.Models.Portfolio;

    public class PortfolioItemOutputModel : IMapFrom<PortfolioItem>
    {
        public int Id { get; private set; }
        public int EmployeeId { get; private set; }
        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string ImageUrl { get; private set; } = default!;
        public string? ThumbnailUrl { get; private set; }
        public DateTime ServiceDate { get; private set; }
        public int PositiveVotes { get; private set; }
        public int NegativeVotes { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<PortfolioItem, PortfolioItemOutputModel>();
    }
}
