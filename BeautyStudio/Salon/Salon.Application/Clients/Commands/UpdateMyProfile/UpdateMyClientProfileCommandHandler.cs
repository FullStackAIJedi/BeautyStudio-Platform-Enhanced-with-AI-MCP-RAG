namespace Salon.Application.Clients.Commands.UpdateMyProfile
{
    using MediatR;

    using SharedKernel.Results;
    using SharedKernel.Security;

    public class UpdateMyClientProfileCommandHandler
        : IRequestHandler<UpdateMyClientProfileCommand, Result>
    {
        private readonly IClientRepository clientRepository;
        private readonly ICurrentUser currentUser;

        public UpdateMyClientProfileCommandHandler(
            IClientRepository clientRepository,
            ICurrentUser currentUser)
        {
            this.clientRepository = clientRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            UpdateMyClientProfileCommand request,
            CancellationToken cancellationToken)
        {
            var client = await this.clientRepository.FindByUserId(
                this.currentUser.UserId,
                cancellationToken);

            if (client == null)
                return "Client profile not found.";

            // Обновяваме само полетата, които не са null
            client.UpdateProfile(
                request.FirstName,
                request.LastName,
                request.Phone
            );

            client.UpdateHairProfile(
                request.HairType,
                request.HairLength,
                request.HairColor,
                request.ScalpType,
                request.Allergies,
                request.Sensitivities
            );

            await this.clientRepository.Save(client, cancellationToken);

            return Result.Success;
        }
    }
}
