using Autofac;
using Microsoft.EntityFrameworkCore;
using WebApplication.Common.Logger;
using WebApplication.Data;

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
                   .WithParameter(new TypedParameter(typeof(string), "connectionSting value")); ;

            builder.RegisterType<Logger>().As<ILogger>();

            return builder.Build();
        }
    }
}
