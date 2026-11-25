namespace Shop.Application.Products.Commands.Delete
{
    using MediatR;
    using SharedKernel.Results;

    public class DeleteProductCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
