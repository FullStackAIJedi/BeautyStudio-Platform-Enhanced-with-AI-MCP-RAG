namespace Salon.Api.Controllers
{ 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Salon.Application.Services.Commands.Create;
    using Salon.Application.Services.Commands.Delete;
    using Salon.Application.Services.Commands.Edit;
    using Salon.Application.Services.Commands.Commands.Deactivate;
    using Salon.Application.Services.Commands.Commands.Activate;

    using Salon.Application.Services.Queries.Details;
    using Salon.Application.Services.Queries.Search;

    [ApiController]
    [Route("api/salon/services")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator mediator; 
        public ServicesController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves the public list of services without authentication.
        /// Intended for display on the homepage.
        /// </summary>
        [HttpGet("public")]
        [AllowAnonymous]
        public async Task<IActionResult> PublicSearch([FromQuery] SearchServicesQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the complete list of services.
        /// Authentication is required.
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Search([FromQuery] SearchServicesQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the details of a specific service.
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Details(int id)
            => Ok(await this.mediator.Send(new ServiceDetailsQuery { Id = id }));

        /// <summary>
        /// Deactivates a service using Service.Deactivate() without deleting it from the database.
        /// </summary>
        [HttpPost("{id:int}/deactivate")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await this.mediator.Send(new DeactivateServiceCommand { Id = id });
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Reactivates a previously deactivated service.
        /// </summary>
        [HttpPost("{id:int}/activate")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Activate(int id)
        {
            var result = await this.mediator.Send(new ActivateServiceCommand { Id = id });
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Creates a new service. Management authorization is required (Level 8+).
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Create([FromBody] CreateServiceCommand command)
        {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing service. Management authorization is required.
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditServiceCommand command)
        {
            command.Id = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Deletes a service. Management authorization is required.
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new DeleteServiceCommand { Id = id });
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        } 
    }
}
