namespace Identity.Application.Queries.GetUsersList
{
    public class UserListItemOutputModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? RoleName { get; set; }
        public int RoleLevel { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
