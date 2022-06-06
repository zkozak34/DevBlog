using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
