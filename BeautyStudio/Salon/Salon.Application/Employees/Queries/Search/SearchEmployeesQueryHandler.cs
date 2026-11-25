namespace Salon.Application.Employees.Queries.Search
{
    using MediatR;
    using Salon.Application.Employees.Queries.Common;
    using Salon.Domain.Specifications.Employees;

    public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, SearchEmployeesOutputModel>
    {
        private const int EmployeesPerPage = 10;

        private readonly IEmployeeRepository employeeRepository;

        public SearchEmployeesQueryHandler(IEmployeeRepository employeeRepository)
            => this.employeeRepository = employeeRepository;

        public async Task<SearchEmployeesOutputModel> Handle(
            SearchEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var specification = new EmployeeByRoleSpecification(request.RoleId)
                .And(new EmployeeByNameSpecification(request.Search));

            var skip = (request.Page - 1) * EmployeesPerPage;

            var listings = await this.employeeRepository.GetListings<EmployeeOutputModel>(
                specification, skip, EmployeesPerPage, cancellationToken);

            var total = await this.employeeRepository.Total(specification, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)total / EmployeesPerPage);

            return new SearchEmployeesOutputModel(listings, request.Page, totalPages);
        }
    }
}
