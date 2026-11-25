namespace Salon.Application.Categories.Commands.Create
{
    using MediatR;

    public class CreateCategoryCommand : IRequest<CreateCategoryOutputModel>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}
