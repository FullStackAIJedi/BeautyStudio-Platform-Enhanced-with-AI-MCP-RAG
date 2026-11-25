namespace Shop.Domain.Models.Carts
{
    using SharedKernel.Models; 

    public class CartItem : Entity<int>
    {
        internal CartItem(int cartId, int referenceId, string name, decimal price, int quantity, int type)
        {
            this.CartId = cartId;
            this.ReferenceId = referenceId;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Type = type;
        }

        private CartItem() { }

        public int CartId { get; private set; }
        public int ReferenceId { get; private set; }   // ProductId or AppointmentId
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int Type { get; private set; }          // 1 = Product, 2 = SalonService
        public int? ProductId => this.Type == 1 ? this.ReferenceId : null;

        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0) return;
            this.Quantity += amount;
        }
    }
}
