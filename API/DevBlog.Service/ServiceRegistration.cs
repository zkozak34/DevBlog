using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevBlog.Service
{
    public static class ServiceRegistration
    {
        public static string SaltKey;
        public static void AddBusinessService(this IServiceCollection service, string salt)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
            SaltKey = salt;
        }
    }
}
