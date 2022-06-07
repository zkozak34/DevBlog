using DevBlog.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevBlog.Repository
{
    public static class ServiceRegistration
    {
        public static void AddRepositoryService(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<DevBlogDbContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
        public static void AddRepositoryServiceScope(IServiceScope serviceScope)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<DevBlogDbContext>();
            context.Database.EnsureCreated();
        }
    }
}
