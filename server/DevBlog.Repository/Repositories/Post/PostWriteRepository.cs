using DevBlog.Repository.Abstract.Post;
using DevBlog.Repository.Context;

namespace DevBlog.Repository.Repositories.Post
{
    public class PostWriteRepository : WriteRepository<Entities.Concrete.Post>, IPostWriteRepository
    {
        public PostWriteRepository(DevBlogDbContext context) : base(context)
        {
        }
    }
}
