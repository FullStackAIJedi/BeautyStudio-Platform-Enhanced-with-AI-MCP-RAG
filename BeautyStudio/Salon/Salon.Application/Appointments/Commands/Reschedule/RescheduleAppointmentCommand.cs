namespace Salon.Application.Appointments.Commands.Reschedule
{
    using MediatR;

    using Salon.Application.Common;
    using SharedKernel.Results;

    public class RescheduleAppointmentCommand : EntityCommand<int>, IRequest<Result>
    {
        public DateTime NewStartAt { get; set; }
    }
}
