namespace Salon.Application.Employees.Commands.DeleteCertifications
{
    using MediatR;
 
    using System.Collections.Generic;
    using SharedKernel.Results;

    public class DeleteEmployeeCertificationsCommand : IRequest<Result>
    {
        public int EmployeeId { get; set; }
        public List<int> CertificationIds { get; set; } = new();
    }
}
