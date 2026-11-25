namespace Salon.Application.Employees.Queries.Search
{
    using MediatR; 

    public class SearchEmployeesQuery : IRequest<SearchEmployeesOutputModel>
    {
        public string? Search { get; set; }
        public int? RoleId { get; set; }
        public int Page { get; set; } = 1;
    }
}
