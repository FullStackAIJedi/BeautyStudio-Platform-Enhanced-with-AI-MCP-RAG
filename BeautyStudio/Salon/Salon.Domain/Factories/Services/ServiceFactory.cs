namespace Salon.Domain.Factories.Services
{
    using Salon.Domain.Models.Services;

    public class ServiceFactory : IServiceFactory
    {
        private string name = default!;
        private string description = default!;
        private int durationMinutes;
        private decimal price;
        private int categoryId;

        public IServiceFactory WithName(string name) { this.name = name; return this; }
        public IServiceFactory WithDescription(string description) { this.description = description; return this; }
        public IServiceFactory WithDuration(int minutes) { this.durationMinutes = minutes; return this; }
        public IServiceFactory WithPrice(decimal price) { this.price = price; return this; }
        public IServiceFactory WithCategory(int categoryId) { this.categoryId = categoryId; return this; }

        public Service Build()
            => new Service(this.name, this.description, this.durationMinutes, this.price, this.categoryId);
    }
}
