using System.Data;
using DevBlog.Repository.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace DevBlog.Repository
{
    public static class RepositoryRegistration
    {
        public static string ConnectionString;

        public static void AddRepositoryService(this IServiceCollection service, string connectionString)
        {
            ConnectionString = connectionString;
            service.AddDbContext<DevBlogContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            service.AddScoped<IDbConnection>(serviceProvider => new MySqlConnection(connectionString));
        }
    }
}
