namespace Shop.Domain.Specifications.Carts
{
    using System.Linq.Expressions;

    using SharedKernel.Models;
    using Shop.Domain.Models.Carts;

    public class CartByUserSpecification : Specification<Cart>
    {
        private readonly int userId;
        private readonly int? status;

        public CartByUserSpecification(int userId, int? status = null)
        {
            this.userId = userId;
            this.status = status;
        }

        protected override bool Include => true;

        public override Expression<Func<Cart, bool>> ToExpression()
            => cart => cart.UserId == this.userId
                    && (this.status == null || cart.Status == this.status);
    }
}
