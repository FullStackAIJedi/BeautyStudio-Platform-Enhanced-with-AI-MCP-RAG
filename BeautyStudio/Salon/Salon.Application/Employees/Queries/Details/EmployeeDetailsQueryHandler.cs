namespace Salon.Application.Employees.Queries.Details
{
    using MediatR;
    using Salon.Application.Common.Exceptions;

    public class EmployeeDetailsQueryHandler : IRequestHandler<EmployeeDetailsQuery, EmployeeDetailsOutputModel>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDetailsQueryHandler(IEmployeeRepository employeeRepository)
            => this.employeeRepository = employeeRepository;

        public async Task<EmployeeDetailsOutputModel> Handle(
            EmployeeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var details = await this.employeeRepository.GetDetails(request.Id, cancellationToken);
            if (details == null) throw new NotFoundException(nameof(EmployeeDetailsQuery), request.Id);
            return details;
        }
    }
}
