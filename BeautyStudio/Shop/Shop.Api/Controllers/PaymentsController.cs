using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using global::Shop.Application.Payments.Commands.SimulatePayment;
using Shop.Application.Payments.Queries.GetMyPayments;
using Shop.Application.Payments.Queries.GetPaymentById;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/shop/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentsController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Simulates payment for the current shopping cart.
        /// Requires an IdempotencyKey in the "Idempotency-Key" header to prevent duplicate payments.
        /// </summary>
        [HttpPost("simulate")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> SimulatePayment(
            [FromHeader(Name = "Idempotency-Key")] string? idempotencyKey)
        {
            if (string.IsNullOrWhiteSpace(idempotencyKey))
                return BadRequest(new[] { "Missing 'Idempotency-Key' header." });

            var result = await this.mediator.Send(new SimulatePaymentCommand
            {
                IdempotencyKey = idempotencyKey
            });

            return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
        }

        /// <summary>
        /// Get my payments.
        /// </summary>
        [HttpGet("my")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> MyPayments([FromQuery] GetMyPaymentsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Payment details.
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Authenticated")]
        public async Task<IActionResult> Details(int id)
            => Ok(await this.mediator.Send(new GetPaymentByIdQuery { Id = id }));
    }
}
