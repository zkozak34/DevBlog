using DevBlog.Entities.Abstract;
using DevBlog.Repository.Abstract;
using DevBlog.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevBlog.Repository.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DevBlogDbContext _context;

        public ReadRepository(DevBlogDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetSingleWhereAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
