namespace Shop.Application.Payments.Queries.GetPaymentById
{ 
    public class PaymentDetailsOutputModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public string IdempotencyKey { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
