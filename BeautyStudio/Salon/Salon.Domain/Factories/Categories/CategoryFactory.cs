namespace Salon.Domain.Factories.Categories
{
    using Salon.Domain.Models.Categories;

    public class CategoryFactory : ICategoryFactory
    {
        private string name = default!;
        private string description = default!;
        private bool isActive = true;

        public ICategoryFactory WithName(string name) { this.name = name; return this; }
        public ICategoryFactory WithDescription(string description) { this.description = description; return this; }
        public ICategoryFactory WithStatus(bool isActive) { this.isActive = isActive; return this; }

        public Category Build() => new Category(this.name, this.description, this.isActive);
    }
}
