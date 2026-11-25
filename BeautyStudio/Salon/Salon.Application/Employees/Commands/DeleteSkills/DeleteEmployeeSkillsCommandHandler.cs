namespace Salon.Application.Employees.Commands.DeleteSkills
{
    using MediatR;
    using SharedKernel.Results;

    public class DeleteEmployeeSkillsCommandHandler : IRequestHandler<DeleteEmployeeSkillsCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        public DeleteEmployeeSkillsCommandHandler(IEmployeeRepository employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<Result> Handle(DeleteEmployeeSkillsCommand request, CancellationToken cancellationToken)
        {
            await this.employeeRepository.DeleteSkills(request.EmployeeId, request.SkillIds, cancellationToken);
            return Result.Success;
        }
    }
}
