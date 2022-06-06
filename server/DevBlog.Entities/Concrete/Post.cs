using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Concrete
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Overview { get; set; }
        public string ThumbnailImage { get; set; }
        public virtual int AuthorId { get; set; }
        public virtual int CategoryId { get; set; }
    }
}
