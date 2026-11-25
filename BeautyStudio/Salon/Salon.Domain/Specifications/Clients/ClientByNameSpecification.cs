namespace Salon.Domain.Specifications.Clients
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Clients;
    using SharedKernel.Models;

    public class ClientByNameSpecification : Specification<Client>
    {
        private readonly string? search;

        public ClientByNameSpecification(string? search) => this.search = search;

        protected override bool Include => !string.IsNullOrEmpty(this.search);

        public override Expression<Func<Client, bool>> ToExpression()
            => client => client.FirstName.ToLower().Contains(this.search!.ToLower())
                      || client.LastName.ToLower().Contains(this.search!.ToLower());
    }
}
