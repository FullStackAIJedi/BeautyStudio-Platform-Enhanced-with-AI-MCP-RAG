namespace Identity.Infrastructure.Services
{
    using BCrypt.Net;

    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
            => BCrypt.HashPassword(password);

        public bool VerifyPassword(string password, string hash)
            => BCrypt.Verify(password, hash);
    }
}
