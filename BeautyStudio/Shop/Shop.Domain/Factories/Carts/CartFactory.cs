namespace Shop.Domain.Factories.Carts
{
    using Shop.Domain.Models.Carts;

    public class CartFactory : ICartFactory
    {
        private int userId;

        public ICartFactory WithUser(int userId)
        {
            this.userId = userId;
            return this;
        }

        public Cart Build()
            => new Cart(this.userId);
    }
}
