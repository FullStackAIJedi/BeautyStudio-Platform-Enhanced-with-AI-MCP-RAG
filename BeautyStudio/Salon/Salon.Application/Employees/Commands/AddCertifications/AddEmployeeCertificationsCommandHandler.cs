namespace Salon.Application.Employees.Commands.AddCertifications
{
    using MediatR;
    using SharedKernel.Results;

    public class AddEmployeeCertificationsCommandHandler : IRequestHandler<AddEmployeeCertificationsCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        public AddEmployeeCertificationsCommandHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(AddEmployeeCertificationsCommand request, CancellationToken cancellationToken)
        {
            await this.employeeRepository.AddCertifications(request.EmployeeId, request.Certifications, cancellationToken);
            return Result.Success;
        }
    }
}
