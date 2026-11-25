namespace Salon.Domain.Factories.Categories
{
    using Salon.Domain.Models.Categories;
    using SharedKernel.Models;

    public interface ICategoryFactory : IFactory<Category>
    {
        ICategoryFactory WithName(string name);
        ICategoryFactory WithDescription(string description);
        ICategoryFactory WithStatus(bool isActive);
    }
}
