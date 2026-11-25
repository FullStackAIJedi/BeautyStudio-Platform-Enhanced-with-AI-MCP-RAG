namespace Salon.Application.Admin.Queries.Reports
{
    using MediatR;

    public class GetSalonReportsQueryHandler : IRequestHandler<GetSalonReportsQuery, GetSalonReportsOutputModel>
    {
        private readonly IReportsRepository reportsRepository;

        public GetSalonReportsQueryHandler(IReportsRepository reportsRepository)
            => this.reportsRepository = reportsRepository;

        public async Task<GetSalonReportsOutputModel> Handle(
            GetSalonReportsQuery request,
            CancellationToken cancellationToken)
            => await this.reportsRepository.GetSalonReports(request.FromDate, request.ToDate, cancellationToken);
    }
}
