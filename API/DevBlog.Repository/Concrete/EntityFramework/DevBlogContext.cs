using DevBlog.Entities.Abstract;
using DevBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Repository.Concrete.EntityFramework
{
    public class DevBlogContext : DbContext
    {
        public DevBlogContext(DbContextOptions<DevBlogContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var data = ChangeTracker.Entries<BaseEntity>();
            foreach (var entityEntry in data)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
