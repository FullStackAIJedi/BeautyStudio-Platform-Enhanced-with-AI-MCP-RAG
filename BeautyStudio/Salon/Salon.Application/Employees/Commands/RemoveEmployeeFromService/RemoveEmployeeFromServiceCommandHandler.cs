namespace Salon.Application.Employees.Commands.RemoveEmployeeFromService
{
    using MediatR;
    using SharedKernel.Results;

    public class RemoveEmployeeFromServiceCommandHandler : IRequestHandler<RemoveEmployeeFromServiceCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        public RemoveEmployeeFromServiceCommandHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(RemoveEmployeeFromServiceCommand request, CancellationToken cancellationToken)
        {
            await this.employeeRepository.RemoveEmployeeFromService(request.EmployeeId, request.ServiceId, cancellationToken);
            return Result.Success;
        }
    }
}
