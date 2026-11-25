namespace Shop.Application.Payments.Queries.GetMyPayments
{
    using MediatR;

    public class GetMyPaymentsQuery : IRequest<GetMyPaymentsOutputModel>
    {
        public int Page { get; set; } = 1;
    }
}
