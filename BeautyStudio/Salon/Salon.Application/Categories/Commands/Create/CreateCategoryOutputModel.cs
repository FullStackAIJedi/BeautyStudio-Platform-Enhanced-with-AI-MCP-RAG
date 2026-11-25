namespace Salon.Application.Categories.Commands.Create
{
    public class CreateCategoryOutputModel
    {
        public CreateCategoryOutputModel(int categoryId) => this.CategoryId = categoryId;
        public int CategoryId { get; }
    }
}
