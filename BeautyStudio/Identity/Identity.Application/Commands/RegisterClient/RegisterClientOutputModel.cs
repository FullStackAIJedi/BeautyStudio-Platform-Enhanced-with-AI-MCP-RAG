namespace Identity.Application.Commands.RegisterClient
{
    public class RegisterClientOutputModel
    {
        public RegisterClientOutputModel(int userId) => this.UserId = userId;
        public int UserId { get; }
    }
}
