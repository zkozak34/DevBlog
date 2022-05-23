using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Category
{
    public class CategoryDto : IDto
    {
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
