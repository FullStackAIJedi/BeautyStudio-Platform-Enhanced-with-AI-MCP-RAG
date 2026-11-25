namespace Salon.Api.Controllers
{ 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Salon.Application.Locations.Commands.Create;
    using Salon.Application.Locations.Commands.Delete;
    using Salon.Application.Locations.Commands.Edit;

    using Salon.Application.Locations.Queries.Details;
    using Salon.Application.Locations.Queries.Search;

    [ApiController]
    [Route("api/salon/locations")]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator mediator; 
        public LocationsController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves the public list of salon locations (for the homepage and booking process).
        /// Supported filters: city, country, isAvailable, and search.
        /// </summary>
        [HttpGet("public")]
        [AllowAnonymous]
        public async Task<IActionResult> PublicSearch([FromQuery] SearchLocationsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the complete list of salon locations (authentication required).
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Search([FromQuery] SearchLocationsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the details of a salon location.
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Details(int id)
            => Ok(await this.mediator.Send(new LocationDetailsQuery { Id = id }));

        /// <summary>
        /// Creates a new salon location. Management authorization is required (Level 8+).
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
        {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing salon location. Management authorization is required.
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditLocationCommand command)
        {
            command.Id = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Deletes an existing salon location. Management authorization is required.
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new DeleteLocationCommand { Id = id });
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
