namespace Shop.Application.EventHandlers
{
    using MassTransit;
    using MediatR;

    using Shop.Application.Carts.Commands.AddSalonService;
    using Shop.Domain.Events;

    public class SalonAppointmentBookedEventHandler
        : IConsumer<SalonAppointmentBookedEvent>
    {
        private readonly IMediator mediator;

        public SalonAppointmentBookedEventHandler(IMediator mediator)
            => this.mediator = mediator;

        public async Task Consume(ConsumeContext<SalonAppointmentBookedEvent> context)
        {
            var evt = context.Message;

            await this.mediator.Send(new AddSalonServiceToCartCommand
            {
                UserId = evt.UserId,
                AppointmentId = evt.AppointmentId,
                ServiceName = evt.ServiceName,
                Price = evt.ServicePrice
            }, context.CancellationToken);
        }
    }
}
