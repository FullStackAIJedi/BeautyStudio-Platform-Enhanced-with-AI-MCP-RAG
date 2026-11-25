namespace Salon.Application.Categories.Queries.Search
{
    public class CategoryOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
