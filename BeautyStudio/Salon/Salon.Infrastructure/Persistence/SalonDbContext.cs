namespace Salon.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;

    using Salon.Domain.Models.Appointments;
    using Salon.Domain.Models.Categories;
    using Salon.Domain.Models.Clients;
    using Salon.Domain.Models.Employees;
    using Salon.Domain.Models.Locations;
    using Salon.Domain.Models.Portfolio;
    using Salon.Domain.Models.Roles;
    using Salon.Domain.Models.Services;

    public class SalonDbContext : DbContext, ISalonDbContext
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options)
            : base(options) { }

        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<Appointment> Appointments { get; set; } = default!;
        public DbSet<PortfolioItem> PortfolioItems { get; set; } = default!;
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<RoleRule> RoleRules { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<EmployeeSkill> EmployeeSkills { get; set; } = default!;
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; } = default!;
        public DbSet<EmployeeService> EmployeeServices { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SalonDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
