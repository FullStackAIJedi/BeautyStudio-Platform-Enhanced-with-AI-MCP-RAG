namespace Identity.Domain.Models
{  
    using Identity.Domain.Exceptions; 
    using SharedKernel.Models;

    public class ApplicationUser : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<UserRole> userRoles;

        internal ApplicationUser(
            string email,
            string userName,
            string firstName,
            string lastName,
            string phoneNumber,
            string passwordHash)
        {
            this.Validate(email, userName, firstName, lastName);

            this.Email = email;
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;

            this.PasswordHash = passwordHash;
            this.CreatedAt = DateTime.UtcNow;
            this.IsActive = true;
            this.IsBlocked = false;

            this.userRoles = new HashSet<UserRole>();
        }

        private ApplicationUser()
        {
            this.Email = default!;
            this.UserName = default!;
            this.FirstName = default!;
            this.LastName = default!;
            this.PhoneNumber = default!;

            this.PasswordHash = default!;
            this.userRoles = new HashSet<UserRole>();
        }

        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }

        public string PasswordHash { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? LastLoginAt { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsBlocked { get; private set; }
        public bool EmailVerified { get; private set; }
        public bool PhoneVerified { get; private set; }

        public IReadOnlyCollection<UserRole> UserRoles => this.userRoles.ToList().AsReadOnly();

        public void UpdatePassword(string passwordHash)
        {
            this.PasswordHash = passwordHash;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateProfile(string firstName, string lastName, string phoneNumber)
        {
            this.ValidateName(firstName, nameof(this.FirstName));
            this.ValidateName(lastName, nameof(this.LastName));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void RecordLogin()
        {
            this.LastLoginAt = DateTime.UtcNow;
        }

        public void Block()
        {
            this.IsBlocked = true;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void Unblock()
        {
            this.IsBlocked = false;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void VerifyEmail()
        {
            this.EmailVerified = true;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void VerifyPhone()
        {
            this.PhoneVerified = true;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void AddRole(UserRole role) => this.userRoles.Add(role);

        private void Validate(string email, string userName, string firstName, string lastName)
        {
            Guard.ForStringLength<InvalidUserException>(
                email,
                ModelConstants.User.MinEmailLength,
                ModelConstants.User.MaxEmailLength,
                nameof(this.Email));

            Guard.ForStringLength<InvalidUserException>(
                userName,
                ModelConstants.User.MinUserNameLength,
                ModelConstants.User.MaxUserNameLength,
                nameof(this.UserName));

            this.ValidateName(firstName, nameof(this.FirstName));
            this.ValidateName(lastName, nameof(this.LastName));
        }

        private void ValidateName(string name, string propertyName)
            => Guard.ForStringLength<InvalidUserException>(
                name,
                ModelConstants.User.MinNameLength,
                ModelConstants.User.MaxNameLength,
                propertyName);
    }
}
