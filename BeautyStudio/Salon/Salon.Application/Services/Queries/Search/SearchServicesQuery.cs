namespace Salon.Application.Services.Queries.Search
{
    using MediatR;
    using Salon.Application.Services.Queries.Common;

    public class SearchServicesQuery : ServicesQuery, IRequest<SearchServicesOutputModel>
    { }
}
