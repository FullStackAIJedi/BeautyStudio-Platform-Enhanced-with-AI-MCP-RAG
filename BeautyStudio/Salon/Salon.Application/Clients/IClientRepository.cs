namespace Salon.Application.Clients
{
    using Salon.Application.Clients.Queries.Details; 
    using Salon.Domain.Models.Clients;

    using SharedKernel.Models;

    public interface IClientRepository
    {
        Task<Client> Find(int id, CancellationToken cancellationToken = default);
        Task<Client> FindByUserId(int userId, CancellationToken cancellationToken = default);
        Task Save(Client client, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Client> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<ClientDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Client> specification, CancellationToken cancellationToken = default);
    }
}
