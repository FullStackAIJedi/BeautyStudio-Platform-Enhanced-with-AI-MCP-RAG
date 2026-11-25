namespace SharedKernel.Security
{
    public interface ICurrentUser
    {
        int UserId { get; }
        string UserName { get; }
        int RoleLevel { get; }
        bool IsAuthenticated { get; }
    }
}
