namespace Shop.Application.Products.Queries.GetMyCart
{ 
    public class GetMyCartOutputModel
    {
        public GetMyCartOutputModel(int cartId, List<CartItemOutputModel> items, decimal total)
        {
            this.CartId = cartId;
            this.Items = items;
            this.Total = total;
        }

        public int CartId { get; }
        public List<CartItemOutputModel> Items { get; }
        public decimal Total { get; }
    }

    public class CartItemOutputModel
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; }
    }
}
