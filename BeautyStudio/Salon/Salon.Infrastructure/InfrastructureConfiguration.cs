namespace Salon.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Salon.Application.Admin;
    using Salon.Application.Appointments;
    using Salon.Application.Categories;
    using Salon.Application.Clients;
    using Salon.Application.Employees;
    using Salon.Application.Locations;
    using Salon.Application.Portfolio;
    using Salon.Application.Services;
    using Salon.Domain.Factories.Appointments;
    using Salon.Domain.Factories.Categories;
    using Salon.Domain.Factories.Locations;
    using Salon.Domain.Factories.Portfolio;
    using Salon.Domain.Factories.Services;
    using Salon.Infrastructure.Persistence;
    using Salon.Infrastructure.Persistence.Common;
    using Salon.Infrastructure.Persistence.InitialData;
    using Salon.Infrastructure.Persistence.Repositories;
      

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        { 
            services.AddDbContext<SalonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<ISalonDbContext>(sp => sp.GetRequiredService<SalonDbContext>());
             
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IClientRepository, ClientRepository>(); 
            services.AddScoped<IReportsRepository, ReportsRepository>();
            services.AddScoped<IRoleRulesRepository, RoleRulesRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IPortfolioItemFactory, PortfolioItemFactory>();
            services.AddScoped<ILocationFactory, LocationFactory>();
            services.AddScoped<IAppointmentFactory, AppointmentFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();

            services.AddScoped<IInitialData, RoleRulesInitialData>();
            services.AddScoped<IInitializer, DatabaseInitializer>();

            return services;
        }
    }
}
