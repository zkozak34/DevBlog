using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Category;

namespace DevBlog.Repository.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<bool> Add(CategoryAddDto categoryAddDto);
        Task<bool> Update(int id, CategoryUpdateDto categoryUpdateDto);
        Task<bool> Delete(int id);
    }
}
