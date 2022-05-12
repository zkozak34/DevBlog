using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Author;

namespace DevBlog.Repository.Abstract
{
    public interface IAuthorRepository
    {
        Task<List<AuthorDto>> GetAll();
        Task<AuthorDto> GetById(int id);
        Task<bool> Add(AuthorAddDto authorAddDto);
        Task<bool> Update(int id, AuthorUpdateDto authorUpdateDto);
        Task<bool> Delete(int id);
        Task<Author> Login(string email, string password);
    }
}
