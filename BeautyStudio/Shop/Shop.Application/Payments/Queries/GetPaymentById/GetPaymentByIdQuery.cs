namespace Shop.Application.Payments.Queries.GetPaymentById
{ 
    using MediatR;

    public class GetPaymentByIdQuery : IRequest<PaymentDetailsOutputModel>
    {
        public int Id { get; set; }
    }
}
