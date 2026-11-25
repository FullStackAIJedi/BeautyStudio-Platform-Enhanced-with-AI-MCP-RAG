namespace Salon.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using Salon.Domain.Models.Appointments;
    using Salon.Domain.Models.Clients;
    using Salon.Domain.Models.Employees;
    using Salon.Domain.Models.Locations;
    using Salon.Domain.Models.Portfolio;
    using Salon.Domain.Models.Roles;
    using Salon.Domain.Models.Services;

    public interface ISalonDbContext
    {
        DbSet<Service> Services { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Appointment> Appointments { get; }
        DbSet<PortfolioItem> PortfolioItems { get; }
        DbSet<Client> Clients { get; }
        DbSet<RoleRule> RoleRules { get; }
        DbSet<Location> Locations { get; }
         
        DbSet<EmployeeSkill> EmployeeSkills { get; }
        DbSet<EmployeeCertification> EmployeeCertifications { get; }
        DbSet<EmployeeService> EmployeeServices { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
