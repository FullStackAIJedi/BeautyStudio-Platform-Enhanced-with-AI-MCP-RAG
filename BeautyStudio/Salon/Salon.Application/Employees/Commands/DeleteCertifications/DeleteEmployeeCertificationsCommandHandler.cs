namespace Salon.Application.Employees.Commands.DeleteCertifications
{
    using MediatR;
    using SharedKernel.Results;

    public class DeleteEmployeeCertificationsCommandHandler : IRequestHandler<DeleteEmployeeCertificationsCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        public DeleteEmployeeCertificationsCommandHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(DeleteEmployeeCertificationsCommand request, CancellationToken cancellationToken)
        {
            await this.employeeRepository.DeleteCertifications(request.EmployeeId, request.CertificationIds, cancellationToken);
            return Result.Success;
        }
    }
}
