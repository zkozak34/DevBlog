using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Author
{
    public class AuthorAddDto : IDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }
    }
}
