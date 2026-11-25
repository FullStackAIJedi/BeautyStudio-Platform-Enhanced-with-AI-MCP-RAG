namespace Salon.Application.Locations.Commands.Create
{
    using MediatR;
    using Salon.Domain.Factories.Locations;

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationOutputModel>
    {
        private readonly ILocationRepository locationRepository;
        private readonly ILocationFactory locationFactory;

        public CreateLocationCommandHandler(
            ILocationRepository locationRepository,
            ILocationFactory locationFactory)
        {
            this.locationRepository = locationRepository;
            this.locationFactory = locationFactory;
        }

        public async Task<CreateLocationOutputModel> Handle(
            CreateLocationCommand request,
            CancellationToken cancellationToken)
        {
            var location = this.locationFactory
                .WithName(request.Name)
                .WithAddress(request.Address, request.City, request.Country)
                .WithPhone(request.Phone)
                .WithTimeZone(request.TimeZone)
                .WithWorkingHours(request.WorkingHours)
                .WithAvailability(request.IsAvailable)
                .Build();

            await this.locationRepository.Save(location, cancellationToken);

            return new CreateLocationOutputModel(location.Id);
        }
    }
}
