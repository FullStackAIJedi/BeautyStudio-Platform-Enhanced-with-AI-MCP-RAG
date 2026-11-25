namespace Identity.Application.Queries.GetUserById
{
    using Identity.Domain.Models;

    public class UserDetailsOutputModel
    {
        public UserDetailsOutputModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.PhoneNumber = user.PhoneNumber;
            this.IsActive = user.IsActive;
            this.IsBlocked = user.IsBlocked;
            this.EmailVerified = user.EmailVerified;
            this.PhoneVerified = user.PhoneVerified;
            this.CreatedAt = user.CreatedAt;
            this.LastLoginAt = user.LastLoginAt;
            this.RoleName = user.UserRoles.FirstOrDefault()?.Role.Name;
            this.RoleLevel = user.UserRoles.FirstOrDefault()?.Role.RoleLevel ?? 0;
        }

        public int Id { get; }
        public string Email { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public bool IsActive { get; }
        public bool IsBlocked { get; }
        public bool EmailVerified { get; }
        public bool PhoneVerified { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastLoginAt { get; }
        public string? RoleName { get; }
        public int RoleLevel { get; }
    }
}
