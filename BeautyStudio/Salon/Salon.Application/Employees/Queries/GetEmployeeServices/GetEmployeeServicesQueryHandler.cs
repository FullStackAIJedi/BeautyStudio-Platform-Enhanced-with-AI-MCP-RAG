namespace Salon.Application.Employees.Queries.GetEmployeeServices
{
    using MediatR;
    using Salon.Application.Services.Queries.Common;

    public class GetEmployeeServicesQueryHandler : IRequestHandler<GetEmployeeServicesQuery, IEnumerable<ServiceOutputModel>>
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeServicesQueryHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<IEnumerable<ServiceOutputModel>> Handle(GetEmployeeServicesQuery request, CancellationToken cancellationToken)
            => await this.employeeRepository.GetEmployeeServices(request.EmployeeId, cancellationToken);
    }
}
