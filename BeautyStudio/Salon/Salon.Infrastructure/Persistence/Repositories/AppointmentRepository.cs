namespace Salon.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Salon.Application.Appointments; 
    using Salon.Domain.Models.Appointments;
    using Salon.Infrastructure.Persistence.Common;
    using SharedKernel.Models;

    internal class AppointmentRepository : DataRepository<SalonDbContext, Appointment>, IAppointmentRepository
    {
        private readonly IMapper mapper;

        public AppointmentRepository(SalonDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<Appointment> Find(int id, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        public async Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Appointment> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TOutputModel>(this.All().Where(specification))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

        public async Task<int> Total(Specification<Appointment> specification, CancellationToken cancellationToken = default)
            => await this.All().Where(specification).CountAsync(cancellationToken);
    }
}
