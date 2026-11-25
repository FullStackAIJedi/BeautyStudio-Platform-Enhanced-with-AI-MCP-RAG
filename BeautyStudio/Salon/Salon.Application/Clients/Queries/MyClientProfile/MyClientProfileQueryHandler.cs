namespace Salon.Application.Clients.Queries.MyClientProfile
{
    using MediatR; 

    using Salon.Application.Common.Exceptions;
    using SharedKernel.Security;

    public class MyClientProfileQueryHandler : IRequestHandler<MyClientProfileQuery, MyClientProfileOutputModel>
    {
        private readonly IClientRepository clientRepository;
        private readonly ICurrentUser currentUser;

        public MyClientProfileQueryHandler(
            IClientRepository clientRepository,
            ICurrentUser currentUser)
        {
            this.clientRepository = clientRepository;
            this.currentUser = currentUser;
        }

        public async Task<MyClientProfileOutputModel> Handle(
            MyClientProfileQuery request,
            CancellationToken cancellationToken)
        {
            var client = await this.clientRepository.FindByUserId(this.currentUser.UserId, cancellationToken);
            if (client == null) throw new NotFoundException(nameof(MyClientProfileQuery), this.currentUser.UserId);

            return new MyClientProfileOutputModel(client);
        }
    }
}
