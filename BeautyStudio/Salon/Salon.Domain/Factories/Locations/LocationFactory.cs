namespace Salon.Domain.Factories.Locations
{
    using Salon.Domain.Models.Locations;

    public class LocationFactory : ILocationFactory
    {
        private string name = default!;
        private string address = default!;
        private string city = default!;
        private string country = default!;
        private string phone = default!;
        private string timeZone = default!;
        private string workingHours = default!;
        private bool isAvailable = true;

        public ILocationFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public ILocationFactory WithAddress(string address, string city, string country)
        {
            this.address = address;
            this.city = city;
            this.country = country;
            return this;
        }

        public ILocationFactory WithPhone(string phone)
        {
            this.phone = phone;
            return this;
        }

        public ILocationFactory WithTimeZone(string timeZone)
        {
            this.timeZone = timeZone;
            return this;
        }

        public ILocationFactory WithWorkingHours(string workingHours)
        {
            this.workingHours = workingHours;
            return this;
        }

        public ILocationFactory WithAvailability(bool isAvailable)
        {
            this.isAvailable = isAvailable;
            return this;
        }

        public Location Build()
            => new Location(
                this.name,
                this.address,
                this.city,
                this.country,
                this.phone,
                this.timeZone,
                this.workingHours,
                this.isAvailable);
    }
}
