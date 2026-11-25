namespace Salon.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Salon.Application.Categories.Commands.Create;
    using Salon.Application.Categories.Commands.Delete;
    using Salon.Application.Categories.Commands.Edit;
    using Salon.Application.Categories.Queries.Search;

    [ApiController]
    [Route("api/salon/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves all categories.
        /// This endpoint is publicly accessible and does not require authentication.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] SearchCategoriesQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Creates a new category.
        /// Only users with the Boss role are authorized.
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "BossOnly")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing category.
        /// Only users with the Boss role are authorized.
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Policy = "BossOnly")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCategoryCommand command)
        {
            command.Id = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
        /// <summary>
        /// Deletes an existing category.
        /// Only users with the Boss role are authorized.
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "BossOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new DeleteCategoryCommand { Id = id });

            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
