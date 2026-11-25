namespace Salon.Application.Admin
{
    using Salon.Application.Admin.Queries.Reports;

    public interface IReportsRepository
    {
        Task<GetSalonReportsOutputModel> GetSalonReports(
            DateTime? fromDate,
            DateTime? toDate,
            CancellationToken cancellationToken = default);

        Task<GetFinancialReportsOutputModel> GetFinancialReports(
            DateTime? fromDate,
            DateTime? toDate,
            CancellationToken cancellationToken = default);
    }
}
