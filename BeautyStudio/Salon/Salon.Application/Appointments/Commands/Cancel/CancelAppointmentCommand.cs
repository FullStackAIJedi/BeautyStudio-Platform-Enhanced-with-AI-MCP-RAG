namespace Salon.Application.Appointments.Commands.Cancel
{
    using MediatR;

    using Salon.Application.Common;
    using SharedKernel.Results;

    public class CancelAppointmentCommand : EntityCommand<int>, IRequest<Result>
    { }
}
