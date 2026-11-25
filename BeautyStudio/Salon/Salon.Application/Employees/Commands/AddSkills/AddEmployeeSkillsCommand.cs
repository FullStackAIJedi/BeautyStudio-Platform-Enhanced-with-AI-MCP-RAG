namespace Salon.Application.Employees.Commands.AddSkills
{
    using MediatR;
 
    using System.Collections.Generic;
    using SharedKernel.Results;

    public class AddEmployeeSkillsCommand : IRequest<Result>
    {
        public int EmployeeId { get; set; }
        public List<SkillDto> Skills { get; set; } = new();
    }

    public class SkillDto
    {
        public string SkillName { get; set; } = default!;
        public int SkillLevel { get; set; } = 1;
    }
}
