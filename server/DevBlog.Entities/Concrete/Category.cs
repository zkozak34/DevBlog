using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
