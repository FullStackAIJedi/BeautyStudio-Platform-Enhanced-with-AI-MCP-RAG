namespace Identity.Application.Queries.GetCurrentUser
{
    using Identity.Domain.Models;

    public class CurrentUserOutputModel
    {
        public CurrentUserOutputModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.PhoneNumber = user.PhoneNumber;
            this.IsActive = user.IsActive;
            this.IsBlocked = user.IsBlocked;
            this.CreatedAt = user.CreatedAt;
        }

        public int Id { get; }
        public string Email { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public bool IsActive { get; }
        public bool IsBlocked { get; }
        public DateTime CreatedAt { get; }
    }
}
