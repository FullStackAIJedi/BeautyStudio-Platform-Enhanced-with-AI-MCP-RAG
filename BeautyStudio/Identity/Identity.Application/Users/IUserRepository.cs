namespace Identity.Application.Users
{ 
    using Identity.Application.Queries.GetUsersList;
    using Identity.Domain.Models;

    public interface IUserRepository
    {
        Task<ApplicationUser> Find(int id, CancellationToken cancellationToken = default);
        Task<ApplicationUser> FindByEmail(string email, CancellationToken cancellationToken = default);
        Task<bool> Exists(string email, CancellationToken cancellationToken = default);
        Task Save(ApplicationUser user, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserListItemOutputModel>> GetListings(
            string? search,
            int? roleLevel,
            int skip,
            int take,
            CancellationToken cancellationToken = default);
        Task<int> Total(
            string? search,
            int? roleLevel,
            CancellationToken cancellationToken = default);
    }
}
