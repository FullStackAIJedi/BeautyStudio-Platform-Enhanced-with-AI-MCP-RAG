namespace Shop.Api.Controllers
{ 
 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Shop.Application.Products.Commands.Create;
    using Shop.Application.Products.Commands.Edit;
    using Shop.Application.Products.Commands.Delete;
    using Shop.Application.Products.Queries.Search;
    using Shop.Application.Products.Queries.Details;

    [ApiController]
    [Route("api/shop/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator; 
        public ProductsController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Public list of products (for the homepage).
        /// </summary>
        [HttpGet("public")]
        [AllowAnonymous]
        public async Task<IActionResult> PublicSearch([FromQuery] SearchProductsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Full list of products (authentication required).
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Search([FromQuery] SearchProductsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Product details.
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Details(int id)
            => Ok(await this.mediator.Send(new ProductDetailsQuery { Id = id }));

        /// <summary>
        /// Create a product – Management only.
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update a product – Management only.
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditProductCommand command)
        {
            command.Id = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Delete a product – Management only.
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new DeleteProductCommand { Id = id });
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
