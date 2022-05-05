using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;

namespace DevBlog.Repository
{
    public static class RepositoryRegistration
    {
        public static string ConnectionString;

        public static void AddRepositoryService(this IServiceCollection service, string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            // under line for entityframework
            //service.AddDbContext<DevBlogContext>(options =>
            //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            service.AddScoped<IDbConnection>(serviceProvider => new MySqlConnection(connectionString));
        }
    }
}
