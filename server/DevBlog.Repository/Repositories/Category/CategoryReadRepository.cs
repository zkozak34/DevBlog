using DevBlog.Repository.Abstract.Category;
using DevBlog.Repository.Concrete.EntityFramework;

namespace DevBlog.Repository.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Entities.Concrete.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(DevBlogDbContext context) : base(context)
        {
        }
    }
}
