namespace Salon.Application.Services.Queries.Common
{
    using AutoMapper;
    using Salon.Application.Common.Mapping;
    using Salon.Domain.Models.Services;

    public class ServiceOutputModel : IMapFrom<Service>
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public int DurationMinutes { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Service, ServiceOutputModel>()
                .ForMember(d => d.CategoryId, cfg => cfg.MapFrom(s => s.CategoryId));
    }
}
