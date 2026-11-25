namespace Salon.Domain.Factories.Portfolio
{
    using Salon.Domain.Models.Portfolio;

    public class PortfolioItemFactory : IPortfolioItemFactory
    {
        private int employeeId;
        private int? serviceId;
        private string title = default!;
        private string description = default!;
        private int locationId;
        private string imageUrl = default!;
        private string? thumbnailUrl;
        private DateTime serviceDate;
        private List<int> tagIds = new();

        public IPortfolioItemFactory WithEmployee(int employeeId) { this.employeeId = employeeId; return this; }
        public IPortfolioItemFactory WithService(int? serviceId) { this.serviceId = serviceId; return this; }
        public IPortfolioItemFactory WithTitle(string title) { this.title = title; return this; }
        public IPortfolioItemFactory WithDescription(string description) { this.description = description; return this; }
        public IPortfolioItemFactory WithLocation(int locationId) { this.locationId = locationId; return this; }
        public IPortfolioItemFactory WithImageUrl(string imageUrl) { this.imageUrl = imageUrl; return this; }
        public IPortfolioItemFactory WithThumbnailUrl(string? thumbnailUrl) { this.thumbnailUrl = thumbnailUrl; return this; }
        public IPortfolioItemFactory WithServiceDate(DateTime serviceDate) { this.serviceDate = serviceDate; return this; }
        public IPortfolioItemFactory WithTags(List<int> tagIds) { this.tagIds = tagIds; return this; }

        public PortfolioItem Build()
        {
            var item = new PortfolioItem(
                this.employeeId,
                this.serviceId,
                this.title,
                this.description,
                this.locationId,
                this.imageUrl,
                this.thumbnailUrl,
                this.serviceDate);

            foreach (var tagId in this.tagIds)
                item.AddTag(tagId);

            return item;
        }
    }
}
