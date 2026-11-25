namespace Salon.Application.Employees.Commands.DeleteSkills
{
    using System.Collections.Generic;

    using MediatR;
    using SharedKernel.Results;

    public class DeleteEmployeeSkillsCommand : IRequest<Result>
    {
        public int EmployeeId { get; set; }
        public List<int> SkillIds { get; set; } = new();
    }
}
