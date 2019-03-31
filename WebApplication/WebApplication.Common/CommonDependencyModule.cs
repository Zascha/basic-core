using Autofac;
using WebApplication.Common.SafeExecuteManagers;
using CLogger = WebApplication.Common.Logger;

namespace WebApplication.Common
{
    public class CommonDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CLogger.Logger>().As<CLogger.ILogger>();

            builder.RegisterType<SafeExecuteManager>().As<ISafeExecuteManager>();
        }
    }
}
