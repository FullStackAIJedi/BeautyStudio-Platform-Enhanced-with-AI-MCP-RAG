namespace Salon.Domain
{
    using Microsoft.Extensions.DependencyInjection; 
    using SharedKernel.Models;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddFactories();

        private static IServiceCollection AddFactories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
