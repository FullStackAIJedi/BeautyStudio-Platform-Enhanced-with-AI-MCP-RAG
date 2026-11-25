namespace Shop.Infrastructure.Messaging
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MassTransit;

    using Shop.Application.EventHandlers;

    public static class MassTransitConfiguration
    {
        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                // Регистрираме consumer-а
                x.AddConsumer<SalonAppointmentBookedEventHandler>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMq:Host"] ?? "rabbitmq", h =>
                    {
                        h.Username(configuration["RabbitMq:Username"] ?? "guest");
                        h.Password(configuration["RabbitMq:Password"] ?? "guest");
                    });

                    // Конфигурираме endpoint за SalonAppointmentBookedEvent
                    cfg.ReceiveEndpoint("shop-salon-appointment-booked", e =>
                    {
                        e.ConfigureConsumer<SalonAppointmentBookedEventHandler>(context);
                    });
                });
            });

            return services;
        }
    }
}
