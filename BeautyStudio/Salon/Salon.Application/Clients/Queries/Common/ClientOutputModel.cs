namespace Salon.Application.Clients.Queries.Common
{
    using AutoMapper;
    using Salon.Application.Common.Mapping;
    using Salon.Domain.Models.Clients;

    public class ClientOutputModel : IMapFrom<Client>
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public int TotalVisits { get; private set; }
        public int AvailablePoints { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Client, ClientOutputModel>();
    }
}
