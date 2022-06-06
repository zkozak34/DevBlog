using DevBlog.Entities.Abstract;

namespace DevBlog.Repository.Abstract
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        bool Delete(TEntity entity);
        Task<bool> Delete(Guid id);
        bool Update(TEntity entity);
        Task<int> SaveAsync();
    }
}
