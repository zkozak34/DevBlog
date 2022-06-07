using DevBlog.Repository.Abstract.Author;
using DevBlog.Repository.Context;

namespace DevBlog.Repository.Repositories.Author
{
    public class AuthorReadRepository : ReadRepository<Entities.Concrete.Author>, IAuthorReadRepository
    {
        public AuthorReadRepository(DevBlogDbContext context) : base(context)
        {
        }
    }
}
