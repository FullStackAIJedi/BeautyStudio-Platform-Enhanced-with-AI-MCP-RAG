namespace Salon.Application.Admin.Queries.Reports
{
    public class EmployeePerformanceSummary
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = default!;
        public int AppointmentsCompleted { get; set; }
        public decimal RevenueGenerated { get; set; }
        public int Points { get; set; }
        public double AverageRating { get; set; }
    }
}
