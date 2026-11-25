namespace Salon.Domain.Factories.Portfolio
{  
    using Salon.Domain.Models.Portfolio;
    using SharedKernel.Models;

    public interface IPortfolioItemFactory : IFactory<PortfolioItem>
    {
        IPortfolioItemFactory WithEmployee(int employeeId);
        IPortfolioItemFactory WithService(int? serviceId);
        IPortfolioItemFactory WithTitle(string title);
        IPortfolioItemFactory WithDescription(string description);
        IPortfolioItemFactory WithLocation(int locationId);
        IPortfolioItemFactory WithImageUrl(string imageUrl);
        IPortfolioItemFactory WithThumbnailUrl(string? thumbnailUrl);
        IPortfolioItemFactory WithServiceDate(DateTime serviceDate);
        IPortfolioItemFactory WithTags(List<int> tagIds);
    }
}
