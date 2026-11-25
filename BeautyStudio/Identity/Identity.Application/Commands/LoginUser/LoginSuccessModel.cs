namespace Identity.Application.Commands.LoginUser
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(int userId, string token, string roleName, int roleLevel)
        {
            this.UserId = userId;
            this.Token = token;
            this.RoleName = roleName;
            this.RoleLevel = roleLevel;
        }

        public int UserId { get; }
        public string Token { get; }
        public string RoleName { get; }
        public int RoleLevel { get; }
    }
}
