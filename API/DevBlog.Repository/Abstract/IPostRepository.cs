using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Post;

namespace DevBlog.Repository.Abstract
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<List<PostFullDto>> GetAllFull();
        Task<Post> GetById(int id);
        Task<bool> Add(PostAddDto postAddDto);
        Task<bool> Update(int id, PostUpdateDto postUpdateDto);
        Task<bool> Delete(int id);
    }
}
