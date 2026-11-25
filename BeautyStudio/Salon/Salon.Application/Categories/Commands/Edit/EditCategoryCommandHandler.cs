namespace Salon.Application.Categories.Commands.Edit
{
    using MediatR;
    using SharedKernel.Results;

    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Result>
    {
        private readonly ICategoryRepository categoryRepository;

        public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
            => this.categoryRepository = categoryRepository;

        public async Task<Result> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await this.categoryRepository.Find(request.Id, cancellationToken);
            if (category == null) return "Category not found.";

            category
                .Update(request.Name, request.Description)
                .SetStatus(request.IsActive);

            await this.categoryRepository.Save(category, cancellationToken);
            return Result.Success;
        }
    }
}
