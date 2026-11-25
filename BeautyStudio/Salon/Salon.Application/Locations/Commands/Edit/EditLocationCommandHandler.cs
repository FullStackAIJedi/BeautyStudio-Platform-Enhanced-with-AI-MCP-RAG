namespace Salon.Application.Locations.Commands.Edit
{
    using MediatR; 
    using SharedKernel.Results;

    public class EditLocationCommandHandler : IRequestHandler<EditLocationCommand, Result>
    {
        private readonly ILocationRepository locationRepository;

        public EditLocationCommandHandler(ILocationRepository locationRepository)
            => this.locationRepository = locationRepository;

        public async Task<Result> Handle(
            EditLocationCommand request,
            CancellationToken cancellationToken)
        {
            var location = await this.locationRepository.Find(request.Id, cancellationToken);
            if (location == null) return "Location not found.";

            location
                .UpdateName(request.Name)
                .UpdateAddress(request.Address, request.City, request.Country)
                .UpdateContact(request.Phone)
                .UpdateTimeZone(request.TimeZone)
                .UpdateWorkingHours(request.WorkingHours)
                .SetAvailability(request.IsAvailable);

            await this.locationRepository.Save(location, cancellationToken);
            return Result.Success;
        }
    }
}
