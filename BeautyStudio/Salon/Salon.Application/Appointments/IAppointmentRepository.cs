namespace Salon.Application.Appointments
{ 
    using Salon.Domain.Models.Appointments;
    using SharedKernel.Models;

    public interface IAppointmentRepository
    {
        Task<Appointment> Find(int id, CancellationToken cancellationToken = default);
        Task Save(Appointment appointment, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Appointment> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Appointment> specification, CancellationToken cancellationToken = default);
    }
}
