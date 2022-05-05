using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Concrete
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }
        public List<Post> Posts { get; set; }
    }
}
