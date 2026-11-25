namespace Salon.Domain.Factories.Appointments
{
    using Salon.Domain.Models.Appointments;
    using SharedKernel.Models;

    public interface IAppointmentFactory : IFactory<Appointment>
    {
        IAppointmentFactory WithClient(int clientId);
        IAppointmentFactory WithEmployee(int employeeId);
        IAppointmentFactory WithService(int serviceId);
        IAppointmentFactory WithLocation(int locationId);
        IAppointmentFactory WithStartAt(DateTime startAt);
        IAppointmentFactory WithNotes(string? notes);
    }
}
