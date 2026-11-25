namespace Salon.Application.Admin.Queries.Reports
{
    using MediatR;

    public class GetFinancialReportsQueryHandler : IRequestHandler<GetFinancialReportsQuery, GetFinancialReportsOutputModel>
    {
        private readonly IReportsRepository reportsRepository;

        public GetFinancialReportsQueryHandler(IReportsRepository reportsRepository)
            => this.reportsRepository = reportsRepository;

        public async Task<GetFinancialReportsOutputModel> Handle(
            GetFinancialReportsQuery request,
            CancellationToken cancellationToken)
            => await this.reportsRepository.GetFinancialReports(request.FromDate, request.ToDate, cancellationToken);
    }
}
