namespace Identity.Application.Commands.RegisterEmployee
{
    public class RegisterEmployeeOutputModel
    {
        public RegisterEmployeeOutputModel(int userId) => this.UserId = userId;
        public int UserId { get; }
    }
}
