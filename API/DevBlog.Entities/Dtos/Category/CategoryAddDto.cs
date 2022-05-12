using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Category
{
    public class CategoryAddDto : IDto
    {
        public string Title { get; set; }
    }
}
