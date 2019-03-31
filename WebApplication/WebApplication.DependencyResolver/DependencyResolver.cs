using Autofac;
using Microsoft.EntityFrameworkCore;
using WebApplication.Common;
using WebApplication.Data;
using WebApplication.DataAccess;

namespace WebApplication.DependencyResolver
{
    public class DependencyResolver
    {
        private static IContainer _container;

        public static IContainer Container => _container ?? (_container = Resolve());

        private static IContainer Resolve()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WebAppContext>().As<DbContext>()
                   .WithParameter(new TypedParameter(typeof(string), "connectionSting value"));

            builder.RegisterModule(new CommonDependencyModule());
            builder.RegisterModule(new DataAccessDependencyModule());

            return builder.Build();
        }
    }
}
