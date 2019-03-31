using Autofac;
using WebApplication.DataAccess.Interfaces;
using WebApplication.DataAccess.Repositories;

namespace WebApplication.DataAccess
{
    public class DataAccessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
