namespace Shop.Application.Payments.Commands.SimulatePayment
{
    using MediatR;

    using Shop.Application.Carts;
    using Shop.Domain.Models.Payments;
    using SharedKernel.Results;

    public class SimulatePaymentCommandHandler
        : IRequestHandler<SimulatePaymentCommand, Result<SimulatePaymentOutputModel>>
    {
        private readonly ICartRepository cartRepository;
        private readonly IPaymentRepository paymentRepository;

        public SimulatePaymentCommandHandler(
            ICartRepository cartRepository,
            IPaymentRepository paymentRepository)
        {
            this.cartRepository = cartRepository;
            this.paymentRepository = paymentRepository;
        }

        public async Task<Result<SimulatePaymentOutputModel>> Handle(
            SimulatePaymentCommand request,
            CancellationToken cancellationToken)
        {
            // Idempotency 
            var existing = await this.paymentRepository
                .FindByIdempotencyKey(request.IdempotencyKey, cancellationToken);

            if (existing != null)
            {
                return new SimulatePaymentOutputModel
                {
                    PaymentId = existing.Id,
                    CartId = existing.CartId,
                    Amount = existing.Amount,
                    Status = existing.Status == PaymentStatus.Completed ? "Completed" : "Pending",
                    CompletedAt = existing.CompletedAt ?? DateTime.UtcNow
                };
            }

            var cart = await this.cartRepository.FindActiveByUser(request.UserId, cancellationToken);
            if (cart == null || !cart.Items.Any())
                return "Cart is empty or not found.";

            var payment = new Payment(cart.Id, cart.Total, request.IdempotencyKey);
             
            payment.SimulateSuccess();

            cart.Checkout();

            await this.paymentRepository.Save(payment, cancellationToken);
            await this.cartRepository.Save(cart, cancellationToken);

            return new SimulatePaymentOutputModel
            {
                PaymentId = payment.Id,
                CartId = payment.CartId,
                Amount = payment.Amount,
                Status = "Completed",
                CompletedAt = payment.CompletedAt!.Value
            };
        }
    }
}
