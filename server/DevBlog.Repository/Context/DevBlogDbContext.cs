using DevBlog.Entities.Abstract;
using DevBlog.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Repository.Context
{
    public class DevBlogDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DevBlogDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<AppRole>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }

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
