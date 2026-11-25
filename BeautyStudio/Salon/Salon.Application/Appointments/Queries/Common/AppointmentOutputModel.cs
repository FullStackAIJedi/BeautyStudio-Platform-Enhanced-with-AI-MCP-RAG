namespace Salon.Application.Appointments.Queries.Common
{
    using AutoMapper;
    using Salon.Application.Common.Mapping;
    using Salon.Domain.Models.Appointments;

    public class AppointmentOutputModel : IMapFrom<Appointment>
    {
        public int Id { get; private set; }
        public int ClientId { get; private set; }
        public int EmployeeId { get; private set; }
        public int ServiceId { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
        public int Status { get; private set; }
        public string? Notes { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Appointment, AppointmentOutputModel>();
    }
}
