namespace Salon.Application.Clients.Commands.UpdateNotes
{
    using MediatR;
    using SharedKernel.Results;

    public class UpdateClientNotesCommandHandler : IRequestHandler<UpdateClientNotesCommand, Result>
    {
        private readonly IClientRepository clientRepository;

        public UpdateClientNotesCommandHandler(IClientRepository clientRepository)
            => this.clientRepository = clientRepository;

        public async Task<Result> Handle(
            UpdateClientNotesCommand request,
            CancellationToken cancellationToken)
        {
            var client = await this.clientRepository.Find(request.ClientId, cancellationToken);
            if (client == null) return "Client not found.";

            var normalizedNotes = string.IsNullOrWhiteSpace(request.Notes)
                ? null : request.Notes.Trim();

            client.UpdateNotes(normalizedNotes);

            await this.clientRepository.Save(client, cancellationToken);
            return Result.Success;
        }
    }
}