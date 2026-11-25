namespace Salon.Application.Employees.Commands.AddCertifications
{
    using System;
    using System.Collections.Generic;

    using MediatR;

    using SharedKernel.Results;

    public class AddEmployeeCertificationsCommand : IRequest<Result>
    {
        public int EmployeeId { get; set; }
        public List<CertDto> Certifications { get; set; } = new();
    }

    public class CertDto
    {
        public string Title { get; set; } = default!;
        public string? Issuer { get; set; }
        public string? CertificateNumber { get; set; }
        public DateTime? IssuedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? DocumentUrl { get; set; }
    }
}
