namespace Shop.Api.Controllers
{  
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Shop.Application.Carts.Commands.Checkout;
    using Shop.Application.Products.Queries.GetMyCart;

    [ApiController]
    [Route("api/shop/cart")]
    public class CartsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartsController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyCart()
            => Ok(await this.mediator.Send(new GetMyCartQuery()));

        [HttpPost("checkout")]
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var result = await this.mediator.Send(new CheckoutCartCommand());
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }
    }
}
