using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using Salon.Application.Clients.Commands.UpdateNotes;
using Salon.Application.Clients.Queries.Details;
using Salon.Application.Clients.Queries.MyClientProfile;
using Salon.Application.Clients.Queries.Search;
using Salon.Application.Clients.Commands.UpdateMyProfile;

namespace Salon.Api.Controllers
{  
    [ApiController]
    [Route("api/salon/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator mediator; 
        public ClientsController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves the list of clients – employees only (Level 1+).
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> Search([FromQuery] SearchClientsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the details of a specific client.
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> Details(int id)
            => Ok(await this.mediator.Send(new ClientDetailsQuery { Id = id }));

        /// <summary>
        /// Creates, updates, or clears client notes.
        /// Notes are cleared when null or an empty string is provided.
        /// </summary>
        [HttpPut("{id:int}/notes")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> UpsertNotes(
            int id, [FromBody] UpdateClientNotesCommand command)
        {
            command.ClientId = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Retrieves the current client's profile, including loyalty points and membership level.
        /// </summary>
        [HttpGet("me")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> MyProfile()
            => Ok(await this.mediator.Send(new MyClientProfileQuery()));

        /// <summary>
        /// Partially updates the current client's profile.
        /// Only the fields provided in the request are updated.
        /// </summary>
        [HttpPatch("me")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> UpdateMyProfile(
            [FromBody] UpdateMyClientProfileCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
