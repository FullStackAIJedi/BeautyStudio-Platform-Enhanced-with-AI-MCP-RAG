namespace Salon.Domain.Models.Categories
{
    using Salon.Domain.Exceptions;
    using SharedKernel.Models;

    public class Category : Entity<int>, IAggregateRoot
    {
        public Category(string name, string description, bool isActive = true)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
            this.IsActive = isActive;
        }

        private Category()
        {
            this.Name = default!;
            this.Description = default!;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }

        public Category Update(string name, string description)
        {
            this.Validate(name, description);
            this.Name = name;
            this.Description = description;
            return this;
        }

        public Category SetStatus(bool isActive)
        {
            this.IsActive = isActive;
            return this;
        }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidCategoryException>(
                name,
                ModelConstants.Category.MinNameLength,
                ModelConstants.Category.MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidCategoryException>(
                description,
                ModelConstants.Category.MinDescriptionLength,
                ModelConstants.Category.MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
