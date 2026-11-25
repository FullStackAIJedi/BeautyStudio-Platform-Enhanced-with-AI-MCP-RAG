namespace Salon.Application.Services.Commands.Commands.Deactivate
{
    using MediatR;
    using SharedKernel.Results;

    public class DeactivateServiceCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
