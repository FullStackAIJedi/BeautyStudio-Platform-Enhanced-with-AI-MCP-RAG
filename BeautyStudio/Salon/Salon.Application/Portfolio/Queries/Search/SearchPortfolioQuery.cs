namespace Salon.Application.Portfolio.Queries.Search
{
    using MediatR;

    public class SearchPortfolioQuery : IRequest<SearchPortfolioOutputModel>
    {
        public int? EmployeeId { get; set; }
        public int? ServiceId { get; set; }
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
    }
}
