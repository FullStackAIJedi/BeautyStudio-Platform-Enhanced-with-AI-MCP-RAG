namespace Salon.Application.Portfolio.Commands.Create
{
    using MediatR; 

    using Salon.Domain.Factories.Portfolio;
    using SharedKernel.Security;

    public class CreatePortfolioItemCommandHandler : IRequestHandler<CreatePortfolioItemCommand, CreatePortfolioItemOutputModel>
    {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IPortfolioItemFactory portfolioFactory;
        private readonly ICurrentUser currentUser;

        public CreatePortfolioItemCommandHandler(
            IPortfolioRepository portfolioRepository,
            IPortfolioItemFactory portfolioFactory,
            ICurrentUser currentUser)
        {
            this.portfolioRepository = portfolioRepository;
            this.portfolioFactory = portfolioFactory;
            this.currentUser = currentUser;
        }

        public async Task<CreatePortfolioItemOutputModel> Handle(
            CreatePortfolioItemCommand request,
            CancellationToken cancellationToken)
        {
            var item = this.portfolioFactory
                .WithEmployee(this.currentUser.UserId)
                .WithService(request.ServiceId)
                .WithTitle(request.Title)
                .WithDescription(request.Description)
                .WithLocation(request.LocationId)
                .WithImageUrl(request.ImageUrl)
                .WithThumbnailUrl(request.ThumbnailUrl)
                .WithServiceDate(request.ServiceDate)
                .WithTags(request.TagIds)
                .Build();

            await this.portfolioRepository.Save(item, cancellationToken);

            return new CreatePortfolioItemOutputModel(item.Id);
        }
    }
}
