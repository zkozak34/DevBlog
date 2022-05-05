using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DevBlog.Repository.Abstract;
using DevBlog.Repository.Concrete.Dapper;

namespace DevBlog.Service
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
            service.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
