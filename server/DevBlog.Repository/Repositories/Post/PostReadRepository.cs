using DevBlog.Repository.Abstract.Post;
using DevBlog.Repository.Context;

namespace DevBlog.Repository.Repositories.Post
{
    public class PostReadRepository : ReadRepository<Entities.Concrete.Post>, IPostReadRepository
    {
        public PostReadRepository(DevBlogDbContext context) : base(context)
        {
        }
    }
}
