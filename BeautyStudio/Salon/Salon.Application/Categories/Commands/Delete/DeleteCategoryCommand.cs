namespace Salon.Application.Categories.Commands.Delete
{
    using MediatR;
    using SharedKernel.Results;

    public class DeleteCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
