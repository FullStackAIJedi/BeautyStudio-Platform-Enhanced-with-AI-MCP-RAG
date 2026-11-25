namespace Identity.Domain.Factories
{
    using Identity.Domain.Models;

    public class UserFactory : IUserFactory
    {
        private string email = default!;
        private string userName = default!;
        private string firstName = default!;
        private string lastName = default!;
        private string phoneNumber = default!;
        private string passwordHash = default!;

        public IUserFactory WithEmail(string email) { this.email = email; return this; }
        public IUserFactory WithUserName(string userName) { this.userName = userName; return this; }
        public IUserFactory WithFirstName(string firstName) { this.firstName = firstName; return this; }
        public IUserFactory WithLastName(string lastName) { this.lastName = lastName; return this; }
        public IUserFactory WithPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber; return this; }
        public IUserFactory WithPasswordHash(string passwordHash) { this.passwordHash = passwordHash; return this; }

        public ApplicationUser Build()
            => new ApplicationUser(
                this.email,
                this.userName,
                this.firstName,
                this.lastName,
                this.phoneNumber,
                this.passwordHash);
    }
}
