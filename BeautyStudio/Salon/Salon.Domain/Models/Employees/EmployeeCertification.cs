namespace Salon.Domain.Models.Employees
{ 
    using SharedKernel.Models;

    public class EmployeeCertification : Entity<int>
    {
        public EmployeeCertification(int employeeId, string title, string? issuer = null)
        {
            this.EmployeeId = employeeId;
            this.Title = title;
            this.Issuer = issuer;
            this.IsVerified = false;
        }

        private EmployeeCertification() { }

        public int EmployeeId { get; set; }
        public string Title { get; private set; } = default!;
        public string? Issuer { get; private set; }
        public string? CertificateNumber { get; private set; }
        public DateTime? IssuedAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public string? DocumentUrl { get; private set; }
        public bool IsVerified { get; private set; }
    }
}
