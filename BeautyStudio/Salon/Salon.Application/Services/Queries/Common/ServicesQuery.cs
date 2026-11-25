namespace Salon.Application.Services.Queries.Common
{ 
    using Salon.Domain.Models.Services;
    using Salon.Domain.Specifications.Services; 
    using Salon.Application.Services;

    using SharedKernel.Models;

    public abstract class ServicesQuery
    {
        protected const int ServicesPerPage = 10;

        public int? CategoryId { get; set; }
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public string? Order { get; set; }
        public int Page { get; set; } = 1;

        public abstract class ServicesQueryHandler
        {
            private readonly IServiceRepository serviceRepository;

            protected ServicesQueryHandler(IServiceRepository serviceRepository)
                => this.serviceRepository = serviceRepository;

            protected async Task<IEnumerable<TOutputModel>> GetServiceListings<TOutputModel>(
                ServicesQuery request,
                CancellationToken cancellationToken = default)
            {
                var specification = this.GetSpecification(request);
                var skip = (request.Page - 1) * ServicesPerPage;

                return await this.serviceRepository.GetListings<TOutputModel>(
                    specification,
                    skip,
                    ServicesPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                ServicesQuery request,
                CancellationToken cancellationToken = default)
            {
                var specification = this.GetSpecification(request);
                var total = await this.serviceRepository.Total(specification, cancellationToken);
                return (int)Math.Ceiling((double)total / ServicesPerPage);
            }

            private Specification<Service> GetSpecification(ServicesQuery request)
                => new ServiceByCategorySpecification(request.CategoryId)
                    .And(new ServiceByNameSpecification(request.Search));
        }
    }
}
