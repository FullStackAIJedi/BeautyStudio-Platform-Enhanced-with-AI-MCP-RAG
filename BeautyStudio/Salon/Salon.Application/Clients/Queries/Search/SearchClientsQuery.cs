namespace Salon.Application.Clients.Queries.Search
{
    using MediatR;

    public class SearchClientsQuery : IRequest<SearchClientsOutputModel>
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
    }
}
