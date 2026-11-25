namespace Salon.Application.Admin.Queries.Reports
{
    public class ServicePopularitySummary
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = default!;
        public int BookingCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public double PopularityPercent { get; set; }
    }
}
