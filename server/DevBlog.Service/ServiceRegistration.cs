using DevBlog.Repository.Abstract.Author;
using DevBlog.Repository.Abstract.Category;
using DevBlog.Repository.Abstract.Post;
using DevBlog.Repository.Repositories.Author;
using DevBlog.Repository.Repositories.Category;
using DevBlog.Repository.Repositories.Post;
using DevBlog.Service.Utilities.Security;
using DevBlog.Service.Utilities.Storage;
using DevBlog.Service.Utilities.Storage.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace DevBlog.Service
{
    public static class ServiceRegistration
    {
        public static string SaltKey;

        public static void AddBusinessService(this IServiceCollection service, string salt)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddScoped<IPostReadRepository, PostReadRepository>();
            service.AddScoped<IPostWriteRepository, PostWriteRepository>();
            service.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            service.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
            service.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            service.AddScoped<IJWTAuthenticationManager, JWTAuthenticationManager>();
            service.AddMediatR(Assembly.GetExecutingAssembly());

            service.AddScoped<IStorageService, StorageService>();

            SaltKey = salt;
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SaltKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void AddStorage<T>(this IServiceCollection service) where T : class, IStorage
        {
            service.AddScoped<IStorage, T>();
        }
    }
}
