using DevBlog.Entities.Abstract;
using DevBlog.Repository.Abstract;
using DevBlog.Repository.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.Repository.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DevBlogDbContext _context;

        public WriteRepository(DevBlogDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> Delete(Guid id)
        {
            TEntity entity = await Table.FirstOrDefaultAsync(i => i.Id == id);
            if (entity != null)
                return Delete(entity);
            return false;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
