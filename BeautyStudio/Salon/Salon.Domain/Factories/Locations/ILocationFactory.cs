namespace Salon.Domain.Factories.Locations
{
    using Salon.Domain.Models.Locations;
    using SharedKernel.Models;

    public interface ILocationFactory : IFactory<Location>
    {
        ILocationFactory WithName(string name);
        ILocationFactory WithAddress(string address, string city, string country);
        ILocationFactory WithPhone(string phone);
        ILocationFactory WithTimeZone(string timeZone);
        ILocationFactory WithWorkingHours(string workingHours);
        ILocationFactory WithAvailability(bool isAvailable);
    }
}
