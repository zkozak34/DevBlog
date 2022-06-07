using DevBlog.Entities.Abstract;
using DevBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Repository.Context
{
    public class DevBlogDbContext : DbContext
    {
        public DevBlogDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var dataEntry = ChangeTracker.Entries<BaseEntity>();

            foreach (var entityEntry in dataEntry)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
