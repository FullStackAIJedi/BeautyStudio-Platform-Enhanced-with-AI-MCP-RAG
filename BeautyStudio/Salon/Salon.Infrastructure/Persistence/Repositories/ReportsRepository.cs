namespace Salon.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Salon.Application.Admin;
    using Salon.Application.Admin.Queries.Reports;

    internal class ReportsRepository : IReportsRepository
    {
        private readonly SalonDbContext db;

        public ReportsRepository(SalonDbContext db) => this.db = db;

        public async Task<GetSalonReportsOutputModel> GetSalonReports(
            DateTime? fromDate,
            DateTime? toDate,
            CancellationToken cancellationToken = default)
        {
            var appointmentsQuery = this.db.Appointments.AsQueryable();
            var clientsQuery = this.db.Clients.AsQueryable();
            var employeesQuery = this.db.Employees.AsQueryable();
            var portfolioQuery = this.db.PortfolioItems.AsQueryable();

            if (fromDate.HasValue)
                appointmentsQuery = appointmentsQuery.Where(a => a.StartAt >= fromDate.Value);

            if (toDate.HasValue)
                appointmentsQuery = appointmentsQuery.Where(a => a.StartAt <= toDate.Value);

            var totalAppointments = await appointmentsQuery.CountAsync(cancellationToken);
            var completedAppointments = await appointmentsQuery
                .CountAsync(a => a.Status == 4, cancellationToken); // Completed
            var cancelledAppointments = await appointmentsQuery
                .CountAsync(a => a.Status == 5, cancellationToken); // Cancelled

            var totalClients = await clientsQuery.CountAsync(cancellationToken);

            return new GetSalonReportsOutputModel
            {
                FromDate = fromDate,
                ToDate = toDate,
                TotalAppointments = totalAppointments,
                CompletedAppointments = completedAppointments,
                CancelledAppointments = cancelledAppointments,
                PendingAppointments = totalAppointments - completedAppointments - cancelledAppointments,
                CompletionRatePercent = totalAppointments > 0
                    ? (double)completedAppointments / totalAppointments * 100
                    : 0,
                CancellationRatePercent = totalAppointments > 0
                    ? (double)cancelledAppointments / totalAppointments * 100
                    : 0,
                TotalClients = totalClients,
                TotalEmployees = await employeesQuery.CountAsync(cancellationToken),
                ActiveEmployees = await employeesQuery.CountAsync(e => e.EmploymentStatus == 1, cancellationToken),
                TotalPortfolioItems = await portfolioQuery.CountAsync(cancellationToken),
                TotalVotes = await portfolioQuery.SumAsync(p => p.PositiveVotes + p.NegativeVotes, cancellationToken),
                PositiveVotes = await portfolioQuery.SumAsync(p => p.PositiveVotes, cancellationToken),
                NegativeVotes = await portfolioQuery.SumAsync(p => p.NegativeVotes, cancellationToken)
            };
        }

        public async Task<GetFinancialReportsOutputModel> GetFinancialReports(
            DateTime? fromDate,
            DateTime? toDate,
            CancellationToken cancellationToken = default)
        {
            var appointmentsQuery = this.db.Appointments.AsQueryable();

            if (fromDate.HasValue)
                appointmentsQuery = appointmentsQuery.Where(a => a.StartAt >= fromDate.Value);

            if (toDate.HasValue)
                appointmentsQuery = appointmentsQuery.Where(a => a.StartAt <= toDate.Value);

            // Services/prices should also be included here 
            var completedAppointments = await appointmentsQuery
                .CountAsync(a => a.Status == 4, cancellationToken);

            return new GetFinancialReportsOutputModel
            {
                FromDate = fromDate,
                ToDate = toDate,
                TotalTransactions = completedAppointments,
                TotalRevenue = 0, // calculated from services.Price
                NetRevenue = 0,
                TotalExpenses = 0,
                NetProfit = 0,
                ProfitMarginPercent = 0
            };
        }
    }
}
