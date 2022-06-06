using DevBlog.Entities.Abstract;
using System.Linq.Expressions;

namespace DevBlog.Repository.Abstract
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        Task<TEntity> GetSingleWhereAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        Task<TEntity> GetByIdAsync(Guid id, bool tracking = true);
    }
}
