using DevBlog.Repository.Abstract.Author;
using DevBlog.Repository.Context;

namespace DevBlog.Repository.Repositories.Author
{
    public class AuthorWriteRepository : WriteRepository<Entities.Concrete.Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(DevBlogDbContext context) : base(context)
        {
        }
    }
}
