namespace Salon.Infrastructure.Persistence.Repositories
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
 
    using Salon.Application.Employees;
    using Salon.Application.Employees.Commands.AddCertifications;
    using Salon.Application.Employees.Commands.AddSkills;
    using Salon.Application.Employees.Queries.Details; 
    using Salon.Application.Services.Queries.Common;
    using Salon.Domain.Models.Employees;
    using Salon.Domain.Models.Services;
    using Salon.Infrastructure.Persistence.Common;
    using SharedKernel.Models;

    internal class EmployeeRepository : DataRepository<SalonDbContext, Employee>, IEmployeeRepository
    {
        private readonly IMapper mapper;

        public EmployeeRepository(SalonDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<Employee> Find(int id, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<Employee> FindByUserId(int userId, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(e => e.UserId == userId, cancellationToken);

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Employee> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.All().Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<EmployeeDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<EmployeeDetailsOutputModel>(this.All().Where(e => e.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(Specification<Employee> specification, CancellationToken cancellationToken = default)
            => await this.All().Where(specification).CountAsync(cancellationToken);










        public async Task<IEnumerable<ServiceOutputModel>> GetEmployeeServices(int employeeId, CancellationToken cancellationToken)
        {
            var serviceIds = await this.Data.EmployeeServices
                .Where(es => es.EmployeeId == employeeId)
                .Select(es => es.ServiceId)
                .ToListAsync(cancellationToken);

            return await this.Data.Services
                .Where(s => serviceIds.Contains(s.Id))
                .ProjectTo<ServiceOutputModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task AssignEmployeeToService(int employeeId, int serviceId, CancellationToken cancellationToken)
        {
            if (!await this.Data.EmployeeServices.AnyAsync(es => es.EmployeeId == employeeId && es.ServiceId == serviceId, cancellationToken))
            {
                this.Data.EmployeeServices.Add(new EmployeeService(employeeId, serviceId));
                await this.Data.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task RemoveEmployeeFromService(int employeeId, int serviceId, CancellationToken cancellationToken)
        {
            var entity = await this.Data.EmployeeServices.FirstOrDefaultAsync(es => es.EmployeeId == employeeId && es.ServiceId == serviceId, cancellationToken);
            if (entity != null)
            {
                this.Data.EmployeeServices.Remove(entity);
                await this.Data.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AddSkills(int employeeId, List<SkillDto> skills, CancellationToken cancellationToken)
        {
            var entities = skills.Select(s => new EmployeeSkill(employeeId, s.SkillName, s.SkillLevel)).ToList();
            this.Data.EmployeeSkills.AddRange(entities);
            await this.Data.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteSkills(int employeeId, List<int> skillIds, CancellationToken cancellationToken)
        {
            var entities = await this.Data.EmployeeSkills
                .Where(s => s.EmployeeId == employeeId && skillIds.Contains(s.Id))
                .ToListAsync(cancellationToken);

            this.Data.EmployeeSkills.RemoveRange(entities);
            await this.Data.SaveChangesAsync(cancellationToken);
        }

        public async Task AddCertifications(int employeeId, List<CertDto> certs, CancellationToken cancellationToken)
        {
            var entities = certs
                .Select(c => new EmployeeCertification(employeeId, c.Title, c.Issuer ))
                .ToList();

            this.Data.EmployeeCertifications.AddRange(entities);
            await this.Data.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCertifications(int employeeId, List<int> certIds, CancellationToken cancellationToken)
        {
            var entities = await this.Data.EmployeeCertifications
                .Where(c => c.EmployeeId == employeeId && certIds.Contains(c.Id))
                .ToListAsync(cancellationToken);

            this.Data.EmployeeCertifications.RemoveRange(entities);
            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
