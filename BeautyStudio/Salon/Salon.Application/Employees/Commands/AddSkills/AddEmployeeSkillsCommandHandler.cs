namespace Salon.Application.Employees.Commands.AddSkills
{
    using MediatR;
    using SharedKernel.Results;

    public class AddEmployeeSkillsCommandHandler : IRequestHandler<AddEmployeeSkillsCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        public AddEmployeeSkillsCommandHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(AddEmployeeSkillsCommand request, CancellationToken cancellationToken)
        {
            await this.employeeRepository.AddSkills(request.EmployeeId, request.Skills, cancellationToken);
            return Result.Success;
        }
    }
}
