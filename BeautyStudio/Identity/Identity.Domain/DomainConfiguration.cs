namespace Identity.Domain
{  
    using Identity.Domain.Factories;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services.AddFactories();

        private static IServiceCollection AddFactories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IUserFactory)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
