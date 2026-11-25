namespace Salon.Application.Categories.Commands.Delete
{ 
    using MediatR; 

    using Salon.Application.Services;
    using SharedKernel.Results;

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IServiceRepository serviceRepository;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IServiceRepository serviceRepository)
        {
            this.categoryRepository = categoryRepository;
            this.serviceRepository = serviceRepository;
        }

        public async Task<Result> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await this.categoryRepository.Find(request.Id, cancellationToken);

            if (category == null)
                return "Category not found.";
             
            var servicesInCategory = await this.serviceRepository
                .Total(new Domain.Specifications.Services.ServiceByCategorySpecification(request.Id), cancellationToken);

            if (servicesInCategory > 0)
            {
                return "Cannot delete category because it contains active services. Deactivate it instead.";
            }

            var deleted = await this.categoryRepository.Delete(request.Id, cancellationToken);

            return deleted ? Result.Success : "Failed to delete category.";
        }
    }
}
