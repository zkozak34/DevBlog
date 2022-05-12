using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Category
{
    public class CategoryUpdateDto : IDto
    {
        public string Title { get; set; }
    }
}
