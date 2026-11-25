namespace Salon.Application.Locations.Commands.Create
{
    public class CreateLocationOutputModel
    {
        public CreateLocationOutputModel(int locationId) => this.LocationId = locationId;
        public int LocationId { get; }
    }
}
