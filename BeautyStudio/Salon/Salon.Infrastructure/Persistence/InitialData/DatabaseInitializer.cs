namespace Salon.Infrastructure.Persistence.InitialData
{
    using Microsoft.EntityFrameworkCore;
     
    using Salon.Infrastructure.Persistence;
    using Salon.Infrastructure.Persistence.Common;

    public class DatabaseInitializer : IInitializer
    {
        private readonly SalonDbContext db;
        private readonly IEnumerable<IInitialData> initialDataProviders;

        public DatabaseInitializer(
            SalonDbContext db,
            IEnumerable<IInitialData> initialDataProviders)
        {
            this.db = db;
            this.initialDataProviders = initialDataProviders;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

            foreach (var provider in this.initialDataProviders)
            {
                if (this.DataSetIsEmpty(provider.EntityType))
                {
                    var data = provider.GetData();
                    foreach (var entity in data)
                        this.db.Add(entity);
                }
            }

            this.db.SaveChanges();
        }

        private bool DataSetIsEmpty(Type type)
        {
            var setMethod = typeof(DbContext)
                .GetMethod(nameof(DbContext.Set), new[] { typeof(Type) })!
                .MakeGenericMethod(type);

            var set = setMethod.Invoke(this.db, Array.Empty<object>()) as IQueryable<object>;
            return set == null || !set.Any();
        }
    }
}
