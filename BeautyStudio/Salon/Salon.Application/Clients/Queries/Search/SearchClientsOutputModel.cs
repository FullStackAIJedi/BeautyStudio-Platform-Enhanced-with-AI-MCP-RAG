namespace Salon.Application.Clients.Queries.Search
{
    using Salon.Application.Clients.Queries.Common;

    public class SearchClientsOutputModel
    {
        public SearchClientsOutputModel(
            IEnumerable<ClientOutputModel> clients,
            int page,
            int totalPages)
        {
            this.Clients = clients;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<ClientOutputModel> Clients { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}
