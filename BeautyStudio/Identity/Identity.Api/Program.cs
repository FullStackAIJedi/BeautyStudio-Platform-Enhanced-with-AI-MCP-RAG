using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using Identity.Api.Services;
using Identity.Application;
using Identity.Domain;
using Identity.Domain.Models;
using Identity.Infrastructure;
using Identity.Infrastructure.InitialData;
using Identity.Infrastructure.Stores;

using SharedKernel.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
 
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
    .AddRoles<ApplicationRole>()
    .AddUserStore<CustomUserStore>()
    .AddRoleStore<CustomRoleStore>()
    .AddDefaultTokenProviders();
 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    { 
        policy.WithOrigins(
                "http://localhost:4200",   // Angular dev
                "https://localhost:4200",  // Angular dev с SSL
                "http://localhost:5000",   // Gateway dev
                "https://localhost:5000"   // Gateway dev с SSL
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();  
    });
}); 

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
         
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            { 
                var authorizationHeader = context.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(authorizationHeader)
                    && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    context.Token = authorizationHeader.Substring("Bearer ".Length).Trim();
                    return Task.CompletedTask;
                }
                 
                if (context.Request.Cookies.TryGetValue("access_token", out var cookieToken))
                {
                    context.Token = cookieToken;
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();
 
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
    options.Cookie.Name = "XSRF-TOKEN";
    options.Cookie.HttpOnly = false;   
    options.Cookie.SameSite = SameSiteMode.Lax;   
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;  
});

builder.Services.AddHealthChecks();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
    await initializer.InitializeAsync();
}

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseCors("AngularPolicy");
 
app.UseMiddleware<Identity.Api.Middleware.ValidationExceptionHandlerMiddleware>();

// HTTPS  
// app.UseHttpsRedirection(); 

app.UseAuthentication();
 
app.UseAuthorization();
 
app.UseAntiforgery();

app.MapControllers();

app.Run();
