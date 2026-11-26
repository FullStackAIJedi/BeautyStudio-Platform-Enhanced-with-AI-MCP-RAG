namespace Identity.Application.Commands.LoginUser
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(
            int userId, 
            string token, 
            string roleName, 
            int roleLevel,

            string userName,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            DateTime createdAt,
            DateTime? lastLoginAt,
            bool isActive,
            bool isBlocked)
        {
            this.UserId = userId;
            this.Token = token;
            this.RoleName = roleName;
            this.RoleLevel = roleLevel;

            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CreatedAt = createdAt;
            this.LastLoginAt = lastLoginAt;
            this.IsActive = isActive;
            this.IsBlocked = isBlocked; 
        }

        public int UserId { get; }
        public string Token { get; }
        public string RoleName { get; }
        public int RoleLevel { get; }

        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastLoginAt { get; }
        public bool IsActive { get; }
        public bool IsBlocked { get; }
    }
}
