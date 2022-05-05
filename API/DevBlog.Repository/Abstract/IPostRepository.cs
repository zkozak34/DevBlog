using DevBlog.Entities.Concrete;

namespace DevBlog.Repository.Abstract
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
    }
}
