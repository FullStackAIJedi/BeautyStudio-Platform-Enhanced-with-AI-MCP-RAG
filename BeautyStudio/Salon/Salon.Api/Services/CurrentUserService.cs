namespace Salon.Api.Services
{
    using System.Security.Claims;
    using SharedKernel.Security;

    // CurrentUserService is in Salon.Api.Services - because this is a class that depends on
    // ASP.NET Core HttpContext and must reside in the outermost layer (Api/Web)
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            => this.httpContextAccessor = httpContextAccessor;

        public int UserId
        {
            get
            {
                var claim = this.httpContextAccessor.HttpContext?.User
                    .FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return int.TryParse(claim, out var id) ? id : 0;
            }
        }

        public string UserName
            => this.httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

        public int RoleLevel
        {
            get
            {
                var claim = this.httpContextAccessor.HttpContext?.User
                    .FindFirst("role_level")?.Value;
                return int.TryParse(claim, out var level) ? level : 0;
            }
        }

        public bool IsAuthenticated
            => this.httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}
