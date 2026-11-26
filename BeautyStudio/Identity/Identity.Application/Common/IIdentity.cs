namespace Identity.Application.Common
{
    using Identity.Application.Commands;
    using Identity.Application.Commands.ChangePassword;
    using Identity.Application.Commands.LoginUser;

    public interface IIdentity
    {
        Task<Result<IUser>> RegisterClient(UserInputModel userInput);
        Task<Result<IUser>> RegisterEmployee(UserInputModel userInput, int roleId);
        Task<Result<LoginSuccessModel>> Login(LoginUserModel userInput);
        Task<Result> ChangePassword(ChangePasswordInputModel input);
        Task<Result> AssignRole(int userId, int roleId);
        Task<Result> RemoveRole(int userId, int roleId);
        Task<Result> EditProfile(int userId, string firstName, string lastName, string phoneNumber);
    }
}
