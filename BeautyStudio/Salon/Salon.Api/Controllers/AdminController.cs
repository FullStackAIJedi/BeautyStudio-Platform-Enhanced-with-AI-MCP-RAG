using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using Salon.Application.Admin.Commands.AdjustEmployeePoints; 
using Salon.Application.Admin.Commands.UpdateRoleRules;

using Salon.Application.Admin.Queries.Reports;
using Salon.Application.Admin.Queries.RoleRules;

namespace Salon.Api.Controllers
{ 
    [ApiController]
    [Route("api/salon/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator; 
        public AdminController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Retrieves the role rules for a specific role.
        /// Top Stylist level or higher is required.
        /// </summary>
        [HttpGet("role-rules/{roleId:int}")]
        [Authorize(Policy = "TopStylistOrAbove")]
        public async Task<IActionResult> GetRoleRules(int roleId)
            => Ok(await this.mediator.Send(new GetRoleRulesQuery { RoleId = roleId }));

        /// <summary>
        /// Updates the rules for a specific role.
        /// Top Stylist level or higher is required.
        /// </summary>
        [HttpPut("role-rules/{roleId:int}")]
        [Authorize(Policy = "TopStylistOrAbove")]
        public async Task<IActionResult> UpdateRoleRules(int roleId, [FromBody] UpdateRoleRulesCommand command)
        {
            command.RoleId = roleId;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Retrieves all available roles and their associated rules (RoleRule).
        /// Top Stylist level or higher is required.
        /// </summary>
        [HttpGet("role-rules")]
        [Authorize(Policy = "TopStylistOrAbove")]
        public async Task<IActionResult> GetAllRoleRules([FromQuery] GetRoleRulesQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Adjusts an employee's points by granting a reward or applying a penalty.
        /// Management authorization is required.
        /// </summary>
        [HttpPost("employees/{employeeId:int}/adjust-points")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> AdjustPoints(int employeeId, [FromBody] AdjustEmployeePointsCommand command)
        {
            command.EmployeeId = employeeId;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Retrieves salon reports.
        /// Management authorization is required.
        /// </summary>
        [HttpGet("reports")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> Reports([FromQuery] GetSalonReportsQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves financial reports.
        /// Management authorization is required.
        /// </summary>
        [HttpGet("reports/financial")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> FinancialReports([FromQuery] GetFinancialReportsQuery query)
            => Ok(await this.mediator.Send(query));
    }
}
