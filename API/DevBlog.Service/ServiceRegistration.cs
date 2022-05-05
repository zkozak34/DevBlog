using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevBlog.Service
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
