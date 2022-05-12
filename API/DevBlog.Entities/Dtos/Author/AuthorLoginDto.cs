using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Author
{
    public class AuthorLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
