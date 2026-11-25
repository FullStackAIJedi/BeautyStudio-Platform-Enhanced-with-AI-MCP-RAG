namespace Salon.Application.Services.Commands.Commands.Activate
{
    using MediatR;
    using SharedKernel.Results;

    public class ActivateServiceCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
