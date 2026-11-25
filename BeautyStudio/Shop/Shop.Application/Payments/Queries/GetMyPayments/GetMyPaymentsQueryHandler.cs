namespace Shop.Application.Payments.Queries.GetMyPayments
{
    using MediatR;
    using SharedKernel.Security;

    public class GetMyPaymentsQueryHandler
        : IRequestHandler<GetMyPaymentsQuery, GetMyPaymentsOutputModel>
    {
        private const int PaymentsPerPage = 20; 
        private readonly IPaymentRepository paymentRepository;
        private readonly ICurrentUser currentUser;

        public GetMyPaymentsQueryHandler(
            IPaymentRepository paymentRepository,
            ICurrentUser currentUser)
        {
            this.paymentRepository = paymentRepository;
            this.currentUser = currentUser;
        }

        public async Task<GetMyPaymentsOutputModel> Handle(
            GetMyPaymentsQuery request,
            CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * PaymentsPerPage;

            var payments = await this.paymentRepository
                .GetByUser(this.currentUser.UserId, skip, PaymentsPerPage, cancellationToken);

            var total = await this.paymentRepository
                .TotalByUser(this.currentUser.UserId, cancellationToken);

            var totalPages = (int)Math.Ceiling((double)total / PaymentsPerPage);

            return new GetMyPaymentsOutputModel(
                payments.Select(p => new PaymentListItemOutputModel
                {
                    Id = p.Id,
                    CartId = p.CartId,
                    Amount = p.Amount,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    CompletedAt = p.CompletedAt
                }).ToList(),
                request.Page,
                totalPages);
        }
    }
}
