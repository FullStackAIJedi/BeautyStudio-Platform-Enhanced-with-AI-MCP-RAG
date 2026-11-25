namespace Identity.Infrastructure.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using Microsoft.IdentityModel.Tokens;

    using Identity.Domain.Models;

    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly string secret;
        private readonly string issuer;
        private readonly string audience;

        public JwtTokenGenerator(string secret, string issuer, string audience)
        {
            this.secret = secret;
            this.issuer = issuer;
            this.audience = audience;
        }

        public Task<string> GenerateToken(ApplicationUser user, string roleName, int roleLevel)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, roleName),
            new Claim("role_level", roleLevel.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: this.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
