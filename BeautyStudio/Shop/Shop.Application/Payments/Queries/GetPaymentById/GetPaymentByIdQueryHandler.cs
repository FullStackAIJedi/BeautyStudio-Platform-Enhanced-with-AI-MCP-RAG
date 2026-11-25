namespace Shop.Application.Payments.Queries.GetPaymentById
{
    using MediatR;
    using SharedKernel.Exceptions; 

    public class GetPaymentByIdQueryHandler
        : IRequestHandler<GetPaymentByIdQuery, PaymentDetailsOutputModel>
    {
        private readonly IPaymentRepository paymentRepository;

        public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository)
            => this.paymentRepository = paymentRepository;

        public async Task<PaymentDetailsOutputModel> Handle(
            GetPaymentByIdQuery request,
            CancellationToken cancellationToken)
        {
            var payment = await this.paymentRepository.Find(request.Id, cancellationToken);
            if (payment == null) throw new NotFoundException(nameof(GetPaymentByIdQuery), request.Id);

            return new PaymentDetailsOutputModel
            {
                Id = payment.Id,
                CartId = payment.CartId,
                Amount = payment.Amount,
                Status = payment.Status,
                IdempotencyKey = payment.IdempotencyKey,
                CreatedAt = payment.CreatedAt,
                CompletedAt = payment.CompletedAt
            };
        }
    }
}
