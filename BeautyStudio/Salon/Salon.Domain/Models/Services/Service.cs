namespace Salon.Domain.Models.Services
{ 
    using Salon.Domain.Exceptions;
    using SharedKernel.Models;

    public class Service : Entity<int>, IAggregateRoot
    {
        internal Service(
            string name,
            string description,
            int durationMinutes,
            decimal price,
            int categoryId)
        {
            this.Validate(name, description, durationMinutes, price);

            this.Name = name;
            this.Description = description;
            this.DurationMinutes = durationMinutes;
            this.Price = price;
            this.CategoryId = categoryId;
            this.IsActive = true;
        }

        private Service()
        {
            this.Name = default!;
            this.Description = default!;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int DurationMinutes { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
        public bool IsActive { get; private set; }

        public Service UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;
            return this;
        }

        public Service UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;
            return this;
        }

        public Service UpdateDuration(int duration)
        {
            Guard.AgainstOutOfRange<InvalidServiceException>(
                duration,
                ModelConstants.Service.MinDuration,
                ModelConstants.Service.MaxDuration,
                nameof(this.DurationMinutes));
            this.DurationMinutes = duration;
            return this;
        }

        public Service UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;
            return this;
        }

        public Service UpdateCategory(int categoryId)
        {
            this.CategoryId = categoryId;
            return this;
        }

        public Service Activate()
        {
            this.IsActive = true;
            return this;
        }

        public Service Deactivate()
        {
            this.IsActive = false;
            return this;
        }

        private void Validate(string name, string description, int duration, decimal price)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
            Guard.AgainstOutOfRange<InvalidServiceException>(
                duration,
                ModelConstants.Service.MinDuration,
                ModelConstants.Service.MaxDuration,
                nameof(this.DurationMinutes));
            this.ValidatePrice(price);
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidServiceException>(
                name,
                ModelConstants.Service.MinNameLength,
                ModelConstants.Service.MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidServiceException>(
                description,
                ModelConstants.Service.MinDescriptionLength,
                ModelConstants.Service.MaxDescriptionLength,
                nameof(this.Description));

        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidServiceException>(
                price,
                0.01m,
                decimal.MaxValue,
                nameof(this.Price));
    }
}
