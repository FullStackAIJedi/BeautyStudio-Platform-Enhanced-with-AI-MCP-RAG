namespace Identity.Application.Commands.ChangePassword
{
    public class ChangePasswordInputModel
    {
        public ChangePasswordInputModel(int userId, string currentPassword, string newPassword)
        {
            this.UserId = userId;
            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
        }

        public int UserId { get; }
        public string CurrentPassword { get; }
        public string NewPassword { get; }
    }
}
