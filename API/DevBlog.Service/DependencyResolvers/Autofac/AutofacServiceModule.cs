using Autofac;
using DevBlog.Repository.Abstract;
using DevBlog.Repository.Concrete.Dapper;

namespace DevBlog.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();

        }
    }
}
