using DevBlog.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevBlog.Entities.Concrete
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ThumbnailImage { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
