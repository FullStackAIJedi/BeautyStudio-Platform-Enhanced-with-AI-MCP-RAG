namespace Salon.Application.Clients.Commands.UpdateNotes
{
    using MediatR;
    using SharedKernel.Results;

    public class UpdateClientNotesCommand : IRequest<Result>
    {
        public int ClientId { get; set; }
        public string Notes { get; set; } = default!;
    }
}
