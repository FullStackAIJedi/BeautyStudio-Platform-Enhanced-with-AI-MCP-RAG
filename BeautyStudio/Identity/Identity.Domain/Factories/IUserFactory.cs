namespace Identity.Domain.Factories
{
    using Identity.Domain.Models;

    using SharedKernel.Models;

    public interface IUserFactory : IFactory<ApplicationUser>
    {
        IUserFactory WithEmail(string email);
        IUserFactory WithUserName(string userName);
        IUserFactory WithFirstName(string firstName);
        IUserFactory WithLastName(string lastName);
        IUserFactory WithPhoneNumber(string phoneNumber);
        IUserFactory WithPasswordHash(string passwordHash);
    }
}
