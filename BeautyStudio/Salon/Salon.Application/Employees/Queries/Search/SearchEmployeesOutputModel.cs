namespace Salon.Application.Employees.Queries.Search
{
    using Salon.Application.Employees.Queries.Common;

    public class SearchEmployeesOutputModel
    {
        public SearchEmployeesOutputModel(
            IEnumerable<EmployeeOutputModel> employees,
            int page,
            int totalPages)
        {
            this.Employees = employees;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<EmployeeOutputModel> Employees { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}
