using DevBlog.Repository.Concrete.EntityFramework;
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
    }
}
