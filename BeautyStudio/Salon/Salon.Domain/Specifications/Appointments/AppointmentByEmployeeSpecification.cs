namespace Salon.Domain.Specifications.Appointments
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Appointments;
    using SharedKernel.Models;

    public class AppointmentByEmployeeSpecification : Specification<Appointment>
    {
        private readonly int? employeeId;

        public AppointmentByEmployeeSpecification(int? employeeId) => this.employeeId = employeeId;

        protected override bool Include => this.employeeId != null;

        public override Expression<Func<Appointment, bool>> ToExpression()
            => appointment => appointment.EmployeeId == this.employeeId;
    }
}
