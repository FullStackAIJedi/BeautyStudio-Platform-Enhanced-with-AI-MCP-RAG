namespace Salon.Application.Services.Queries.Search
{
    using Salon.Application.Services.Queries.Common;

    public class SearchServicesOutputModel : ServicesOutputModel<ServiceOutputModel>
    {
        public SearchServicesOutputModel(
            IEnumerable<ServiceOutputModel> services,
            int page,
            int totalPages)
            : base(services, page, totalPages)
        {
        }
    }
}
