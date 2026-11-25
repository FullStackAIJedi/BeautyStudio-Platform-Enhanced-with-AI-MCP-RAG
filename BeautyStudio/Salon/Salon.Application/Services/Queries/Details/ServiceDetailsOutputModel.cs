namespace Salon.Application.Services.Queries.Details
{
    using AutoMapper;
    using Salon.Application.Services.Queries.Common;
    using Salon.Domain.Models.Services;

    public class ServiceDetailsOutputModel : ServiceOutputModel
    {
        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Service, ServiceDetailsOutputModel>()
                .IncludeBase<Service, ServiceOutputModel>();
    }
}
