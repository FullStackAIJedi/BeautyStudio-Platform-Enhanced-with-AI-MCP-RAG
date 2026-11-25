namespace Salon.Application.Categories.Commands.Create
{ 
    using MediatR;
    using Salon.Domain.Factories.Categories;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryOutputModel>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryFactory categoryFactory;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            ICategoryFactory categoryFactory)
        {
            this.categoryRepository = categoryRepository;
            this.categoryFactory = categoryFactory;
        }

        public async Task<CreateCategoryOutputModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = this.categoryFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithStatus(request.IsActive)
                .Build();

            await this.categoryRepository.Save(category, cancellationToken);

            return new CreateCategoryOutputModel(category.Id);
        }
    }
}
