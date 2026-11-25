namespace Shop.Application.Payments.Commands.SimulatePayment
{ 
    using MediatR;
    using SharedKernel.Results;

    public class SimulatePaymentCommand : IRequest<Result<SimulatePaymentOutputModel>>
    {
        public int UserId { get; set; }
        public string IdempotencyKey { get; set; } = default!;
    }

    public class SimulatePaymentOutputModel
    {
        public int PaymentId { get; set; }
        public int CartId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = default!;
        public DateTime CompletedAt { get; set; }
    }
}
