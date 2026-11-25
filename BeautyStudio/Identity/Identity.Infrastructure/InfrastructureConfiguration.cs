namespace Identity.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Identity.Application.Common;
    using Identity.Application.Users;

    using Identity.Domain.Factories;

    using Identity.Infrastructure.InitialData;
    using Identity.Infrastructure.Persistence;
    using Identity.Infrastructure.Persistence.Repositories;
    using Identity.Infrastructure.Services;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IIdentityDbContext>(sp => sp.GetRequiredService<IdentityDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserFactory, UserFactory>(); 
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenGenerator>(sp =>
                new JwtTokenGenerator(
                    configuration["Jwt:Secret"]!,
                    configuration["Jwt:Issuer"]!,
                    configuration["Jwt:Audience"]!));

            services.AddScoped<IdentityService>();
            services.AddScoped<IIdentity>(sp => sp.GetRequiredService<IdentityService>()); 
            services.AddScoped<DatabaseInitializer>();

            return services;
        }
    }
}
