namespace Salon.Application.Admin.Queries.Reports
{
    public class GetFinancialReportsOutputModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        // Revenues
        public decimal TotalRevenue { get; set; }
        public decimal TotalServiceRevenue { get; set; }
        public decimal TotalProductRevenue { get; set; }
        public decimal TotalDiscounts { get; set; }
        public decimal TotalRefunds { get; set; }
        public decimal NetRevenue { get; set; }

        // Expenses
        public decimal TotalExpenses { get; set; }
        public decimal TotalPayroll { get; set; }
        public decimal TotalCommissions { get; set; }
        public decimal TotalInventoryCosts { get; set; }

        // Profit
        public decimal GrossProfit { get; set; }
        public decimal NetProfit { get; set; }
        public decimal ProfitMarginPercent { get; set; }

        // Transactions
        public int TotalTransactions { get; set; }
        public int CashTransactions { get; set; }
        public int CardTransactions { get; set; }
        public int BankTransferTransactions { get; set; }
        public int OnlineTransactions { get; set; }

        // By month (for the chart)
        public List<MonthlyFinancialSummary> MonthlyBreakdown { get; set; } = new();

         // By employees (commissions)
        public List<EmployeeFinancialSummary> EmployeeCommissions { get; set; } = new();
    }  
}
