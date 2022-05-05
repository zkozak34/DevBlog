using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevBlog.Repository.Concrete.EntityFramework
{
    public class DevBlogContextFactory : IDesignTimeDbContextFactory<DevBlogContext>
    {
        public DevBlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DevBlogContext>();
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(RepositoryRegistration.ConnectionString));
            return new DevBlogContext(optionsBuilder.Options);
        }
    }
}
