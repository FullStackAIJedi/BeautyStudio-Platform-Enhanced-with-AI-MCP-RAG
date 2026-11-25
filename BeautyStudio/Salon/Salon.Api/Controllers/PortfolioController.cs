namespace Salon.Api.Controllers
{ 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Salon.Application.Portfolio.Commands.Create;
    using Salon.Application.Portfolio.Commands.Vote;
    using Salon.Application.Portfolio.Queries.Search;
    using Salon.Application.Portfolio.Queries.Details;

    [ApiController]
    [Route("api/salon/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator mediator; 
        public PortfolioController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves the public portfolio for browsing.
        /// Authentication is not required.
        /// </summary>
        [HttpGet("public")]
        [AllowAnonymous]
        public async Task<IActionResult> PublicSearch([FromQuery] SearchPortfolioQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the complete portfolio.
        /// Authentication is required.
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Search([FromQuery] SearchPortfolioQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the details of a specific portfolio item, including its associated image or images.
        /// </summary>
        /// <param name="id">The unique identifier of the portfolio item.</param>
        /// <returns>The portfolio item details and its associated images.</returns>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Details(int id)
            => Ok(await this.mediator.Send(new PortfolioDetailsQuery { Id = id }));

        /// <summary>
        /// Creates a new portfolio item and uploads its associated image or images.
        /// Employee authorization is required.
        /// </summary>
        /// <param name="command">The data required to create the portfolio item.</param>
        /// <returns>The result of the creation operation.</returns>
        [HttpPost]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> Create([FromBody] CreatePortfolioItemCommand command)
        {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Submits a vote for a portfolio item.
        /// Only authenticated clients who have paid for a service are eligible to vote.
        /// </summary>
        /// <param name="id">The unique identifier of the portfolio item.</param>
        /// <param name="command">The voting information.</param>
        /// <returns>200 OK if the vote is successful; otherwise, 400 Bad Request with validation errors.</returns>
        [HttpPost("{id:int}/vote")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Vote(int id, [FromBody] VotePortfolioCommand command)
        {
            command.PortfolioItemId = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
