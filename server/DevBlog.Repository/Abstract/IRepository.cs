using DevBlog.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> Table { get; }
    }
}
