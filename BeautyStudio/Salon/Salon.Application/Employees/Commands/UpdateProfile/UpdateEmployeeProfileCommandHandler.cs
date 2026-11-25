namespace Salon.Application.Employees.Commands.UpdateProfile
{
    using MediatR;
     
    using SharedKernel.Results;
    using SharedKernel.Security;

    public class UpdateEmployeeProfileCommandHandler : IRequestHandler<UpdateEmployeeProfileCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICurrentUser currentUser;

        public UpdateEmployeeProfileCommandHandler(
            IEmployeeRepository employeeRepository,
            ICurrentUser currentUser)
        {
            this.employeeRepository = employeeRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            UpdateEmployeeProfileCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await this.employeeRepository.FindByUserId(this.currentUser.UserId, cancellationToken);
            if (employee == null) return "Employee profile not found.";

            employee.UpdateProfile(request.FirstName, request.LastName, request.Bio, request.ProfilePhotoUrl);

            await this.employeeRepository.Save(employee, cancellationToken);
            return Result.Success;
        }
    }
}
