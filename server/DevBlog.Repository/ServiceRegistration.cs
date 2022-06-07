using DevBlog.Entities.Concrete;
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
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<DevBlogDbContext>();
        }
        public static void AddRepositoryServiceScope(IServiceScope serviceScope)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<DevBlogDbContext>();
            context.Database.EnsureCreated();
        }
    }
}
