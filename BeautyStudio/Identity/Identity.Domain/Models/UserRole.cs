namespace Identity.Domain.Models
{
    public class UserRole
    {
        public UserRole(int userId, int roleId)
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        private UserRole() { }

        public int UserId { get; private set; }
        public ApplicationUser User { get; private set; } = default!;

        public int RoleId { get; private set; }
        public ApplicationRole Role { get; private set; } = default!;
    }
}
