using DevBlog.Repository.Abstract.Category;
using DevBlog.Repository.Concrete.EntityFramework;

namespace DevBlog.Repository.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Entities.Concrete.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(DevBlogDbContext context) : base(context)
        {
        }
    }
}
