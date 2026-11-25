namespace Salon.Domain.Factories.Services
{  
    using Salon.Domain.Models.Services;
    using SharedKernel.Models;

    public interface IServiceFactory : IFactory<Service>
    {
        IServiceFactory WithName(string name);
        IServiceFactory WithDescription(string description);
        IServiceFactory WithDuration(int minutes);
        IServiceFactory WithPrice(decimal price);
        IServiceFactory WithCategory(int categoryId);
    }
}
