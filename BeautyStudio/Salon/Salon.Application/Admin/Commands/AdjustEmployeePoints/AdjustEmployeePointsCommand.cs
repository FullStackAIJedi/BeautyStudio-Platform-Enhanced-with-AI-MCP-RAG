namespace Salon.Application.Admin.Commands.AdjustEmployeePoints
{
    using MediatR; 
    using SharedKernel.Results;

    public class AdjustEmployeePointsCommand : IRequest<Result>
    {
        public int EmployeeId { get; set; }
        public int PointsDelta { get; set; }
        public int Reason { get; set; } // EMPLOYEE_POINT_REASON
        public string? Description { get; set; }
    }
}
