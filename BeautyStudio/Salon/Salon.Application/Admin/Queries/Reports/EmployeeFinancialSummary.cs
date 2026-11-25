namespace Salon.Application.Admin.Queries.Reports
{
    public class EmployeeFinancialSummary
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = default!;
        public decimal TotalRevenueGenerated { get; set; }
        public decimal CommissionEarned { get; set; }
        public int AppointmentsCompleted { get; set; }
        public decimal AverageTicket { get; set; }
    }
}
