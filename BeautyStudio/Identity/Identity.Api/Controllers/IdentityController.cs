namespace Identity.Api.Controllers
{
    using Identity.Application.Commands.AssignRole;
    using Identity.Application.Commands.ChangePassword;
    using Identity.Application.Commands.EditProfile;
    using Identity.Application.Commands.LoginUser;
    using Identity.Application.Commands.RegisterClient;
    using Identity.Application.Commands.RegisterEmployee;
    using Identity.Application.Commands.RemoveRole;
    using Identity.Application.Queries.GetCurrentUser;
    using Identity.Application.Queries.GetUserById;
    using Identity.Application.Queries.GetUsersList;
    using MediatR;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IAntiforgery antiforgery;
        private readonly IWebHostEnvironment environment;

        public IdentityController(
            IMediator mediator,
            IAntiforgery antiforgery,
            IWebHostEnvironment environment)
        {
            this.mediator = mediator;
            this.antiforgery = antiforgery;
            this.environment = environment;
        }

        /// <summary>
        /// Client registration. Available to everyone.
        /// </summary>
        [HttpPost("register-client")]
        [AllowAnonymous]
        //[IgnoreAntiforgeryToken]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterClientCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
        }

        /// <summary>
        /// Employee registration. ONLY the Boss is authorized.
        /// </summary>
        [HttpPost("register-employee")]
        [Authorize(Roles = "Boss")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
        }

        /// <summary>
        /// Login. Returns the JWT in an HttpOnly cookie and the CSRF token in a readable cookie.
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        //[IgnoreAntiforgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await this.mediator.Send(command);

            if (!result.Succeeded)
                return Unauthorized(result.Errors);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = !this.environment.IsDevelopment(),
                SameSite = this.environment.IsDevelopment()
                    ? SameSiteMode.Lax
                    : SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(8),
                Path = "/"
            };

            this.Response.Cookies.Append("access_token", result.Data.Token, cookieOptions);

            var tokens = this.antiforgery.GetAndStoreTokens(this.HttpContext);
            this.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!, new CookieOptions
            {
                HttpOnly = false,
                Secure = !this.environment.IsDevelopment(),
                SameSite = this.environment.IsDevelopment()
                    ? SameSiteMode.Lax
                    : SameSiteMode.None,
                Path = "/"
            });

            return Ok(new { result.Data.UserId, result.Data.RoleName, result.Data.RoleLevel });
        }

        /// <summary>
        /// Logout. Clears both cookies.
        /// </summary>
        [HttpPost("logout")]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete("access_token");
            this.Response.Cookies.Delete("XSRF-TOKEN");
            return Ok();
        }

        /// <summary>
        /// Change password.
        /// </summary>
        [HttpPost("change-password")]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Get the current user.
        /// </summary>
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var result = await this.mediator.Send(new GetCurrentUserQuery());
            return Ok(result);
        }

        [HttpPut("me")]
        [Authorize]
        //[ValidateAntiForgeryToken] // CSRF protection
        public async Task<IActionResult> EditProfile([FromBody] EditProfileCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Get the list of users (Boss, Management).
        /// </summary>
        [HttpGet("users")]
        [Authorize(Roles = "Boss,Salon Manager,Salon Director")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersListQuery query)
        {
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Get user details (Boss, Management).
        /// </summary>
        [HttpGet("users/{id:int}")]
        [Authorize(Roles = "Boss,Salon Manager,Salon Director")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await this.mediator.Send(new GetUserByIdQuery { UserId = id });
            return Ok(result);
        }

        /// <summary>
        /// The Boss assigns a role to an employee.
        /// </summary>
        [HttpPost("assign-role")]
        [Authorize(Roles = "Boss")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// The Boss removes a role from an employee.
        /// </summary>
        [HttpPost("remove-role")]
        [Authorize(Roles = "Boss")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRole([FromBody] RemoveRoleCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Endpoint for retrieving a CSRF token (in case Angular loses it).
        /// </summary>
        [HttpGet("csrf-token")]
        [Authorize]
        public IActionResult GetCsrfToken()
        {
            var tokens = this.antiforgery.GetAndStoreTokens(this.HttpContext);
            this.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!, new CookieOptions
            {
                HttpOnly = false,
                Secure = !this.environment.IsDevelopment(),
                SameSite = this.environment.IsDevelopment()
                    ? SameSiteMode.Lax
                    : SameSiteMode.None,
                Path = "/"
            });
            return Ok();
        }  
    }
}