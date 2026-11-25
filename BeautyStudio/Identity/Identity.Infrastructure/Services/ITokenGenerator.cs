namespace Identity.Infrastructure.Services
{
    using Identity.Domain.Models;

    public interface ITokenGenerator
    {
        Task<string> GenerateToken(ApplicationUser user, string roleName, int roleLevel);
    }
}
