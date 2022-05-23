using DevBlog.Entities.Dtos.Author;
using DevBlog.Entities.Dtos.Category;

namespace DevBlog.Entities.Dtos.Post
{
    public class PostFullDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Overview { get; set; }
        public string ThumbnailImage { get; set; }

        public AuthorDto Author { get; set; }

        public CategoryDto Category { get; set; }
    }
}
