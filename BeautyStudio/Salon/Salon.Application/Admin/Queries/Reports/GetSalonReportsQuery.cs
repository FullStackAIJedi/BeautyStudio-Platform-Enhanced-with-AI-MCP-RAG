namespace Salon.Application.Admin.Queries.Reports
{
    using MediatR;

    public class GetSalonReportsQuery : IRequest<GetSalonReportsOutputModel>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
