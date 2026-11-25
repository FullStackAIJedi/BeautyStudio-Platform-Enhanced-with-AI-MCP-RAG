namespace Salon.Application.Admin.Queries.Reports
{
    public class MonthlyFinancialSummary
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; } = default!;
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal Profit { get; set; }
        public int Transactions { get; set; }
    }
}
