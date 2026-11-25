namespace Salon.Application.Categories.Commands.Edit
{
    using MediatR;
    using SharedKernel.Results;

    public class EditCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
