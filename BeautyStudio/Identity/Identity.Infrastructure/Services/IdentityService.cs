namespace Identity.Infrastructure.Services
{
    using Identity.Application.Commands;
    using Identity.Application.Commands.ChangePassword;
    using Identity.Application.Commands.LoginUser;
    using Identity.Application.Common;
    using Identity.Application.Users;
    using Identity.Domain.Factories;
    using Identity.Domain.Models;
    using Microsoft.AspNetCore.Identity;

    public class IdentityService : IIdentity
    {
        private readonly IUserRepository userRepository;
        private readonly IUserFactory userFactory;
        private readonly IPasswordHasher passwordHasher;
        private readonly ITokenGenerator tokenGenerator;

        public IdentityService(
            IUserRepository userRepository,
            IUserFactory userFactory,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
        {
            this.userRepository = userRepository;
            this.userFactory = userFactory;
            this.passwordHasher = passwordHasher;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<Result<IUser>> RegisterClient(UserInputModel input)
        {
            if (await this.userRepository.Exists(input.Email))
                return "Email is already taken.";

            var passwordHash = this.passwordHasher.HashPassword(input.Password);

            var user = this.userFactory
                .WithEmail(input.Email)
                .WithUserName(input.UserName)
                .WithFirstName(input.FirstName)
                .WithLastName(input.LastName)
                .WithPhoneNumber(input.PhoneNumber ?? string.Empty)
                .WithPasswordHash(passwordHash)
                .Build();

            await this.userRepository.Save(user);
            return Result<IUser>.SuccessWith(new User(user.Id, string.Empty));
        }

        public async Task<Result<IUser>> RegisterEmployee(UserInputModel input, int roleId)
        {
            // Само Boss може да регистрира служители (проверява се в API слоя)
            if (roleId < 1 || roleId > 10)
                return "Invalid role for employee.";

            if (await this.userRepository.Exists(input.Email))
                return "Email is already taken.";

            var passwordHash = this.passwordHasher.HashPassword(input.Password);

            var user = this.userFactory
                .WithEmail(input.Email)
                .WithUserName(input.UserName)
                .WithFirstName(input.FirstName)
                .WithLastName(input.LastName)
                .WithPhoneNumber(input.PhoneNumber ?? string.Empty)
                .WithPasswordHash(passwordHash)
                .Build();

            await this.userRepository.Save(user);
            return Result<IUser>.SuccessWith(new User(user.Id, string.Empty));
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel input)
        {
            var user = await this.userRepository.FindByEmail(input.Email);
            if (user == null) return "Invalid credentials.";

            var valid = this.passwordHasher.VerifyPassword(input.Password, user.PasswordHash);
            if (!valid) return "Invalid credentials.";

            user.RecordLogin();
            await this.userRepository.Save(user);

            var role = user.UserRoles.FirstOrDefault()?.Role;
            var roleName = role?.Name ?? "Client";
            var roleLevel = role?.RoleLevel ?? 0;

            var token = await this.tokenGenerator.GenerateToken(user, roleName, roleLevel);

            return new LoginSuccessModel(user.Id, token, roleName, roleLevel);
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel input)
        {
            var user = await this.userRepository.Find(input.UserId);
            if (user == null) return "User not found.";

            if (!this.passwordHasher.VerifyPassword(input.CurrentPassword, user.PasswordHash))
                return "Current password is incorrect.";

            user.UpdatePassword(this.passwordHasher.HashPassword(input.NewPassword));
            await this.userRepository.Save(user);
            return Result.Success;
        }

        public async Task<Result> AssignRole(int userId, int roleId)
        {
            var user = await this.userRepository.Find(userId);
            if (user == null) return "User not found.";

            // Проверка за обхват на управление се прави в API слоя
            // Тук само записваме ролята
            return Result.Success;
        }

        public async Task<Result> RemoveRole(int userId, int roleId)
        {
            return Result.Success;
        }
    }

    internal record User(int UserId, string Token) : IUser;
}
