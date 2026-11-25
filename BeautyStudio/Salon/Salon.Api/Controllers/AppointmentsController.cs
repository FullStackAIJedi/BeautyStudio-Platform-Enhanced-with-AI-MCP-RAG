using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using Salon.Application.Appointments.Queries.MyAppointments;
using Salon.Application.Appointments.Queries.AllAppointments;

using Salon.Application.Appointments.Commands.Create;
using Salon.Application.Appointments.Commands.Cancel;
using Salon.Application.Appointments.Commands.Reschedule;

namespace Salon.Api.Controllers
{ 
    [ApiController]
    [Route("api/salon/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator; 
        public AppointmentsController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves the current user's appointments (for clients or employees).
        /// Authentication is required.
        /// </summary>
        [HttpGet("my")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> MyAppointments([FromQuery] MyAppointmentsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves all appointments.
        /// Management authorization is required.
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> AllAppointments([FromQuery] AllAppointmentsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Creates a new appointment.
        /// Authentication is required.
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
        {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Cancels an existing appointment.
        /// Authentication is required.
        /// </summary>
        [HttpPost("{id:int}/cancel")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await this.mediator.Send(new CancelAppointmentCommand { Id = id });
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Reschedules an existing appointment.
        /// Authentication is required.
        /// </summary>
        [HttpPut("{id:int}/reschedule")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Reschedule(int id, [FromBody] RescheduleAppointmentCommand command)
        {
            command.Id = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
