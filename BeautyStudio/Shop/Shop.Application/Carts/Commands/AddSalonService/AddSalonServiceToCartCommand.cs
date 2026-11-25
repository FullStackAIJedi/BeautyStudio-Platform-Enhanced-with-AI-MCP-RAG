namespace Shop.Application.Carts.Commands.AddSalonService
{
    using MediatR;
    using SharedKernel.Results; 

    public class AddSalonServiceToCartCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string ServiceName { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
