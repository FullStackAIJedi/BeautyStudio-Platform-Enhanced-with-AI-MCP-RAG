namespace Salon.Application.Services.Queries.Common
{
    public abstract class ServicesOutputModel<TServiceOutputModel>
    {
        internal ServicesOutputModel(
            IEnumerable<TServiceOutputModel> services,
            int page,
            int totalPages)
        {
            this.Services = services;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TServiceOutputModel> Services { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}
