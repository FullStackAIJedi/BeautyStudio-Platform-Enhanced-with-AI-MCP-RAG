namespace Salon.Infrastructure.Persistence.Repositories
{
    using AutoMapper; 
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Salon.Application.Employees.Queries.Common;
    using Salon.Application.Services;
    using Salon.Application.Services.Queries.Details; 
    using Salon.Domain.Models.Services; 
    using Salon.Infrastructure.Persistence.Common;
    using SharedKernel.Models;

    internal class ServiceRepository : DataRepository<SalonDbContext, Service>, IServiceRepository
    {
        private readonly IMapper mapper;

        public ServiceRepository(SalonDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<Service> Find(int id, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var service = await this.Data.Services.FindAsync(id);
            if (service == null) return false;

            this.Data.Services.Remove(service);
            await this.Data.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Service> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.All().Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<ServiceDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ServiceDetailsOutputModel>(this.All().Where(s => s.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(Specification<Service> specification, CancellationToken cancellationToken = default)
            => await this.All().Where(specification).CountAsync(cancellationToken);






        public async Task<IEnumerable<EmployeeOutputModel>> GetServiceEmployees(int serviceId, CancellationToken cancellationToken)
        {
            var employeeIds = await this.Data.EmployeeServices
                .Where(es => es.ServiceId == serviceId)
                .Select(es => es.EmployeeId)
                .ToListAsync(cancellationToken);

            return await this.Data.Employees
                .Where(e => employeeIds.Contains(e.Id))
                .ProjectTo<EmployeeOutputModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task AssignEmployeesToService(int serviceId, List<int> employeeIds, CancellationToken cancellationToken)
        {
            var existing = await this.Data.EmployeeServices.Where(es => es.ServiceId == serviceId).ToListAsync(cancellationToken);
            this.Data.EmployeeServices.RemoveRange(existing);

            var newEntities = employeeIds.Select(empId => new EmployeeService(empId, serviceId)).ToList();
            this.Data.EmployeeServices.AddRange(newEntities);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
