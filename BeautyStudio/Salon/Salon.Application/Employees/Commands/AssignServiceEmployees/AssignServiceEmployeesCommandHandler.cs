namespace Salon.Application.Employees.Commands.AssignEmployeesToService
{ 
    using MediatR;

    using SharedKernel.Results;
    using Salon.Application.Services;

    public class AssignServiceEmployeesCommandHandler : IRequestHandler<AssignServiceEmployeesCommand, Result>
    {
        private readonly IServiceRepository serviceRepository;
        public AssignServiceEmployeesCommandHandler(IServiceRepository serviceRepository) => this.serviceRepository = serviceRepository;

        public async Task<Result> Handle(AssignServiceEmployeesCommand request, CancellationToken cancellationToken)
        {
            await this.serviceRepository.AssignEmployeesToService(request.ServiceId, request.EmployeeIds, cancellationToken);
            return Result.Success;
        }
    }
}
