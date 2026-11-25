namespace Identity.Application.Common
{
    public interface IUser
    {
        int UserId { get; }
        string Token { get; }
    }
}
