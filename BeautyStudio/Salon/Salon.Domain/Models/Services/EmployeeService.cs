namespace Salon.Domain.Models.Services
{
    using SharedKernel.Models;

    public class EmployeeService : Entity<int>
    {
        public EmployeeService(int employeeId, int serviceId)
        {
            this.EmployeeId = employeeId;
            this.ServiceId = serviceId;
        }

        private EmployeeService() { }

        public int EmployeeId { get; set; }
        public int ServiceId { get; private set; }
    }
}
