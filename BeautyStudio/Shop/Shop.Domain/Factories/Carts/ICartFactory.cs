namespace Shop.Domain.Factories.Carts
{
    using Shop.Domain.Models.Carts;
    using SharedKernel.Models;

    public interface ICartFactory : IFactory<Cart>
    {
        ICartFactory WithUser(int userId);
    }
}
