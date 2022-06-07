using Microsoft.AspNetCore.Identity;

namespace DevBlog.Entities.Concrete
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
