namespace Salon.Application.Clients.Queries.Details
{
    using MediatR;
    using Salon.Application.Common;

    public class ClientDetailsQuery : EntityCommand<int>, IRequest<ClientDetailsOutputModel>
    {
    }
}
