namespace Identity.Application
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    
    using MediatR;
    using FluentValidation;

    using Identity.Application.Common.Behaviours;
    using Identity.Application.Common.Mapping; 
    using SharedKernel.Models;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddEventHandlers();

        private static IServiceCollection AddEventHandlers(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
