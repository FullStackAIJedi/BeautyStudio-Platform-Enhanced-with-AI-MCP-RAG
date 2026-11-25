namespace Salon.Application.Employees.Commands.AssignEmployeeToService
{
    using MediatR;
    using SharedKernel.Results;

    public class AssignEmployeeToServiceCommandHandler : IRequestHandler<AssignEmployeeToServiceCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        public AssignEmployeeToServiceCommandHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(AssignEmployeeToServiceCommand request, CancellationToken cancellationToken)
        {
            await this.employeeRepository.AssignEmployeeToService(request.EmployeeId, request.ServiceId, cancellationToken);
            return Result.Success;
        }
    }
}
