using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Post
{
    public class PostUpdateDto : IDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Overview { get; set; }

        public string ThumbnailImage { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
    }
}
