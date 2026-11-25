namespace Salon.Domain.Specifications.Appointments
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Appointments;
    using SharedKernel.Models;

    public class AppointmentByDateRangeSpecification : Specification<Appointment>
    {
        private readonly DateTime? fromDate;
        private readonly DateTime? toDate;

        public AppointmentByDateRangeSpecification(DateTime? fromDate, DateTime? toDate)
        {
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        protected override bool Include => this.fromDate != null || this.toDate != null;

        public override Expression<Func<Appointment, bool>> ToExpression()
            => appointment =>
                (this.fromDate == null || appointment.StartAt >= this.fromDate) &&
                (this.toDate == null || appointment.StartAt <= this.toDate);
    }
}
