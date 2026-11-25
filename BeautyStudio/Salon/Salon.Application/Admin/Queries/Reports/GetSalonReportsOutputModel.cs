namespace Salon.Application.Admin.Queries.Reports
{ 
    public class GetSalonReportsOutputModel
    { 
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
         
        // Appointments
        public int TotalAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int PendingAppointments { get; set; }

        public double CompletionRatePercent { get; set; }
        public double CancellationRatePercent { get; set; }

        // Clients
        public int TotalClients { get; set; }
        public int NewClients { get; set; }
        public int ReturningClients { get; set; }
        public double RetentionRatePercent { get; set; }

        // Employees
        public int TotalEmployees { get; set; }
        public int ActiveEmployees { get; set; }

        public List<EmployeePerformanceSummary> TopPerformers { get; set; } = new();

        // Services
        public int TotalServices { get; set; }

        public List<ServicePopularitySummary> TopServices { get; set; } = new();

        // Portfolio
        public int TotalPortfolioItems { get; set; }
        public int TotalVotes { get; set; }
        public int PositiveVotes { get; set; }
        public int NegativeVotes { get; set; }

        // Points
        public int TotalPointsEarned { get; set; }
        public int TotalPointsRedeemed { get; set; }

        // Revenue
        public decimal TotalRevenue { get; set; }
        public decimal TotalServiceRevenue { get; set; }
        public decimal TotalProductRevenue { get; set; }
        public decimal AverageTicket { get; set; }
    } 
}
