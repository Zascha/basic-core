using System;
using System.Threading.Tasks;

namespace WebApplication.Common.SafeExecuteManagers
{
    public interface ISafeExecuteManager
    {
        void ExecuteWithExceptionLogging(Action action);

        void ExecuteWithExceptionLogging(Func<Task> func);
    }
}
