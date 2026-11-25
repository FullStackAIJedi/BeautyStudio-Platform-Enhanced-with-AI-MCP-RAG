namespace Salon.Application.Admin.Queries.Reports
{
    using MediatR;

    public class GetFinancialReportsQuery : IRequest<GetFinancialReportsOutputModel>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
