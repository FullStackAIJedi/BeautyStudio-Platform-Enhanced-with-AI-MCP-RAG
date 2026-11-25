namespace Shop.Application.Payments.Queries.GetMyPayments
{
    public class GetMyPaymentsOutputModel
    {
        public GetMyPaymentsOutputModel(
            List<PaymentListItemOutputModel> payments,
            int page,
            int totalPages)
        {
            this.Payments = payments;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public List<PaymentListItemOutputModel> Payments { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }

    public class PaymentListItemOutputModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
