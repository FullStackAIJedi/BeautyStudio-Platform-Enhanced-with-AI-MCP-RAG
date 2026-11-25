namespace Salon.Application.Portfolio.Commands.Create
{
    using MediatR;

    public class CreatePortfolioItemCommand : IRequest<CreatePortfolioItemOutputModel>
    {
        public int ServiceId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int LocationId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public string? ThumbnailUrl { get; set; }
        public DateTime ServiceDate { get; set; }
        public List<int> TagIds { get; set; } = new();
    }
}
