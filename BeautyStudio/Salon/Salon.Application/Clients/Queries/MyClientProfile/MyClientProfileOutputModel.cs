namespace Salon.Application.Clients.Queries.MyClientProfile
{
    using Salon.Domain.Models.Clients;

    public class MyClientProfileOutputModel
    {
        public MyClientProfileOutputModel(Client client)
        {
            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.AvailablePoints = client.AvailablePoints;
            this.LifetimePoints = client.LifetimePoints;
            this.ClientLevelId = client.ClientLevelId;
            this.TotalVisits = client.TotalVisits;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int AvailablePoints { get; }
        public int LifetimePoints { get; }
        public int? ClientLevelId { get; }
        public int TotalVisits { get; }
    }
}
