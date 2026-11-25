namespace Salon.Application.Clients.Queries.Details
{
    using AutoMapper;
    using Salon.Application.Clients.Queries.Common;
    using Salon.Domain.Models.Clients;

    public class ClientDetailsOutputModel : ClientOutputModel
    {
        public string? Notes { get; private set; }
        public string? HairType { get; private set; }
        public string? Allergies { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Client, ClientDetailsOutputModel>()
                .IncludeBase<Client, ClientOutputModel>();
    }
}
