namespace Salon.Domain.Specifications.Appointments
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Appointments;
    using SharedKernel.Models;

    public class AppointmentByUserSpecification : Specification<Appointment>
    {
        private readonly int userId;

        public AppointmentByUserSpecification(int userId) => this.userId = userId;

        public override Expression<Func<Appointment, bool>> ToExpression()
            => appointment => appointment.ClientId == this.userId || appointment.EmployeeId == this.userId;
    }
}
