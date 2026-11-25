namespace Salon.Application.Services.Queries.Details
{ 
    using MediatR;
    using Salon.Application.Common;

    public class ServiceDetailsQuery : EntityCommand<int>, IRequest<ServiceDetailsOutputModel>
    {
    }
}
