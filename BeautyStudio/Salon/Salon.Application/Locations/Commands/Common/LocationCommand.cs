namespace Salon.Application.Locations.Commands.Common
{
    using Salon.Application.Common;

    public abstract class LocationCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string TimeZone { get; set; } = default!;
        public string WorkingHours { get; set; } = default!;
        public bool IsAvailable { get; set; } = true;
    }
}
