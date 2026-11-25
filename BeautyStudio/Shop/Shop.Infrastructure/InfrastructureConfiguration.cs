namespace Shop.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Shop.Application.Carts;
    using Shop.Application.Payments;
    using Shop.Application.Products;

    using Shop.Domain.Factories.Carts;
    using Shop.Domain.Factories.Products;

    using Shop.Infrastructure.Persistence;
    using Shop.Infrastructure.Persistence.Repositories;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        { 
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));
             
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ICartFactory, CartFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();

            return services;
        }
    }
}
