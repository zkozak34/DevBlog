using Autofac;
using DevBlog.Repository.Abstract;
using DevBlog.Repository.Concrete.Dapper;
using DevBlog.Service.Utilities.Security;

namespace DevBlog.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JWTAuthenticationManager>().As<IJWTAuthenticationManager>().InstancePerLifetimeScope();

        }
    }
}
