using System;

namespace WebApplication.Common.SafeExecuteManagers
{
    public interface ISafeExecuteManager
    {
        void ExecuteWithExceptionLogging(Action action);

        ResultT ExecuteWithExceptionLogging<ArgT, ResultT>(ArgT arg, Func<ArgT, ResultT> func);
    }
}
