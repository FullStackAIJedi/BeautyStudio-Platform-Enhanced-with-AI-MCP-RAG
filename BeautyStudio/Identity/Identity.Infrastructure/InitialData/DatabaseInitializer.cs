
namespace Identity.Infrastructure.InitialData
{
    using Identity.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public sealed class DatabaseInitializer
    {
        private readonly IdentityDbContext db;
        private readonly ILogger<DatabaseInitializer> logger;

        public DatabaseInitializer(
            IdentityDbContext db,
            ILogger<DatabaseInitializer> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task InitializeAsync(
            CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation(
                "Applying IdentityDb database migrations...");

            await this.db.Database.MigrateAsync(cancellationToken);

            this.logger.LogInformation(
                "IdentityDb database migrations completed.");
        }
    }
}
