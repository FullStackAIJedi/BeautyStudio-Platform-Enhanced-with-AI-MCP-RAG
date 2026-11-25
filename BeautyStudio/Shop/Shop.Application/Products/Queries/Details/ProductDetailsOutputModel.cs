namespace Shop.Application.Products.Queries.Details
{
    using AutoMapper;
    using Shop.Application.Common.Mapping;
    using Shop.Domain.Models.Products;

    public class ProductDetailsOutputModel : IMapFrom<Product>
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Product, ProductDetailsOutputModel>();
    }
}
