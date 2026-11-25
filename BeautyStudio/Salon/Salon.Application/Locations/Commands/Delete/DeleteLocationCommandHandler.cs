namespace Salon.Application.Locations.Commands.Delete
{
    using MediatR; 
    using SharedKernel.Results;

    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Result>
    {
        private readonly ILocationRepository locationRepository;

        public DeleteLocationCommandHandler(ILocationRepository locationRepository)
            => this.locationRepository = locationRepository;

        public async Task<Result> Handle(
            DeleteLocationCommand request,
            CancellationToken cancellationToken)
        {
            var deleted = await this.locationRepository.Delete(request.Id, cancellationToken);
            return deleted ? Result.Success : "Location not found.";
        }
    }
}
