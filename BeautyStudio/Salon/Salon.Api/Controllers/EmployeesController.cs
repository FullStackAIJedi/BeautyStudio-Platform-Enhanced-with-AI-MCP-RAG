namespace Salon.Api.Controllers
{ 
 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Salon.Application.Employees.Commands.AddCertifications;
    using Salon.Application.Employees.Commands.AddSkills;
    using Salon.Application.Employees.Commands.AssignEmployeesToService;
    using Salon.Application.Employees.Commands.AssignEmployeeToService;
    using Salon.Application.Employees.Commands.DeleteCertifications;
    using Salon.Application.Employees.Commands.DeleteSkills;
    using Salon.Application.Employees.Commands.RemoveEmployeeFromService;
    using Salon.Application.Employees.Commands.UpdateProfile;

    using Salon.Application.Employees.Queries.Details;
    using Salon.Application.Employees.Queries.GetEmployeeServices;
    using Salon.Application.Employees.Queries.GetServiceEmployees;
    using Salon.Application.Employees.Queries.Search;

    [ApiController]
    [Route("api/salon/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator; 
        public EmployeesController(IMediator mediator) => this.mediator = mediator;
        
        /// <summary>
        /// Retrieves the public list of employees (for the booking page).
        /// </summary>
        [HttpGet("public")]
        [AllowAnonymous]
        public async Task<IActionResult> PublicSearch([FromQuery] SearchEmployeesQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the complete list of employees. Employee authorization is required (Level 1+).
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> Search([FromQuery] SearchEmployeesQuery query)
            => Ok(await this.mediator.Send(query));

        /// <summary>
        /// Retrieves the details of an employee.
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> MyProfile(int id)
            => Ok(await this.mediator.Send(new EmployeeDetailsQuery { Id = id }));

        /// <summary>
        /// Updates the current employee's own profile.
        /// </summary>
        [HttpPut("me")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateEmployeeProfileCommand command)
        {
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        } 

        /// <summary>
        /// Retrieves the services assigned to a specific employee.
        /// Employee authorization is required.
        /// </summary>
        // GET: api/salon/employees/10/services
        [HttpGet("{id:int}/services")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> GetEmployeeServices(int id)
        {
            var result = await this.mediator.Send(
                new GetEmployeeServicesQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Retrieves the employees assigned to a specific service.
        /// Authentication is not required.
        /// </summary> 
        // GET: api/salon/services/5/employees
        [HttpGet("{id:int}/employees")]
        [AllowAnonymous]
        public async Task<IActionResult> GetServiceEmployees(int id)
        {
            var result = await this.mediator.Send(
                new GetServiceEmployeesQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Assigns multiple employees to a specific service.
        /// Management authorization is required.
        /// </summary>
        // PUT: api/salon/services/5/employees
        [HttpPut("{id:int}/employees")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> AssignEmployeesToService(
            int id,
            AssignServiceEmployeesCommand command)
        {
            if (id != command.ServiceId)
                return BadRequest();

            await this.mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Assigns a specific employee to a service.
        /// Management authorization is required.
        /// </summary>
        // POST: api/salon/services/5/employees/10
        [HttpPost("{id:int}/employees/{employeeId:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> AssignEmployeeToService(
            int id,
            int employeeId,
            AssignEmployeeToServiceCommand command)
        {
            if (id != command.ServiceId ||
                employeeId != command.EmployeeId)
                return BadRequest();

            await this.mediator.Send(command);

            return NoContent();
        } 

        /// <summary>
        /// Removes an employee from a specific service.
        /// Management authorization is required.
        /// </summary>
        // DELETE: api/salon/services/5/employees/10
        [HttpDelete("{id:int}/employees/{employeeId:int}")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> RemoveEmployeeFromService(
            int id,
            int employeeId)
        {
            await this.mediator.Send(
                new RemoveEmployeeFromServiceCommand(id, employeeId));

            return NoContent();
        }

        /// <summary>
        /// Adds one or more skills (SkillName, SkillLevel) to an employee using Employee.AddSkill.
        /// Management authorization is required.
        /// </summary>
        [HttpPost("{id:int}/skills")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> AddSkills(
            int id, [FromBody] AddEmployeeSkillsCommand command)
        {
            command.EmployeeId = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result.Errors);
        }

        /// <summary>
        /// Deletes one or more skills from an employee by their IDs.
        /// Management authorization is required.
        /// </summary>
        [HttpDelete("{id:int}/skills")]
        [Authorize(Policy = "Management")]
        public async Task<IActionResult> DeleteSkills(
            int id, [FromBody] DeleteEmployeeSkillsCommand command)
        {
            command.EmployeeId = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        /// <summary>
        /// Adds one or more certifications (Title, Issuer, CertificateNumber, IssuedAt, ExpiresAt, DocumentUrl) to an employee using Employee.AddCertification.
        /// Employee authorization is required.
        /// </summary>
        [HttpPost("{id:int}/certifications")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> AddCertifications(
            int id, [FromBody] AddEmployeeCertificationsCommand command)
        {
            command.EmployeeId = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result.Errors);
        }

        /// <summary>
        /// Deletes one or more certifications from an employee by their IDs.
        /// Employee authorization is required.
        /// </summary>
        [HttpDelete("{id:int}/certifications")]
        [Authorize(Policy = "Employee")]
        public async Task<IActionResult> DeleteCertifications(
            int id, [FromBody] DeleteEmployeeCertificationsCommand command)
        {
            command.EmployeeId = id;
            var result = await this.mediator.Send(command);
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        } 
    }
}
